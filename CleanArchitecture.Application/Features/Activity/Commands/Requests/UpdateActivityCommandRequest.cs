
namespace CleanArchitecture.Application.Features.Activity.Commands.Requests;

using MediatR;
using CleanArchitecture.Application.Features.Activity.Commands.DTOs;

public class UpdateActivityCommandRequest : IRequest<Unit>
{
    public UpdateActivityDto Activity { get; set; }
}
