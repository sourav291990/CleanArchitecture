namespace CleanArchitecture.Application.Features.Customer.Commands.RequestHandlers
{
    using MediatR;
    using CleanArchitecture.Domain.Entities.Customer;
    using CleanArchitecture.Application.CustomExceptions;
    using CleanArchitecture.Application.Contracts.Persistence;
    using CleanArchitecture.Application.Features.Customer.Commands.Requests;

    public sealed class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommand, Unit>
    {
        private readonly ICustomerRepository _customerRepository;

        public DeleteCustomerCommandHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<Unit> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
        {
            if (_customerRepository.Exists(request.CustomerId))
            {
                throw new NotFoundException(nameof(Customer), request.CustomerId);
            }
            var customer = await _customerRepository.GetAsync(request.CustomerId);
            await _customerRepository.DeleteAsync(customer);
            return Unit.Value;

        }
    }
}
