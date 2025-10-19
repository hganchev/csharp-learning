namespace AdvancedConcepts.DependencyInjection;

// Request Context
public interface IRequestContext
{
    string RequestId { get; }
}

public class RequestContext : IRequestContext
{
    public string RequestId { get; } = Guid.NewGuid().ToString();
}
