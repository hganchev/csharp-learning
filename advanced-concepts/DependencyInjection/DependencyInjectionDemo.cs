using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace AdvancedConcepts.DependencyInjection;

/// <summary>
/// Demonstrates Dependency Injection patterns and service lifetimes
/// </summary>
public static class DependencyInjectionDemo
{
    public static void Run()
    {
        Console.WriteLine("=== DEPENDENCY INJECTION & LIFETIMES ===\n");
        
        DemonstrateServiceLifetimes();
        DemonstrateServiceRegistration();
        DemonstrateLifetimeScenarios();
        DemonstrateBestPractices();
    }

    private static void DemonstrateServiceLifetimes()
    {
        Console.WriteLine("1. Service Lifetimes:\n");
        
        var services = new ServiceCollection();
        
        // Transient: New instance every time
        services.AddTransient<ITransientService, TransientService>();
        Console.WriteLine("  TRANSIENT:");
        Console.WriteLine("  - New instance every time requested");
        Console.WriteLine("  - Use for lightweight, stateless services");
        Console.WriteLine("  - Example: Repositories, Validators");
        
        // Scoped: One instance per scope (request in web apps)
        services.AddScoped<IScopedService, ScopedService>();
        Console.WriteLine("\n  SCOPED:");
        Console.WriteLine("  - One instance per scope/request");
        Console.WriteLine("  - Use for per-request state");
        Console.WriteLine("  - Example: DbContext, Unit of Work");
        
        // Singleton: One instance for application lifetime
        services.AddSingleton<ISingletonService, SingletonService>();
        Console.WriteLine("\n  SINGLETON:");
        Console.WriteLine("  - One instance for entire application");
        Console.WriteLine("  - Must be thread-safe");
        Console.WriteLine("  - Example: Configuration, Caching, Logging\n");
        
        var serviceProvider = services.BuildServiceProvider();
        
        // Demonstrate different lifetimes
        Console.WriteLine("  Resolving services:");
        
        // Transient - different instances
        var transient1 = serviceProvider.GetRequiredService<ITransientService>();
        var transient2 = serviceProvider.GetRequiredService<ITransientService>();
        Console.WriteLine($"  Transient same instance? {transient1.InstanceId == transient2.InstanceId}");
        
        // Singleton - same instance
        var singleton1 = serviceProvider.GetRequiredService<ISingletonService>();
        var singleton2 = serviceProvider.GetRequiredService<ISingletonService>();
        Console.WriteLine($"  Singleton same instance? {singleton1.InstanceId == singleton2.InstanceId}");
        
        // Scoped - same within scope, different across scopes
        using (var scope1 = serviceProvider.CreateScope())
        {
            var scoped1a = scope1.ServiceProvider.GetRequiredService<IScopedService>();
            var scoped1b = scope1.ServiceProvider.GetRequiredService<IScopedService>();
            Console.WriteLine($"  Scoped same within scope? {scoped1a.InstanceId == scoped1b.InstanceId}");
        }
        
        using (var scope2 = serviceProvider.CreateScope())
        {
            var scoped2 = scope2.ServiceProvider.GetRequiredService<IScopedService>();
            Console.WriteLine($"  Scoped different across scopes? (new instance created)");
        }
        
        Console.WriteLine();
    }

    private static void DemonstrateServiceRegistration()
    {
        Console.WriteLine("2. Service Registration Patterns:\n");
        
        var services = new ServiceCollection();
        
        // 1. Interface to Implementation
        services.AddTransient<IEmailService, EmailService>();
        Console.WriteLine("  AddTransient<IEmailService, EmailService>()");
        Console.WriteLine("  - Maps interface to implementation");
        
        // 2. Concrete type
        services.AddTransient<ConcreteService>();
        Console.WriteLine("\n  AddTransient<ConcreteService>()");
        Console.WriteLine("  - Register concrete type directly");
        
        // 3. Factory method
        services.AddTransient<IEmailService>(sp => 
            new EmailService(sp.GetRequiredService<ILogger<EmailService>>()));
        Console.WriteLine("\n  AddTransient<IEmailService>(sp => new EmailService(...))");
        Console.WriteLine("  - Custom factory for complex initialization");
        
        // 4. Instance
        var configInstance = new Configuration { Setting = "Production" };
        services.AddSingleton(configInstance);
        Console.WriteLine("\n  AddSingleton(instance)");
        Console.WriteLine("  - Register existing instance");
        
        // 5. Multiple implementations
        services.AddTransient<INotificationService, EmailNotificationService>();
        services.AddTransient<INotificationService, SmsNotificationService>();
        Console.WriteLine("\n  Multiple implementations of same interface");
        Console.WriteLine("  - Resolve with IEnumerable<INotificationService>");
        
        var sp = services.BuildServiceProvider();
        var notifications = sp.GetServices<INotificationService>();
        Console.WriteLine($"  Resolved {notifications.Count()} implementations\n");
    }

    private static void DemonstrateLifetimeScenarios()
    {
        Console.WriteLine("3. Common Lifetime Scenarios:\n");
        
        var services = new ServiceCollection();
        
        // Scenario 1: Database context (Scoped)
        Console.WriteLine("  Scenario 1: Database Context");
        services.AddScoped<IUserRepository, UserRepository>();
        Console.WriteLine("  ✅ Scoped - One DbContext per request");
        Console.WriteLine("  Multiple repositories in same request share same context");
        
        // Scenario 2: HTTP Client (Singleton factory)
        Console.WriteLine("\n  Scenario 2: HTTP Client");
        services.AddSingleton<IHttpClientFactory, HttpClientFactory>();
        Console.WriteLine("  ✅ Singleton factory creates transient clients");
        Console.WriteLine("  Factory is singleton, clients are managed appropriately");
        
        // Scenario 3: Caching (Singleton)
        Console.WriteLine("\n  Scenario 3: Cache Service");
        services.AddSingleton<ICacheService, MemoryCacheService>();
        Console.WriteLine("  ✅ Singleton - Shared cache across all requests");
        Console.WriteLine("  Must be thread-safe");
        
        // Scenario 4: Request-specific data (Scoped)
        Console.WriteLine("\n  Scenario 4: Request Context");
        services.AddScoped<IRequestContext, RequestContext>();
        Console.WriteLine("  ✅ Scoped - Holds data for current request");
        
        // Scenario 5: Validators (Transient)
        Console.WriteLine("\n  Scenario 5: Validators");
        services.AddTransient<IValidator<User>, UserValidator>();
        Console.WriteLine("  ✅ Transient - Lightweight, stateless validation");
        
        Console.WriteLine();
    }

    private static void DemonstrateBestPractices()
    {
        Console.WriteLine("4. DI Best Practices:\n");
        
        Console.WriteLine("  ✅ Constructor injection (preferred)");
        Console.WriteLine("  ✅ Register interfaces, not concrete types");
        Console.WriteLine("  ✅ Use appropriate lifetime");
        Console.WriteLine("  ✅ Avoid service locator pattern");
        Console.WriteLine("  ✅ Keep constructors simple");
        Console.WriteLine("  ✅ Use IOptions<T> for configuration");
        Console.WriteLine("  ✅ Dispose scopes properly");
        Console.WriteLine("  ❌ Don't inject Transient into Singleton (captive dependency)");
        Console.WriteLine("  ❌ Don't use ServiceProvider directly in app code");
        Console.WriteLine("  ❌ Don't register Singleton with mutable state without thread-safety");
        Console.WriteLine("  ❌ Don't create circular dependencies\n");
    }
}
