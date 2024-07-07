using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace CleanArchitecture.Application
{
    public static class ApplicationServiceRegistration
    {
        /// <summary>
        /// Registers the dependencies for Application Services
        /// </summary>
        /// <param name="services">IServiceCollection</param>
        /// <returns>IServiceCollection</returns>
        public static IServiceCollection ConfigureApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(config => { config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()); });
            return services;
        }
    }
}
