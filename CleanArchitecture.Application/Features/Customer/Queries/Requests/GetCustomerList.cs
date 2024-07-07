namespace CleanArchitecture.Application.Features.Customer.Queries.Requests;

using MediatR;
using CleanArchitecture.Application.Features.Customer.Queries.DTOs;

public sealed class GetCustomerList : IRequest<List<CustomerDto>>
{
}
