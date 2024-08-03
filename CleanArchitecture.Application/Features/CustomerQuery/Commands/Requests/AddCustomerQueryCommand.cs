
namespace CleanArchitecture.Application.Features.CustomerQuery.Commands.Requests
{
    using MediatR;
    using CleanArchitecture.Application.Features.CustomerQuery.Commands.DTOs;
    public sealed record AddCustomerQueryCommand : IRequest<Unit>
    {
        public AddCustomerQueryDto CustomerQuery { get; set; }
    }
}
