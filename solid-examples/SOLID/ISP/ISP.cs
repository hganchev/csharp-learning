using System;

namespace SOLID
{
    /// <summary>
    /// ISP - Interface Segregation Principle
    /// Definition: Many client-specific interfaces are better than one general-purpose interface.
    /// Clients should not be forced to depend on interfaces they do not use.
    /// </summary>
    class ISP
    {
        public ISP()
        {
            Console.WriteLine("=== Interface Segregation Principle (ISP) ===");
            Console.WriteLine("Clients should not be forced to depend on interfaces they do not use.\n");

            // Problem Example - Violating ISP
            Console.WriteLine("PROBLEM - Violating ISP:");
            var humanWorker = new HumanWorkerProblem();
            var robotWorker = new RobotWorkerProblem();
            
            humanWorker.Work();
            humanWorker.Eat(); // OK for humans
            
            robotWorker.Work();
            try
            {
                robotWorker.Eat(); // Robots don't eat! This violates ISP
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            Console.WriteLine();

            // Solution Example - Following ISP
            Console.WriteLine("SOLUTION - Following ISP:");
            var developer = new Developer();
            var printer = new Printer();
            var scanner = new Scanner();
            var allInOneDevice = new AllInOneDevice();
            
            // Each worker only implements what they need
            developer.Work();
            developer.Eat();
            developer.Sleep();
            
            Console.WriteLine();
            
            // Devices only implement relevant interfaces
            printer.Print("Document.pdf");
            scanner.Scan("Photo.jpg");
            
            Console.WriteLine();
            
            // All-in-one device implements multiple interfaces
            allInOneDevice.Print("Report.docx");
            allInOneDevice.Scan("Contract.pdf");
            allInOneDevice.Fax("Invoice.pdf");
        }
    }

    #region Problem - Violating ISP
    /// <summary>
    /// PROBLEM: This interface is too broad and forces all implementers to implement
    /// methods they might not need.
    /// </summary>
    interface IWorkerProblem
    {
        void Work();
        void Eat(); // Not all workers need to eat (e.g., robots)
        void Sleep(); // Not all workers need to sleep
    }

    class HumanWorkerProblem : IWorkerProblem
    {
        public void Work()
        {
            Console.WriteLine("Human is working");
        }

        public void Eat()
        {
            Console.WriteLine("Human is eating lunch");
        }

        public void Sleep()
        {
            Console.WriteLine("Human is sleeping");
        }
    }

    class RobotWorkerProblem : IWorkerProblem
    {
        public void Work()
        {
            Console.WriteLine("Robot is working");
        }

        public void Eat()
        {
            // Robots don't eat! Forced to implement anyway
            throw new NotSupportedException("Robots don't eat!");
        }

        public void Sleep()
        {
            // Robots don't sleep! Forced to implement anyway
            throw new NotSupportedException("Robots don't sleep!");
        }
    }
    #endregion

    #region Solution - Following ISP
    /// <summary>
    /// SOLUTION: Split the large interface into smaller, more specific interfaces
    /// </summary>
    
    // Small, focused interfaces
    interface IWorkable
    {
        void Work();
    }

    interface IEatable
    {
        void Eat();
    }

    interface ISleepable
    {
        void Sleep();
    }

    // Example: Human worker implements all biological needs
    class Developer : IWorkable, IEatable, ISleepable
    {
        public void Work()
        {
            Console.WriteLine("Developer is coding");
        }

        public void Eat()
        {
            Console.WriteLine("Developer is having coffee and snacks");
        }

        public void Sleep()
        {
            Console.WriteLine("Developer is taking a power nap");
        }
    }

    // Example: Robot worker only implements what it can do
    class Robot : IWorkable
    {
        public void Work()
        {
            Console.WriteLine("Robot is performing automated tasks");
        }
        // No need to implement Eat() or Sleep()
    }

    // Device interfaces following ISP
    interface IPrintable
    {
        void Print(string document);
    }

    interface IScannable
    {
        void Scan(string document);
    }

    interface IFaxable
    {
        void Fax(string document);
    }

    // Simple printer only implements printing
    class Printer : IPrintable
    {
        public void Print(string document)
        {
            Console.WriteLine($"Printing: {document}");
        }
    }

    // Simple scanner only implements scanning
    class Scanner : IScannable
    {
        public void Scan(string document)
        {
            Console.WriteLine($"Scanning: {document}");
        }
    }

    // Complex device implements multiple interfaces as needed
    class AllInOneDevice : IPrintable, IScannable, IFaxable
    {
        public void Print(string document)
        {
            Console.WriteLine($"All-in-One: Printing {document}");
        }

        public void Scan(string document)
        {
            Console.WriteLine($"All-in-One: Scanning {document}");
        }

        public void Fax(string document)
        {
            Console.WriteLine($"All-in-One: Faxing {document}");
        }
    }
    #endregion
}