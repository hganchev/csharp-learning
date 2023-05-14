// The Product class
public class Pizza
{
    public string Crust { get; set; }
    public string Sauce { get; set; }
    public List<string> Toppings { get; set; }

    public Pizza()
    {
        Toppings = new List<string>();
    }

    public void Display()
    {
        Console.WriteLine("Pizza with {0} crust, {1} sauce, and {2} toppings:", Crust, Sauce, Toppings.Count);
        foreach (var topping in Toppings)
        {
            Console.WriteLine("- {0}", topping);
        }
    }
}

// The Builder interface
public interface IPizzaBuilder
{
    void BuildCrust();
    void BuildSauce();
    void BuildToppings();
    Pizza GetPizza();
}

// The ConcreteBuilder classes
public class ThinCrustPizzaBuilder : IPizzaBuilder
{
    private Pizza _pizza = new Pizza();

    public void BuildCrust()
    {
        _pizza.Crust = "thin";
    }

    public void BuildSauce()
    {
        _pizza.Sauce = "marinara";
    }

    public void BuildToppings()
    {
        _pizza.Toppings.Add("cheese");
        _pizza.Toppings.Add("pepperoni");
        _pizza.Toppings.Add("mushrooms");
    }

    public Pizza GetPizza()
    {
        return _pizza;
    }
}

public class DeepDishPizzaBuilder : IPizzaBuilder
{
    private Pizza _pizza = new Pizza();

    public void BuildCrust()
    {
        _pizza.Crust = "deep dish";
    }

    public void BuildSauce()
    {
        _pizza.Sauce = "tomato";
    }

    public void BuildToppings()
    {
        _pizza.Toppings.Add("sausage");
        _pizza.Toppings.Add("peppers");
        _pizza.Toppings.Add("onions");
    }

    public Pizza GetPizza()
    {
        return _pizza;
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

    public void BuildPizza()
    {
        _builder.BuildCrust();
        _builder.BuildSauce();
        _builder.BuildToppings();
    }
}