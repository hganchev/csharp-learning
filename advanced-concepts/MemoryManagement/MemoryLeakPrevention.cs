namespace AdvancedConcepts.MemoryManagement;

/// <summary>
/// Memory leak prevention strategies
/// </summary>
public static class MemoryLeakPrevention
{
    // Strategy 1: WeakReference for cache
    public class WeakCache<TKey, TValue> where TKey : notnull where TValue : class
    {
        private readonly Dictionary<TKey, WeakReference<TValue>> _cache = new();
        
        public void Add(TKey key, TValue value)
        {
            _cache[key] = new WeakReference<TValue>(value);
        }
        
        public bool TryGet(TKey key, out TValue? value)
        {
            if (_cache.TryGetValue(key, out var weakRef))
            {
                return weakRef.TryGetTarget(out value);
            }
            value = null;
            return false;
        }
    }
    
    // Strategy 2: Unsubscribe from events
    public class ProperEventHandling
    {
        private EventPublisher? _publisher;
        
        public void Subscribe(EventPublisher publisher)
        {
            _publisher = publisher;
            _publisher.SomethingHappened += OnSomethingHappened;
        }
        
        public void Unsubscribe()
        {
            if (_publisher != null)
            {
                _publisher.SomethingHappened -= OnSomethingHappened;
                _publisher = null;
            }
        }
        
        private void OnSomethingHappened(object? sender, EventArgs e) { }
    }
    
    // Strategy 3: Use IDisposable for cleanup
    public class ResourceManager : IDisposable
    {
        private System.Threading.Timer? _timer;
        private DisposableResource? _resource;
        
        public ResourceManager()
        {
            _timer = new System.Threading.Timer(_ => { }, null, 0, 1000);
            _resource = new DisposableResource("Managed");
        }
        
        public void Dispose()
        {
            _timer?.Dispose();
            _timer = null;
            
            _resource?.Dispose();
            _resource = null;
        }
    }
    
    // Strategy 4: Avoid capturing in closures unnecessarily
    public class ClosureMemoryLeak
    {
        private List<Action> _callbacks = new();
        
        // ❌ BAD: Captures 'this' unnecessarily
        public void BadClosure()
        {
            var largeData = new byte[1000000];
            _callbacks.Add(() =>
            {
                // This captures largeData even if not used!
                Console.WriteLine("Callback");
            });
        }
        
        // ✅ GOOD: Only capture what's needed
        public void GoodClosure()
        {
            var largeData = new byte[1000000];
            var needed = largeData.Length;
            _callbacks.Add(() =>
            {
                Console.WriteLine($"Callback: {needed}"); // Only captures 'needed'
            });
        }
    }
}
