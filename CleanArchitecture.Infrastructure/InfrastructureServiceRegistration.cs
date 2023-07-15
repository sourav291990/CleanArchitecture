using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitecture.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        /// <summary>
        /// Registers infrastructure service dependencies
        /// </summary>
        /// <param name="services">IServiceCollection</param>
        /// <returns>IServiceCollection</returns>
        public static IServiceCollection RegisterInfrastructureServices(this IServiceCollection services)
        {
            return services;
        }
    }
}
