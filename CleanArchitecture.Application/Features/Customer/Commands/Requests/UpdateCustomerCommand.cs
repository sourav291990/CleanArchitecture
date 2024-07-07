namespace CleanArchitecture.Application.Features.Customer.Commands.Requests;

using MediatR;
using CleanArchitecture.Application.Features.Customer.Commands.DTOs;

public sealed class UpdateCustomerCommand : IRequest<Unit>
{
    public UpdateCustomerDto Customer { get; set; }
}
