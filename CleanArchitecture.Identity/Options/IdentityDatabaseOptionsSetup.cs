
namespace CleanArchitecture.Identity.Options;

using Microsoft.Extensions.Options;
using Microsoft.Extensions.Configuration;

public class IdentityDatabaseOptionsSetup(IConfiguration configuration) : IConfigureOptions<IdentityDatabaseOptions>
{
    private readonly IConfiguration _configuration = configuration;
    private const string ConfigurationSectionName = "IdentityDatabaseOptions";

    public void Configure(IdentityDatabaseOptions options)
    {
        _configuration.GetSection(ConfigurationSectionName).Bind(options);
    }
}
