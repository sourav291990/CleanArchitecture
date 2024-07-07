namespace CleanArchitecture.Application.Features.Customer.Commands.RequestHandlers;

using MediatR;
using AutoMapper;
using CleanArchitecture.Domain.Entities.Customer;
using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Application.Features.Customer.Commands.Requests;

public class AddCustomerCommandHandler : IRequestHandler<AddCustomerCommand, Unit>
{
    private readonly IMapper _mapper;
    private readonly ICustomerRepository _customerRepository;

    public AddCustomerCommandHandler(IMapper mapper, ICustomerRepository customerRepository)
    {
        _mapper = mapper;
        _customerRepository = customerRepository;
    }

    public async Task<Unit> Handle(AddCustomerCommand request, CancellationToken cancellationToken)
    {
        var customer = _mapper.Map<Customer>(request.Customer);
        await _customerRepository.AddAsync(customer);
        return Unit.Value;
    }
}
