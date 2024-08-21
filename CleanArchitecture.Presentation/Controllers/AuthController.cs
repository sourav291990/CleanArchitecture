namespace CleanArchitecture.Web.Controllers;

using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using CleanArchitecture.Application.Models.Identity;
using CleanArchitecture.Application.Contracts.Infrastructure.Identity;

[ApiController]
[ApiVersion(1)]
[Route("api/v{version:apiVersion}/[controller]")]
public class AuthController(IAuthService authService) : ControllerBase
{
    private readonly IAuthService _authService = authService;

    [HttpPost("login")]
    public async Task<ActionResult<AuthResponse>> Login(AuthRequest request)
    {
        return Ok(await _authService.Login(request));
    }

    [HttpPost("register")]
    public async Task<ActionResult<RegistrationResponse>> Register(RegistrationRequest request)
    {
        return Ok(await _authService.Register(request));
    }
}
