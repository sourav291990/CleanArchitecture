
namespace CleanArchitecture.Application.Contracts.Persistence;

using CleanArchitecture.Domain.Entities.Common;

public interface IGenericRepository<T> where T : BaseEntity
{
    bool Exists(Guid id);
    T Get(Guid id);
    IReadOnlyList<T> GetAll();
    void Add(T entity);
    void Update(T entity);
    void Delete(T entity);
    Task<bool> ExistsAsync(Guid id);
    Task<T> GetAsync(Guid id);
    Task<IReadOnlyList<T>> GetAllAsync();
    Task AddAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(T entity);
}
