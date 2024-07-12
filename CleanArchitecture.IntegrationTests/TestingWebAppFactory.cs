namespace CleanArchitecture.IntegrationTests;

using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using CleanArchitecture.Persistence.DbContexts;

public class TestingWebAppFactory<TEntryPoint> : WebApplicationFactory<Program>
    where TEntryPoint : Program
{
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureServices(services =>
        {
            var descriptor = services.SingleOrDefault(d => d.ServiceType == typeof(DbContextOptions<CustomerDbContext>));
            if (descriptor != null)
                services.Remove(descriptor);

            services.AddDbContext<CustomerDbContext>(options =>
            {
                options.UseInMemoryDatabase("InMemoryCustomerTest");
            });

            var serviceProvider = services.BuildServiceProvider();
            using var scope = serviceProvider.CreateScope();
            using (var appContext = scope.ServiceProvider.GetRequiredService<CustomerDbContext>())
            {
                try
                {
                    appContext.Database.EnsureCreated();
                }
                catch (Exception)
                {
                    throw;
                }
            }
        });
    }
}
