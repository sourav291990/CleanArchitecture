namespace CleanArchitecture.Domain.Entities.Customer;

using System.ComponentModel.DataAnnotations;
using CleanArchitecture.Domain.Entities.Common;

public sealed class Customer : BaseEntity
{
    public Customer(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
    }
    [Required]
    public string FirstName { get; set; }
    [Required]
    public string LastName { get; set; }
    [Phone]
    [Required]
    public long PrimaryContactNumber { get; set; }
    [Phone]
    public long SecondaryContactNumber { get; set; }
}
