namespace CleanArchitecture.Application.Features.CustomerQuery.Queries.DTOs;

public sealed record CustomerQueryDto
{
    public Guid Id { get; set; }
    public Guid CustomerId { get; set; }
    public string Query { get; set; }
    public DateTime CreatedAt { get; set; }
    public Guid CreatedBy { get; set; }
    public DateTime UpdatedAt { get; set; }
    public Guid UpdatedBy { get; set; }
}
