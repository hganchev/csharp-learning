using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class PizzaBuilderTests
{
    [TestMethod]
    public void BuildThinCrustPizza()
    {
        // Arrange
        var builder = new ThinCrustPizzaBuilder();
        var director = new PizzaDirector(builder);

        // Act
        director.BuildPizza();
        var pizza = builder.GetPizza();

        // Assert
        Assert.AreEqual("thin", pizza.Crust);
        Assert.AreEqual("marinara", pizza.Sauce);
        Assert.AreEqual(3, pizza.Toppings.Count);
        CollectionAssert.Contains(pizza.Toppings, "cheese");
        CollectionAssert.Contains(pizza.Toppings, "pepperoni");
        CollectionAssert.Contains(pizza.Toppings, "mushrooms");
    }

    [TestMethod]
    public void BuildDeepDishPizza()
    {
        // Arrange
        var builder = new DeepDishPizzaBuilder();
        var director = new PizzaDirector(builder);

        // Act
        director.BuildPizza();
        var pizza = builder.GetPizza();

        // Assert
        Assert.AreEqual("deep dish", pizza.Crust);
        Assert.AreEqual("tomato", pizza.Sauce);
        Assert.AreEqual(3, pizza.Toppings.Count);
        CollectionAssert.Contains(pizza.Toppings, "sausage");
        CollectionAssert.Contains(pizza.Toppings, "peppers");
        CollectionAssert.Contains(pizza.Toppings, "onions");
    }
}
