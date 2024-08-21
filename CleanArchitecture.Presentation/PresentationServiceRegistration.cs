namespace CleanArchitecture.Presentation;

using CleanArchitecture.Identity;
using CleanArchitecture.Application;
using CleanArchitecture.Persistence;
using CleanArchitecture.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Asp.Versioning;

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
        AddApiVersioning(services);

        return services;
    }

    private static void AddApiVersioning(IServiceCollection services)
    {
        services.AddApiVersioning(options =>
        {
            options.DefaultApiVersion = new Asp.Versioning.ApiVersion(1);
            options.ReportApiVersions = true;
            options.ApiVersionReader = new UrlSegmentApiVersionReader();
        })
            .AddMvc()
            .AddApiExplorer(options =>
            {
                options.GroupNameFormat = "'v'V";
                options.SubstituteApiVersionInUrl = true;
            });
    }
}
