namespace CleanArchitecture.Application.Features.Customer.Queries.Requests;

using MediatR;
using CleanArchitecture.Application.Features.Customer.Queries.DTOs;

public sealed record GetCustomerList : IRequest<List<CustomerDto>>
{
}
