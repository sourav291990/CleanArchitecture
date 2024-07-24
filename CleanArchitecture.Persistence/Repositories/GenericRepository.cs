namespace CleanArchitecture.Persistence.Repositories;

using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using CleanArchitecture.Persistence.DbContexts;
using CleanArchitecture.Domain.Entities.Common;
using CleanArchitecture.Application.Contracts.Persistence;

public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
{
    protected readonly CustomerDbContext _customerDbContext;

    public GenericRepository(CustomerDbContext customerDbContext) => _customerDbContext = customerDbContext;

    public void Add(T entity)
    {
        _customerDbContext.Add(entity);
        _customerDbContext.SaveChanges();
    }

    public Task AddAsync(T entity)
    {
        _customerDbContext.AddAsync(entity);
        _customerDbContext.SaveChangesAsync();
        return Task.CompletedTask;
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

    public async Task<bool> ExistsAsync(Guid id)
    {
        var customer = await _customerDbContext.FindAsync<T>(id);
        return customer != null;
    }

    public T Get(Guid id)
    {
        return _customerDbContext.Find<T>(id);
    }

    public IReadOnlyList<T> GetAll()
    {
        return _customerDbContext.Set<T>().ToList();
    }

    public async Task<IReadOnlyList<T>> GetAllAsync()
    {
        return await _customerDbContext.Set<T>().ToListAsync();
    }

    public async Task<T> GetAsync(Guid id)
    {
        return await _customerDbContext.Set<T>().FindAsync(id);
    }

    public void Update(T entity)
    {
        _customerDbContext.Entry(entity).State = (Microsoft.EntityFrameworkCore.EntityState)EntityState.Modified;
        _customerDbContext.SaveChanges();
    }

    public Task UpdateAsync(T entity)
    {
        _customerDbContext.Entry(entity).State = (Microsoft.EntityFrameworkCore.EntityState)EntityState.Modified;
        _customerDbContext.SaveChangesAsync();
        return Task.CompletedTask;
    }

}
