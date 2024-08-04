namespace CleanArchitecture.Persistence.Options;

using Microsoft.Extensions.Options;
using Microsoft.Extensions.Configuration;

public class ActivityDatabaseOptionsSetup(IConfiguration configuration) : IConfigureOptions<ActivityDatabaseOptions>
{
    private readonly IConfiguration _configuration = configuration;
    private const string ConfigurationSectionName = "ActivityDatabaseOptions";

    public void Configure(ActivityDatabaseOptions options)
    {
        _configuration.GetSection(ConfigurationSectionName).Bind(options);
    }
}
