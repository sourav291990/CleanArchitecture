
namespace CleanArchitecture.Domain.Entities.Customer;

using CleanArchitecture.Domain.Entities.Common;

public class CustomerOrders : BaseEntity
{
    internal CustomerOrders(Guid customerId, int orderQuantity, string productCode)
    {
        CustomerId = customerId;
        OrderQuantity = orderQuantity;
        ProductCode = productCode;
    }
    public Guid CustomerId { get; private set; }
    public int OrderQuantity { get; private set; }
    public string ProductCode { get; private set; }
}
