namespace CleanArchitecture.Persistence.Options;

using Microsoft.Extensions.Options;
using Microsoft.Extensions.Configuration;
using CleanArchitecture.Persistence.Settings;

public class CustomerDatabaseOptionsSetup(IConfiguration configuration) : IConfigureOptions<CustomerDatabaseOptions>
{
    private readonly IConfiguration _configuration = configuration;
    private const string ConfigurationSectionName = "CustomerDatabaseOptions";

    public void Configure(CustomerDatabaseOptions options)
    {
        _configuration.GetSection(ConfigurationSectionName).Bind(options);
    }
}
