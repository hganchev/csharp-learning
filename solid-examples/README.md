# C# SOLID Principles Examples

A comprehensive demonstration of SOLID design principles with clear problem/solution examples and dependency injection patterns.

## Overview

The SOLID design principles help us create maintainable, reusable, and flexible software designs. This repository provides practical examples of each principle, showing both violations (problems) and correct implementations (solutions).

**Reference:** [SOLID Principles - Wikipedia](https://en.wikipedia.org/wiki/SOLID)

## Project Structure

```
SOLID/
├── Program.cs                    # Main entry point demonstrating all principles
├── SRP/SRP.cs                   # Single Responsibility Principle
├── OCP/OCP.cs                   # Open/Closed Principle  
├── LSP/LSP.cs                   # Liskov Substitution Principle
├── ISP/ISP.cs                   # Interface Segregation Principle
├── DIP/DIP.cs                   # Dependency Inversion Principle
└── Dependency Injection/        # Dependency Injection examples
    ├── IDatabase.cs
    ├── Logger.cs
    └── SqlDatabase.cs
```

## SOLID Principles Explained

### S: Single Responsibility Principle (SRP)

**Definition:** A class should have only ONE reason to change, meaning it should have only ONE job or responsibility.

**Problem Example:** A `User` class that handles user data, database operations, AND email sending.
```csharp
// VIOLATION: Multiple responsibilities in one class
class UserProblem
{
    public void UpdateName(string newName) { } // User data management
    public void Save() { }                     // Database operations  
    public void SendEmail(string message) { } // Email operations
}
```

**Solution Example:** Separate classes for separate responsibilities.
```csharp
class User { }                    // Only user data
class UserRepository { }          // Only database operations
class EmailService { }            // Only email operations
```

### O: Open/Closed Principle (OCP)

**Definition:** Software entities should be OPEN for extension but CLOSED for modification.

**Problem Example:** Adding new shapes requires modifying the calculator class.
```csharp
// VIOLATION: Must modify this class for every new shape
class AreaCalculatorProblem
{
    public double CalculateArea(object shape)
    {
        if (shape is Circle) { /* calculate */ }
        if (shape is Rectangle) { /* calculate */ }
        // Must add new if-statement for Triangle!
    }
}
```

**Solution Example:** Use abstraction to allow extension without modification.
```csharp
interface IShape { double CalculateArea(); }
class AreaCalculatorSolution
{
    public double CalculateArea(IShape shape) => shape.CalculateArea();
}
// New shapes can be added without modifying existing code!
```

### L: Liskov Substitution Principle (LSP)

**Definition:** Objects of a superclass should be replaceable with objects of its subclasses without breaking the application.

**Problem Example:** Not all birds can fly, but the base class forces flying behavior.
```csharp
// VIOLATION: Penguin can't fly but must implement Fly()
abstract class BirdProblem
{
    public abstract void Fly(); // Forces ALL birds to fly
}
class PenguinProblem : BirdProblem
{
    public override void Fly() => throw new NotSupportedException(); // VIOLATION!
}
```

**Solution Example:** Use appropriate abstractions that don't force inappropriate behavior.
```csharp
interface IFlyingBird { void Fly(); }
interface ISwimmingBird { void Swim(); }
class Penguin : ISwimmingBird { } // Only implements what it can do
class Eagle : IFlyingBird { }     // Only implements what it can do
```

### I: Interface Segregation Principle (ISP)

**Definition:** Many client-specific interfaces are better than one general-purpose interface. Clients should not be forced to depend on interfaces they do not use.

**Problem Example:** A large interface that forces implementers to implement methods they don't need.
```csharp
// VIOLATION: Forces all workers to implement methods they might not need
interface IWorkerProblem
{
    void Work();
    void Eat();   // Robots don't eat!
    void Sleep(); // Robots don't sleep!
}
```

**Solution Example:** Split large interfaces into smaller, focused ones.
```csharp
interface IWorkable { void Work(); }
interface IEatable { void Eat(); }
interface ISleepable { void Sleep(); }

class Human : IWorkable, IEatable, ISleepable { } // Implements all
class Robot : IWorkable { }                       // Only implements what it needs
```

### D: Dependency Inversion Principle (DIP)

**Definition:** 
1. High-level modules should not depend on low-level modules. Both should depend on abstractions.
2. Abstractions should not depend on details. Details should depend on abstractions.

**Problem Example:** High-level class directly depends on concrete low-level classes.
```csharp
// VIOLATION: Tightly coupled to concrete implementations
class OrderServiceProblem
{
    private EmailService _emailService = new EmailService();     // Tight coupling
    private DatabaseService _dbService = new DatabaseService();  // Tight coupling
}
```

**Solution Example:** Use dependency injection with interfaces.
```csharp
class OrderService
{
    private readonly INotificationService _notifier;
    private readonly IOrderRepository _repository;
    
    // Dependencies injected through constructor
    public OrderService(IOrderRepository repository, INotificationService notifier)
    {
        _repository = repository;
        _notifier = notifier;
    }
}
```

## Dependency Injection Examples

The project also includes comprehensive dependency injection examples showing:

- **Problem:** Tight coupling between classes
- **Solution:** Loose coupling using interfaces and dependency injection
- **Benefits:** Easier testing, flexibility, and maintainability

## How to Run

1. Clone the repository
2. Open in Visual Studio or VS Code
3. Build the solution: `dotnet build`
4. Run the project: `dotnet run`

The console output will demonstrate each principle with clear problem/solution comparisons.

## Key Benefits of SOLID Principles

- **Maintainability:** Code is easier to understand and modify
- **Testability:** Classes with single responsibilities are easier to test
- **Flexibility:** Open/closed principle allows extension without modification
- **Reusability:** Well-designed interfaces promote code reuse
- **Loose Coupling:** Dependency inversion reduces dependencies between modules

## Learning Outcomes

After studying these examples, you'll understand:

- How to identify SOLID principle violations in code
- How to refactor code to follow SOLID principles
- The relationship between SOLID principles and dependency injection
- Best practices for writing maintainable, extensible C# code

## Additional Resources

- [SOLID Principles - Wikipedia](https://en.wikipedia.org/wiki/SOLID)
- [Clean Code by Robert C. Martin](https://www.amazon.com/Clean-Code-Handbook-Software-Craftsmanship/dp/0132350884)
- [Dependency Injection in .NET](https://docs.microsoft.com/en-us/dotnet/core/extensions/dependency-injection)
