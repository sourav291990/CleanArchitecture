using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitecture.Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection RegisterPersistenceServices(this IServiceCollection services)
        {
            return services;
        }
    }
}
