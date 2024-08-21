namespace CleanArchitecture.Persistence.Repositories;

using Microsoft.EntityFrameworkCore;
using CleanArchitecture.Persistence.DbContexts;
using CleanArchitecture.Domain.Entities.Customer;
using CleanArchitecture.Persistence.DbContextProvider;
using CleanArchitecture.Application.Contracts.Persistence;

public class CustomerRepository : GenericRepository<Customer, CustomerDbContext>, ICustomerRepository
{
    private readonly CustomerDbContext _customerDbContext;
    public CustomerRepository(IDbContextProvider dbContextProvider) : base(dbContextProvider) => _customerDbContext = dbContextProvider.Get<CustomerDbContext>();
    public async Task<bool> IsUniqueCustomerName(string customerFirstName, string customerLastName)
    {
        return !await _customerDbContext.Customers.AnyAsync(x => x.FirstName == customerFirstName && x.LastName == customerLastName);
    }
}
