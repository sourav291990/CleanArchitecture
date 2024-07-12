using CleanArchitecture.BlazorUI.Services.Base;
using CleanArchitecture.BlazorUI.ViewModels.Customer;

namespace CleanArchitecture.BlazorUI.Contracts;

public interface ICustomerService
{
    Task<List<CustomerVM>> GetCustomers();
    Task<CustomerVM> GetCustomerById(Guid id);
    Task<Response<Guid>> CreateCustomer(CustomerVM customer);
    Task<Response<Guid>> UpdateCustomer(CustomerVM customer);
    Task<Response<Guid>> DeleteCustomer(Guid id);
}
