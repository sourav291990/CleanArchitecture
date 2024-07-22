namespace CleanArchitecture.Application.Contracts.Persistence;

using CleanArchitecture.Domain.Entities.Customer;

public interface ICustomerQueryRepository : IGenericRepository<CustomerQuery>
{
    Task<IEnumerable<CustomerQuery>> GetQueryByCustomerId(Guid customerId);
}