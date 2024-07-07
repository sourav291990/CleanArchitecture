namespace CleanArchitecture.Persistence.Repositories;

using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using CleanArchitecture.Domain.Entities.Common;
using CleanArchitecture.Application.Contracts.Persistence;

public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
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

    public bool Exists(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<bool> ExistsAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public T Get(Guid id)
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

    public Task<T> GetAsync(Guid id)
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
