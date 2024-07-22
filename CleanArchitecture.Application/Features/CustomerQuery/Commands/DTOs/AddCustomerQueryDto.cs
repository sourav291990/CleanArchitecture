namespace CleanArchitecture.Application.Features.CustomerQuery.Commands.DTOs;

public class AddCustomerQueryDto
{
    public Guid CustomerId { get; set; }
    public string Query { get; set; }
}