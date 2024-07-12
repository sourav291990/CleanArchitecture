namespace CleanArchitecture.BlazorUI.Services;

using System;
using AutoMapper;
using System.Threading.Tasks;
using System.Collections.Generic;
using CleanArchitecture.BlazorUI.Contracts;
using CleanArchitecture.BlazorUI.Services.Base;
using CleanArchitecture.BlazorUI.ViewModels.Customer;

public class CustomerService : BaseHttpService, ICustomerService
{
    private readonly IMapper _mapper;
    public CustomerService(IClient client, IMapper mapper) : base(client)
    {
        _mapper = mapper;
    }

    public async Task<Response<Guid>> CreateCustomer(CustomerVM customer)
    {
        try
        {
            var customerDto = _mapper.Map<AddCustomerDto>(customer);
            await _client.CustomerPOSTAsync(customerDto);
            return new Response<Guid>() { Success = true };
        }
        catch (ApiException ex)
        {
            return ConvertApiException<Guid>(ex);
        }
    }

    public async Task<Response<Guid>> DeleteCustomer(Guid id)
    {
        try
        {
            await _client.CustomerDELETEAsync(id);
            return new Response<Guid>() { Success = true };
        }
        catch (ApiException ex)
        {
            return ConvertApiException<Guid>(ex);
        }
    }

    public async Task<CustomerVM> GetCustomerById(Guid id)
    {
        var customer = await _client.CustomerGETAsync(id);
        return _mapper.Map<CustomerVM>(customer);
    }

    public async Task<List<CustomerVM>> GetCustomers()
    {
        var customers = await _client.CustomerAllAsync();
        return _mapper.Map<List<CustomerVM>>(customers);
    }

    public async Task<Response<Guid>> UpdateCustomer(CustomerVM customer)
    {
        try
        {
            var customerDto = _mapper.Map<UpdateCustomerDto>(customer);
            await _client.CustomerPUTAsync(0, customerDto);
            return new Response<Guid>() { Success = true };
        }
        catch (ApiException ex)
        {
            return ConvertApiException<Guid>(ex);
        }
    }
}
