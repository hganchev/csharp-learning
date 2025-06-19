using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using DesignPatterns.AbstractFactory;

[TestClass]
public class UIThemeTests
{    private StringWriter _stringWriter = null!;
    private IUIThemeFactory _factory = null!;
    private UIThemeClient _client = null!;

    [TestInitialize]
    public void Initialize()
    {
        // Redirect Console output to a StringWriter
        _stringWriter = new StringWriter();
        Console.SetOut(_stringWriter);

        // Set up the factory and client
        _factory = new LightThemeFactory();
        _client = new UIThemeClient(_factory);
    }

    [TestCleanup]
    public void Cleanup()
    {
        // Reset Console output to the original
        Console.SetOut(new StreamWriter(Console.OpenStandardOutput()));
        _stringWriter.Dispose();
    }

    [TestMethod]
    public void TestLightTheme()
    {
        // Arrange
        var expectedButtonColor = "Light Gray";
        var expectedLabelColor = "Black";
        var expectedTextBoxColor = "White";

        // Act
        var actualButtonColor = _client.Button.Color;
        var actualLabelColor = _client.Label.Color;
        var actualTextBoxColor = _client.TextBox.Color;

        // Assert
        Assert.AreEqual(expectedButtonColor, actualButtonColor);
        Assert.AreEqual(expectedLabelColor, actualLabelColor);
        Assert.AreEqual(expectedTextBoxColor, actualTextBoxColor);
        Assert.IsInstanceOfType(_client.Button, typeof(LightButton));
        Assert.IsInstanceOfType(_client.Label, typeof(LightLabel));
        Assert.IsInstanceOfType(_client.TextBox, typeof(LightTextBox));
    }

    [TestMethod]
    public void TestDarkTheme()
    {
        // Arrange
        _factory = new DarkThemeFactory();
        _client = new UIThemeClient(_factory);
        var expectedButtonColor = "Dark Gray";
        var expectedLabelColor = "Light Gray";
        var expectedTextBoxColor = "Black";

        // Act
        var actualButtonColor = _client.Button.Color;
        var actualLabelColor = _client.Label.Color;
        var actualTextBoxColor = _client.TextBox.Color;

        // Assert
        Assert.AreEqual(expectedButtonColor, actualButtonColor);
        Assert.AreEqual(expectedLabelColor, actualLabelColor);
        Assert.AreEqual(expectedTextBoxColor, actualTextBoxColor);
        Assert.IsInstanceOfType(_client.Button, typeof(DarkButton));
        Assert.IsInstanceOfType(_client.Label, typeof(DarkLabel));
        Assert.IsInstanceOfType(_client.TextBox, typeof(DarkTextBox));
    }

    [TestMethod]
    public void TestClientInteraction()
    {
        // Arrange & Act
        _client.Paint();
        _client.InteractWithUI();

        // Assert - no exceptions should be thrown
        var output = _stringWriter.ToString();
        Assert.IsTrue(output.Contains("Painting UI components"));
        Assert.IsTrue(output.Contains("Light theme"));
    }
}
