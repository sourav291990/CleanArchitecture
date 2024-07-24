namespace CleanArchitecture.Persistence.Repositories;

using Microsoft.EntityFrameworkCore;
using CleanArchitecture.Persistence.DbContexts;
using CleanArchitecture.Domain.Entities.Customer;
using CleanArchitecture.Application.Contracts.Persistence;

public class CustomerRepository(CustomerDbContext customerDbContext) : GenericRepository<Customer>(customerDbContext), ICustomerRepository
{
    public async Task<bool> IsUniqueCustomerName(string customerFirstName, string customerLastName)
    {
        return !await _customerDbContext.Customers.AnyAsync(x => x.FirstName == customerFirstName && x.LastName == customerLastName);
    }
}
