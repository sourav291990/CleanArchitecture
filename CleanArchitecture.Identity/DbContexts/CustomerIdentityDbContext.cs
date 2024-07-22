
namespace CleanArchitecture.Identity.DbContexts;

using Microsoft.EntityFrameworkCore;
using CleanArchitecture.Identity.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

public class CustomerIdentityDbContext(DbContextOptions<CustomerIdentityDbContext> options) : IdentityDbContext<ApplicationUser>(options)
{

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("cleanarchitecture");
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(CustomerIdentityDbContext).Assembly);
    }
}
