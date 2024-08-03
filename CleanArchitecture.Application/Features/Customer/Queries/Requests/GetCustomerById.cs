namespace CleanArchitecture.Application.Features.Customer.Queries.Requests;

using MediatR;
using CleanArchitecture.Application.Features.Customer.Queries.DTOs;

public sealed record GetCustomerById : IRequest<CustomerDto>
{
    public Guid CustomerId { get; set; }
}
