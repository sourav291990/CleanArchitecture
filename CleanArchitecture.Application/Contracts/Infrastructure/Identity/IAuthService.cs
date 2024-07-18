namespace CleanArchitecture.Application.Contracts.Infrastructure.Identity;

using CleanArchitecture.Application.Models.Identity;

public interface IAuthService
{
    Task<AuthResponse> Login(AuthRequest request);
    Task<RegistrationResponse> Register(RegistrationRequest request);
}
