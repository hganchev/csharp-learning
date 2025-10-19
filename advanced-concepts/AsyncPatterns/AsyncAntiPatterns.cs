namespace AdvancedConcepts.AsyncPatterns;

/// <summary>
/// Common async anti-patterns and how to fix them
/// </summary>
public static class AsyncAntiPatterns
{
    // ❌ ANTI-PATTERN 1: async void
    public static async void AntiPattern_AsyncVoid()
    {
        await Task.Delay(100);
        throw new Exception("This exception cannot be caught!");
    }
    
    // ✅ FIX: Use async Task
    public static async Task Fixed_AsyncTask()
    {
        await Task.Delay(100);
        // Exceptions can be caught properly
    }
    
    // ❌ ANTI-PATTERN 2: Blocking on async
    public static void AntiPattern_Blocking()
    {
        // var result = GetDataAsync().Result; // Deadlock risk!
        // GetDataAsync().Wait(); // Deadlock risk!
    }
    
    // ✅ FIX: Use await
    public static async Task<string> Fixed_Await()
    {
        return await GetDataAsync();
    }
    
    // ❌ ANTI-PATTERN 3: Not using CancellationToken
    public static async Task AntiPattern_NoCancellation()
    {
        await Task.Delay(10000); // Can't be cancelled
    }
    
    // ✅ FIX: Accept and use CancellationToken
    public static async Task Fixed_WithCancellation(CancellationToken cancellationToken)
    {
        await Task.Delay(10000, cancellationToken);
    }
    
    // ❌ ANTI-PATTERN 4: Fire and forget
    public static void AntiPattern_FireAndForget()
    {
        #pragma warning disable CS4014
        DoWorkAsync(); // Not awaited - exceptions lost!
        #pragma warning restore CS4014
    }
    
    // ✅ FIX: Always await or handle explicitly
    public static async Task Fixed_AwaitOrHandle()
    {
        await DoWorkAsync();
        
        // Or if truly fire-and-forget, handle exceptions
        _ = Task.Run(async () =>
        {
            try
            {
                await DoWorkAsync();
            }
            catch (Exception ex)
            {
                // Log exception
                Console.WriteLine($"Background task failed: {ex.Message}");
            }
        });
    }
    
    private static Task<string> GetDataAsync() => Task.FromResult("Data");
    private static Task DoWorkAsync() => Task.CompletedTask;
}
