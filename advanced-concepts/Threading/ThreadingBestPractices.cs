using System.Collections.Concurrent;

namespace AdvancedConcepts.Threading;

/// <summary>
/// Best practices for threading
/// </summary>
public static class ThreadingBestPractices
{
    // 1. Prefer Task over Thread
    public static async Task PreferTaskOverThread()
    {
        // BAD: Manual thread creation
        // var thread = new Thread(() => DoWork());
        // thread.Start();
        
        // GOOD: Use Task
        await Task.Run(() => DoWork());
    }
    
    // 2. Always protect shared state
    private static readonly object _lockObject = new object();
    private static int _sharedCounter = 0;
    
    public static void AlwaysProtectSharedState()
    {
        // GOOD: Lock around shared state
        lock (_lockObject)
        {
            _sharedCounter++;
        }
    }
    
    // 3. Use thread-safe collections
    private static ConcurrentDictionary<int, string> _threadSafeDict = new();
    
    // 4. Avoid lock contention
    public static void AvoidLockContention()
    {
        // Keep lock scope minimal
        lock (_lockObject)
        {
            // Only critical section here
            _sharedCounter++;
        }
        // Don't include IO or expensive operations inside lock
    }
    
    // 5. Use SemaphoreSlim for async scenarios
    private static SemaphoreSlim _asyncSemaphore = new SemaphoreSlim(1, 1);
    
    public static async Task UseSemaphoreForAsync()
    {
        await _asyncSemaphore.WaitAsync();
        try
        {
            // Critical section
            await Task.Delay(100);
        }
        finally
        {
            _asyncSemaphore.Release();
        }
    }
    
    private static void DoWork() { }
}
