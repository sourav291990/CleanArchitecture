namespace CleanArchitecture.Application.Contracts.Infrastructure.Logging;

public interface IAppLogger<T>
{
    void LogWarn(string message, params object[] args);
    void LogInfo(string message, params object[] args);
    void LogError(string message, params object[] args);
    void LogDebug(string message, params object[] args);
}
