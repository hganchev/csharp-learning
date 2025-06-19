using System;
using System.Collections.Generic;
using app.Functional;

namespace app
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== PROGRAMMING PARADIGMS DEMONSTRATION ===");
            Console.WriteLine("This application demonstrates various programming paradigms in C#\n");
            
            // ========================= Object-Oriented Programming ===================================
            Console.WriteLine("🔹 OBJECT-ORIENTED PROGRAMMING");
            Console.WriteLine("Encapsulation, Inheritance, Polymorphism, and Abstraction\n");
            
            try
            {
                DemonstrateOOP();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in OOP demo: {ex.Message}");
            }
            
            Console.WriteLine("\n" + new string('=', 80) + "\n");
            
            // ========================= Functional Programming ========================================
            Console.WriteLine("🔹 FUNCTIONAL PROGRAMMING");
            Console.WriteLine("Pure functions, Immutability, Higher-order functions, Function composition\n");
            
            try
            {
                DemonstrateFunctional();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in Functional demo: {ex.Message}");
            }
            
            Console.WriteLine("\n" + new string('=', 80) + "\n");
            
            // ========================= Procedural Programming ========================================
            Console.WriteLine("🔹 PROCEDURAL/IMPERATIVE PROGRAMMING");
            Console.WriteLine("Step-by-step execution, Mutable state, Control structures\n");
            
            try
            {
                DemonstrateProcedural();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in Procedural demo: {ex.Message}");
            }
            
            Console.WriteLine("\n" + new string('=', 80) + "\n");
            
            // ========================= Event-Driven Programming ======================================
            Console.WriteLine("🔹 EVENT-DRIVEN PROGRAMMING");
            Console.WriteLine("Publisher-Subscriber pattern, Event handling, Loose coupling\n");
            
            try
            {
                DemonstrateEventDriven();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in Event-Driven demo: {ex.Message}");
            }
            
            Console.WriteLine("\n" + new string('=', 80) + "\n");
            
            // ========================= Structured Programming =======================================
            Console.WriteLine("🔹 STRUCTURED PROGRAMMING");
            Console.WriteLine("Control structures, Modularity, Top-down design\n");
            
            try
            {
                DemonstrateStructured();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in Structured demo: {ex.Message}");
            }
            
            Console.WriteLine("\n" + new string('=', 80));
            Console.WriteLine("🎉 DEMONSTRATION COMPLETE!");
            Console.WriteLine("All programming paradigms have been demonstrated successfully.");
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
        
        private static void DemonstrateOOP()
        {
            // Create different types of vehicles
            var myCar = new OOP.Car("Toyota", 2022, 4, "Automatic", "Blue");
            var myMotorcycle = new OOP.Motorcycle("Harley-Davidson", 2021, false, "Black");
            var myRentalCar = new OOP.RentalCar("Ford", 2023, 45.99m, "White");
            
            // Demonstrate encapsulation
            Console.WriteLine("--- Encapsulation Example ---");
            OOP.VehicleUtilities.DisplayVehicleInfo(myCar);
            
            // Demonstrate polymorphism
            Console.WriteLine("\n--- Polymorphism Example ---");
            var vehicles = new List<OOP.Vehicle> { myCar, myMotorcycle };
            OOP.VehicleUtilities.TestPolymorphism(vehicles);
            
            // Demonstrate interface implementation
            Console.WriteLine("--- Interface Implementation ---");
            Console.WriteLine($"Rental car daily rate: ${myRentalCar.DailyRate}");
            Console.WriteLine($"Is available: {myRentalCar.IsAvailable}");
            
            try
            {
                myRentalCar.Rent("John Doe");
                Console.WriteLine($"After rental - Is available: {myRentalCar.IsAvailable}");
                myRentalCar.Return();
                Console.WriteLine($"After return - Is available: {myRentalCar.IsAvailable}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Rental operation failed: {ex.Message}");
            }
            
            // Demonstrate maintenance interface
            if (myRentalCar.NeedsMaintenance)
            {
                myRentalCar.PerformMaintenance();
            }
            
            // Demonstrate enum usage
            Console.WriteLine($"\nVehicle status example: {OOP.VehicleStatus.Available}");
        }
          private static void DemonstrateFunctional()
        {
            // Demonstrate basic functional concepts
            app.Functional.FunctionalExamples.DemonstrateBasicConcepts();
            
            // Demonstrate data processing
            app.Functional.FunctionalDataProcessor.DemonstrateDataProcessing();
            
            // Demonstrate Option monad
            Console.WriteLine("\n--- Option Monad Example ---");
            var someValue = app.Functional.Option<int>.Some(42);
            var noneValue = app.Functional.Option<int>.None();
            
            var result1 = someValue.Map(x => x * 2);
            var result2 = noneValue.Map(x => x * 2);
            
            Console.WriteLine($"Some(42) mapped: {result1}");
            Console.WriteLine($"None mapped: {result2}");
            
            // Function composition example
            var numbers = new[] { 1, 2, 3, 4, 5 };
            var processedNumbers = app.Functional.FunctionalExamples.ProcessNumbers(
                numbers,
                app.Functional.FunctionalExamples.IsEven,
                app.Functional.FunctionalExamples.Square
            );
            
            Console.WriteLine($"Even squares: [{string.Join(", ", processedNumbers)}]");
        }
          private static void DemonstrateProcedural()
        {
            // Run the main procedural example
            var proceduralExample = new app.Imperative.ProceduralExamples();
            
            // Run additional data processing example
            app.Imperative.DataProcessor.ProcessEmployeeData();
        }
        
        private static void DemonstrateEventDriven()
        {
            // Run the comprehensive event-driven demo
            app.EventDriven.EventDrivenDemo.RunDemo();
        }
        
        private static void DemonstrateStructured()
        {
            // Run the main structured programming example
            var structuredExample = new app.Structured.StructuredExamples();
        }
    }
}