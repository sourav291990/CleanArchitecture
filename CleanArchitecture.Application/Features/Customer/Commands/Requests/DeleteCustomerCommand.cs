
namespace CleanArchitecture.Application.Features.Customer.Commands.Requests;

using MediatR;
public sealed record DeleteCustomerCommand : IRequest<Unit>
{
    public Guid CustomerId { get; set; }
}
