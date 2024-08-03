
namespace CleanArchitecture.Application.Features.Customer.Commands.Requests;

using MediatR;
using CleanArchitecture.Application.Features.Customer.Commands.DTOs;

public sealed record AddCustomerCommand : IRequest<Unit>
{
    public AddCustomerDto Customer { get; set; }
}
