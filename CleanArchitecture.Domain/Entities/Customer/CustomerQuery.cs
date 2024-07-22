namespace CleanArchitecture.Domain.Entities.Customer
{
    using CleanArchitecture.Domain.Entities.Common;
    public class CustomerQuery : BaseEntity
    {
        public Guid CustomerId { get; set; }
        public string Query { get; set; }
    }
}
