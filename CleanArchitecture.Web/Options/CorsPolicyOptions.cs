namespace CleanArchitecture.Web.Options;

public record CorsPolicyOptions
{
    public string PolicyName { get; set; }
    public string[] AllowedOrigins { get; set; }
    public string[] AllowedMethods { get; set; }
    public string[] AllowedHeaders { get; set; }
}
