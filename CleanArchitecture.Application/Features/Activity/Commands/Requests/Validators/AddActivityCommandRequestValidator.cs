namespace CleanArchitecture.Application.Features.Activity.Commands.Requests.Validators;

using FluentValidation;
using CleanArchitecture.Application.Features.Activity.Commands.DTOs;
public class AddActivityCommandRequestValidator : AbstractValidator<AddActivityDto>
{
    public AddActivityCommandRequestValidator()
    {
        RuleFor(p => p.Title)
            .NotNull()
            .NotEmpty()
            .MinimumLength(3)
            .MaximumLength(50);

        RuleFor(p => p.Description)
            .NotEmpty()
            .MinimumLength(10)
            .MaximumLength(100);

        RuleFor(p => p.Category)
            .NotEmpty()
            .MinimumLength(3);

        RuleFor(p => p.City)
            .NotEmpty()
            .MinimumLength(3);

        RuleFor(p => p.Venue)
            .NotEmpty()
            .MinimumLength(3);
    }
}
