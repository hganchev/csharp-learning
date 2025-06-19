// Prototype Pattern Example
// The Prototype pattern creates objects by cloning existing instances rather than creating new ones from scratch.
// This is useful when object creation is expensive or when you need to create many similar objects.

using System.Text.Json;

namespace DesignPatterns.Prototype
{
    // Prototype interface
    public interface IPrototype<T>
    {
        T Clone();
    }

    // Abstract base class for documents
    public abstract class Document : IPrototype<Document>
    {
        public string Title { get; set; } = "";
        public string Content { get; set; } = "";
        public DateTime CreatedDate { get; set; }
        public string Author { get; set; } = "";

        protected Document(string title, string author)
        {
            Title = title;
            Author = author;
            CreatedDate = DateTime.Now;
        }

        public abstract Document Clone();

        public virtual void Display()
        {
            Console.WriteLine($"Document Type: {GetType().Name}");
            Console.WriteLine($"Title: {Title}");
            Console.WriteLine($"Author: {Author}");
            Console.WriteLine($"Created: {CreatedDate:yyyy-MM-dd HH:mm:ss}");
            Console.WriteLine($"Content: {Content}");
        }
    }

    // Concrete prototype implementations
    public class Report : Document
    {
        public string Department { get; set; } = "";
        public List<string> Sections { get; set; }

        public Report(string title, string author, string department) : base(title, author)
        {
            Department = department;
            Sections = new List<string>();
        }

        public override Document Clone()
        {
            // Deep copy
            var cloned = new Report(Title, Author, Department)
            {
                Content = Content,
                CreatedDate = CreatedDate,
                Sections = new List<string>(Sections) // Create new list with copied elements
            };
            return cloned;
        }

        public override void Display()
        {
            base.Display();
            Console.WriteLine($"Department: {Department}");
            Console.WriteLine($"Sections: {string.Join(", ", Sections)}");
        }
    }

    public class Proposal : Document
    {
        public decimal Budget { get; set; }
        public DateTime Deadline { get; set; }
        public List<string> Requirements { get; set; }

        public Proposal(string title, string author, decimal budget, DateTime deadline) : base(title, author)
        {
            Budget = budget;
            Deadline = deadline;
            Requirements = new List<string>();
        }

        public override Document Clone()
        {
            // Deep copy
            var cloned = new Proposal(Title, Author, Budget, Deadline)
            {
                Content = Content,
                CreatedDate = CreatedDate,
                Requirements = new List<string>(Requirements) // Create new list with copied elements
            };
            return cloned;
        }

        public override void Display()
        {
            base.Display();
            Console.WriteLine($"Budget: ${Budget:N2}");
            Console.WriteLine($"Deadline: {Deadline:yyyy-MM-dd}");
            Console.WriteLine($"Requirements: {string.Join(", ", Requirements)}");
        }
    }

    public class Contract : Document
    {
        public decimal Value { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public List<string> Terms { get; set; }

        public Contract(string title, string author, decimal value, DateTime startDate, DateTime endDate) : base(title, author)
        {
            Value = value;
            StartDate = startDate;
            EndDate = endDate;
            Terms = new List<string>();
        }

        public override Document Clone()
        {
            // Deep copy
            var cloned = new Contract(Title, Author, Value, StartDate, EndDate)
            {
                Content = Content,
                CreatedDate = CreatedDate,
                Terms = new List<string>(Terms) // Create new list with copied elements
            };
            return cloned;
        }

        public override void Display()
        {
            base.Display();
            Console.WriteLine($"Contract Value: ${Value:N2}");
            Console.WriteLine($"Start Date: {StartDate:yyyy-MM-dd}");
            Console.WriteLine($"End Date: {EndDate:yyyy-MM-dd}");
            Console.WriteLine($"Terms: {string.Join(", ", Terms)}");
        }
    }

    // Document registry for managing prototypes
    public class DocumentRegistry
    {
        private readonly Dictionary<string, Document> _prototypes = new();

        public void RegisterPrototype(string key, Document prototype)
        {
            _prototypes[key] = prototype;
        }

        public Document? GetPrototype(string key)
        {
            return _prototypes.TryGetValue(key, out var prototype) ? prototype.Clone() : null;
        }

        public void ListAvailablePrototypes()
        {
            Console.WriteLine("Available prototypes:");
            foreach (var key in _prototypes.Keys)
            {
                Console.WriteLine($"  - {key}: {_prototypes[key].GetType().Name}");
            }
        }
    }

    // Demo class
    public class PrototypePatternDemo
    {
        public static void RunDemo()
        {
            Console.WriteLine("=== Prototype Pattern Demo ===");

            // Create prototype instances
            var reportPrototype = new Report("Monthly Report Template", "System", "Finance");
            reportPrototype.Content = "This is a template for monthly reports.";
            reportPrototype.Sections.AddRange(new[] { "Summary", "Details", "Recommendations" });

            var proposalPrototype = new Proposal("Project Proposal Template", "System", 50000m, DateTime.Now.AddDays(30));
            proposalPrototype.Content = "This is a template for project proposals.";
            proposalPrototype.Requirements.AddRange(new[] { "Requirement 1", "Requirement 2", "Requirement 3" });

            var contractPrototype = new Contract("Service Contract Template", "System", 100000m, DateTime.Now, DateTime.Now.AddMonths(12));
            contractPrototype.Content = "This is a template for service contracts.";
            contractPrototype.Terms.AddRange(new[] { "Term 1", "Term 2", "Term 3" });

            // Set up registry
            var registry = new DocumentRegistry();
            registry.RegisterPrototype("monthly-report", reportPrototype);
            registry.RegisterPrototype("project-proposal", proposalPrototype);
            registry.RegisterPrototype("service-contract", contractPrototype);

            Console.WriteLine("\n--- Available Prototypes ---");
            registry.ListAvailablePrototypes();

            // Clone documents from prototypes
            Console.WriteLine("\n--- Creating Documents from Prototypes ---");

            // Create a new report by cloning
            var januaryReport = registry.GetPrototype("monthly-report") as Report;
            if (januaryReport != null)
            {
                januaryReport.Title = "January 2024 Financial Report";
                januaryReport.Author = "John Doe";
                januaryReport.Content = "January financial summary and analysis.";
                januaryReport.Sections.Add("Year-over-Year Comparison");

                Console.WriteLine("\n--- Cloned Report ---");
                januaryReport.Display();
            }

            // Create a new proposal by cloning
            var websiteProposal = registry.GetPrototype("project-proposal") as Proposal;
            if (websiteProposal != null)
            {
                websiteProposal.Title = "Website Redesign Proposal";
                websiteProposal.Author = "Jane Smith";
                websiteProposal.Content = "Proposal for redesigning the company website.";
                websiteProposal.Budget = 75000m;
                websiteProposal.Requirements.Add("Mobile responsive design");

                Console.WriteLine("\n--- Cloned Proposal ---");
                websiteProposal.Display();
            }

            // Create a new contract by cloning
            var consultingContract = registry.GetPrototype("service-contract") as Contract;
            if (consultingContract != null)
            {
                consultingContract.Title = "IT Consulting Agreement";
                consultingContract.Author = "Mike Johnson";
                consultingContract.Content = "Agreement for IT consulting services.";
                consultingContract.Value = 150000m;
                consultingContract.Terms.Add("24/7 support included");

                Console.WriteLine("\n--- Cloned Contract ---");
                consultingContract.Display();
            }

            // Demonstrate that original prototypes are unchanged
            Console.WriteLine("\n--- Original Prototype (unchanged) ---");
            reportPrototype.Display();
        }
    }
}
