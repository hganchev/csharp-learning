using Microsoft.VisualStudio.TestTools.UnitTesting;
using DesignPatterns.Builder;

[TestClass]
public class PizzaBuilderTests
{    [TestMethod]
    public void BuildThinCrustPizza()
    {
        // Arrange
        var builder = new ThinCrustPizzaBuilder();
        var director = new PizzaDirector(builder);

        // Act
        var pizza = director.MakeSmallPizza();

        // Assert
        Assert.AreEqual("thin and crispy", pizza.Crust);
        Assert.AreEqual("marinara", pizza.Sauce);
        Assert.AreEqual("Small", pizza.Size);
        Assert.AreEqual(3, pizza.Toppings.Count);
        Assert.IsTrue(pizza.HasCheese);
        CollectionAssert.Contains(pizza.Toppings, "pepperoni");
        CollectionAssert.Contains(pizza.Toppings, "mushrooms");
        CollectionAssert.Contains(pizza.Toppings, "bell peppers");
    }

    [TestMethod]
    public void BuildDeepDishPizza()
    {
        // Arrange
        var builder = new DeepDishPizzaBuilder();
        var director = new PizzaDirector(builder);

        // Act
        var pizza = director.MakeLargePizza();

        // Assert
        Assert.AreEqual("thick deep dish", pizza.Crust);
        Assert.AreEqual("rich tomato sauce", pizza.Sauce);
        Assert.AreEqual("Large", pizza.Size);
        Assert.AreEqual(4, pizza.Toppings.Count);
        Assert.IsTrue(pizza.HasCheese);
        CollectionAssert.Contains(pizza.Toppings, "italian sausage");
        CollectionAssert.Contains(pizza.Toppings, "green peppers");
        CollectionAssert.Contains(pizza.Toppings, "onions");
        CollectionAssert.Contains(pizza.Toppings, "extra cheese");
    }

    [TestMethod]
    public void BuildCustomPizza()
    {
        // Arrange & Act
        var pizza = new ThinCrustPizzaBuilder()
            .SetSize("Large")
            .BuildCrust()
            .BuildSauce()
            .AddCheese()
            .BuildToppings()
            .GetPizza();

        // Assert
        Assert.AreEqual("Large", pizza.Size);
        Assert.AreEqual("thin and crispy", pizza.Crust);
        Assert.AreEqual("marinara", pizza.Sauce);
        Assert.IsTrue(pizza.HasCheese);
        Assert.AreEqual(3, pizza.Toppings.Count);
    }
}
