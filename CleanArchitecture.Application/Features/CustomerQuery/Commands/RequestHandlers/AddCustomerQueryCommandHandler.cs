namespace CleanArchitecture.Application.Features.CustomerQuery.Commands.RequestHandlers
{
    using MediatR;
    using AutoMapper;
    using CleanArchitecture.Domain.Entities.Customer;
    using CleanArchitecture.Application.Contracts.Persistence;
    using CleanArchitecture.Application.Contracts.Infrastructure.Logging;
    using CleanArchitecture.Application.Features.CustomerQuery.Commands.Requests;

    public class AddCustomerQueryCommandHandler : IRequestHandler<AddCustomerQueryCommand, Unit>
    {
        private readonly IMapper _mapper;
        private readonly ICustomerQueryRepository _customerQueryRepository;
        private readonly IAppLogger<AddCustomerQueryCommandHandler> _logger;

        public AddCustomerQueryCommandHandler(IMapper mapper, ICustomerQueryRepository customerQueryRepository, IAppLogger<AddCustomerQueryCommandHandler> logger)
        {
            _mapper = mapper;
            _customerQueryRepository = customerQueryRepository;
            _logger = logger;
        }

        public async Task<Unit> Handle(AddCustomerQueryCommand request, CancellationToken cancellationToken)
        {
            var customerQuery = _mapper.Map<CustomerQuery>(request.CustomerQuery);
            await _customerQueryRepository.AddAsync(customerQuery);
            return Unit.Value;
        }
    }
}
