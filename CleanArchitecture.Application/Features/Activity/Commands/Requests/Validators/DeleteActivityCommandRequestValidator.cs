
namespace CleanArchitecture.Application.Features.Activity.Commands.Requests.Validators;

using FluentValidation;
using CleanArchitecture.Application.Contracts.Persistence;
public class DeleteActivityCommandRequestValidator : AbstractValidator<Guid>
{
    private readonly IActivityRepository _activityRepository;

    public DeleteActivityCommandRequestValidator(IActivityRepository activityRepository)
    {
        _activityRepository = activityRepository;
        RuleFor(p => p).MustAsync(IsActivityPresent).WithMessage("{PropertyName} does't exist.");
    }

    private async Task<bool> IsActivityPresent(Guid activityId, CancellationToken token)
    {
        return await _activityRepository.ExistsAsync(activityId);
    }
}
