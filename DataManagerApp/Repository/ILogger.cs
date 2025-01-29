namespace DataManagerApp.Logging
{
    /// <summary>
    /// Defines logging functionalities for tracking data operations.
    /// 
    /// @author Kaan Baytan
    /// @version 1.0
    /// @since 29.01.2025
    /// </summary>
    public interface ILogger
    {
        /// <summary>
        /// Logs an operation performed on an entity.
        /// </summary>
        /// <param name="operation">The type of operation (Create, Read, Update, Delete).</param>
        /// <param name="entityType">The type of entity (Movie, Book, Magazine).</param>
        /// <param name="id">The ID of the entity.</param>
        void Log(string operation, string entityType, int id);

        /// <summary>
        /// Retrieves all logs stored in memory.
        /// </summary>
        /// <returns>A list of log entries.</returns>
        List<string> GetLogs();
    }
}
