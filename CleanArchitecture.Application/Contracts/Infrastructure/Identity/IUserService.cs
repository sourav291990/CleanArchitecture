namespace CleanArchitecture.Application.Contracts.Infrastructure.Identity;

using CleanArchitecture.Application.Models.Identity;

public interface IUserService
{
    Task<List<User>> GetUsers();
    Task<User> GetUser(string userId);
}
