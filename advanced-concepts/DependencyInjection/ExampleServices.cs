using Microsoft.Extensions.Logging;

namespace AdvancedConcepts.DependencyInjection;

// Example Services
public interface IEmailService
{
    void SendEmail(string to, string subject, string body);
}

public class EmailService : IEmailService
{
    private readonly ILogger<EmailService> _logger;
    
    public EmailService(ILogger<EmailService> logger)
    {
        _logger = logger;
    }
    
    public void SendEmail(string to, string subject, string body)
    {
        _logger.LogInformation($"Sending email to {to}: {subject}");
    }
}

public class ConcreteService
{
    public void DoWork() => Console.WriteLine("Working...");
}

public class Configuration
{
    public string Setting { get; set; } = string.Empty;
}

public interface INotificationService
{
    void Notify(string message);
}

public class EmailNotificationService : INotificationService
{
    public void Notify(string message) => Console.WriteLine($"Email: {message}");
}

public class SmsNotificationService : INotificationService
{
    public void Notify(string message) => Console.WriteLine($"SMS: {message}");
}
