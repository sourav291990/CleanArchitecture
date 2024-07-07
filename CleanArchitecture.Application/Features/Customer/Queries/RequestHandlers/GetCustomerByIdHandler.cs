namespace CleanArchitecture.Application.Features.Customer.Queries.RequestHandlers;

using MediatR;
using AutoMapper;
using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Application.Features.Customer.Queries.DTOs;
using CleanArchitecture.Application.Features.Customer.Queries.Requests;

public class GetCustomerByIdHandler : IRequestHandler<GetCustomerById, CustomerDto>
{
    private readonly IMapper _mapper;
    private readonly ICustomerRepository _customerRepository;

    public GetCustomerByIdHandler(IMapper mapper, ICustomerRepository customerRepository)
    {
        _mapper = mapper;
        _customerRepository = customerRepository;
    }

    public async Task<CustomerDto> Handle(GetCustomerById request, CancellationToken cancellationToken)
    {
        if (!await _customerRepository.ExistsAsync(request.CustomerId))
        {
            throw new Exception("Customer doesn't exists");
        }
        var customer = _customerRepository.Get(request.CustomerId);
        var customerAsDto = _mapper.Map<CustomerDto>(customer);
        return customerAsDto;
    }
}
