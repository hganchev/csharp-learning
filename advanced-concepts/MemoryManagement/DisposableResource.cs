namespace AdvancedConcepts.MemoryManagement;

/// <summary>
/// Proper IDisposable implementation
/// </summary>
public class DisposableResource : IDisposable
{
    private bool _disposed = false;
    private readonly string _name;
    
    public DisposableResource(string name)
    {
        _name = name;
        Console.WriteLine($"    {_name} created");
    }
    
    public void DoWork()
    {
        if (_disposed)
            throw new ObjectDisposedException(_name);
        
        Console.WriteLine($"    {_name} doing work");
    }
    
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this); // Prevent finalizer from running
    }
    
    protected virtual void Dispose(bool disposing)
    {
        if (!_disposed)
        {
            if (disposing)
            {
                // Dispose managed resources
                Console.WriteLine($"    {_name} disposing managed resources");
            }
            
            // Dispose unmanaged resources (if any)
            
            _disposed = true;
        }
    }
    
    // Finalizer (avoid if possible, use SafeHandle instead)
    ~DisposableResource()
    {
        Dispose(false);
    }
}
