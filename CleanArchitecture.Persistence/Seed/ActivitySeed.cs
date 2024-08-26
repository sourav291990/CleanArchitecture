namespace CleanArchitecture.Persistence.Seed;

using CleanArchitecture.Persistence.DbContexts;
using CleanArchitecture.Domain.Entities.Activity;

public class ActivitySeed
{
    public static async Task SeedData(ActivityDbContext context)
    {
        if (context.Activities.Any())
            return;
        var activities = new List<Activity>
        {
            Activity.Create(Guid.NewGuid(), "SampleActivity1","Activity 1 Description","Casual", "Bangalore","Marathahalli",DateTime.UtcNow),
            Activity.Create(Guid.NewGuid(),"SampleActivity2","Activity 2 Description","Casual", "Bangalore","Bellandur",DateTime.UtcNow.AddMinutes(5)),
        };
        await context.Activities.AddRangeAsync(activities);
        await context.SaveChangesAsync();
    }
}
