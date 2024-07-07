namespace CleanArchitecture.Application.Features.Customer.Commands.Requests.Validators;

using FluentValidation;
using CleanArchitecture.Application.Contracts.Persistence;

public class AddCustomerCommandValidator : AbstractValidator<AddCustomerCommand>
{
    private readonly ICustomerRepository _customerRepository;
    public AddCustomerCommandValidator(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
        RuleFor(p => p.Customer.FirstName)
            .NotNull()
            .NotEmpty()
            .MinimumLength(2)
            .MaximumLength(200);

        RuleFor(p => p.Customer.LastName)
            .NotNull()
            .NotEmpty()
            .MinimumLength(2)
            .MaximumLength(200);

        RuleFor(p => p.Customer.PrimaryContactNumber)
            .NotEmpty()
            .NotEmpty()
            .Must(IsValidMobileNumber).WithMessage("{PropertyName} is not valid");

        RuleFor(p => p).MustAsync(IsUniqueCustomer).WithMessage("Customer Already Exisits");
    }

    private async Task<bool> IsUniqueCustomer(AddCustomerCommand command, CancellationToken token)
    {
        return await _customerRepository.IsUniqueCustomerName(command.Customer.FirstName, command.Customer.LastName);
    }

    private bool IsValidMobileNumber(long mobileNumber)
    {
        throw new NotImplementedException();
    }
}
