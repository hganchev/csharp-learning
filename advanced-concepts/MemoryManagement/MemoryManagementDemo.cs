using System.Runtime;

namespace AdvancedConcepts.MemoryManagement;

/// <summary>
/// Demonstrates memory management, garbage collection, and best practices
/// </summary>
public static class MemoryManagementDemo
{
    public static void Run()
    {
        Console.WriteLine("=== MEMORY MANAGEMENT & GARBAGE COLLECTION ===\n");
        
        DemonstrateStackVsHeap();
        DemonstrateGarbageCollection();
        DemonstrateDisposablePattern();
        DemonstrateMemoryLeaks();
        DemonstrateGCBestPractices();
    }

    private static void DemonstrateStackVsHeap()
    {
        Console.WriteLine("1. Stack vs Heap Memory:");
        
        // Stack: Value types, method parameters, local variables
        int stackValue = 42; // Stored on stack
        var point = new PointStruct(10, 20); // Stored on stack (struct)
        Console.WriteLine($"  Stack value: {stackValue}");
        Console.WriteLine($"  Struct on stack: {point}");
        
        // Heap: Reference types, objects
        var person = new Person("John"); // Reference on stack, object on heap
        var array = new int[100]; // Array on heap
        Console.WriteLine($"  Object on heap: {person.Name}");
        Console.WriteLine($"  Array on heap, length: {array.Length}");
        
        Console.WriteLine("\n  Stack: Fast, automatic cleanup, limited size");
        Console.WriteLine("  Heap: Slower, GC cleanup, larger size\n");
    }

    private static void DemonstrateGarbageCollection()
    {
        Console.WriteLine("2. Garbage Collection:");
        
        // GC Generations
        Console.WriteLine("  GC has 3 generations:");
        Console.WriteLine("  - Gen 0: Short-lived objects (< 1MB)");
        Console.WriteLine("  - Gen 1: Buffer between Gen 0 and Gen 2");
        Console.WriteLine("  - Gen 2: Long-lived objects");
        
        // Create objects to demonstrate GC
        Console.WriteLine("\n  Creating objects...");
        for (int i = 0; i < 1000; i++)
        {
            var temp = new Person($"Person{i}");
        }
        
        // Check GC statistics
        Console.WriteLine($"  Gen 0 collections: {GC.CollectionCount(0)}");
        Console.WriteLine($"  Gen 1 collections: {GC.CollectionCount(1)}");
        Console.WriteLine($"  Gen 2 collections: {GC.CollectionCount(2)}");
        Console.WriteLine($"  Total memory: {GC.GetTotalMemory(false):N0} bytes");
        
        // Force collection (rarely needed in production!)
        Console.WriteLine("\n  Forcing GC.Collect() (avoid in production)...");
        GC.Collect();
        GC.WaitForPendingFinalizers();
        GC.Collect();
        
        Console.WriteLine($"  Memory after GC: {GC.GetTotalMemory(false):N0} bytes\n");
    }

    private static void DemonstrateDisposablePattern()
    {
        Console.WriteLine("3. IDisposable Pattern:");
        
        // ✅ Using statement - automatic disposal
        Console.WriteLine("  Using statement (recommended):");
        using (var resource = new DisposableResource("Resource1"))
        {
            resource.DoWork();
        } // Dispose called automatically
        Console.WriteLine("  Resource disposed\n");
        
        // ✅ Using declaration (C# 8+)
        Console.WriteLine("  Using declaration:");
        using var resource2 = new DisposableResource("Resource2");
        resource2.DoWork();
        Console.WriteLine("  Will be disposed at end of scope\n");
        
        // ✅ Manual disposal with try-finally
        Console.WriteLine("  Manual disposal:");
        DisposableResource? resource3 = null;
        try
        {
            resource3 = new DisposableResource("Resource3");
            resource3.DoWork();
        }
        finally
        {
            resource3?.Dispose();
        }
        Console.WriteLine("  Resource disposed\n");
    }

    private static void DemonstrateMemoryLeaks()
    {
        Console.WriteLine("4. Common Memory Leak Scenarios:");
        
        // Scenario 1: Event handlers not unsubscribed
        Console.WriteLine("  ❌ Leak: Event handlers not removed");
        var publisher = new EventPublisher();
        var subscriber = new EventSubscriber();
        publisher.SomethingHappened += subscriber.HandleEvent;
        // subscriber goes out of scope but event keeps it alive!
        
        // ✅ Fix: Unsubscribe
        publisher.SomethingHappened -= subscriber.HandleEvent;
        Console.WriteLine("  ✅ Fixed: Event handler unsubscribed");
        
        // Scenario 2: Static references
        Console.WriteLine("\n  ❌ Leak: Static collections holding references");
        // StaticCache.Items.Add(new Person("Leaked")); // Lives forever!
        Console.WriteLine("  ✅ Fix: Use WeakReference or clear when done");
        
        // Scenario 3: Timers not disposed
        Console.WriteLine("\n  ❌ Leak: Timer not disposed");
        Console.WriteLine("  ✅ Fix: Dispose timer when done");
        using var timer = new System.Threading.Timer(_ => { }, null, 100, 100);
        
        // Scenario 4: Unmanaged resources
        Console.WriteLine("\n  ❌ Leak: Unmanaged resources not freed");
        Console.WriteLine("  ✅ Fix: Implement IDisposable and use SafeHandle\n");
    }

    private static void DemonstrateGCBestPractices()
    {
        Console.WriteLine("5. GC Best Practices:");
        
        Console.WriteLine("  ✅ Minimize allocations in hot paths");
        Console.WriteLine("  ✅ Reuse objects (object pooling)");
        Console.WriteLine("  ✅ Use structs for small, short-lived data");
        Console.WriteLine("  ✅ Dispose IDisposable objects");
        Console.WriteLine("  ✅ Avoid finalizers (use SafeHandle instead)");
        Console.WriteLine("  ✅ Use Span<T> and Memory<T> to avoid allocations");
        Console.WriteLine("  ✅ Avoid large object heap (LOH) allocations (> 85KB)");
        Console.WriteLine("  ❌ Don't call GC.Collect() manually (GC knows best)");
        Console.WriteLine("  ❌ Don't keep unnecessary references");
        Console.WriteLine("  ❌ Don't forget to unsubscribe from events\n");
    }
}
