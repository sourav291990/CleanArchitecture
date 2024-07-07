using AutoMapper;
using CleanArchitecture.Application.Features.Customer.Commands.DTOs;
using CleanArchitecture.Application.Features.Customer.Queries.DTOs;
using CleanArchitecture.Domain.Entities.Customer;

namespace CleanArchitecture.Application.Mappings;

public class CustomerProfile : Profile
{
    public CustomerProfile()
    {
        CreateMap<Customer, CustomerDto>().ReverseMap();
        CreateMap<Customer, UpdateCustomerDto>().ReverseMap();
        CreateMap<Customer, AddCustomerDto>().ReverseMap();
    }
}
