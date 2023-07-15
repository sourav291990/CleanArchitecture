using Microsoft.Extensions.DependencyInjection;

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
            return services;
        }
    }
}
