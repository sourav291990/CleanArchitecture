namespace CleanArchitecture.Identity.Services;

using Microsoft.AspNetCore.Identity;
using CleanArchitecture.Identity.Models;
using CleanArchitecture.Application.Models.Identity;
using CleanArchitecture.Application.Contracts.Infrastructure.Identity;

public class UserService(UserManager<ApplicationUser> userManager) : IUserService
{
    private readonly UserManager<ApplicationUser> _userManager = userManager;
    public async Task<User> GetUser(string userId)
    {
        var user = await _userManager.FindByIdAsync(userId);
        return new User
        {
            Email = user.Email,
            FirstName = user.FirstName,
            LastName = user.LastName,
            Id = user.Id,
        };
    }

    public async Task<List<User>> GetUsers()
    {
        var users = await _userManager.GetUsersInRoleAsync("User");
        return users.Select(q => new User
        {
            Email = q.Email,
            FirstName = q.FirstName,
            LastName = q.LastName,
            Id = q.Id,
        }).ToList();
    }
}
