namespace CleanArchitecture.Infrastructure;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using CleanArchitecture.Infrastructure.Logging;
using CleanArchitecture.Application.Models.EmailSender;
using CleanArchitecture.Application.Contracts.Infrastructure.Logging;
using CleanArchitecture.Application.Contracts.Infrastructure.EmailSender;
using CleanArchitecture.Application.Models.CustomerQuery;

public static class InfrastructureServiceRegistration
{
    /// <summary>
    /// Registers infrastructure service dependencies
    /// </summary>
    /// <param name="services">IServiceCollection</param>
    /// <returns>IServiceCollection</returns>
    public static IServiceCollection RegisterInfrastructureServices(this IServiceCollection services
        , IConfiguration configuration)
    {
        services.Configure<EmailSettings>(configuration.GetSection("EmailSettings"));
        services.Configure<CustomerQuerySettings>(configuration.GetSection("CustomerQueryDatabaseSettings"));
        services.AddTransient<IEmailSender, EmailSender.EmailSender>();
        services.AddSingleton(typeof(IAppLogger<>), typeof(LoggerAdapter<>));
        return services;
    }
}
