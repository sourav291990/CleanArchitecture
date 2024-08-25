
namespace CleanArchitecture.Application.Mappings;

using AutoMapper;
using CleanArchitecture.Domain.Entities.Activity;
using CleanArchitecture.Application.Features.Activity.Queries.DTOs;
using CleanArchitecture.Application.Features.Activity.Commands.DTOs;

public class ActivityProfile : Profile
{
    public ActivityProfile()
    {
        #region Activity
        CreateMap<GetActivityDto, Activity>().ReverseMap();
        CreateMap<AddActivityDto, Activity>().ReverseMap();
        CreateMap<UpdateActivityDto, Activity>().ReverseMap();
        #endregion
    }
}
