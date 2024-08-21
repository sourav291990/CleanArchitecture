namespace CleanArchitecture.Domain.Abstractions;
public static class ActivityErrors
{
    public static readonly Error InvalidActivity = new("Invalid Activity", "Invalid Activity");
    public static readonly Error DuplicateActivity = new("Duplicate Activity", "Duplicate Activity");
}
