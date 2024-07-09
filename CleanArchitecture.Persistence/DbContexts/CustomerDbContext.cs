namespace CleanArchitecture.Persistence.DbContexts;

using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CleanArchitecture.Domain.Entities.Common;
using CleanArchitecture.Domain.Entities.Customer;

public class CustomerDbContext : DbContext
{
    public CustomerDbContext()
    {
    }
    public DbSet<Customer> Customers { get; set; }

    public override int SaveChanges()
    {
        UpdateBaseEntity();
        return base.SaveChanges();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(CustomerDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        UpdateBaseEntity();
        return base.SaveChangesAsync(cancellationToken);
    }

    private void UpdateBaseEntity()
    {
        foreach (var entry in ChangeTracker.Entries<BaseEntity>()
            .Where(x => x.State == EntityState.Added || x.State == EntityState.Modified))
        {
            entry.Entity.UpdatedAt = DateTime.UtcNow;
            if (entry.State == EntityState.Added)
            {
                entry.Entity.CreatedAt = DateTime.UtcNow;
            }
        }
    }
}


