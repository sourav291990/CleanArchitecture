namespace CleanArchitecture.Identity.Configurations;

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class UserRoleConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
{
    public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
    {
        builder.HasData(new IdentityUserRole<string> 
        {
            RoleId = "60999a15-cb87-4241-aaa5-82d88a90e021",
            UserId = "2e1fe356-5ed5-4e46-b76e-214c960032da"
        },
        new IdentityUserRole<string>
        {
            RoleId = "4dd6d40c-bc04-428f-90ab-c0e529e9fb18",
            UserId = "9bffc491-f117-4389-bc01-4a3403389fcc"
        });
    }
}
