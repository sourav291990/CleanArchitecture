using CleanArchitecture.Domain.Entities.Customer;

namespace CleanArchitecture.Application.Contracts.Persistence
{
    public interface ICustomerRepository : IGenericRepository<Customer>
    {
        Task<bool> IsUniqueCustomerName(string customerFirstName, string customerLastName);
    }
}
