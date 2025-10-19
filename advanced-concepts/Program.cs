using AdvancedConcepts.TypeComparison;
using AdvancedConcepts.Threading;
using AdvancedConcepts.AsyncPatterns;
using AdvancedConcepts.Deadlocks;
using AdvancedConcepts.MemoryManagement;
using AdvancedConcepts.DependencyInjection;

namespace AdvancedConcepts;

/// <summary>
/// Main program demonstrating advanced C# concepts
/// </summary>
class Program
{
    static async Task Main(string[] args)
    {
        Console.Clear();
        PrintHeader();
        
        if (args.Length > 0 && int.TryParse(args[0], out int choice))
        {
            await RunDemo(choice);
        }
        else
        {
            await RunInteractiveMenu();
        }
    }

    static void PrintHeader()
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("╔════════════════════════════════════════════════════════════╗");
        Console.WriteLine("║         ADVANCED C# CONCEPTS - LEARNING PROJECT           ║");
        Console.WriteLine("║                  Best Practices & Patterns                 ║");
        Console.WriteLine("╚════════════════════════════════════════════════════════════╝");
        Console.ResetColor();
        Console.WriteLine();
    }

    static async Task RunInteractiveMenu()
    {
        while (true)
        {
            PrintMenu();
            
            Console.Write("Enter your choice (0-7): ");
            var input = Console.ReadLine();
            
            if (!int.TryParse(input, out int choice))
            {
                Console.WriteLine("\n❌ Invalid input. Please enter a number.\n");
                continue;
            }
            
            if (choice == 0)
            {
                Console.WriteLine("\n👋 Thank you for exploring C# advanced concepts!");
                break;
            }
            
            Console.WriteLine();
            await RunDemo(choice);
            
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
            Console.Clear();
            PrintHeader();
        }
    }

    static void PrintMenu()
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("📚 Available Demos:");
        Console.ResetColor();
        Console.WriteLine();
        
        Console.WriteLine("  1. Class vs Struct vs Record");
        Console.WriteLine("     • Reference vs Value types");
        Console.WriteLine("     • Equality semantics");
        Console.WriteLine("     • When to use each");
        Console.WriteLine();
        
        Console.WriteLine("  2. Threading & Concurrency");
        Console.WriteLine("     • Thread creation and management");
        Console.WriteLine("     • Thread safety and synchronization");
        Console.WriteLine("     • Task Parallel Library (TPL)");
        Console.WriteLine();
        
        Console.WriteLine("  3. Async/Await Patterns");
        Console.WriteLine("     • Asynchronous programming");
        Console.WriteLine("     • Task composition");
        Console.WriteLine("     • Cancellation and error handling");
        Console.WriteLine();
        
        Console.WriteLine("  4. Deadlocks");
        Console.WriteLine("     • Deadlock scenarios");
        Console.WriteLine("     • Prevention strategies");
        Console.WriteLine("     • Detection techniques");
        Console.WriteLine();
        
        Console.WriteLine("  5. Memory Management & GC");
        Console.WriteLine("     • Stack vs Heap");
        Console.WriteLine("     • Garbage Collection generations");
        Console.WriteLine("     • IDisposable pattern");
        Console.WriteLine();
        
        Console.WriteLine("  6. Dependency Injection");
        Console.WriteLine("     • Service lifetimes (Transient, Scoped, Singleton)");
        Console.WriteLine("     • Registration patterns");
        Console.WriteLine("     • Best practices");
        Console.WriteLine();
        
        Console.WriteLine("  7. Run All Demos");
        Console.WriteLine("     • Execute all demonstrations sequentially");
        Console.WriteLine();
        
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("  0. Exit");
        Console.ResetColor();
        Console.WriteLine();
    }

    static async Task RunDemo(int choice)
    {
        try
        {
            switch (choice)
            {
                case 1:
                    TypeComparisonDemo.Run();
                    break;
                
                case 2:
                    ThreadingDemo.Run();
                    break;
                
                case 3:
                    await AsyncAwaitDemo.Run();
                    break;
                
                case 4:
                    DeadlockDemo.Run();
                    break;
                
                case 5:
                    MemoryManagementDemo.Run();
                    break;
                
                case 6:
                    DependencyInjectionDemo.Run();
                    break;
                
                case 7:
                    await RunAllDemos();
                    break;
                
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("❌ Invalid choice. Please select 0-7.");
                    Console.ResetColor();
                    break;
            }
        }
        catch (Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"\n❌ Error running demo: {ex.Message}");
            Console.WriteLine($"\nStack trace:\n{ex.StackTrace}");
            Console.ResetColor();
        }
    }

    static async Task RunAllDemos()
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("🚀 Running all demonstrations...\n");
        Console.ResetColor();
        
        var demos = new List<(string name, Func<Task> action)>
        {
            ("Class vs Struct vs Record", () => { TypeComparisonDemo.Run(); return Task.CompletedTask; }),
            ("Threading & Concurrency", () => { ThreadingDemo.Run(); return Task.CompletedTask; }),
            ("Async/Await Patterns", () => AsyncAwaitDemo.Run()),
            ("Deadlocks", () => { DeadlockDemo.Run(); return Task.CompletedTask; }),
            ("Memory Management & GC", () => { MemoryManagementDemo.Run(); return Task.CompletedTask; }),
            ("Dependency Injection", () => { DependencyInjectionDemo.Run(); return Task.CompletedTask; })
        };
        
        for (int i = 0; i < demos.Count; i++)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine($"═══════════════════════════════════════════════════════════");
            Console.WriteLine($" Demo {i + 1}/{demos.Count}: {demos[i].name}");
            Console.WriteLine($"═══════════════════════════════════════════════════════════");
            Console.ResetColor();
            Console.WriteLine();
            
            await demos[i].action();
            
            if (i < demos.Count - 1)
            {
                Console.WriteLine("\n⏸  Press any key to continue to next demo...");
                Console.ReadKey();
                Console.WriteLine();
            }
        }
        
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("\n✅ All demonstrations completed!");
        Console.ResetColor();
    }
}

