using CleanArchitecture.Domain.Entities.Activity;
using CleanArchitecture.Persistence.DbContexts;

namespace CleanArchitecture.Persistence.Seed;

public class ActivitySeed
{
    public static async Task SeedData(ActivityDbContext context)
    {
        if (context.Activities.Any())
            return;
        var activities = new List<Activity>
        {
            Activity.Create("SampleActivity1","Activity 1 Description","Casual", "Bangalore","Marathahalli"),
            Activity.Create("SampleActivity2","Activity 2 Description","Casual", "Bangalore","Bellandur"),
        };
        await context.Activities.AddRangeAsync(activities);
        await context.SaveChangesAsync();
    }
}
