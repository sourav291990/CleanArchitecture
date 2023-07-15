using CleanArchitecture.Domain.Entities.Customer;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Persistence.DbContexts
{
    public class CustomerDbContext : DbContext
    {
        public CustomerDbContext()
        {
            
        }
        public DbSet<Customer> Customers { get; set; }
    }

    
}
