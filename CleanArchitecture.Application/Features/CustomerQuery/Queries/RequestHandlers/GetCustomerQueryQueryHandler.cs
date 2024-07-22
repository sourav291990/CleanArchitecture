namespace CleanArchitecture.Application.Features.CustomerQuery.Queries.RequestHandlers
{
    using MediatR;
    using AutoMapper;
    using CleanArchitecture.Application.Contracts.Persistence;
    using CleanArchitecture.Application.Contracts.Infrastructure.Logging;
    using CleanArchitecture.Application.Features.CustomerQuery.Queries.DTOs;
    using CleanArchitecture.Application.Features.CustomerQuery.Queries.Requests;
    public class GetCustomerQueryQueryHandler : IRequestHandler<GetCustomerQueryQuery, IReadOnlyList<CustomerQueryDto>>
    {
        private readonly IMapper _mapper;
        private readonly ICustomerQueryRepository _customerQueryRepository;
        private readonly IAppLogger<GetCustomerQueryQueryHandler> _logger;

        public GetCustomerQueryQueryHandler(IMapper mapper, ICustomerQueryRepository customerQueryRepository, IAppLogger<GetCustomerQueryQueryHandler> logger)
        {
            _mapper = mapper;
            _customerQueryRepository = customerQueryRepository;
            _logger = logger;
        }

        public async Task<IReadOnlyList<CustomerQueryDto>> Handle(GetCustomerQueryQuery request, CancellationToken cancellationToken)
        {
            var response = await _customerQueryRepository.GetAllAsync();
            return _mapper.Map<IReadOnlyList<CustomerQueryDto>>(response);
        }
    }
}