/// <summary>
/// Quick reference guide
/// </summary>
public static class QuickReference
{
    public static void PrintQuickReference()
    {
        Console.WriteLine("QUICK REFERENCE GUIDE");
        Console.WriteLine("=====================\n");
        
        Console.WriteLine("CLASS vs STRUCT vs RECORD:");
        Console.WriteLine("  Class    → Reference type, heap, inheritance, identity");
        Console.WriteLine("  Struct   → Value type, stack, no inheritance, value semantics");
        Console.WriteLine("  Record   → Reference type, immutable, value equality\n");
        
        Console.WriteLine("THREADING:");
        Console.WriteLine("  lock     → Mutual exclusion (Monitor)");
        Console.WriteLine("  Mutex    → Cross-process synchronization");
        Console.WriteLine("  Semaphore → Limit concurrent access");
        Console.WriteLine("  Task     → Preferred over Thread\n");
        
        Console.WriteLine("ASYNC/AWAIT:");
        Console.WriteLine("  async Task              → Async method");
        Console.WriteLine("  await                   → Wait for async operation");
        Console.WriteLine("  CancellationToken       → Support cancellation");
        Console.WriteLine("  ConfigureAwait(false)   → Library code optimization\n");
        
        Console.WriteLine("MEMORY:");
        Console.WriteLine("  Stack    → Fast, value types, limited size");
        Console.WriteLine("  Heap     → Slower, reference types, GC managed");
        Console.WriteLine("  Gen 0/1/2 → GC generations");
        Console.WriteLine("  IDisposable → Cleanup pattern\n");
        
        Console.WriteLine("DEPENDENCY INJECTION:");
        Console.WriteLine("  Transient → New instance every time");
        Console.WriteLine("  Scoped    → One per request/scope");
        Console.WriteLine("  Singleton → One for application lifetime\n");
    }
}
