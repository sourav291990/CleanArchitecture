namespace CleanArchitecture.Domain.Entities.Customer;

using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using CleanArchitecture.Domain.Entities.Common;

public sealed class Customer : BaseEntity
{
    private readonly List<CustomerOrders> _customerOrders = new();
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

    public IReadOnlyCollection<CustomerOrders> CustomerOrders => _customerOrders;

    public static Customer Create(string firstName, string lastName, int customerTypeId)
    {
        Customer customer = new(firstName, lastName);
        customer.CustomerType = customerTypeId switch
        {
            1 => "Prime",
            2 => "Standard",
            _ => "Subsidized",
        };
        customer.Id = Guid.NewGuid();
        return customer;
    }

    public CustomerOrders CreateOrder(Guid customerId, int orderQuantity, string productCode)
    {
        var customerOrder = new CustomerOrders(customerId, orderQuantity, productCode);
        _customerOrders.Add(customerOrder);
        return customerOrder;
    }
}
