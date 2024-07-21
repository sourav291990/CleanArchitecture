namespace CleanArchitecture.Identity.Configurations;

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
{
    public void Configure(EntityTypeBuilder<IdentityRole> builder)
    {
        builder.HasData(new IdentityRole
        {
            Id = "60999a15-cb87-4241-aaa5-82d88a90e021",
            Name = "User",
            NormalizedName = "USER"
        },
        new IdentityRole
        {
            Id = "4dd6d40c-bc04-428f-90ab-c0e529e9fb18",
            Name = "Admin",
            NormalizedName = "ADMIN"
        });
    }
}
