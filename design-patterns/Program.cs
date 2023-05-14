namespace DesignPatterns
{
    class Program
    {
        static void Main(string[] args)
        {
            // The Abstract Factory pattern is a creational design pattern that provides an interface for creating families of related 
            // or dependent objects without specifying their concrete classes. The main idea behind the Abstract Factory pattern is 
            // to abstract the process of object creation and make it possible to create families of related objects without having 
            // to specify their concrete classes directly. In this example, the IFactory interface is the abstract factory that provides 
            // a common interface for creating the ITypeProcessor objects, while the concrete factory classes TypeAProcessor and TypeBProcessor 
            // implement this interface and provide the necessary implementations for each type.
            Console.WriteLine("===================== AbstractFactoryPatternExample =========================");
            AbstractFactoryPatternExample();

            Console.WriteLine("===================== AbstractFactoryPatternUsage =========================");
            AbstractFactoryPatternUsage();

            // The Builder design pattern is a creational pattern that allows you to separate the construction of a complex object from 
            // its representation, so that you can create different representations of the same object.

            // The Builder pattern involves the following participants:

            // The Builder interface, which defines the steps involved in creating the complex object.
            // The ConcreteBuilder classes, which implement the Builder interface and provide specific implementations of the steps involved in creating the complex object.
            // The Director class, which uses the Builder interface to create the complex object.
            // The Product class, which represents the complex object being built.
            Console.WriteLine("===================== BuilderPatternExample  =========================");
            BuilderPatternExample();
            
        }

        static void AbstractFactoryPatternExample()
        {
            // In this example, the DoSomething method uses a string parameter to determine which code path to take, 
            // and this can lead to issues such as code duplication, hard-coded dependencies, and difficulty in adding new types.
            try
            {
                var example = new ExampleCode();
                example.DoSomething("A");
                example.DoSomething("B");
                example.DoSomething("AB");
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
            // To refactor this code using the Abstract Factory pattern, we can create an abstract factory interface that 
            // defines the contract for creating objects of different types, and then create concrete factory classes that implement 
            // this interface and provide the necessary implementations for each type.

            // Read type from command line arguments or other source
            string type = "A";

            IFactory factory = new Factory();
            try
            {
                ITypeProcessor typeProcessor = factory.CreateTypeProcessor(type);
                typeProcessor.Process();
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static void AbstractFactoryPatternUsage()
        {
            
            // Example usage
            var lightThemeFactory = new LightThemeFactory();
            var darkThemeFactory = new DarkThemeFactory();

            var lightUIThemeClient = new UIThemeClient(lightThemeFactory);
            lightUIThemeClient.Paint();

            var darkUIThemeClient = new UIThemeClient(darkThemeFactory);
            darkUIThemeClient.Paint();
        }

        static void BuilderPatternExample()
        {
            // Example usage
            var thinCrustPizzaBuilder = new ThinCrustPizzaBuilder();
            var pizzaDirector = new PizzaDirector(thinCrustPizzaBuilder);
            pizzaDirector.BuildPizza();
            var pizza = thinCrustPizzaBuilder.GetPizza();
            pizza.Display();
        }
    }
}