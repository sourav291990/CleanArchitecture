﻿namespace CleanArchitecture.Application.Models.Identity;

public class AuthResponse
{
    public string Id { get; set; }
    public string UserName { get; set; }
    public string EmailId { get; set; }
    public string Token { get; set; }
}
