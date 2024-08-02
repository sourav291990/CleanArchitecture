namespace CleanArchitecture.Persistence;

using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using CleanArchitecture.Persistence.Options;
using CleanArchitecture.Persistence.Settings;
using Microsoft.Extensions.DependencyInjection;
using CleanArchitecture.Persistence.DbContexts;
using CleanArchitecture.Persistence.Repositories;
using CleanArchitecture.Application.Contracts.Persistence;
public static class PersistenceServiceRegistration
{
    public static IServiceCollection RegisterPersistenceServices(this IServiceCollection services)
    {
        services.ConfigureOptions<DatabaseOptionsSetup>();

        services.AddDbContext<CustomerDbContext>((serviceProvider, options) =>
        {
            var databaseOptions = serviceProvider.GetService<IOptions<DatabaseOptions>>()!.Value;
            options.UseSqlServer(databaseOptions.ConnectionString, sqlServerActions =>
                {
                    sqlServerActions.EnableRetryOnFailure(databaseOptions.MaxRetryCount);
                    sqlServerActions.CommandTimeout(databaseOptions.CommandTimeout);
                });

            options.EnableDetailedErrors(databaseOptions.EnableDetailedError);
            options.EnableSensitiveDataLogging(databaseOptions.EnableSensitiveDataLogging);
        });

        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        services.AddScoped<ICustomerRepository, CustomerRepository>();
        services.AddScoped<ICustomerQueryRepository, CustomerQueryRepository>();
        return services;
    }
}
