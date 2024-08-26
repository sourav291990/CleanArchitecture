
namespace CleanArchitecture.Domain.Entities.Activity;

using CleanArchitecture.Domain.Entities.Common;

public class Activity : BaseEntity
{
    private Activity()
    {
    }
    public string Title { get; private set; }
    public string Description { get; private set; }
    public string Category { get; private set; }
    public string City { get; private set; }
    public string Venue { get; private set; }
    public DateTime Date { get; set; }

    public static Activity Create(Guid id, string title, string description
        , string category, string city, string venue, DateTime date)
    {
        var activity = new Activity
        {
            Title = title,
            Description = description,
            Category = category,
            City = city,
            Venue = venue,
            Date = date
        };
        activity.Id = id;
        return activity;
    }
}
