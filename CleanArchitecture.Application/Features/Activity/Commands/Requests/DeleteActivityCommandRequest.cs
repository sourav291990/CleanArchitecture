using MediatR;

namespace CleanArchitecture.Application.Features.Activity.Commands.Requests;

public class DeleteActivityCommandRequest : IRequest<Unit>
{
    public Guid ActivityId { get; set; }
}
