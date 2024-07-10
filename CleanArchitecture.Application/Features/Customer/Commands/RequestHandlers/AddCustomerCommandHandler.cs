namespace CleanArchitecture.Application.Features.Customer.Commands.RequestHandlers;

using MediatR;
using AutoMapper;
using CleanArchitecture.Domain.Entities.Customer;
using CleanArchitecture.Application.CustomExceptions;
using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Application.Contracts.Infrastructure.Logging;
using CleanArchitecture.Application.Features.Customer.Commands.Requests;
using CleanArchitecture.Application.Features.Customer.Commands.Requests.Validators;

public class AddCustomerCommandHandler : IRequestHandler<AddCustomerCommand, Unit>
{
    private readonly IMapper _mapper;
    private readonly ICustomerRepository _customerRepository;
    private readonly IAppLogger<AddCustomerCommandHandler> _logger;

    public AddCustomerCommandHandler(IMapper mapper, ICustomerRepository customerRepository, IAppLogger<AddCustomerCommandHandler> logger)
    {
        _mapper = mapper;
        _customerRepository = customerRepository;
        _logger = logger;
    }

    public async Task<Unit> Handle(AddCustomerCommand request, CancellationToken cancellationToken)
    {
        var validator = new AddCustomerCommandValidator(_customerRepository);
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
        {
            _logger.LogError("Invalid customer details provided");
            throw new BadRequestException("Invalid Customer", validationResult);
        }

        var customer = _mapper.Map<Customer>(request.Customer);
        await _customerRepository.AddAsync(customer);
        return Unit.Value;
    }
}
