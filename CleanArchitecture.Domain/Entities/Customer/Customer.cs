namespace CleanArchitecture.Domain.Entities.Customer;

using System.ComponentModel.DataAnnotations;
using CleanArchitecture.Domain.Entities.Common;

public sealed class Customer : BaseEntity
{
    private Customer(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
    }
    [Required]
    public string FirstName { get; private set; }
    [Required]
    public string LastName { get; private set; }
    [Phone]
    [Required]
    public long PrimaryContactNumber { get; private set; }
    [Phone]
    public long SecondaryContactNumber { get; private set; }
    [Required]
    public string CustomerType { get; private set; }

    public static Customer Create(string firstName, string lastName, int customerTypeId)
    {
        Customer customer = new(firstName, lastName);
        customer.CustomerType = customerTypeId switch
        {
            1 => "Prime",
            2 => "Standard",
            _ => "Subsidized",
        };
        return customer;
    }
}
