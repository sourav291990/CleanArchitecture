using CleanArchitecture.Application.Contracts.Persistence;

namespace CleanArchitecture.Persistence.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        public T Add(T entity)
        {
            throw new NotImplementedException();
        }

        public Task<T> AddAsync(T entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(T entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(T entity)
        {
            throw new NotImplementedException();
        }

        public bool Exists(long id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ExistsAsync(long id)
        {
            throw new NotImplementedException();
        }

        public T Get(long id)
        {
            throw new NotImplementedException();
        }

        public IReadOnlyList<T> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<T>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<T> GetAsync(long id)
        {
            throw new NotImplementedException();
        }

        public void Update(T entity)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
