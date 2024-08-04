
namespace CleanArchitecture.Persistence.DbContexts;

using Microsoft.EntityFrameworkCore;
using CleanArchitecture.Domain.Entities.Common;
using CleanArchitecture.Domain.Entities.Activity;
public class ActivityDbContext(DbContextOptions<ActivityDbContext> options) : DbContext(options)
{
    public DbSet<Activity> Activities { get; set; }

    public override int SaveChanges()
    {
        UpdateBaseEntity();
        return base.SaveChanges();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("cleanarchitecture");
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ActivityDbContext).Assembly);
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
                entry.Entity.Id = Guid.NewGuid();
                entry.Entity.CreatedAt = DateTime.UtcNow;
            }
        }
    }
}