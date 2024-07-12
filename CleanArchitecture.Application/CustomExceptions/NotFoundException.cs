namespace CleanArchitecture.Application.CustomExceptions;

using FluentValidation.Results;

public class NotFoundException : Exception
{
    public IDictionary<string, string[]> Errors { get; set; } = new Dictionary<string, string[]>();
    public NotFoundException(string message, object key) : base($"{message} ({key} was not found)")
    { }
    public NotFoundException(string message, ValidationResult validationResult) : base(message)
    {
        Errors = validationResult.ToDictionary();
    }
}
