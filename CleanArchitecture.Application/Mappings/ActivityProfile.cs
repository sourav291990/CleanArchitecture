
namespace CleanArchitecture.Application.Mappings;

using AutoMapper;
using CleanArchitecture.Domain.Entities.Activity;
using CleanArchitecture.Application.Features.Activity.Queries.DTOs;

public class ActivityProfile : Profile
{
    public ActivityProfile()
    {
        #region Activity
        CreateMap<GetActivityDto, Activity>().ReverseMap();
        #endregion
    }
}
