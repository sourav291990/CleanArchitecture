namespace CleanArchitecture.Persistence.Repositories;

using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using CleanArchitecture.Domain.Entities.Common;
using CleanArchitecture.Persistence.DbContextProvider;
using CleanArchitecture.Application.Contracts.Persistence;

public class GenericRepository<TEntity, TContext> : IGenericRepository<TEntity, TContext> where TEntity : BaseEntity where TContext : DbContext
{
    protected TContext Context { get; private set; }

    public GenericRepository(IDbContextProvider dbContextProvider) => Context = dbContextProvider.Get<TContext>()
                ?? throw new InvalidOperationException($"DbContext of type {typeof(TEntity).Name} is not registered");

    public void Add(TEntity entity)
    {
        Set().Add(entity);
        SaveChanges();
        //_customerDbContext.Add(entity);
        //_customerDbContext.SaveChanges();
    }

    public async Task AddAsync(TEntity entity)
    {
        await Set().AddAsync(entity);
        await SaveChangesAsync();
        //_customerDbContext.AddAsync(entity);
        //_customerDbContext.SaveChangesAsync();
    }

    public void Delete(TEntity entity)
    {
        //_customerDbContext.Remove(entity);
        //_customerDbContext.SaveChangesAsync();
        Set().Remove(entity);
        SaveChanges();
    }

    public async Task DeleteAsync(TEntity entity)
    {
        //_customerDbContext.Remove(entity);
        //_customerDbContext.SaveChangesAsync();
        Set().Remove(entity);
        await SaveChangesAsync();
    }

    public bool Exists(Guid id)
    {
        return null != Set().Find(id);
    }

    public async Task<bool> ExistsAsync(Guid id)
    {
        var customer = await Set().FindAsync(id);
        return customer != null;
    }

    public TEntity Get(Guid id)
    {
        return Set().Find(id);
    }

    public IReadOnlyList<TEntity> GetAll()
    {
        return [.. Set()];
    }

    public async Task<IReadOnlyList<TEntity>> GetAllAsync()
    {
        return await Set().ToListAsync();
    }

    public async Task<TEntity> GetAsync(Guid id)
    {
        return await Set().FindAsync(id);
    }

    public void Update(TEntity entity)
    {
        Context.Entry(entity).State = EntityState.Modified;
        SaveChanges();
        //_customerDbContext.Entry(entity).State = EntityState.Modified;
        //_customerDbContext.SaveChanges();
    }

    public Task UpdateAsync(TEntity entity)
    {
        Context.Entry(entity).State = EntityState.Modified;
        SaveChangesAsync();
        //_customerDbContext.Entry(entity).State = EntityState.Modified;
        //_customerDbContext.SaveChangesAsync();
        return Task.CompletedTask;
    }


    #region Protected Methods
    protected DbSet<TEntity> Set()
    {
        return Context.Set<TEntity>();
    }

    protected async Task SaveChangesAsync()
    {
        await Context.SaveChangesAsync();
    }

    protected void SaveChanges()
    {
        Context.SaveChangesAsync();
    }
    #endregion

}
