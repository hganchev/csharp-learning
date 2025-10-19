namespace AdvancedConcepts.AsyncPatterns;

/// <summary>
/// Best practices for async/await
/// </summary>
public static class AsyncBestPractices
{
    // ✅ GOOD: Return Task, not void
    public static async Task DoWorkAsync()
    {
        await Task.Delay(100);
    }
    
    // ❌ BAD: async void (only for event handlers)
    public static async void AsyncVoidMethod() // Avoid!
    {
        await Task.Delay(100);
        // Exceptions here can't be caught!
    }
    
    // ✅ GOOD: Accept CancellationToken
    public static async Task ProcessAsync(CancellationToken cancellationToken = default)
    {
        await Task.Delay(100, cancellationToken);
        cancellationToken.ThrowIfCancellationRequested();
    }
    
    // ✅ GOOD: Use ConfigureAwait(false) in libraries
    public static async Task<string> LibraryMethodAsync()
    {
        var data = await FetchDataFromApiAsync().ConfigureAwait(false);
        return await ProcessDataAsync(data).ConfigureAwait(false);
    }
    
    // ✅ GOOD: Parallel execution when possible
    public static async Task<(string, string)> ParallelFetchAsync()
    {
        var task1 = FetchDataFromApiAsync();
        var task2 = FetchDataFromApiAsync();
        
        await Task.WhenAll(task1, task2);
        
        return (task1.Result, task2.Result);
    }
    
    // ✅ GOOD: Don't mix async and sync code
    public static async Task<string> GoodAsyncPattern()
    {
        // All async all the way
        var data = await FetchDataFromApiAsync();
        var processed = await ProcessDataAsync(data);
        return processed;
    }
    
    // ❌ BAD: Don't block on async code
    public static string BadSyncPattern()
    {
        // DON'T DO THIS - can cause deadlocks!
        // var data = FetchDataFromApiAsync().Result;
        // var processed = ProcessDataAsync(data).Wait();
        
        // Instead, make the method async
        return "Use async all the way";
    }
    
    // ✅ GOOD: ValueTask for hot path optimization
    public static ValueTask<int> GetCachedValueAsync(int key)
    {
        // If value is cached, return synchronously
        if (TryGetFromCache(key, out int value))
        {
            return new ValueTask<int>(value);
        }
        
        // Otherwise, fetch asynchronously
        return new ValueTask<int>(FetchFromDatabaseAsync(key));
    }
    
    // ✅ GOOD: IAsyncEnumerable for streaming
    public static async IAsyncEnumerable<int> GetNumbersAsync()
    {
        for (int i = 0; i < 10; i++)
        {
            await Task.Delay(10);
            yield return i;
        }
    }
    
    // Helper methods
    private static Task<string> FetchDataFromApiAsync() => Task.FromResult("API Data");
    private static Task<string> ProcessDataAsync(string data) => Task.FromResult($"Processed: {data}");
    private static bool TryGetFromCache(int key, out int value)
    {
        value = key * 10;
        return key < 5;
    }
    private static Task<int> FetchFromDatabaseAsync(int key) => Task.FromResult(key * 10);
}
