namespace CleanArchitecture.Application.Features.Activity.Queries.RequestHandlers;

using MediatR;
using AutoMapper;
using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Application.Features.Activity.Queries.DTOs;
using CleanArchitecture.Application.Features.Activity.Queries.Requests;

public class GetActivityListRequestHandler : IRequestHandler<GetActivityListRequest, IReadOnlyList<GetActivityDto>>
{
    private readonly IActivityRepository _activityRepository;
    private readonly IMapper _mapper;
    public GetActivityListRequestHandler(IActivityRepository activityRepository, IMapper mapper)
    {
        _activityRepository = activityRepository;
        _mapper = mapper;
    }
    public async Task<IReadOnlyList<GetActivityDto>> Handle(GetActivityListRequest request, CancellationToken cancellationToken)
    {
        var activities = await _activityRepository.GetAllAsync();

        return _mapper.Map<List<GetActivityDto>>(activities);
    }
}
