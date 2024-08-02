namespace CleanArchitecture.Presentation;

using CleanArchitecture.Identity;
using CleanArchitecture.Application;
using CleanArchitecture.Persistence;
using CleanArchitecture.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

public static class PresentationServiceRegistration
{
    public static IServiceCollection RegisterPresentationServices(this IServiceCollection services, IConfiguration configuration)
    {
        // Add services to the container.
        services.ConfigureApplicationServices();
        services.RegisterInfrastructureServices(configuration);
        services.RegisterPersistenceServices();
        services.RegisterIdentityServices(configuration);

        services.AddSwaggerGen();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        services.AddEndpointsApiExplorer();


        return services;
    }
}
