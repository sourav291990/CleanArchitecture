namespace CleanArchitecture.Application.CustomExceptions;

using FluentValidation.Results;

public class BadRequestException : Exception
{
    public IDictionary<string, string[]> Errors { get; set; } = new Dictionary<string, string[]>();
    public BadRequestException(string? message) : base(message)
    {
    }

    public BadRequestException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
    public BadRequestException(string message, ValidationResult validationResult) : base(message)
    {
        Errors = validationResult.ToDictionary();
    }
}
