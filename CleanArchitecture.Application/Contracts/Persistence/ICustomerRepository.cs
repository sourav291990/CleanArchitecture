using CleanArchitecture.Domain.Entities.Customer;

namespace CleanArchitecture.Application.Contracts.Persistence
{
    public interface ICustomerRepository : IGenericRepository<Customer>
    {
    }
}
