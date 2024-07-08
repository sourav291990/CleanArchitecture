namespace CleanArchitecture.Persistence.Repositories;

using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using CleanArchitecture.Persistence.DbContexts;
using CleanArchitecture.Domain.Entities.Common;
using CleanArchitecture.Application.Contracts.Persistence;

public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
{
    protected readonly CustomerDbContext _customerDbContext;

    public GenericRepository(CustomerDbContext customerDbContext)
    {
        _customerDbContext = customerDbContext;
    }

    public T Add(T entity)
    {
        _customerDbContext.Add(entity);
        _customerDbContext.SaveChanges();
        return entity;
    }

    public Task<T> AddAsync(T entity)
    {
        _customerDbContext.AddAsync(entity);
        _customerDbContext.SaveChangesAsync();
        return Task.FromResult<T>(entity);

    }

    public void Delete(T entity)
    {
        _customerDbContext.Remove(entity);
        _customerDbContext.SaveChangesAsync();
    }

    public Task DeleteAsync(T entity)
    {
        _customerDbContext.Remove(entity);
        _customerDbContext.SaveChangesAsync();
        return Task.CompletedTask;
    }

    public bool Exists(Guid id)
    {
        return null != _customerDbContext.Find<T>(id) ? true : false;
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
