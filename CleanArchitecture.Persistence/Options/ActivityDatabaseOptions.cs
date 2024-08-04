namespace CleanArchitecture.Persistence.Options;

public class ActivityDatabaseOptions
{
    public string ConnectionString { get; set; } = string.Empty;
    public int MaxRetryCount { get; set; }
    public int CommandTimeout { get; set; }
    public bool EnableDetailedError { get; set; }
    public bool EnableSensitiveDataLogging { get; set; }
}
