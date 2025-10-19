using Microsoft.Extensions.DependencyInjection;

namespace AdvancedConcepts.DependencyInjection;

// Extension method for Decorate pattern
public static class ServiceCollectionExtensions
{
    public static IServiceCollection Decorate<TInterface, TDecorator>(
        this IServiceCollection services)
        where TInterface : class
        where TDecorator : class, TInterface
    {
        var wrappedDescriptor = services.FirstOrDefault(
            s => s.ServiceType == typeof(TInterface));
        
        if (wrappedDescriptor == null)
            throw new InvalidOperationException($"{typeof(TInterface).Name} is not registered");
        
        var objectFactory = ActivatorUtilities.CreateFactory(
            typeof(TDecorator),
            new[] { typeof(TInterface) });
        
        services.Add(ServiceDescriptor.Describe(
            typeof(TInterface),
            sp => (TInterface)objectFactory(sp, new[] { sp.CreateInstance(wrappedDescriptor) }),
            wrappedDescriptor.Lifetime));
        services.Remove(wrappedDescriptor);
        
        return services;
    }
    
    private static object CreateInstance(this IServiceProvider services, ServiceDescriptor descriptor)
    {
        if (descriptor.ImplementationInstance != null)
            return descriptor.ImplementationInstance;
        
        if (descriptor.ImplementationFactory != null)
            return descriptor.ImplementationFactory(services);
        
        return ActivatorUtilities.GetServiceOrCreateInstance(
            services, descriptor.ImplementationType!);
    }
}
