
namespace CleanArchitecture.Application.Features.Activity.Commands.Requests;

using CleanArchitecture.Application.Features.Activity.Commands.DTOs;
using MediatR;

public sealed record AddActivityCommandRequest : IRequest<Unit>
{
    public AddActivityDto Activity { get; set; }
}
