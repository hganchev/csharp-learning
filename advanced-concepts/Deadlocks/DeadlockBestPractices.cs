namespace AdvancedConcepts.Deadlocks;

/// <summary>
/// Best practices to avoid deadlocks
/// </summary>
public static class DeadlockBestPractices
{
    // 1. ✅ Always acquire locks in the same order
    private static readonly object _lock1 = new object();
    private static readonly object _lock2 = new object();
    
    public static void AlwaysSameLockOrder()
    {
        lock (_lock1)
        {
            lock (_lock2)
            {
                // Work here
            }
        }
    }
    
    // 2. ✅ Use timeout with Monitor.TryEnter
    public static bool UseTimeout()
    {
        if (Monitor.TryEnter(_lock1, TimeSpan.FromSeconds(5)))
        {
            try
            {
                // Work here
                return true;
            }
            finally
            {
                Monitor.Exit(_lock1);
            }
        }
        return false;
    }
    
    // 3. ✅ Minimize lock scope
    public static void MinimizeLockScope()
    {
        // Prepare data outside lock
        var data = PrepareData();
        
        // Lock only critical section
        lock (_lock1)
        {
            // Minimal work here
            SaveData(data);
        }
    }
    
    // 4. ✅ Avoid nested locks when possible
    public static void AvoidNestedLocks()
    {
        // Instead of nested locks, redesign to use single lock
        lock (_lock1)
        {
            // All work here
        }
    }
    
    // 5. ✅ Use higher-level constructs
    private static SemaphoreSlim _semaphore = new SemaphoreSlim(1, 1);
    
    public static async Task UseHigherLevelConstructs()
    {
        await _semaphore.WaitAsync();
        try
        {
            // Work here
        }
        finally
        {
            _semaphore.Release();
        }
    }
    
    // 6. ✅ Never call external code while holding lock
    public static void NeverCallExternalCodeInLock()
    {
        lock (_lock1)
        {
            // ❌ DON'T: Call virtual methods, events, or external code
            // OnSomething(); // Could acquire another lock!
            
            // ✅ DO: Only modify internal state
            _ = 42; // Internal operation only
        }
    }
    
    private static object PrepareData() => new object();
    private static void SaveData(object data) { }
}
