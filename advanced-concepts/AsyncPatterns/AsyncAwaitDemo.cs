namespace AdvancedConcepts.AsyncPatterns;

/// <summary>
/// Demonstrates async/await patterns and best practices
/// </summary>
public static class AsyncAwaitDemo
{
    public static async Task Run()
    {
        Console.WriteLine("=== ASYNC/AWAIT PATTERNS ===\n");
        
        await DemonstrateBasicAsync();
        await DemonstrateTaskComposition();
        await DemonstrateCancellation();
        await DemonstrateConfigureAwait();
        await DemonstrateErrorHandling();
        DemonstrateCommonPitfalls();
    }

    private static async Task DemonstrateBasicAsync()
    {
        Console.WriteLine("1. Basic Async/Await:");
        
        // Async methods return Task or Task<T>
        var result = await FetchDataAsync();
        Console.WriteLine($"  Fetched: {result}");
        
        // Multiple awaits in sequence
        var data1 = await FetchDataAsync();
        var data2 = await FetchDataAsync();
        Console.WriteLine($"  Sequential: {data1}, {data2}\n");
    }

    private static async Task DemonstrateTaskComposition()
    {
        Console.WriteLine("2. Task Composition:");
        
        // Running tasks in parallel
        var task1 = FetchDataAsync();
        var task2 = FetchDataAsync();
        var task3 = FetchDataAsync();
        
        await Task.WhenAll(task1, task2, task3);
        Console.WriteLine($"  Parallel completion: {task1.Result}, {task2.Result}, {task3.Result}");
        
        // WhenAny - return when first completes
        var fastestTask = await Task.WhenAny(
            Task.Delay(100),
            Task.Delay(200),
            Task.Delay(300)
        );
        Console.WriteLine("  WhenAny: First task completed");
        
        // Task.Run for CPU-bound work
        var cpuResult = await Task.Run(() => PerformCpuIntensiveWork());
        Console.WriteLine($"  CPU-bound result: {cpuResult}\n");
    }

    private static async Task DemonstrateCancellation()
    {
        Console.WriteLine("3. Cancellation Token:");
        
        using var cts = new CancellationTokenSource();
        
        // Cancel after 500ms
        cts.CancelAfter(500);
        
        try
        {
            await LongRunningOperationAsync(cts.Token);
        }
        catch (OperationCanceledException)
        {
            Console.WriteLine("  Operation was cancelled");
        }
        
        // Cooperative cancellation
        using var cts2 = new CancellationTokenSource();
        cts2.CancelAfter(50);
        
        try
        {
            await ProcessItemsAsync(new[] { 1, 2, 3, 4, 5 }, cts2.Token);
        }
        catch (OperationCanceledException)
        {
            Console.WriteLine("  Processing cancelled gracefully\n");
        }
    }

    private static async Task DemonstrateConfigureAwait()
    {
        Console.WriteLine("4. ConfigureAwait:");
        
        // ConfigureAwait(false) - don't capture context
        // Use in library code for better performance
        var data = await FetchDataAsync().ConfigureAwait(false);
        Console.WriteLine($"  Data fetched without context: {data}");
        
        // ConfigureAwait(true) or no parameter - capture context
        // Use in UI code where you need to update UI elements
        await Task.Delay(10); // Default is ConfigureAwait(true)
        Console.WriteLine("  Context captured (default behavior)\n");
    }

    private static async Task DemonstrateErrorHandling()
    {
        Console.WriteLine("5. Error Handling:");
        
        // Try-catch with async
        try
        {
            await FailingOperationAsync();
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine($"  Caught exception: {ex.Message}");
        }
        
        // Handling multiple task exceptions
        try
        {
            await Task.WhenAll(
                FailingOperationAsync(),
                FailingOperationAsync()
            );
        }
        catch (Exception ex)
        {
            Console.WriteLine($"  WhenAll exception: {ex.Message}");
            // Note: Only first exception is thrown, check AggregateException for all
        }
        
        // Proper way to get all exceptions
        var tasks = new[]
        {
            SafeFailingOperationAsync(),
            SafeFailingOperationAsync()
        };
        
        var results = await Task.WhenAll(tasks);
        Console.WriteLine($"  All tasks completed (some may have failed gracefully)\n");
    }

    private static void DemonstrateCommonPitfalls()
    {
        Console.WriteLine("6. Common Pitfalls to Avoid:");
        Console.WriteLine("  ❌ async void (except event handlers)");
        Console.WriteLine("  ❌ .Result or .Wait() (causes deadlocks)");
        Console.WriteLine("  ❌ Not using ConfigureAwait(false) in libraries");
        Console.WriteLine("  ❌ Ignoring CancellationToken");
        Console.WriteLine("  ❌ Not handling exceptions");
        Console.WriteLine("  ✅ async Task instead of async void");
        Console.WriteLine("  ✅ await instead of .Result");
        Console.WriteLine("  ✅ Always accept CancellationToken");
        Console.WriteLine("  ✅ Use try-catch for error handling\n");
    }

    // Helper methods
    private static async Task<string> FetchDataAsync()
    {
        await Task.Delay(10);
        return "Data";
    }

    private static int PerformCpuIntensiveWork()
    {
        int sum = 0;
        for (int i = 0; i < 1000; i++)
            sum += i;
        return sum;
    }

    private static async Task LongRunningOperationAsync(CancellationToken cancellationToken)
    {
        for (int i = 0; i < 10; i++)
        {
            cancellationToken.ThrowIfCancellationRequested();
            await Task.Delay(100, cancellationToken);
        }
    }

    private static async Task ProcessItemsAsync(int[] items, CancellationToken cancellationToken)
    {
        foreach (var item in items)
        {
            if (cancellationToken.IsCancellationRequested)
            {
                Console.WriteLine($"  Cancellation requested at item {item}");
                cancellationToken.ThrowIfCancellationRequested();
            }
            
            await Task.Delay(20, cancellationToken);
            Console.WriteLine($"  Processed item: {item}");
        }
    }

    private static Task FailingOperationAsync()
    {
        throw new InvalidOperationException("Simulated failure");
    }

    private static async Task<bool> SafeFailingOperationAsync()
    {
        try
        {
            await FailingOperationAsync();
            return true;
        }
        catch
        {
            return false;
        }
    }
}
