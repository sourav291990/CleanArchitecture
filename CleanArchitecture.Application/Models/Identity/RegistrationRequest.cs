﻿namespace CleanArchitecture.Application.Models.Identity;

using System.ComponentModel.DataAnnotations;

public class RegistrationRequest
{
    [Required]
    public string FirstName { get; set; }

    [Required]
    public string LastName { get; set; }

    [Required]
    [EmailAddress]
    public string EmailId { get; set; }

    [Required]
    [MinLength(6)]
    public string UserName { get; set; }

    [Required]
    [MinLength(6)]
    public string Password { get; set; }
}
