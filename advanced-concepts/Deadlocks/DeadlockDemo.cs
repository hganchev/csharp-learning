namespace AdvancedConcepts.Deadlocks;

/// <summary>
/// Demonstrates deadlock scenarios and prevention strategies
/// </summary>
public static class DeadlockDemo
{
    private static readonly object _lock1 = new object();
    private static readonly object _lock2 = new object();
    
    public static void Run()
    {
        Console.WriteLine("=== DEADLOCK SCENARIOS & PREVENTION ===\n");
        
        DemonstrateClassicDeadlock();
        DemonstrateDeadlockPrevention();
        DemonstrateAsyncDeadlock();
        DemonstrateDeadlockDetection();
    }

    private static void DemonstrateClassicDeadlock()
    {
        Console.WriteLine("1. Classic Deadlock (Lock Ordering Problem):");
        Console.WriteLine("  Starting two threads that will deadlock...");
        Console.WriteLine("  (This will timeout after 2 seconds)\n");
        
        var thread1 = new Thread(() => ClassicDeadlock_Thread1());
        var thread2 = new Thread(() => ClassicDeadlock_Thread2());
        
        thread1.Start();
        thread2.Start();
        
        // Wait with timeout to prevent actual deadlock in demo
        thread1.Join(TimeSpan.FromSeconds(2));
        thread2.Join(TimeSpan.FromSeconds(2));
        
        Console.WriteLine("  Threads timed out (deadlock occurred)\n");
    }

    // ❌ DEADLOCK: Thread 1 locks A then B
    private static void ClassicDeadlock_Thread1()
    {
        lock (_lock1)
        {
            Console.WriteLine("  Thread 1: Acquired lock1");
            Thread.Sleep(100); // Simulate work
            
            lock (_lock2)
            {
                Console.WriteLine("  Thread 1: Acquired lock2");
            }
        }
    }

    // ❌ DEADLOCK: Thread 2 locks B then A (opposite order!)
    private static void ClassicDeadlock_Thread2()
    {
        lock (_lock2)
        {
            Console.WriteLine("  Thread 2: Acquired lock2");
            Thread.Sleep(100); // Simulate work
            
            lock (_lock1)
            {
                Console.WriteLine("  Thread 2: Acquired lock1");
            }
        }
    }

    private static void DemonstrateDeadlockPrevention()
    {
        Console.WriteLine("2. Deadlock Prevention Strategies:");
        
        // Strategy 1: Lock Ordering
        Console.WriteLine("\n  Strategy 1: Consistent Lock Ordering");
        var t1 = new Thread(() => FixedDeadlock_Thread1_LockOrdering());
        var t2 = new Thread(() => FixedDeadlock_Thread2_LockOrdering());
        t1.Start();
        t2.Start();
        t1.Join();
        t2.Join();
        Console.WriteLine("  ✅ Both threads completed successfully");
        
        // Strategy 2: Lock Timeout
        Console.WriteLine("\n  Strategy 2: Lock Timeout with Monitor.TryEnter");
        var t3 = new Thread(() => FixedDeadlock_WithTimeout());
        t3.Start();
        t3.Join();
        Console.WriteLine("  ✅ Thread completed with timeout protection");
        
        // Strategy 3: Single Lock
        Console.WriteLine("\n  Strategy 3: Use Single Lock");
        var singleLock = new object();
        var t4 = new Thread(() => FixedDeadlock_SingleLock(singleLock));
        var t5 = new Thread(() => FixedDeadlock_SingleLock(singleLock));
        t4.Start();
        t5.Start();
        t4.Join();
        t5.Join();
        Console.WriteLine("  ✅ Both threads completed with single lock\n");
    }

    // ✅ FIX: Always lock in same order
    private static void FixedDeadlock_Thread1_LockOrdering()
    {
        lock (_lock1) // Always lock1 first
        {
            Thread.Sleep(10);
            lock (_lock2) // Then lock2
            {
                Console.WriteLine("    Thread 1: Both locks acquired");
            }
        }
    }

    // ✅ FIX: Same order as Thread1
    private static void FixedDeadlock_Thread2_LockOrdering()
    {
        lock (_lock1) // Always lock1 first
        {
            Thread.Sleep(10);
            lock (_lock2) // Then lock2
            {
                Console.WriteLine("    Thread 2: Both locks acquired");
            }
        }
    }

    // ✅ FIX: Use timeout
    private static void FixedDeadlock_WithTimeout()
    {
        bool lock1Acquired = false;
        bool lock2Acquired = false;
        
        try
        {
            lock1Acquired = Monitor.TryEnter(_lock1, TimeSpan.FromSeconds(1));
            if (lock1Acquired)
            {
                Thread.Sleep(10);
                lock2Acquired = Monitor.TryEnter(_lock2, TimeSpan.FromSeconds(1));
                
                if (lock2Acquired)
                {
                    Console.WriteLine("    Both locks acquired with timeout");
                }
                else
                {
                    Console.WriteLine("    Could not acquire lock2, aborting");
                }
            }
            else
            {
                Console.WriteLine("    Could not acquire lock1, aborting");
            }
        }
        finally
        {
            if (lock2Acquired) Monitor.Exit(_lock2);
            if (lock1Acquired) Monitor.Exit(_lock1);
        }
    }

    // ✅ FIX: Single lock for related data
    private static void FixedDeadlock_SingleLock(object sharedLock)
    {
        lock (sharedLock)
        {
            // All related operations under one lock
            Console.WriteLine($"    Thread {Thread.CurrentThread.ManagedThreadId}: Operation completed");
        }
    }

    private static void DemonstrateAsyncDeadlock()
    {
        Console.WriteLine("3. Async/Await Deadlock:");
        
        // This is safe because we're not blocking
        AsyncDeadlock_Demonstration().Wait();
    }

    private static async Task AsyncDeadlock_Demonstration()
    {
        Console.WriteLine("  Demonstrating async deadlock scenario...");
        
        // ❌ DEADLOCK SCENARIO: UI thread blocks on async code
        // var result = GetDataAsync().Result; // Would deadlock in UI app!
        
        // ✅ FIX: Use await
        var result = await GetDataAsync();
        Console.WriteLine($"  ✅ Data retrieved using await: {result}");
        
        // ✅ FIX: Use ConfigureAwait(false) in libraries
        var result2 = await GetDataWithConfigureAwaitAsync();
        Console.WriteLine($"  ✅ Data retrieved with ConfigureAwait(false): {result2}\n");
    }

    private static async Task<string> GetDataAsync()
    {
        await Task.Delay(10);
        return "Data";
    }

    private static async Task<string> GetDataWithConfigureAwaitAsync()
    {
        await Task.Delay(10).ConfigureAwait(false);
        return "Data";
    }

    private static void DemonstrateDeadlockDetection()
    {
        Console.WriteLine("4. Deadlock Detection Techniques:");
        Console.WriteLine("  - Use debugger's 'Parallel Stacks' window");
        Console.WriteLine("  - Monitor thread states (Blocked, WaitSleepJoin)");
        Console.WriteLine("  - Use performance counters");
        Console.WriteLine("  - Implement timeout mechanisms");
        Console.WriteLine("  - Use concurrent profilers (dotTrace, PerfView)");
        Console.WriteLine("  - Add logging around lock acquisition\n");
    }
}
