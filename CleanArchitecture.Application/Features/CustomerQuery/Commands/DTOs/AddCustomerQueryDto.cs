namespace CleanArchitecture.Application.Features.CustomerQuery.Commands.DTOs;

public sealed record AddCustomerQueryDto
{
    public Guid CustomerId { get; set; }
    public string Query { get; set; }
}