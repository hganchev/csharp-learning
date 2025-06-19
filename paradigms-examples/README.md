# Programming Paradigms Examples in C#

A comprehensive demonstration of major programming paradigms implemented in C#. This project showcases real-world examples of different programming approaches, highlighting their unique characteristics, benefits, and use cases.

## 🚀 Quick Start

```bash
# Clone the repository
git clone <repository-url>
cd paradigms-examples

# Build and run the project
dotnet build app/app.csproj
dotnet run --project app/app.csproj
```

## 📋 Table of Contents

- [Object-Oriented Programming (OOP)](#object-oriented-programming-oop)
- [Functional Programming](#functional-programming)
- [Procedural/Imperative Programming](#proceduralimperative-programming)
- [Event-Driven Programming](#event-driven-programming)
- [Structured Programming](#structured-programming)
- [Project Structure](#project-structure)
- [Key Learning Outcomes](#key-learning-outcomes)

---

## 🎯 Object-Oriented Programming (OOP)

Object-Oriented Programming organizes code around objects and classes, emphasizing encapsulation, inheritance, polymorphism, and abstraction.

### 🔍 Implementation Highlights

**Location**: `app/OOP/OOPClasses.cs`

Our OOP examples feature a comprehensive vehicle management system that demonstrates:

#### Core OOP Principles

- **Encapsulation**: Private fields with property-based access control and validation
- **Inheritance**: `Car` and `Motorcycle` classes inheriting from abstract `Vehicle` base class
- **Polymorphism**: Different implementations of `Start()` and `Accelerate()` methods
- **Abstraction**: Abstract `Vehicle` class and interface contracts (`IMaintainable`, `IRentable`)

#### Key Classes and Features

```csharp
// Abstract base class with encapsulation
public abstract class Vehicle
{
    private string _brand;           // Encapsulated field
    public string Brand { get; set; } // Property with validation
    public abstract void Accelerate(); // Abstract method
    public virtual void Start() { }    // Virtual method for polymorphism
}

// Inheritance example
public class Car : Vehicle
{
    public override void Start() { /* Car-specific implementation */ }
    public override void Accelerate() { /* Car-specific behavior */ }
}

// Multiple interface implementation
public class RentalCar : Car, IMaintainable, IRentable
{
    // Implements multiple contracts
}
```

#### Real-World Examples

- **Vehicle Management**: Cars, motorcycles with different behaviors
- **Rental System**: Business logic with maintenance scheduling
- **Interface Segregation**: Separate concerns for maintainable and rentable vehicles
- **Enum Usage**: Type-safe constants for vehicle status

### ✨ Key Benefits Demonstrated

- **Code Reusability**: Base class provides common functionality
- **Maintainability**: Changes to base class affect all derived classes
- **Extensibility**: Easy to add new vehicle types
- **Data Protection**: Private fields prevent unauthorized access
- **Contract Enforcement**: Interfaces ensure consistent implementation

---

## 🧮 Functional Programming

Functional programming emphasizes pure functions, immutability, and function composition, treating computation as mathematical function evaluation.

### 🔍 Implementation Highlights

**Location**: `app/Functional/Functions.cs`

Our functional programming examples showcase advanced concepts through practical implementations:

#### Core Functional Concepts

- **Pure Functions**: No side effects, same input always produces same output
- **Higher-Order Functions**: Functions that take other functions as parameters
- **Function Composition**: Building complex operations from simple functions
- **Immutability**: Data structures that don't change after creation
- **Monadic Patterns**: Safe null handling with Option/Maybe types

#### Key Features Demonstrated

```csharp
// Pure functions
public static int Square(int x) => x * x;
public static bool IsEven(int x) => x % 2 == 0;

// Higher-order function
public static IEnumerable<TResult> Map<T, TResult>(
    IEnumerable<T> source, 
    Func<T, TResult> selector)

// Function composition
public static Func<T, TResult> Compose<T, TIntermediate, TResult>(
    Func<T, TIntermediate> first, 
    Func<TIntermediate, TResult> second)

// Currying
public static Func<int, int> AddCurried(int x) => y => x + y;

// Option monad for safe null handling
public struct Option<T>
{
    public TResult Match<TResult>(Func<T, TResult> onSome, Func<TResult> onNone)
}
```

#### Advanced Examples

- **Memoization**: Caching function results for performance optimization
- **Recursive Functions**: Fibonacci and factorial implementations
- **Mathematical Functions**: Polynomial creation, numerical integration
- **Data Processing**: LINQ-style operations with functional pipelines
- **Option Monad**: Null-safe operations with railway-oriented programming

### ✨ Key Benefits Demonstrated

- **Predictability**: Pure functions are easy to test and reason about
- **Concurrency Safety**: Immutable data prevents race conditions
- **Modularity**: Small, composable functions
- **Mathematical Rigor**: Functions behave like mathematical functions
- **Error Handling**: Monadic patterns for safe error propagation

---

## 🔄 Procedural/Imperative Programming

Procedural programming organizes code into procedures that execute step-by-step, emphasizing the sequence of actions to be performed.

### 🔍 Implementation Highlights

**Location**: `app/Imperative/Procedural.cs`

Our procedural examples demonstrate enterprise-level task management and data processing:

#### Core Procedural Concepts

- **Sequential Execution**: Step-by-step program flow
- **Procedures/Subroutines**: Modular code organization
- **Mutable State**: Variables that change during execution
- **Control Structures**: Loops, conditionals, and branching
- **Top-Down Design**: Breaking complex problems into smaller procedures

#### Key Features Demonstrated

```csharp
public class ProceduralExamples
{
    private static List<string> _taskList = new();  // Mutable state
    
    public ProceduralExamples()
    {
        // Sequential execution
        InitializeSystem();
        DisplayWelcomeMessage();
        DemonstrateBasicOperations();
        DemonstrateControlStructures();
        // ... more steps
    }
    
    // Procedure with state modification
    private static void AddTask(string taskDescription)
    {
        string task = $"[{_taskIdCounter}] {taskDescription} - Pending";
        _taskList.Add(task);  // Modifying global state
        _taskIdCounter++;
    }
}
```

#### Real-World Examples

- **Task Management System**: Creating, updating, and tracking tasks
- **Employee Data Processing**: Step-by-step data analysis and reporting
- **System Operations**: Initialization, processing, and cleanup procedures
- **Control Flow**: Nested loops, conditional branching, and sequential operations

### ✨ Key Benefits Demonstrated

- **Clarity**: Clear step-by-step execution flow
- **Debugging**: Easy to trace program execution
- **Performance**: Direct manipulation of data structures
- **Simplicity**: Straightforward problem-solving approach
- **Legacy Compatibility**: Works well with existing procedural codebases

---

## 📡 Event-Driven Programming

Event-driven programming structures applications around event production, detection, and consumption, enabling loose coupling between components.

### 🔍 Implementation Highlights

**Location**: `app/Event_Driven/EventDriven.cs`

Our event-driven examples simulate a complete e-commerce system with multiple interacting services:

#### Core Event-Driven Concepts

- **Publisher-Subscriber Pattern**: Loose coupling between event sources and handlers
- **Event Aggregation**: Centralized event management
- **Asynchronous Processing**: Non-blocking event handling
- **Event Sourcing**: State changes represented as events
- **Service Communication**: Inter-service communication through events

#### Key Features Demonstrated

```csharp
// Publisher class
public class ECommerceSystem
{
    public event EventHandler<OrderEventArgs>? OrderPlaced;
    public event EventHandler<InventoryEventArgs>? InventoryChanged;
    
    public void PlaceOrder(string orderId, string customerName, decimal amount)
    {
        // Business logic...
        OrderPlaced?.Invoke(this, new OrderEventArgs(orderId, customerName, amount));
    }
}

// Subscriber classes
public class EmailNotificationService
{
    public void Subscribe(ECommerceSystem system)
    {
        system.OrderPlaced += OnOrderPlaced;
        system.OrderShipped += OnOrderShipped;
    }
    
    private void OnOrderPlaced(object? sender, OrderEventArgs e)
    {
        // Send email notification
    }
}
```

#### Enterprise-Level Examples

- **E-Commerce System**: Order processing, inventory management, notifications
- **Service Architecture**: Email service, analytics service, inventory management
- **Event Aggregator**: Centralized event routing and management
- **Custom EventArgs**: Strongly-typed event data with timestamps
- **Multiple Event Types**: Order events, inventory events, user activity events

### ✨ Key Benefits Demonstrated

- **Loose Coupling**: Services don't directly depend on each other
- **Scalability**: Easy to add new event handlers without modifying existing code
- **Responsiveness**: Asynchronous event processing
- **Maintainability**: Clear separation of concerns
- **Extensibility**: New services can easily subscribe to existing events

---

## 🏗️ Structured Programming

Structured programming emphasizes clear control flow using standard structures (sequence, selection, iteration) while avoiding unstructured jumps.

### 🔍 Implementation Highlights

**Location**: `app/Structured/Structured.cs`

Our structured programming examples demonstrate enterprise application workflow with proper modularity:

#### Core Structured Concepts

- **Control Structures**: Loops, conditionals, and subroutines
- **Modularity**: Breaking programs into manageable modules
- **Top-Down Design**: Hierarchical program organization
- **No GOTO**: Structured control flow without arbitrary jumps
- **Sequential Execution**: Predictable program flow

#### Key Features Demonstrated

```csharp
public class StructuredExamples
{
    // Main program structure
    private void RunMainProgram()
    {
        InitializeProgram();        // Module 1
        
        bool continueProgram = true;
        int operationCount = 0;
        
        // Structured control loop
        while (continueProgram && operationCount < 5)
        {
            if (operationCount < 2)
                PerformBasicOperations();    // Module 2
            else if (operationCount < 4)
                PerformDataProcessing();     // Module 3
            else
            {
                PerformCleanupOperations();  // Module 4
                continueProgram = false;
            }
            operationCount++;
        }
        
        FinalizeProgram();          // Module 5
    }
}
```

#### Complex Examples

- **Student Data Analysis**: Structured data processing with loops and conditionals
- **Mathematical Calculations**: Statistical analysis, series calculations
- **System Workflow**: Initialization, processing, cleanup phases
- **Nested Control Structures**: Complex decision trees and loop combinations
- **Modular Design**: Clear separation of functionality into subroutines

### ✨ Key Benefits Demonstrated

- **Readability**: Clear, predictable program flow
- **Maintainability**: Modular structure makes updates easier
- **Debugging**: Easy to trace execution through structured flow
- **Reliability**: Reduced complexity compared to unstructured approaches
- **Team Development**: Clear module boundaries for collaborative development

---

## 📁 Project Structure

```
paradigms-examples/
├── app/
│   ├── Program.cs                 # Main application entry point
│   ├── app.csproj                # Project configuration
│   ├── OOP/
│   │   └── OOPClasses.cs         # Vehicle management system
│   ├── Functional/
│   │   └── Functions.cs          # Functional programming examples
│   ├── Imperative/
│   │   └── Procedural.cs         # Task management and data processing
│   ├── Event_Driven/
│   │   └── EventDriven.cs        # E-commerce event system
│   └── Structured/
│       └── Structured.cs         # Enterprise workflow examples
├── README.md                      # This documentation
└── paradigms-examples.sln        # Solution file
```

## 🎓 Key Learning Outcomes

After exploring this project, you will understand:

### Paradigm Selection Criteria
- **When to use OOP**: Complex systems with multiple interacting entities
- **When to use Functional**: Data transformation, mathematical computations, concurrent systems
- **When to use Procedural**: Simple workflows, system scripts, performance-critical code
- **When to use Event-Driven**: User interfaces, distributed systems, real-time applications
- **When to use Structured**: Legacy system maintenance, algorithm implementation

### Advanced Programming Concepts
- **Abstraction Levels**: From low-level procedural to high-level object-oriented design
- **State Management**: Immutable vs. mutable state across paradigms
- **Code Organization**: Different approaches to modularity and reusability
- **Error Handling**: Paradigm-specific error handling strategies
- **Testing Strategies**: How different paradigms affect testing approaches

### Real-World Applications
- **Enterprise Systems**: How different paradigms solve business problems
- **Performance Considerations**: Trade-offs between paradigms
- **Team Collaboration**: How paradigm choice affects team development
- **Maintenance**: Long-term code maintainability across paradigms

## 🛠️ Technical Requirements

- **.NET 9.0 or later**
- **C# 12.0 features** (records, pattern matching, nullable reference types)
- **Visual Studio 2022** or **VS Code** with C# extension

## 🤝 Contributing

This project serves as an educational resource. Contributions that enhance the examples or add new paradigm demonstrations are welcome. Please ensure all contributions:

- Include comprehensive documentation
- Follow existing code style and structure
- Provide real-world, practical examples
- Include proper error handling and validation

## 📚 Further Reading

- **Design Patterns**: Gang of Four patterns and their paradigm relationships
- **Functional Programming**: Advanced concepts like monads, functors, and category theory
- **Concurrent Programming**: How different paradigms handle concurrency
- **Domain-Driven Design**: Applying OOP principles to complex business domains
- **Reactive Programming**: Event-driven patterns for responsive applications

---

*This project demonstrates that understanding multiple programming paradigms makes you a more versatile and effective developer. Each paradigm has its strengths, and knowing when and how to apply them is crucial for building robust, maintainable software systems.*
