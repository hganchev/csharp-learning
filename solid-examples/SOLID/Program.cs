using System;

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

            // ============= Original Dependency Injection Example =================================================================
            Console.WriteLine("=== Additional Dependency Injection Example ===");
            Console.WriteLine("This example shows how dependency injection works in practice:\n");
            
            // In this example, we have an interface called IDatabase that defines a single method called Save(string data).
            // We also have a class called SqlDatabase that implements this interface and provides an actual implementation for the Save(string data) 
            // method that saves data to a SQL database.
            // The Logger class has a constructor that takes an IDatabase object as a parameter. 
            // The constructor stores this object in a private field called _database. The Logger class has a method called Log(string message)
            // that takes a string message as a parameter and logs it to the database by calling the Save(string data) method on the _database object.
            // This is an example of dependency injection, because the Logger class does not create its own IDatabase object. 
            // Instead, it receives an IDatabase object as a parameter through its constructor and stores it in a private field. 
            // This allows the Logger class to be more loosely coupled to the IDatabase object and more testable.
            // In this example, the SqlDatabase class is being injected as a dependency in the Logger class, 
            // but it could be replaced by other classes that implements the IDatabase interface and the Logger class would still work.
            // This is one of the benefits of dependency injection, it allows to change the implementation of a dependency without
            // modifying the code of the class that depends on it, making the code more flexible and maintainable.
            // =============================================================================================================
            
            var sqlDb = new SqlDatabase();
            var logger = new Logger(sqlDb);
            logger.Log("Application started successfully!");

            Console.WriteLine("\n======================================");
            Console.WriteLine("    All SOLID Principles Demonstrated");
            Console.WriteLine("======================================");
        }
    }
}