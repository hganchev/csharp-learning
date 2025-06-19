using DesignPatterns.Factory;
using DesignPatterns.AbstractFactory;
using DesignPatterns.Builder;
using DesignPatterns.Prototype;
using DesignPatterns.Singleton;

namespace DesignPatterns
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=========================================");
            Console.WriteLine("     C# DESIGN PATTERNS DEMONSTRATION   ");
            Console.WriteLine("=========================================");

            // Factory Pattern Demo
            Console.WriteLine("\n");
            FactoryPatternDemo.RunDemo();

            // Simple Factory Pattern Demo (from refactored code)
            Console.WriteLine("\n");
            SimpleFactoryPatternDemo.RunDemo();

            // Abstract Factory Pattern Demo
            Console.WriteLine("\n");
            AbstractFactoryPatternDemo.RunDemo();

            // Builder Pattern Demo
            Console.WriteLine("\n");
            BuilderPatternDemo.RunDemo();

            // Prototype Pattern Demo
            Console.WriteLine("\n");
            PrototypePatternDemo.RunDemo();

            // Singleton Pattern Demo
            Console.WriteLine("\n");
            SingletonPatternDemo.RunDemo();

            Console.WriteLine("\n=========================================");
            Console.WriteLine("     ALL DESIGN PATTERNS DEMONSTRATED   ");
            Console.WriteLine("=========================================");
        }
    }
}