namespace AdvancedConcepts.DependencyInjection;

// Service Interfaces
public interface ITransientService
{
    Guid InstanceId { get; }
}

public interface IScopedService
{
    Guid InstanceId { get; }
}

public interface ISingletonService
{
    Guid InstanceId { get; }
}
