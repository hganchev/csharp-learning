using System;
using System.Collections.Generic;
using System.Linq;

namespace app.Functional
{
    /// <summary>
    /// Demonstrates Functional Programming principles:
    /// - First-class functions: Functions can be assigned to variables and passed as parameters
    /// - Pure functions: Functions with no side effects that always return same output for same input
    /// - Immutability: Data structures that don't change after creation
    /// - Higher-order functions: Functions that take other functions as parameters
    /// - Function composition: Building complex operations by combining simple functions
    /// </summary>
    public static class FunctionalExamples
    {
        // Delegate definitions for function types
        public delegate T UnaryFunction<T>(T input);
        public delegate TResult BinaryFunction<T1, T2, TResult>(T1 input1, T2 input2);
        
        // Pure functions - no side effects, same input always produces same output
        public static int Square(int x) => x * x;
        public static int Add(int a, int b) => a + b;
        public static int Multiply(int a, int b) => a * b;
        public static bool IsEven(int x) => x % 2 == 0;
        public static bool IsPositive(int x) => x > 0;
        
        // Higher-order function - takes another function as parameter
        public static IEnumerable<TResult> Map<T, TResult>(IEnumerable<T> source, Func<T, TResult> selector)
        {
            foreach (var item in source)
                yield return selector(item);
        }
        
        // Function composition - combining simple functions to create complex ones
        public static Func<T, TResult> Compose<T, TIntermediate, TResult>(
            Func<T, TIntermediate> first, 
            Func<TIntermediate, TResult> second)
        {
            return input => second(first(input));
        }
        
        // Currying - transforming a function with multiple parameters into a series of functions
        public static Func<int, int> AddCurried(int x) => y => x + y;
        public static Func<int, Func<int, int>> MultiplyCurried = x => y => x * y;
        
        // Partial application - fixing some arguments of a function
        public static Func<int, int> CreateAdder(int valueToAdd) => x => x + valueToAdd;
        public static Func<int, bool> CreateGreaterThanChecker(int threshold) => x => x > threshold;
        
        // Recursive functions - functional style for repetitive operations
        public static int Factorial(int n) => n <= 1 ? 1 : n * Factorial(n - 1);
        
        public static int Fibonacci(int n) => n switch
        {
            0 => 0,
            1 => 1,
            _ => Fibonacci(n - 1) + Fibonacci(n - 2)
        };
        
        // Memoization - caching function results for optimization
        private static readonly Dictionary<int, int> FibonacciCache = new();
        
        public static int FibonacciMemoized(int n)
        {
            if (FibonacciCache.TryGetValue(n, out int cached))
                return cached;
                
            int result = n switch
            {
                0 => 0,
                1 => 1,
                _ => FibonacciMemoized(n - 1) + FibonacciMemoized(n - 2)
            };
            
            FibonacciCache[n] = result;
            return result;
        }
        
        // Immutable data structures example
        public static IEnumerable<T> AppendToImmutableList<T>(IEnumerable<T> original, T newItem)
        {
            return original.Concat(new[] { newItem });
        }
        
        // Function pipeline - chaining operations together
        public static IEnumerable<TResult> ProcessNumbers<TResult>(
            IEnumerable<int> numbers,
            Func<int, bool> filter,
            Func<int, TResult> transform)
        {
            return numbers
                .Where(filter)
                .Select(transform);
        }
        
        // Monadic operations (Option/Maybe pattern)
        public static Option<TResult> Map<T, TResult>(this Option<T> option, Func<T, TResult> func)
        {
            return option.HasValue ? Option<TResult>.Some(func(option.Value)) : Option<TResult>.None();
        }
        
        public static Option<TResult> FlatMap<T, TResult>(this Option<T> option, Func<T, Option<TResult>> func)
        {
            return option.HasValue ? func(option.Value) : Option<TResult>.None();
        }
        
        public static void DemonstrateBasicConcepts()
        {
            Console.WriteLine("=== Basic Functional Concepts ===");
            
            // First-class functions
            Func<int, int> squareFunc = Square;
            Func<int, int> addFive = CreateAdder(5);
            
            Console.WriteLine($"Square of 4: {squareFunc(4)}");
            Console.WriteLine($"Add 5 to 3: {addFive(3)}");
            
            // Function composition
            var squareAndAddFive = Compose<int, int, int>(Square, addFive);
            Console.WriteLine($"Square 3 then add 5: {squareAndAddFive(3)}");
            
            // Higher-order functions with LINQ
            var numbers = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            
            var evenSquares = numbers
                .Where(IsEven)
                .Select(Square)
                .ToList();
            
            Console.WriteLine($"Even squares: [{string.Join(", ", evenSquares)}]");
            
            // Currying example
            var add10 = AddCurried(10);
            var multiply3 = MultiplyCurried(3);
            
            Console.WriteLine($"Add 10 to 5: {add10(5)}");
            Console.WriteLine($"Multiply 3 by 4: {multiply3(4)}");
            
            // Recursive functions
            Console.WriteLine($"Factorial of 5: {Factorial(5)}");
            Console.WriteLine($"Fibonacci of 10: {Fibonacci(10)}");
            Console.WriteLine($"Memoized Fibonacci of 10: {FibonacciMemoized(10)}");
        }
    }
    
    // Option/Maybe monad implementation for safer null handling
    public struct Option<T>
    {
        private readonly T _value;
        public bool HasValue { get; }
        public T Value => HasValue ? _value : throw new InvalidOperationException("No value present");
        
        private Option(T value, bool hasValue)
        {
            _value = value;
            HasValue = hasValue;
        }
        
        public static Option<T> Some(T value) => new(value, true);
        public static Option<T> None() => new(default!, false);
        
        public TResult Match<TResult>(Func<T, TResult> onSome, Func<TResult> onNone)
        {
            return HasValue ? onSome(_value) : onNone();
        }
        
        public override string ToString() => HasValue ? $"Some({_value})" : "None";
    }
    
    // Functional data processing example
    public class FunctionalDataProcessor
    {
        // Sample data
        private static readonly List<Person> People = new()
        {
            new("Alice", 30, "Engineering"),
            new("Bob", 25, "Marketing"),
            new("Charlie", 35, "Engineering"),
            new("Diana", 28, "Sales"),
            new("Eve", 32, "Engineering")
        };
        
        public static void DemonstrateDataProcessing()
        {
            Console.WriteLine("\n=== Functional Data Processing ===");
            
            // Functional pipeline for data processing
            var result = People
                .Where(p => p.Department == "Engineering")
                .Select(p => new { p.Name, p.Age })
                .OrderBy(p => p.Age)
                .ToList();
            
            Console.WriteLine("Engineers sorted by age:");
            result.ForEach(p => Console.WriteLine($"  {p.Name}: {p.Age}"));
            
            // Using higher-order functions
            var averageAge = People
                .Where(p => p.Age > 25)
                .Average(p => p.Age);
            
            Console.WriteLine($"Average age of people over 25: {averageAge:F1}");
            
            // Demonstrating immutability
            var originalList = new List<int> { 1, 2, 3 };
            var newList = FunctionalExamples.AppendToImmutableList(originalList, 4);
            
            Console.WriteLine($"Original: [{string.Join(", ", originalList)}]");
            Console.WriteLine($"New: [{string.Join(", ", newList)}]");
        }
    }
    
    // Record type for immutable data
    public record Person(string Name, int Age, string Department);
}