namespace CleanArchitecture.Application.Features.Activity.Queries.RequestHandlers;

using MediatR;
using AutoMapper;
using System.Threading;
using System.Threading.Tasks;
using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Application.Features.Activity.Queries.DTOs;
using CleanArchitecture.Application.Features.Activity.Queries.Requests;

public class GetActivityByIdRequestHandler(IActivityRepository activityRepository, IMapper mapper) : IRequestHandler<GetActivityByIdRequest, GetActivityDto>
{
    private readonly IActivityRepository _activityRepository = activityRepository;
    private readonly IMapper _mapper = mapper;

    public async Task<GetActivityDto> Handle(GetActivityByIdRequest request, CancellationToken cancellationToken)
    {
        var activity = await _activityRepository.GetAsync(request.ActivityId);
        return _mapper.Map<GetActivityDto>(activity);
    }
}
