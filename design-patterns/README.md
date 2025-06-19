# CSharp_Design_Patterns
Design patterns for OOP - A comprehensive demonstration of creational design patterns in C#

## Overview
This project demonstrates five essential creational design patterns with practical examples and clear explanations. Each pattern is implemented in its own namespace with comprehensive demo code.

## Design Patterns Implemented

### 1. Factory Pattern
**Location:** `Factory/FactoryPattern.cs`

The Factory pattern provides an interface for creating objects without specifying their exact class. It encapsulates object creation logic in a single place, making it easier to manage and extend.

**Key Benefits:**
- Centralizes object creation logic
- Easy to extend with new product types
- Reduces coupling between client code and concrete classes

**Example:** Vehicle factory that creates Cars, Motorcycles, and Trucks based on input parameters.

### 2. Abstract Factory Pattern
**Location:** `Abstract_Factory/AbstractFactoryUINew.cs`

The Abstract Factory pattern provides an interface for creating families of related or dependent objects without specifying their concrete classes. It's useful when you need to create sets of related objects that work together.

**Key Benefits:**
- Creates families of related objects
- Ensures compatibility between related products
- Easy to switch between different product families

**Example:** UI Theme factory that creates consistent sets of UI components (buttons, labels, textboxes) for Light and Dark themes.

### 3. Builder Pattern
**Location:** `Builder/Builder.cs`

The Builder pattern separates the construction of complex objects from their representation, allowing the same construction process to create different representations. It's particularly useful for objects with many optional parameters.

**Key Benefits:**
- Step-by-step object construction
- Fluent interface for readable code
- Optional parameters without constructor overloading
- Immutable object creation

**Example:** Pizza builder that constructs pizzas with different crusts, sauces, sizes, and toppings using a fluent interface.

### 4. Prototype Pattern
**Location:** `Prototype/PrototypePattern.cs`

The Prototype pattern creates objects by cloning existing instances rather than creating new ones from scratch. This is useful when object creation is expensive or when you need to create many similar objects.

**Key Benefits:**
- Avoids expensive object creation
- Runtime object configuration
- Deep cloning of complex objects
- Registry pattern for prototype management

**Example:** Document prototypes (Reports, Proposals, Contracts) that can be cloned and customized, managed through a prototype registry.

### 5. Singleton Pattern
**Location:** `Singleton/SingletonPattern.cs`

The Singleton pattern ensures that a class has only one instance and provides global access to it. This project demonstrates multiple thread-safe implementations.

**Key Benefits:**
- Controlled access to sole instance
- Global point of access
- Lazy initialization
- Thread-safe implementations

**Examples:** 
- Logger (thread-safe with Lazy<T>)
- Database Connection (double-checked locking)
- Configuration Manager (thread-safe singleton)
- Cache Manager (generic singleton with expiration)

## Project Structure
```
├── Factory/
│   └── FactoryPattern.cs
├── Abstract_Factory/
│   ├── ExampleCode.cs (original problematic code)
│   ├── RefactoredCode.cs (simple factory refactor)
│   ├── AbstractFactoryUI.cs (legacy)
│   └── AbstractFactoryUINew.cs (improved implementation)
├── Builder/
│   └── Builder.cs
├── Prototype/
│   └── PrototypePattern.cs
├── Singleton/
│   └── SingletonPattern.cs
├── Program.cs (main demo runner)
└── README.md
```

## Running the Demos

1. **Build the project:**
   ```bash
   dotnet build
   ```

2. **Run the application:**
   ```bash
   dotnet run
   ```

The application will run demonstrations of all five design patterns, showing:
- How each pattern works
- Practical use cases
- Benefits and implementation details
- Multiple variations where applicable

## Key Learning Points

### When to Use Each Pattern

- **Factory:** When you need to create objects but don't want to specify the exact class
- **Abstract Factory:** When you need to create families of related objects
- **Builder:** When constructing complex objects with many optional parameters
- **Prototype:** When object creation is expensive or you need many similar objects
- **Singleton:** When you need exactly one instance of a class throughout the application

### Best Practices Demonstrated

- Thread-safe implementations
- Proper error handling
- Clean separation of concerns
- Fluent interfaces (Builder)
- Deep vs shallow copying (Prototype)
- Memory management considerations
- Proper use of generics and modern C# features

This implementation showcases modern C# practices including nullable reference types, pattern matching, and proper encapsulation while maintaining clear, educational examples.
