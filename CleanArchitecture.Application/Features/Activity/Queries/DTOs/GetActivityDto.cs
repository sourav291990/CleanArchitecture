namespace CleanArchitecture.Application.Features.Activity.Queries.DTOs;
public record GetActivityDto
{
    public Guid Id { get; set; }
    public string Title { get; private set; }
    public string Description { get; private set; }
    public string Category { get; private set; }
    public string City { get; private set; }
    public string Venue { get; private set; }
}
