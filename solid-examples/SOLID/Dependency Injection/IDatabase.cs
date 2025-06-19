using System;

namespace SOLID.DependencyInjection
{
    /// <summary>
    /// Interface for database operations - used for proper dependency abstraction
    /// </summary>
    public interface IDatabase
    {
        void Save(string data);
        string Get(int id);
    }

    /// <summary>
    /// Interface for email service operations
    /// </summary>
    public interface IEmailService
    {
        void SendEmail(string to, string subject, string body);
    }

    /// <summary>
    /// Interface for logging operations
    /// </summary>
    public interface ILogger
    {
        void Log(string message);
    }
}