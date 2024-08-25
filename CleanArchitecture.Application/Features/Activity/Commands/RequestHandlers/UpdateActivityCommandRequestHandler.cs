namespace CleanArchitecture.Application.Features.Activity.Commands.RequestHandlers;

using MediatR;
using AutoMapper;
using CleanArchitecture.Domain.Entities.Activity;
using CleanArchitecture.Application.CustomExceptions;
using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Application.Contracts.Infrastructure.Logging;
using CleanArchitecture.Application.Features.Activity.Commands.Requests;
using CleanArchitecture.Application.Features.Activity.Commands.Requests.Validators;

public class UpdateActivityCommandRequestHandler : IRequestHandler<UpdateActivityCommandRequest, Unit>
{
    private readonly IActivityRepository _activityRepository;
    private readonly IAppLogger<UpdateActivityCommandRequestHandler> _logger;
    private readonly IMapper _mapper;

    public UpdateActivityCommandRequestHandler(IActivityRepository activityRepository, IAppLogger<UpdateActivityCommandRequestHandler> logger, IMapper mapper)
    {
        _activityRepository = activityRepository;
        _logger = logger;
        _mapper = mapper;
    }

    public async Task<Unit> Handle(UpdateActivityCommandRequest request, CancellationToken cancellationToken)
    {
        var validator = new UpdateActivityCommandRequestValidator(_activityRepository);
        var validationResult = await validator.ValidateAsync(request.Activity, cancellationToken);
        if (!validationResult.IsValid)
        {
            _logger.LogError("Invalid activity details provided");
            throw new BadRequestException("Invalid Activity", validationResult);
        }

        var activity = _mapper.Map<Activity>(request.Activity);
        await _activityRepository.UpdateAsync(activity);
        return Unit.Value;
    }
}
