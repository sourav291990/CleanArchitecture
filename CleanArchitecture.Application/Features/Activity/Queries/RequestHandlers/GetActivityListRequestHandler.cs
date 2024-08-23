namespace CleanArchitecture.Application.Features.Activity.Queries.RequestHandlers;

using MediatR;
using AutoMapper;
using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Application.Features.Activity.Queries.DTOs;
using CleanArchitecture.Application.Contracts.Infrastructure.Caching;
using CleanArchitecture.Application.Features.Activity.Queries.Requests;

public class GetActivityListRequestHandler(IActivityRepository activityRepository, IMapper mapper, ICacheService cacheService) : IRequestHandler<GetActivityListRequest, IReadOnlyList<GetActivityDto>>
{
    private readonly IActivityRepository _activityRepository = activityRepository;
    private readonly IMapper _mapper = mapper;
    private readonly ICacheService _cacheService = cacheService;

    public async Task<IReadOnlyList<GetActivityDto>> Handle(GetActivityListRequest request, CancellationToken cancellationToken)
    {
        List<GetActivityDto> activitiesList = await _cacheService.GetAsync<List<GetActivityDto>>("activities", cancellationToken);
        if (activitiesList is not null)
        {
            return activitiesList;
        }
        var activities = await _activityRepository.GetAllAsync();
        activitiesList = _mapper.Map<List<GetActivityDto>>(activities);
        await _cacheService.SetAsync("activities", activitiesList, cancellationToken);
        return activitiesList;
    }
}
