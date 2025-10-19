# Advanced C# Concepts

This project demonstrates advanced C# concepts with best practices and real-world examples.

## Topics Covered

### 1. Class vs Struct vs Record
- **Classes**: Reference types, heap allocation, inheritance support
- **Structs**: Value types, stack allocation, lightweight objects
- **Records**: Immutable reference types, value-based equality

### 2. Threading & Concurrency
- Thread creation and management
- Thread synchronization (lock, Monitor, Mutex, Semaphore)
- Thread-safe collections
- Task Parallel Library (TPL)

### 3. Async/Await
- Asynchronous programming patterns
- Best practices for async/await
- ConfigureAwait usage
- Avoiding async void
- Task cancellation

### 4. Deadlocks
- Common deadlock scenarios
- Prevention strategies
- Detection and debugging
- Lock ordering

### 5. Memory Management & Garbage Collection
- Stack vs Heap memory
- GC generations (Gen 0, 1, 2)
- IDisposable pattern
- Using statements
- Finalization
- Memory leaks prevention

### 6. Dependency Injection & Lifetimes
- **Transient**: New instance each time
- **Scoped**: One instance per scope
- **Singleton**: One instance for application lifetime
- Service registration and resolution
- Best practices

## Running the Project

```bash
dotnet build
dotnet run
```

## Project Structure

```
advanced-concepts/
├── Program.cs                          # Main entry point with menu
├── TypeComparison/                     # Class vs Struct vs Record examples
├── Threading/                          # Threading and concurrency
├── AsyncPatterns/                      # Async/await patterns
├── Deadlocks/                          # Deadlock scenarios and solutions
├── MemoryManagement/                   # GC and memory patterns
└── DependencyInjection/               # DI patterns and lifetimes
```

## Best Practices Demonstrated

1. **Use structs** for small, immutable data with value semantics
2. **Use classes** for complex objects with identity and behavior
3. **Use records** for immutable DTOs and value objects
4. **Prefer async/await** over manual thread management
5. **Always use CancellationToken** for cancellable operations
6. **Implement IDisposable** for unmanaged resources
7. **Use using statements** for automatic disposal
8. **Register services** with appropriate lifetimes
9. **Avoid deadlocks** with proper lock ordering
10. **Monitor memory** and dispose resources properly
