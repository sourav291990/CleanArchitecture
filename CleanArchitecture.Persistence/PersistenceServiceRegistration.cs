namespace CleanArchitecture.Persistence;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using CleanArchitecture.Persistence.DbContexts;
using CleanArchitecture.Persistence.Repositories;
using CleanArchitecture.Application.Contracts.Persistence;

public static class PersistenceServiceRegistration
{
    public static IServiceCollection RegisterPersistenceServices(this IServiceCollection services
        , IConfiguration configuration)
    {
        services.AddDbContext<CustomerDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("CustomerDbConnectionString"));
        });

        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        services.AddScoped<ICustomerRepository, CustomerRepository>();
        return services;
    }
}
