using Microsoft.Extensions.DependencyInjection;

namespace AdvancedConcepts.DependencyInjection;

/// <summary>
/// Common DI anti-patterns
/// </summary>
public static class DIAntiPatterns
{
    // ❌ ANTI-PATTERN 1: Captive Dependency
    // Singleton depends on Scoped/Transient - the scoped service is "captured"
    public class BadSingletonService
    {
        private readonly IScopedService _scopedService; // ❌ Scoped in Singleton!
        
        public BadSingletonService(IScopedService scopedService)
        {
            _scopedService = scopedService; // Will live as long as singleton!
        }
    }
    
    // ✅ FIX: Use IServiceScopeFactory
    public class GoodSingletonService
    {
        private readonly IServiceScopeFactory _scopeFactory;
        
        public GoodSingletonService(IServiceScopeFactory scopeFactory)
        {
            _scopeFactory = scopeFactory;
        }
        
        public void DoWork()
        {
            using var scope = _scopeFactory.CreateScope();
            var scopedService = scope.ServiceProvider.GetRequiredService<IScopedService>();
            // Use scoped service
        }
    }
    
    // ❌ ANTI-PATTERN 2: Service Locator
    public class BadServiceLocator
    {
        private readonly IServiceProvider _serviceProvider;
        
        public BadServiceLocator(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider; // ❌ Hides dependencies
        }
        
        public void DoWork()
        {
            var service = _serviceProvider.GetRequiredService<IEmailService>();
            // Dependencies not explicit
        }
    }
    
    // ✅ FIX: Constructor injection
    public class GoodConstructorInjection
    {
        private readonly IEmailService _emailService;
        
        public GoodConstructorInjection(IEmailService emailService)
        {
            _emailService = emailService; // ✅ Explicit dependency
        }
        
        public void DoWork()
        {
            // Use _emailService
        }
    }
    
    // ❌ ANTI-PATTERN 3: Circular Dependencies
    // public class ServiceA { public ServiceA(ServiceB b) { } }
    // public class ServiceB { public ServiceB(ServiceA a) { } }
    
    // ✅ FIX: Introduce interface or refactor design
    public class RefactoredServiceA
    {
        public RefactoredServiceA(ISharedService shared) { }
    }
    
    public class RefactoredServiceB
    {
        public RefactoredServiceB(ISharedService shared) { }
    }
    
    public interface ISharedService { }
    public class SharedService : ISharedService { }
}
