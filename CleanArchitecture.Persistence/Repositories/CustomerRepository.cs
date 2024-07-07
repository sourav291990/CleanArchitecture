using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Domain.Entities.Customer;

namespace CleanArchitecture.Persistence.Repositories
{
    public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
    {
        public Task<bool> IsUniqueCustomerName(string customerFirstName, string customerLastName)
        {
            throw new NotImplementedException();
        }
    }
}
