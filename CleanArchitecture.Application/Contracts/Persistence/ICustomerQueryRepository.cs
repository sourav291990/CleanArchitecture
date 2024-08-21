namespace CleanArchitecture.Application.Contracts.Persistence;

using Microsoft.EntityFrameworkCore;
using CleanArchitecture.Domain.Entities.Customer;

public interface ICustomerQueryRepository : IGenericRepository<CustomerQuery, DbContext>
{
    Task<IEnumerable<CustomerQuery>> GetQueryByCustomerId(Guid customerId);
}