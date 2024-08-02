namespace CleanArchitecture.Persistence.Options;

using Microsoft.Extensions.Options;
using Microsoft.Extensions.Configuration;
using CleanArchitecture.Persistence.Settings;

public class DatabaseOptionsSetup : IConfigureOptions<DatabaseOptions>
{
    private readonly IConfiguration _configuration;
    private const string ConfigurationSectionName = "DatabaseOptions";
    public DatabaseOptionsSetup(IConfiguration configuration) => _configuration = configuration;

    public void Configure(DatabaseOptions options)
    {
        var connectionString = _configuration.GetConnectionString("CustomerDbConnectionString");
        options.ConnectionString = connectionString;

        _configuration.GetSection(ConfigurationSectionName).Bind(options);
    }
}
