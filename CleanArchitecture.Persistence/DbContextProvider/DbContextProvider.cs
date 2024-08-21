namespace CleanArchitecture.Persistence.DbContextProvider;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

public class DbContextProvider : IDbContextProvider
{
    protected IServiceProvider ServiceProvider { get; }
    public DbContextProvider(IServiceProvider serviceProvider) => ServiceProvider = serviceProvider;

    public T Get<T>() where T : DbContext
    {
        return ServiceProvider.GetRequiredService<T>();
    }
}
