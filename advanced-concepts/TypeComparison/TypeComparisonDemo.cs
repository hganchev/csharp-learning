namespace AdvancedConcepts.TypeComparison;

/// <summary>
/// Demonstrates the differences between Class, Struct, and Record types
/// </summary>
public static class TypeComparisonDemo
{
    public static void Run()
    {
        Console.WriteLine("=== CLASS vs STRUCT vs RECORD ===\n");
        
        DemonstrateReferenceVsValue();
        DemonstrateEquality();
        DemonstrateMutability();
        DemonstratePerformance();
        DemonstrateInheritance();
    }

    private static void DemonstrateReferenceVsValue()
    {
        Console.WriteLine("1. Reference vs Value Type:");
        
        // Class (Reference Type)
        var person1 = new PersonClass("John", 30);
        var person2 = person1; // Copy reference
        person2.Age = 31;
        Console.WriteLine($"  Class - person1.Age: {person1.Age}, person2.Age: {person2.Age}");
        Console.WriteLine($"  Both point to same object: {person1.Age == person2.Age}");
        
        // Struct (Value Type)
        var point1 = new PointStruct(10, 20);
        var point2 = point1; // Copy value
        var point3 = new PointStruct(15, point2.Y); // Create new instance
        Console.WriteLine($"  Struct - point1.X: {point1.X}, point3.X: {point3.X}");
        Console.WriteLine($"  Independent copies: {point1.X != point3.X}");
        
        // Record (Reference Type with value semantics)
        var employee1 = new EmployeeRecord("Jane", "Engineering");
        var employee2 = employee1 with { Department = "Marketing" }; // Non-destructive mutation
        Console.WriteLine($"  Record - employee1: {employee1.Department}, employee2: {employee2.Department}");
        Console.WriteLine($"  Records are immutable, use 'with' for changes\n");
    }

    private static void DemonstrateEquality()
    {
        Console.WriteLine("2. Equality Comparison:");
        
        // Class - Reference equality
        var p1 = new PersonClass("Alice", 25);
        var p2 = new PersonClass("Alice", 25);
        Console.WriteLine($"  Class equality (same data): {p1 == p2} (reference equality)");
        Console.WriteLine($"  Class Equals: {p1.Equals(p2)}");
        
        // Struct - Value equality
        var s1 = new PointStruct(5, 10);
        var s2 = new PointStruct(5, 10);
        Console.WriteLine($"  Struct equality (same data): {s1.Equals(s2)} (value equality)");
        
        // Record - Value equality (built-in)
        var r1 = new EmployeeRecord("Bob", "Sales");
        var r2 = new EmployeeRecord("Bob", "Sales");
        Console.WriteLine($"  Record equality (same data): {r1 == r2} (value equality)");
        Console.WriteLine($"  Record GetHashCode: {r1.GetHashCode() == r2.GetHashCode()}\n");
    }

    private static void DemonstrateMutability()
    {
        Console.WriteLine("3. Mutability:");
        
        var person = new PersonClass("John", 30);
        person.Age = 31; // Mutable
        Console.WriteLine($"  Class: Mutable - Age changed to {person.Age}");
        
        var point = new PointStruct(1, 2);
        // point.X = 5; // Would work if not readonly
        Console.WriteLine($"  Struct: Can be mutable, but best practice is readonly");
        
        var employee = new EmployeeRecord("Jane", "IT");
        // employee.Name = "Janet"; // Compilation error - records are immutable
        var updatedEmployee = employee with { Department = "HR" };
        Console.WriteLine($"  Record: Immutable - use 'with' expression for updates");
        Console.WriteLine($"  Original: {employee}, Updated: {updatedEmployee}\n");
    }

    private static void DemonstratePerformance()
    {
        Console.WriteLine("4. Performance & Memory:");
        
        // Structs are stack-allocated (faster, less GC pressure)
        Console.WriteLine("  Struct: Stack-allocated, no GC overhead for small data");
        Console.WriteLine("  Class: Heap-allocated, subject to GC");
        Console.WriteLine("  Record: Heap-allocated like class, but with additional features");
        
        // Best practice: Use structs for small, frequently used data (< 16 bytes)
        Console.WriteLine("  Rule of thumb: Structs should be < 16 bytes, immutable, and value-like\n");
    }

    private static void DemonstrateInheritance()
    {
        Console.WriteLine("5. Inheritance:");
        
        Console.WriteLine("  Class: Supports full inheritance");
        Console.WriteLine("  Struct: No inheritance (except from ValueType)");
        Console.WriteLine("  Record: Supports inheritance (record class)");
        Console.WriteLine("  Record struct: Value-type record without inheritance\n");
        
        var manager = new Manager("Alice", "Engineering", 5);
        Console.WriteLine($"  Manager (inherits from EmployeeRecord): {manager}");
        Console.WriteLine($"  Manager TeamSize: {manager.TeamSize}\n");
    }
}

// When to use what:
// 
// CLASS:
// - Complex objects with identity
// - Large objects (> 16 bytes)
// - Need inheritance
// - Mutable state is required
// - Example: User, Order, Service classes
//
// STRUCT:
// - Small data (< 16 bytes)
// - Immutable, value-like semantics
// - High-performance scenarios
// - No identity needed
// - Example: Point, Color, DateTime, Guid
//
// RECORD:
// - DTOs (Data Transfer Objects)
// - Immutable data models
// - Value objects
// - Need value equality
// - Example: Configuration, API responses, Events
