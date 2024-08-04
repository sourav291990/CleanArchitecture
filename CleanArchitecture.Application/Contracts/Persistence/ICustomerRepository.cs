
namespace CleanArchitecture.Application.Contracts.Persistence;

using CleanArchitecture.Domain.Entities.Customer;
public interface ICustomerRepository : IGenericRepository<Customer>
{
    Task<bool> IsUniqueCustomerName(string customerFirstName, string customerLastName);
}
