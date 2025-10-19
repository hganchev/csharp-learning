# Advanced C# Concepts - Project Structure

## Overview
This project has been refactored with all classes separated into individual files following C# best practices. Each class is in its own file, making the code more maintainable, readable, and following the Single Responsibility Principle.

## Project Structure

```
advanced-concepts/
├── AdvancedConcepts.csproj
├── Program.cs
├── README.md
│
├── TypeComparison/
│   ├── TypeComparisonDemo.cs          # Main demonstration class
│   ├── PersonClass.cs                 # Reference type example
│   ├── PointStruct.cs                 # Value type example
│   ├── EmployeeRecord.cs              # Record type example
│   ├── Manager.cs                     # Record with inheritance
│   └── CoordinateRecordStruct.cs      # Record struct example
│
├── Threading/
│   ├── ThreadingDemo.cs               # Main demonstration class
│   └── ThreadingBestPractices.cs      # Best practices and patterns
│
├── AsyncPatterns/
│   ├── AsyncAwaitDemo.cs              # Main demonstration class
│   ├── AsyncBestPractices.cs          # Best practices
│   └── AsyncAntiPatterns.cs           # Common anti-patterns to avoid
│
├── Deadlocks/
│   ├── DeadlockDemo.cs                # Main demonstration class
│   ├── RealWorldDeadlocks.cs          # Real-world scenarios
│   └── DeadlockBestPractices.cs       # Prevention strategies
│
├── MemoryManagement/
│   ├── MemoryManagementDemo.cs        # Main demonstration class
│   ├── Person.cs                      # Helper class
│   ├── PointStruct.cs                 # Helper struct
│   ├── DisposableResource.cs          # IDisposable pattern
│   ├── EventPublisher.cs              # Event example
│   ├── EventSubscriber.cs             # Event subscriber
│   ├── AdvancedMemoryPatterns.cs      # Object pooling, Span<T>, etc.
│   ├── MemoryLeakPrevention.cs        # Leak prevention strategies
│   └── GCConfiguration.cs             # GC tuning and configuration
│
└── DependencyInjection/
    ├── DependencyInjectionDemo.cs     # Main demonstration class
    ├── ServiceInterfaces.cs           # Service interfaces (Transient, Scoped, Singleton)
    ├── ServiceImplementations.cs      # Service implementations
    ├── ExampleServices.cs             # Email, Notification services
    ├── RepositoryPattern.cs           # Repository pattern example
    ├── HttpClientFactoryService.cs    # HTTP client factory
    ├── CacheService.cs                # Cache service example
    ├── RequestContext.cs              # Request context (scoped)
    ├── ValidatorService.cs            # Validator pattern
    ├── AdvancedDIPatterns.cs          # Decorator, Options, Factory patterns
    ├── DIAntiPatterns.cs              # Common anti-patterns
    └── ServiceCollectionExtensions.cs # Extension methods
```

## Benefits of This Structure

### 1. **Single Responsibility Principle**
- Each file contains one class/interface
- Easy to locate specific classes
- Clear separation of concerns

### 2. **Maintainability**
- Easier to modify individual classes
- Reduced merge conflicts in version control
- Simpler code reviews

### 3. **Readability**
- File name matches class name
- Easier navigation in IDE
- Clear project organization

### 4. **Discoverability**
- Logical grouping by feature area
- Consistent naming conventions
- Self-documenting structure

## Concepts Covered

### 1. Type Comparison (Class vs Struct vs Record)
- **Classes**: Reference types for complex objects
- **Structs**: Value types for small, immutable data
- **Records**: Immutable reference types with value semantics
- **When to use each type**

### 2. Threading & Concurrency
- Thread creation and management
- Thread safety and synchronization
- Lock mechanisms
- Thread-safe collections
- Task Parallel Library (TPL)

### 3. Async/Await Patterns
- Asynchronous programming fundamentals
- Task composition (WhenAll, WhenAny)
- Cancellation tokens
- ConfigureAwait usage
- Error handling
- Common pitfalls and anti-patterns

### 4. Deadlocks
- Classic deadlock scenarios
- Lock ordering problems
- Prevention strategies
- Detection techniques
- Real-world examples

### 5. Memory Management & GC
- Stack vs Heap allocation
- Garbage Collection generations
- IDisposable pattern implementation
- Memory leak prevention
- Object pooling
- Span<T> and ArrayPool<T>
- GC configuration

### 6. Dependency Injection
- **Transient**: New instance every time
- **Scoped**: One instance per scope/request
- **Singleton**: One instance for app lifetime
- Service registration patterns
- Advanced patterns (Decorator, Options, Factory)
- Anti-patterns to avoid

## Running the Project

```bash
# Build the project
dotnet build AdvancedConcepts.csproj

# Run the project
dotnet run --project AdvancedConcepts.csproj
```

## Interactive Demo Menu

The project includes an interactive menu system that lets you:
1. Explore each concept individually
2. See practical examples
3. Understand best practices
4. Learn anti-patterns to avoid

## Best Practices Demonstrated

### Code Organization
✅ One class per file
✅ Consistent naming (file name = class name)
✅ Logical folder structure
✅ Proper namespacing

### Threading & Concurrency
✅ Use Task over Thread
✅ Always protect shared state
✅ Use thread-safe collections
✅ Minimize lock scope

### Async/Await
✅ async Task instead of async void
✅ Always await, never .Result or .Wait()
✅ Use ConfigureAwait(false) in libraries
✅ Accept CancellationToken parameters

### Dependency Injection
✅ Constructor injection
✅ Register interfaces, not concrete types
✅ Use appropriate lifetimes
✅ Avoid service locator pattern
✅ Prevent captive dependencies

### Memory Management
✅ Implement IDisposable correctly
✅ Use 'using' statements
✅ Unsubscribe from events
✅ Use WeakReference for caches
✅ Minimize allocations in hot paths

## Learning Resources

Each folder contains:
- Demo classes showing how things work
- Best practices classes with recommended patterns
- Anti-pattern classes showing what to avoid
- Real-world examples
- Comprehensive comments and documentation

## Key Takeaways

1. **Type Selection**: Choose the right type (class/struct/record) for your use case
2. **Thread Safety**: Always protect shared mutable state
3. **Async All the Way**: Don't mix synchronous and asynchronous code
4. **Deadlock Prevention**: Consistent lock ordering and timeouts
5. **Memory Awareness**: Understand stack vs heap, use IDisposable
6. **DI Lifetimes**: Match service lifetime to its purpose

## Next Steps

- Experiment with each demo
- Try modifying examples
- Create your own scenarios
- Apply patterns to real projects
- Study the best practices
- Avoid the anti-patterns

---

**Author**: Advanced C# Learning Project
**Last Updated**: October 2025
**Framework**: .NET 9.0
