using System;
using SOLID.DependencyInjection;

namespace SOLID
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("======================================");
            Console.WriteLine("       SOLID PRINCIPLES EXAMPLES     ");
            Console.WriteLine("======================================\n");

            // Single Responsibility Principle
            var srp = new SRP();
            Console.WriteLine("\n" + new string('=', 60) + "\n");

            // Open/Closed Principle
            var ocp = new OCP();
            Console.WriteLine("\n" + new string('=', 60) + "\n");

            // Liskov Substitution Principle
            var lsp = new LSP();
            Console.WriteLine("\n" + new string('=', 60) + "\n");

            // Interface Segregation Principle
            var isp = new ISP();
            Console.WriteLine("\n" + new string('=', 60) + "\n");

            // Dependency Inversion Principle
            var dip = new DIP();
            Console.WriteLine("\n" + new string('=', 60) + "\n");

            // Dependency Injection Examples
            DependencyInjectionExamples.RunDependencyInjectionExamples();

            Console.WriteLine("\n======================================");
            Console.WriteLine("    All SOLID Principles Demonstrated");
            Console.WriteLine("======================================");
            
            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}