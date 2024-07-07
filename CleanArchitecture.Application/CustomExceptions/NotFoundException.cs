namespace CleanArchitecture.Application.CustomExceptions;

public class NotFoundException : Exception
{
    public NotFoundException(string message, object key) : base($"{message} ({key} was not found)")
    { }
}
