using System;

namespace SOLID.DependencyInjection
{
    /// <summary>
    /// SQL Server implementation of IDatabase
    /// </summary>
    public class SqlDatabase : IDatabase
    {
        public void Save(string data)
        {
            Console.WriteLine($"[SQL Database] Saving to SQL Server: {data}");
        }

        public string Get(int id)
        {
            Console.WriteLine($"[SQL Database] Getting data from SQL Server with ID: {id}");
            return $"Data from SQL Server with ID: {id}";
        }
    }

    /// <summary>
    /// MongoDB implementation of IDatabase
    /// </summary>
    public class MongoDatabase : IDatabase
    {
        public void Save(string data)
        {
            Console.WriteLine($"[Mongo Database] Saving to MongoDB: {data}");
        }

        public string Get(int id)
        {
            Console.WriteLine($"[Mongo Database] Getting data from MongoDB with ID: {id}");
            return $"Data from MongoDB with ID: {id}";
        }
    }

    /// <summary>
    /// SMTP Email Service implementation
    /// </summary>
    public class SmtpEmailService : IEmailService
    {
        public void SendEmail(string to, string subject, string body)
        {
            Console.WriteLine($"[SMTP] Sending email to {to}: {subject} - {body}");
        }
    }

    /// <summary>
    /// SendGrid Email Service implementation
    /// </summary>
    public class SendGridEmailService : IEmailService
    {
        public void SendEmail(string to, string subject, string body)
        {
            Console.WriteLine($"[SendGrid] Sending email to {to}: {subject} - {body}");
        }
    }

    /// <summary>
    /// Console Logger implementation
    /// </summary>
    public class ConsoleLogger : ILogger
    {
        public void Log(string message)
        {
            Console.WriteLine($"[Console Logger] {DateTime.Now:yyyy-MM-dd HH:mm:ss}: {message}");
        }
    }

    /// <summary>
    /// File Logger implementation
    /// </summary>
    public class FileLogger : ILogger
    {
        public void Log(string message)
        {
            Console.WriteLine($"[File Logger] Writing to file: {DateTime.Now:yyyy-MM-dd HH:mm:ss}: {message}");
        }
    }
}
