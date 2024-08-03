namespace CleanArchitecture.Persistence.Configuration;

using Microsoft.EntityFrameworkCore;
using CleanArchitecture.Domain.Entities.Customer;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.HasData(
            Customer.Create("SampleUser", "SampleUser", 1));

        builder.Property(q => q.FirstName).IsRequired().HasMaxLength(100);
        builder.Property(q => q.LastName).IsRequired().HasMaxLength(100);
    }
}
