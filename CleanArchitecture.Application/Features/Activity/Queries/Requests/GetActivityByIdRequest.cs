namespace CleanArchitecture.Application.Features.Activity.Queries.Requests;

using MediatR;
using CleanArchitecture.Application.Features.Activity.Queries.DTOs;
public sealed record GetActivityByIdRequest : IRequest<GetActivityDto>
{
    public Guid ActivityId { get; set; }
}
