namespace CleanArchitecture.Identity;

using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using CleanArchitecture.Identity.Models;
using CleanArchitecture.Identity.Services;
using CleanArchitecture.Identity.Options;
using Microsoft.Extensions.Configuration;
using CleanArchitecture.Identity.DbContexts;
using Microsoft.Extensions.DependencyInjection;
using CleanArchitecture.Application.Models.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using CleanArchitecture.Application.Contracts.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

public static class IdentityServiceRegistration
{
    public static IServiceCollection RegisterIdentityServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<JwtSettings>(configuration.GetSection("JwtSettings"));
        services.ConfigureOptions<IdentityDatabaseOptionsSetup>();

        services.AddDbContext<CustomerIdentityDbContext>((serviceProvider, options) =>
        {
            var databaseOptions = serviceProvider.GetService<IOptions<IdentityDatabaseOptions>>().Value;
            options.UseSqlServer(databaseOptions.ConnectionString, sqlServerActions =>
            {
                sqlServerActions.EnableRetryOnFailure(databaseOptions.MaxRetryCount);
                sqlServerActions.CommandTimeout(databaseOptions.CommandTimeout);
            });

            options.EnableDetailedErrors(databaseOptions.EnableDetailedError);
            options.EnableSensitiveDataLogging(databaseOptions.EnableSensitiveDataLogging);
        });
        using var serviceProvider = services.BuildServiceProvider();
        try
        {
            var identityContext = serviceProvider.GetRequiredService<CustomerIdentityDbContext>();
            identityContext.Database.Migrate();
        }
        catch (Exception ex)
        {
            var logger = serviceProvider.GetRequiredService<ILogger<CustomerIdentityDbContext>>();
            logger.LogError(ex, ex.Message);
        }

        services.AddIdentity<ApplicationUser, IdentityRole>()
            .AddEntityFrameworkStores<CustomerIdentityDbContext>()
            .AddDefaultTokenProviders();

        services.AddTransient<IAuthService, AuthService>();
        services.AddTransient<IUserService, UserService>();

        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ClockSkew = TimeSpan.Zero,
                ValidIssuer = configuration["JwtSettings:Issuer"],
                ValidAudience = configuration["JwtSettings:Audience"],
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtSettings:Key"]))
            };
        });
        return services;
    }
}
