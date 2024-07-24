namespace CleanArchitecture.Application.Features.Customer.Queries.DTOs
{
    public class CustomerDto
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public long PrimaryContactNumber { get; set; }
        public long SecondaryContactNumber { get; set; }
    }
}
