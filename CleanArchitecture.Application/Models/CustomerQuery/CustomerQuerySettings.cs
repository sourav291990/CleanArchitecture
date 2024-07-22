namespace CleanArchitecture.Application.Models.CustomerQuery;
public class CustomerQuerySettings
{
    public string ConnectionString { get; set; } = null!;

    public string DatabaseName { get; set; } = null!;

    public string CustomerQueryCollectionName { get; set; } = null!;
}
