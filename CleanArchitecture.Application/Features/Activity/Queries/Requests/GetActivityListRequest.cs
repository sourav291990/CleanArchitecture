namespace CleanArchitecture.Application.Features.Activity.Queries.Requests;

using MediatR;
using CleanArchitecture.Application.Features.Activity.Queries.DTOs;
public sealed record GetActivityListRequest : IRequest<IReadOnlyList<GetActivityDto>>
{
}
