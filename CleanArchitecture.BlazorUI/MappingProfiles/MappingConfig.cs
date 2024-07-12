namespace CleanArchitecture.BlazorUI.MappingProfiles;

using AutoMapper;
using CleanArchitecture.BlazorUI.Services.Base;
using CleanArchitecture.BlazorUI.ViewModels.Customer;

public class MappingConfig : Profile
{
    public MappingConfig()
    {
        CreateMap<CustomerVM, CustomerDto>().ReverseMap();
    }
}
