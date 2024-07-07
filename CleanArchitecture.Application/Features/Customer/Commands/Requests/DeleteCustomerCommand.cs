
namespace CleanArchitecture.Application.Features.Customer.Commands.Requests;

using MediatR;
public sealed class DeleteCustomerCommand : IRequest<Unit>
{
    public Guid CustomerId { get; set; }
}
