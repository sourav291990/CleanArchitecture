namespace CleanArchitecture.Application.Features.Activity.Queries.RequestHandlers;

using MediatR;
using CleanArchitecture.Application.Features.Activity.Queries.DTOs;
using CleanArchitecture.Application.Features.Activity.Queries.Requests;
public class GetActivityListRequestHandler : IRequestHandler<GetActivityListRequest, IReadOnlyList<GetActivityDto>>
{
    public GetActivityListRequestHandler()
    {
    }
    public Task<IReadOnlyList<GetActivityDto>> Handle(GetActivityListRequest request, CancellationToken cancellationToken)
    {

    }
}
