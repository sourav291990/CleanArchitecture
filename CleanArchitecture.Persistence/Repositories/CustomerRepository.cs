namespace CleanArchitecture.Persistence.Repositories;

using CleanArchitecture.Domain.Entities.Customer;
using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Persistence.DbContexts;

public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
{
    public Task<bool> IsUniqueCustomerName(string customerFirstName, string customerLastName)
    {
        throw new NotImplementedException();
    }
}
