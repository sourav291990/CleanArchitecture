
namespace CleanArchitecture.Persistence.Settings;

using CleanArchitecture.Persistence.Options;
public class CustomerDatabaseOptions
{
    public string ConnectionString { get; set; }
    public int MaxRetryCount { get; set; }
    public int CommandTimeout { get; set; }
    public bool EnableDetailedError { get; set; }
    public bool EnableSensitiveDataLogging { get; set; }
}
