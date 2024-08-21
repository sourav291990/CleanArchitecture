namespace CleanArchitecture.Application.Features.Activity.Commands.RequestHandlers;

using MediatR;
using AutoMapper;
using CleanArchitecture.Application.CustomExceptions;
using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Application.Contracts.Infrastructure.Logging;
using CleanArchitecture.Application.Features.Activity.Commands.Requests;
using CleanArchitecture.Application.Features.Activity.Commands.Requests.Validators;

public class DeleteActivityCommandRequestHandler : IRequestHandler<DeleteActivityCommandRequest, Unit>
{
    private readonly IActivityRepository _activityRepository;
    private readonly IMapper _mapper;
    private readonly IAppLogger<DeleteActivityCommandRequestHandler> _logger;

    public DeleteActivityCommandRequestHandler(IActivityRepository activityRepository, IMapper mapper, IAppLogger<DeleteActivityCommandRequestHandler> logger)
    {
        _activityRepository = activityRepository;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<Unit> Handle(DeleteActivityCommandRequest request, CancellationToken cancellationToken)
    {
        var validator = new DeleteActivityCommandRequestValidator(_activityRepository);
        var validationResult = await validator.ValidateAsync(request.ActivityId);
        if (!validationResult.IsValid)
        {
            _logger.LogError("Invalid activity id provided");
            throw new BadRequestException("Invalid activity id", validationResult);
        }
        var activity = await _activityRepository.GetAsync(request.ActivityId);
        await _activityRepository.DeleteAsync(activity);

        return Unit.Value;
    }
}
