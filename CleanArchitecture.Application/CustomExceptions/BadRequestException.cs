namespace CleanArchitecture.Application.CustomExceptions;

using FluentValidation.Results;

public class BadRequestException : Exception
{
    public List<string> Errors { get; set; } = new List<string>();
    public BadRequestException(string? message) : base(message)
    {
    }

    public BadRequestException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
    public BadRequestException(string message, ValidationResult validationResult) : base(message)
    {
        Errors = new List<string>();

        foreach (var item in validationResult.Errors)
        {
            Errors.Add(item.ErrorMessage);
        }
    }
}
