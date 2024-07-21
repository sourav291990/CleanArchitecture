namespace CleanArchitecture.Identity.Configurations;

using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using CleanArchitecture.Identity.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class UserConfiguration : IEntityTypeConfiguration<ApplicationUser>
{
    public void Configure(EntityTypeBuilder<ApplicationUser> builder)
    {
        var hasher = new PasswordHasher<ApplicationUser>();
        builder.HasData(new ApplicationUser
        {
            Id = "2e1fe356-5ed5-4e46-b76e-214c960032da",
            Email = "user@localhost.com",
            FirstName = "Test",
            LastName = "User",
            PasswordHash = hasher.HashPassword(null,"Password@1"),
            EmailConfirmed = true
        },
        new ApplicationUser
        {
            Id = "9bffc491-f117-4389-bc01-4a3403389fcc",
            Email = "admin@localhost.com",
            FirstName = "Test",
            LastName = "Admin",
            PasswordHash = hasher.HashPassword(null, "Password@1"),
            EmailConfirmed = true
        });
    }
}
