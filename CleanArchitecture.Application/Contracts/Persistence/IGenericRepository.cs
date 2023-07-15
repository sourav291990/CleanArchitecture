namespace CleanArchitecture.Application.Contracts.Persistence
{
    public interface IGenericRepository<T> where T : class
    {
        bool Exists(long id);
        T Get(long id);
        IReadOnlyList<T> GetAll();
        T Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        Task<bool> ExistsAsync(long id);
        Task<T> GetAsync(long id);
        Task<IReadOnlyList<T>> GetAllAsync();
        Task<T> AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
    }
}
