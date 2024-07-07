namespace CleanArchitecture.Application.Features.Customer.Commands.DTOs;

using System.ComponentModel.DataAnnotations;

public class UpdateCustomerDto
{
    public Guid CustomerId { get; set; }
    [Required]
    public string FirstName { get; set; } = string.Empty;
    [Required]
    public string LastName { get; set; } = string.Empty;
    [Phone]
    [Required]
    public long PrimaryContactNumber { get; set; }
    [Phone]
    public long SecondaryContactNumber { get; set; }
}
