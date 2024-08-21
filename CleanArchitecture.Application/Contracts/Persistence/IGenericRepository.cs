
namespace CleanArchitecture.Application.Contracts.Persistence;

using Microsoft.EntityFrameworkCore;
using CleanArchitecture.Domain.Entities.Common;

public interface IGenericRepository<TEntity, TContext> where TEntity : BaseEntity where TContext : DbContext
{
    bool Exists(Guid id);
    TEntity Get(Guid id);
    IReadOnlyList<TEntity> GetAll();
    void Add(TEntity entity);
    void Update(TEntity entity);
    void Delete(TEntity entity);
    Task<bool> ExistsAsync(Guid id);
    Task<TEntity> GetAsync(Guid id);
    Task<IReadOnlyList<TEntity>> GetAllAsync();
    Task AddAsync(TEntity entity);
    Task UpdateAsync(TEntity entity);
    Task DeleteAsync(TEntity entity);
}
