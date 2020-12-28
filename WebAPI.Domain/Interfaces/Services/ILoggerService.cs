namespace WebAPI.Domain.Interfaces.Services
{
    /// <summary>
    /// Description of logger service
    /// </summary>
    public interface ILoggerService
    {
        void LogInfo(string message);
        void LogWarn(string message);
        void LogDebug(string message);
        void LogError(string message);
    }
}
