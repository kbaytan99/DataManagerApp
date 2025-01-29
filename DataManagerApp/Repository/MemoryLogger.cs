namespace DataManagerApp.Logging
{
    /// <summary>
    /// In-memory logger implementation for tracking data operations.
    /// Stores logs in a list and keeps them in memory.
    /// 
    /// @author Kaan Baytan
    /// @version 1.0
    /// @since 29.01.2025
    /// </summary>
    public class MemoryLogger : ILogger
    {
        private readonly List<string> _logs = new();

        public void Log(string operation, string entityType, int id)
        {
            string logEntry = $"{operation} | {entityType} | ID: {id}";
            _logs.Add(logEntry);
        }

        public List<string> GetLogs()
        {
            return new List<string>(_logs);
        }
    }
}
