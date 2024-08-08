namespace CleanArchitecture.Persistence;

using Microsoft.Extensions.Logging;
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
        services.ConfigureOptions<CustomerDatabaseOptionsSetup>();
        services.ConfigureOptions<ActivityDatabaseOptionsSetup>();

        services.AddDbContext<CustomerDbContext>((serviceProvider, options) =>
        {
            var databaseOptions = serviceProvider.GetService<IOptions<CustomerDatabaseOptions>>().Value;
            options.UseSqlServer(databaseOptions.ConnectionString, sqlServerActions =>
                {
                    sqlServerActions.EnableRetryOnFailure(databaseOptions.MaxRetryCount);
                    sqlServerActions.CommandTimeout(databaseOptions.CommandTimeout);
                });

            options.EnableDetailedErrors(databaseOptions.EnableDetailedError);
            options.EnableSensitiveDataLogging(databaseOptions.EnableSensitiveDataLogging);
        });

        services.AddDbContext<ActivityDbContext>((serviceProvider, options) =>
        {
            var databaseOptions = serviceProvider.GetService<IOptions<ActivityDatabaseOptions>>().Value;
            options.UseSqlServer(databaseOptions.ConnectionString, sqlServerActions =>
            {
                sqlServerActions.EnableRetryOnFailure(databaseOptions.MaxRetryCount);
                sqlServerActions.CommandTimeout(databaseOptions.CommandTimeout);
            });

            options.EnableDetailedErrors(databaseOptions.EnableDetailedError);
            options.EnableSensitiveDataLogging(databaseOptions.EnableSensitiveDataLogging);
        });

        using var serviceProvider = services.BuildServiceProvider();
        try
        {
            var context = serviceProvider.GetRequiredService<ActivityDbContext>();
            context.Database.Migrate();
            Seed.ActivitySeed.SeedData(context);
        }
        catch (Exception ex)
        {
            var logger = serviceProvider.GetRequiredService<ILogger<ActivityDbContext>>();
            logger.LogError(ex, ex.Message);
        }

        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        services.AddScoped<ICustomerRepository, CustomerRepository>();
        services.AddScoped<ICustomerQueryRepository, CustomerQueryRepository>();
        services.AddScoped<IActivityRepository, ActivityRepository>();
        return services;
    }
}
