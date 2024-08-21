namespace CleanArchitecture.Identity.Options;

public class IdentityDatabaseOptions
{
    public string ConnectionString { get; set; }
    public int MaxRetryCount { get; set; }
    public int CommandTimeout { get; set; }
    public bool EnableDetailedError { get; set; }
    public bool EnableSensitiveDataLogging { get; set; }
}
