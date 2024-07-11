namespace CleanArchitecture.Application.Features.Customer.Queries.RequestHandlers;

using MediatR;
using AutoMapper;
using System.Threading;
using System.Threading.Tasks;
using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Application.Features.Customer.Queries.DTOs;
using CleanArchitecture.Application.Features.Customer.Queries.Requests;
using CleanArchitecture.Application.Contracts.Infrastructure.Logging;

public class GetCustomerListHandler : IRequestHandler<GetCustomerList, List<CustomerDto>>
{
    private readonly IMapper _mapper;
    private readonly ICustomerRepository _customerRepository;
    private readonly IAppLogger<GetCustomerListHandler> _appLogger;
    public GetCustomerListHandler(IMapper mapper, ICustomerRepository customerRepository, IAppLogger<GetCustomerListHandler> appLogger)
    {
        _customerRepository = customerRepository;
        _mapper = mapper;
        _appLogger = appLogger;
    }
    public async Task<List<CustomerDto>> Handle(GetCustomerList request, CancellationToken cancellationToken)
    {
        var customers = await _customerRepository.GetAllAsync();
        var customerDtos = _mapper.Map<List<CustomerDto>>(customers);
        return customerDtos;
    }
}
