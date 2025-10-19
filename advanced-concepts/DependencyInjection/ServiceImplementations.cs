namespace AdvancedConcepts.DependencyInjection;

// Service Implementations
public class TransientService : ITransientService
{
    public Guid InstanceId { get; } = Guid.NewGuid();
}

public class ScopedService : IScopedService
{
    public Guid InstanceId { get; } = Guid.NewGuid();
}

public class SingletonService : ISingletonService
{
    public Guid InstanceId { get; } = Guid.NewGuid();
}
