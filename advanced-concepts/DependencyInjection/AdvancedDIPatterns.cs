using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace AdvancedConcepts.DependencyInjection;

/// <summary>
/// Advanced DI patterns
/// </summary>
public static class AdvancedDIPatterns
{
    // Pattern 1: Decorator Pattern
    public static void RegisterDecorator(IServiceCollection services)
    {
        services.AddTransient<IEmailService, EmailService>();
        services.Decorate<IEmailService, LoggingEmailServiceDecorator>();
    }
    
    // Pattern 2: Options Pattern
    public class EmailOptions
    {
        public string SmtpServer { get; set; } = "smtp.example.com";
        public int Port { get; set; } = 587;
    }
    
    public static void RegisterWithOptions(IServiceCollection services)
    {
        services.Configure<EmailOptions>(options =>
        {
            options.SmtpServer = "smtp.myserver.com";
            options.Port = 587;
        });
        
        services.AddTransient<IEmailService, EmailServiceWithOptions>();
    }
    
    // Pattern 3: Factory Pattern with DI
    public interface IServiceFactory
    {
        IEmailService CreateEmailService();
    }
    
    public class ServiceFactory : IServiceFactory
    {
        private readonly IServiceProvider _serviceProvider;
        
        public ServiceFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
        
        public IEmailService CreateEmailService()
        {
            return _serviceProvider.GetRequiredService<IEmailService>();
        }
    }
    
    // Pattern 4: Keyed Services (.NET 8+)
    public static void RegisterKeyedServices(IServiceCollection services)
    {
        services.AddKeyedTransient<INotificationService, EmailNotificationService>("email");
        services.AddKeyedTransient<INotificationService, SmsNotificationService>("sms");
    }
}

// Decorator implementation
public class LoggingEmailServiceDecorator : IEmailService
{
    private readonly IEmailService _inner;
    private readonly ILogger<LoggingEmailServiceDecorator> _logger;
    
    public LoggingEmailServiceDecorator(IEmailService inner, ILogger<LoggingEmailServiceDecorator> logger)
    {
        _inner = inner;
        _logger = logger;
    }
    
    public void SendEmail(string to, string subject, string body)
    {
        _logger.LogInformation($"Sending email to {to}");
        _inner.SendEmail(to, subject, body);
        _logger.LogInformation("Email sent");
    }
}

// Options pattern implementation
public class EmailServiceWithOptions : IEmailService
{
    private readonly AdvancedDIPatterns.EmailOptions _options;
    private readonly ILogger<EmailServiceWithOptions> _logger;
    
    public EmailServiceWithOptions(
        Microsoft.Extensions.Options.IOptions<AdvancedDIPatterns.EmailOptions> options,
        ILogger<EmailServiceWithOptions> logger)
    {
        _options = options.Value;
        _logger = logger;
    }
    
    public void SendEmail(string to, string subject, string body)
    {
        _logger.LogInformation($"Sending via {_options.SmtpServer}:{_options.Port}");
    }
}
