// Simple Factory Pattern Example (moved from Abstract Factory)
// This demonstrates the difference between Factory and Abstract Factory patterns

namespace DesignPatterns.Factory
{
    public interface IFactory
    {
        ITypeProcessor CreateTypeProcessor(string type);
    }

    public interface ITypeProcessor
    {
        string Output { get; set; }
        void Process();
    }

    public class TypeAProcessor : ITypeProcessor
    {
        public string Output { get; set; } = string.Empty;
        
        public void Process()
        {
            // Do something for type A
            Output = "Process for type A";
            Console.WriteLine(Output);
        }
    }

    public class TypeBProcessor : ITypeProcessor
    {
        public string Output { get; set; } = string.Empty;
        
        public void Process()
        {
            // Do something for type B
            Output = "Process for type B";
            Console.WriteLine(Output);
        }
    }

    public class Factory : IFactory
    {
        public ITypeProcessor CreateTypeProcessor(string type)
        {
            return type switch
            {
                "A" => new TypeAProcessor(),
                "B" => new TypeBProcessor(),
                _ => throw new ArgumentException($"Invalid type: {type}")
            };
        }
    }

    // Demo class for the simple factory pattern
    public class SimpleFactoryPatternDemo
    {
        public static void RunDemo()
        {
            Console.WriteLine("=== Simple Factory Pattern Demo ===");
            
            IFactory factory = new Factory();
            string[] types = { "A", "B" };

            foreach (string type in types)
            {
                try
                {
                    ITypeProcessor processor = factory.CreateTypeProcessor(type);
                    processor.Process();
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }
    }
}
