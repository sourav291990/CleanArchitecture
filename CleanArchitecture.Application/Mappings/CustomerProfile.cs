namespace CleanArchitecture.Application.Mappings;

using AutoMapper;
using CleanArchitecture.Domain.Entities.Customer;
using CleanArchitecture.Application.Features.Customer.Queries.DTOs;
using CleanArchitecture.Application.Features.Customer.Commands.DTOs;
using CleanArchitecture.Application.Features.CustomerQuery.Commands.DTOs;
using CleanArchitecture.Application.Features.CustomerQuery.Queries.DTOs;

public class CustomerProfile : Profile
{
    public CustomerProfile()
    {
        #region Customer
        CreateMap<Customer, CustomerDto>().ReverseMap();
        CreateMap<Customer, UpdateCustomerDto>().ReverseMap();
        CreateMap<Customer, AddCustomerDto>().ReverseMap();
        #endregion

        #region CustomerQuery
        CreateMap<CustomerQuery, AddCustomerQueryDto>().ReverseMap();
        CreateMap<CustomerQuery, CustomerQueryDto>().ReverseMap();
        #endregion
    }
}
