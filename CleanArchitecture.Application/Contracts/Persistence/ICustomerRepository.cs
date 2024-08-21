
namespace CleanArchitecture.Application.Contracts.Persistence;

using Microsoft.EntityFrameworkCore;
using CleanArchitecture.Domain.Entities.Customer;

public interface ICustomerRepository : IGenericRepository<Customer, DbContext>
{
    Task<bool> IsUniqueCustomerName(string customerFirstName, string customerLastName);
}
