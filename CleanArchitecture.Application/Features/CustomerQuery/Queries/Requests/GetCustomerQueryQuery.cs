namespace CleanArchitecture.Application.Features.CustomerQuery.Queries.Requests
{
    using MediatR;
    using CleanArchitecture.Application.Features.CustomerQuery.Queries.DTOs;
    public class GetCustomerQueryQuery : IRequest<IReadOnlyList<CustomerQueryDto>>
    {
    }
}
