namespace CleanArchitecture.Application.Features.Customer.Commands.RequestHandlers;

using MediatR;
using AutoMapper;
using CleanArchitecture.Domain.Entities.Customer;
using CleanArchitecture.Application.CustomExceptions;
using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Application.Features.Customer.Commands.Requests;

public sealed class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand, Unit>
{
    private readonly IMapper _mapper;
    private readonly ICustomerRepository _customerRepository;

    public UpdateCustomerCommandHandler(IMapper mapper, ICustomerRepository customerRepository)
    {
        _mapper = mapper;
        _customerRepository = customerRepository;
    }

    public async Task<Unit> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
    {
        if (!_customerRepository.Exists(request.Customer.CustomerId))
        {
            throw new NotFoundException(nameof(Customer), request.Customer.CustomerId);
        }
        var customer = _mapper.Map<Customer>(request.Customer);
        await _customerRepository.UpdateAsync(customer);
        return Unit.Value;
    }
}
