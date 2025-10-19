using System.Collections.Concurrent;

namespace AdvancedConcepts.Threading;

/// <summary>
/// Demonstrates threading, concurrency, and synchronization patterns
/// </summary>
public static class ThreadingDemo
{
    private static int _counter = 0;
    private static readonly object _lock = new object();
    
    public static void Run()
    {
        Console.WriteLine("=== THREADING & CONCURRENCY ===\n");
        
        DemonstrateBasicThreading();
        DemonstrateThreadSafety();
        DemonstrateSynchronization();
        DemonstrateThreadPool();
        DemonstrateTaskParallelLibrary();
        DemonstrateThreadSafeCollections();
    }

    private static void DemonstrateBasicThreading()
    {
        Console.WriteLine("1. Basic Threading:");
        
        var thread = new Thread(() =>
        {
            Console.WriteLine($"  Thread {Thread.CurrentThread.ManagedThreadId} starting...");
            Thread.Sleep(100);
            Console.WriteLine($"  Thread {Thread.CurrentThread.ManagedThreadId} completed");
        });
        
        thread.Start();
        thread.Join(); // Wait for completion
        
        Console.WriteLine("  Main thread continuing\n");
    }

    private static void DemonstrateThreadSafety()
    {
        Console.WriteLine("2. Thread Safety Issues:");
        
        // WITHOUT synchronization (race condition)
        _counter = 0;
        var threads1 = new Thread[5];
        for (int i = 0; i < 5; i++)
        {
            threads1[i] = new Thread(() =>
            {
                for (int j = 0; j < 1000; j++)
                {
                    _counter++; // NOT thread-safe
                }
            });
            threads1[i].Start();
        }
        
        foreach (var t in threads1) t.Join();
        Console.WriteLine($"  Without lock: Counter = {_counter} (expected 5000, likely less due to race condition)");
        
        // WITH synchronization
        _counter = 0;
        var threads2 = new Thread[5];
        for (int i = 0; i < 5; i++)
        {
            threads2[i] = new Thread(() =>
            {
                for (int j = 0; j < 1000; j++)
                {
                    lock (_lock)
                    {
                        _counter++; // Thread-safe
                    }
                }
            });
            threads2[i].Start();
        }
        
        foreach (var t in threads2) t.Join();
        Console.WriteLine($"  With lock: Counter = {_counter} (expected 5000)\n");
    }

    private static void DemonstrateSynchronization()
    {
        Console.WriteLine("3. Synchronization Primitives:");
        
        // Monitor (similar to lock, but more control)
        Console.WriteLine("  Monitor: Low-level lock with timeout support");
        var monitorLock = new object();
        if (Monitor.TryEnter(monitorLock, TimeSpan.FromSeconds(1)))
        {
            try
            {
                Console.WriteLine("  Monitor acquired");
            }
            finally
            {
                Monitor.Exit(monitorLock);
            }
        }
        
        // Mutex (cross-process synchronization)
        Console.WriteLine("  Mutex: Can synchronize across processes");
        using var mutex = new Mutex(false, "MyUniqueMutexName");
        if (mutex.WaitOne(TimeSpan.FromSeconds(1)))
        {
            try
            {
                Console.WriteLine("  Mutex acquired");
            }
            finally
            {
                mutex.ReleaseMutex();
            }
        }
        
        // Semaphore (limit concurrent access)
        Console.WriteLine("  Semaphore: Limits number of concurrent threads");
        using var semaphore = new SemaphoreSlim(2, 2); // Max 2 concurrent
        
        var tasks = new List<Task>();
        for (int i = 0; i < 5; i++)
        {
            int taskNum = i;
            tasks.Add(Task.Run(async () =>
            {
                await semaphore.WaitAsync();
                try
                {
                    Console.WriteLine($"    Task {taskNum} entered (max 2 concurrent)");
                    await Task.Delay(100);
                }
                finally
                {
                    semaphore.Release();
                }
            }));
        }
        
        Task.WaitAll(tasks.ToArray());
        Console.WriteLine();
    }

    private static void DemonstrateThreadPool()
    {
        Console.WriteLine("4. Thread Pool:");
        Console.WriteLine("  Thread Pool reuses threads, avoiding creation overhead");
        
        var countdown = new CountdownEvent(3);
        
        for (int i = 0; i < 3; i++)
        {
            int workItem = i;
            ThreadPool.QueueUserWorkItem(_ =>
            {
                Console.WriteLine($"  Work item {workItem} on thread {Thread.CurrentThread.ManagedThreadId}");
                Thread.Sleep(50);
                countdown.Signal();
            });
        }
        
        countdown.Wait();
        Console.WriteLine("  All work items completed\n");
    }

    private static void DemonstrateTaskParallelLibrary()
    {
        Console.WriteLine("5. Task Parallel Library (TPL):");
        
        // Parallel.For
        Console.WriteLine("  Parallel.For:");
        Parallel.For(0, 5, i =>
        {
            Console.WriteLine($"    Processing {i} on thread {Thread.CurrentThread.ManagedThreadId}");
        });
        
        // Parallel.ForEach
        Console.WriteLine("  Parallel.ForEach:");
        var items = new[] { "A", "B", "C", "D" };
        Parallel.ForEach(items, item =>
        {
            Console.WriteLine($"    Processing {item} on thread {Thread.CurrentThread.ManagedThreadId}");
        });
        
        // PLINQ (Parallel LINQ)
        Console.WriteLine("  PLINQ:");
        var numbers = Enumerable.Range(1, 100);
        var evenSum = numbers
            .AsParallel()
            .Where(n => n % 2 == 0)
            .Sum();
        Console.WriteLine($"    Sum of even numbers: {evenSum}\n");
    }

    private static void DemonstrateThreadSafeCollections()
    {
        Console.WriteLine("6. Thread-Safe Collections:");
        
        // ConcurrentBag
        var bag = new ConcurrentBag<int>();
        Parallel.For(0, 10, i => bag.Add(i));
        Console.WriteLine($"  ConcurrentBag count: {bag.Count}");
        
        // ConcurrentQueue
        var queue = new ConcurrentQueue<string>();
        queue.Enqueue("First");
        queue.Enqueue("Second");
        if (queue.TryDequeue(out var item))
        {
            Console.WriteLine($"  ConcurrentQueue dequeued: {item}");
        }
        
        // ConcurrentDictionary
        var dict = new ConcurrentDictionary<int, string>();
        dict.TryAdd(1, "One");
        dict.AddOrUpdate(1, "One", (key, oldValue) => "Updated One");
        Console.WriteLine($"  ConcurrentDictionary[1]: {dict[1]}");
        
        // BlockingCollection (producer-consumer pattern)
        using var blockingCollection = new BlockingCollection<int>(boundedCapacity: 5);
        
        var producer = Task.Run(() =>
        {
            for (int i = 0; i < 3; i++)
            {
                blockingCollection.Add(i);
                Console.WriteLine($"  Produced: {i}");
            }
            blockingCollection.CompleteAdding();
        });
        
        var consumer = Task.Run(() =>
        {
            foreach (var item in blockingCollection.GetConsumingEnumerable())
            {
                Console.WriteLine($"  Consumed: {item}");
                Thread.Sleep(50);
            }
        });
        
        Task.WaitAll(producer, consumer);
        Console.WriteLine();
    }
}
