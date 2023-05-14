using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

[TestClass]
public class UIThemeTests
{
    private StringWriter _stringWriter;
    private IUIThemeFactory _factory;
    private UIThemeClient _client;

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
    }

    [TestMethod]
    public void TestLightTheme()
    {
        // Arrange
        var expectedButtonColor = "Light";
        var expectedLabelColor = "Light";

        // Act
        _client.Paint();
        var actualButtonColor = _client._button.Color;
        var actualLabelColor = _client._label.Color;

        // Assert
        Assert.AreEqual(expectedButtonColor, actualButtonColor);
        Assert.AreEqual(expectedLabelColor, actualLabelColor);
    }

    [TestMethod]
    public void TestDarkTheme()
    {
        // Arrange
        _factory = new DarkThemeFactory();
        _client = new UIThemeClient(_factory);
        var expectedButtonColor = "Dark";
        var expectedLabelColor = "Dark";

        // Act
        _client.Paint();
        var actualButtonColor = _client._button.Color;
        var actualLabelColor = _client._label.Color;

        // Assert
        Assert.AreEqual(expectedButtonColor, actualButtonColor);
        Assert.AreEqual(expectedLabelColor, actualLabelColor);
    }
}
