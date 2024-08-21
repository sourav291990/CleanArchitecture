namespace CleanArchitecture.Application.Features.Activity.Commands.RequestHandlers;

using MediatR;
using AutoMapper;
using CleanArchitecture.Domain.Entities.Activity;
using CleanArchitecture.Application.CustomExceptions;
using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Application.Contracts.Infrastructure.Logging;
using CleanArchitecture.Application.Features.Activity.Commands.Requests;
using CleanArchitecture.Application.Features.Activity.Commands.Requests.Validators;

public class AddActivityCommandRequestHandler : IRequestHandler<AddActivityCommandRequest, Unit>
{
    private readonly IActivityRepository _activityRepository;
    private readonly IAppLogger<AddActivityCommandRequestHandler> _logger;
    private readonly IMapper _mapper;
    public AddActivityCommandRequestHandler(IActivityRepository activityRepository, IMapper mapper, IAppLogger<AddActivityCommandRequestHandler> logger)
    {
        _activityRepository = activityRepository;
        _mapper = mapper;
        _logger = logger;
    }
    public async Task<Unit> Handle(AddActivityCommandRequest request, CancellationToken cancellationToken)
    {
        var validator = new AddActivityCommandRequestValidator();
        var validationResult = await validator.ValidateAsync(request.Activity, cancellationToken);
        if (!validationResult.IsValid)
        {
            _logger.LogError("Invalid activity details provided");
            throw new BadRequestException("Invalid Activity", validationResult);
        }

        var activity = _mapper.Map<Activity>(request.Activity);
        await _activityRepository.AddAsync(activity);
        return Unit.Value;
    }
}
