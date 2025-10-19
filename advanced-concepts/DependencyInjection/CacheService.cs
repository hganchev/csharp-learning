namespace AdvancedConcepts.DependencyInjection;

// Cache Service
public interface ICacheService
{
    void Set(string key, object value);
    object? Get(string key);
}

public class MemoryCacheService : ICacheService
{
    private readonly Dictionary<string, object> _cache = new();
    private readonly object _lock = new object();
    
    public void Set(string key, object value)
    {
        lock (_lock)
        {
            _cache[key] = value;
        }
    }
    
    public object? Get(string key)
    {
        lock (_lock)
        {
            return _cache.TryGetValue(key, out var value) ? value : null;
        }
    }
}
