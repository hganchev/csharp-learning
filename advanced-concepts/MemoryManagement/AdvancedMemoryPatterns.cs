namespace AdvancedConcepts.MemoryManagement;

/// <summary>
/// Advanced memory management patterns
/// </summary>
public static class AdvancedMemoryPatterns
{
    // Pattern 1: Object Pooling
    public class ObjectPool<T> where T : class, new()
    {
        private readonly Stack<T> _pool = new Stack<T>();
        private readonly int _maxSize;
        
        public ObjectPool(int maxSize = 100)
        {
            _maxSize = maxSize;
        }
        
        public T Rent()
        {
            lock (_pool)
            {
                return _pool.Count > 0 ? _pool.Pop() : new T();
            }
        }
        
        public void Return(T obj)
        {
            lock (_pool)
            {
                if (_pool.Count < _maxSize)
                {
                    _pool.Push(obj);
                }
            }
        }
    }
    
    // Pattern 2: Span<T> for stack allocation
    public static void UseSpanToAvoidAllocation()
    {
        Span<int> numbers = stackalloc int[100]; // Stack allocated!
        for (int i = 0; i < numbers.Length; i++)
        {
            numbers[i] = i;
        }
        // No GC pressure!
    }
    
    // Pattern 3: ArrayPool for temporary arrays
    public static void UseArrayPool()
    {
        var pool = System.Buffers.ArrayPool<byte>.Shared;
        
        byte[] buffer = pool.Rent(1024); // Rent from pool
        try
        {
            // Use buffer
        }
        finally
        {
            pool.Return(buffer); // Return to pool
        }
    }
    
    // Pattern 4: Struct with unmanaged resources
    public struct UnmanagedResourceStruct : IDisposable
    {
        private IntPtr _handle;
        
        public UnmanagedResourceStruct(IntPtr handle)
        {
            _handle = handle;
        }
        
        public void Dispose()
        {
            if (_handle != IntPtr.Zero)
            {
                // Free unmanaged resource
                _handle = IntPtr.Zero;
            }
        }
    }
}
