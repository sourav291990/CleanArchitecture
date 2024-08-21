namespace CleanArchitecture.Persistence.DbContextProvider;

using Microsoft.EntityFrameworkCore;

public interface IDbContextProvider
{
    T Get<T>() where T : DbContext;
}
