// Builder Pattern Example
// The Builder pattern separates the construction of complex objects from their representation
// allowing the same construction process to create different representations

namespace DesignPatterns.Builder
{
    // The Product class
    public class Pizza
    {
        public string Crust { get; set; } = "";
        public string Sauce { get; set; } = "";
        public List<string> Toppings { get; set; }
        public string Size { get; set; } = "";
        public bool HasCheese { get; set; }

        public Pizza()
        {
            Toppings = new List<string>();
        }

        public void Display()
        {
            Console.WriteLine($"Pizza Details:");
            Console.WriteLine($"  Size: {Size}");
            Console.WriteLine($"  Crust: {Crust}");
            Console.WriteLine($"  Sauce: {Sauce}");
            Console.WriteLine($"  Has Cheese: {HasCheese}");
            Console.WriteLine($"  Toppings ({Toppings.Count}):");
            foreach (var topping in Toppings)
            {
                Console.WriteLine($"    - {topping}");
            }
        }
    }

    // The Builder interface
    public interface IPizzaBuilder
    {
        IPizzaBuilder SetSize(string size);
        IPizzaBuilder BuildCrust();
        IPizzaBuilder BuildSauce();
        IPizzaBuilder AddCheese();
        IPizzaBuilder BuildToppings();
        Pizza GetPizza();
        void Reset();
    }

    // Concrete Builder for Thin Crust Pizza
    public class ThinCrustPizzaBuilder : IPizzaBuilder
    {
        private Pizza _pizza = new Pizza();

        public IPizzaBuilder SetSize(string size)
        {
            _pizza.Size = size;
            return this;
        }

        public IPizzaBuilder BuildCrust()
        {
            _pizza.Crust = "thin and crispy";
            return this;
        }

        public IPizzaBuilder BuildSauce()
        {
            _pizza.Sauce = "marinara";
            return this;
        }

        public IPizzaBuilder AddCheese()
        {
            _pizza.HasCheese = true;
            return this;
        }

        public IPizzaBuilder BuildToppings()
        {
            _pizza.Toppings.Add("pepperoni");
            _pizza.Toppings.Add("mushrooms");
            _pizza.Toppings.Add("bell peppers");
            return this;
        }

        public Pizza GetPizza()
        {
            var result = _pizza;
            Reset();
            return result;
        }

        public void Reset()
        {
            _pizza = new Pizza();
        }
    }

    // Concrete Builder for Deep Dish Pizza
    public class DeepDishPizzaBuilder : IPizzaBuilder
    {
        private Pizza _pizza = new Pizza();

        public IPizzaBuilder SetSize(string size)
        {
            _pizza.Size = size;
            return this;
        }

        public IPizzaBuilder BuildCrust()
        {
            _pizza.Crust = "thick deep dish";
            return this;
        }

        public IPizzaBuilder BuildSauce()
        {
            _pizza.Sauce = "rich tomato sauce";
            return this;
        }

        public IPizzaBuilder AddCheese()
        {
            _pizza.HasCheese = true;
            return this;
        }

        public IPizzaBuilder BuildToppings()
        {
            _pizza.Toppings.Add("italian sausage");
            _pizza.Toppings.Add("green peppers");
            _pizza.Toppings.Add("onions");
            _pizza.Toppings.Add("extra cheese");
            return this;
        }

        public Pizza GetPizza()
        {
            var result = _pizza;
            Reset();
            return result;
        }

        public void Reset()
        {
            _pizza = new Pizza();
        }
    }

    // The Director class
    public class PizzaDirector
    {
        private IPizzaBuilder _builder;

        public PizzaDirector(IPizzaBuilder builder)
        {
            _builder = builder;
        }

        public Pizza MakeSmallPizza()
        {
            return _builder
                .SetSize("Small")
                .BuildCrust()
                .BuildSauce()
                .AddCheese()
                .BuildToppings()
                .GetPizza();
        }

        public Pizza MakeLargePizza()
        {
            return _builder
                .SetSize("Large")
                .BuildCrust()
                .BuildSauce()
                .AddCheese()
                .BuildToppings()
                .GetPizza();
        }

        public Pizza MakeCustomPizza(string size, bool withCheese, bool withToppings)
        {
            var builder = _builder.SetSize(size).BuildCrust().BuildSauce();
            
            if (withCheese)
                builder = builder.AddCheese();
            
            if (withToppings)
                builder = builder.BuildToppings();
            
            return builder.GetPizza();
        }
    }

    // Demo class
    public class BuilderPatternDemo
    {
        public static void RunDemo()
        {
            Console.WriteLine("=== Builder Pattern Demo ===");

            // Using Director with Thin Crust Builder
            Console.WriteLine("\n--- Using Director with Thin Crust ---");
            var thinCrustBuilder = new ThinCrustPizzaBuilder();
            var director = new PizzaDirector(thinCrustBuilder);

            var smallThinPizza = director.MakeSmallPizza();
            smallThinPizza.Display();

            // Using Director with Deep Dish Builder
            Console.WriteLine("\n--- Using Director with Deep Dish ---");
            var deepDishBuilder = new DeepDishPizzaBuilder();
            director = new PizzaDirector(deepDishBuilder);

            var largeDeepDishPizza = director.MakeLargePizza();
            largeDeepDishPizza.Display();

            // Direct builder usage (without Director)
            Console.WriteLine("\n--- Direct Builder Usage ---");
            var customPizza = new ThinCrustPizzaBuilder()
                .SetSize("Medium")
                .BuildCrust()
                .BuildSauce()
                .AddCheese()
                .GetPizza(); // No toppings

            customPizza.Display();
        }
    }
}