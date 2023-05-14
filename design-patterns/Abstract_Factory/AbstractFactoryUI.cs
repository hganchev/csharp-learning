// The Abstract Factory interface
public interface IUIThemeFactory
{
    IButton CreateButton();
    ILabel CreateLabel();
}

// The Concrete Factory classes
public class LightThemeFactory : IUIThemeFactory
{
    public IButton CreateButton()
    {
        return new LightButton();
    }

    public ILabel CreateLabel()
    {
        return new LightLabel();
    }
}

public class DarkThemeFactory : IUIThemeFactory
{
    public IButton CreateButton()
    {
        return new DarkButton();
    }

    public ILabel CreateLabel()
    {
        return new DarkLabel();
    }
}

// The Abstract Product interfaces
public interface IButton
{
    public string Color { get; set; }
    void Paint();
}

public interface ILabel
{
    public string Color { get; set; }
    void Paint();
}

// The Concrete Product classes
public class LightButton : IButton
{
    public string Color { get; set; }

    public void Paint()
    {
        Console.WriteLine("Light button painted");
        Color = "Light";
    }
}

public class LightLabel : ILabel
{
    public string Color { get; set; }
    public void Paint()
    {
        Console.WriteLine("Light label painted");
        Color = "Light";
    }
}

public class DarkButton : IButton
{
    public string Color { get; set; }
    public void Paint()
    {
        Console.WriteLine("Dark button painted");
        Color = "Dark";
    }
}

public class DarkLabel : ILabel
{
    public string Color { get; set; }
    public void Paint()
    {
        Console.WriteLine("Dark label painted");
        Color = "Dark";
    }
}

// The Client class
public class UIThemeClient
{
    private IUIThemeFactory _factory;
    public IButton _button;
    public ILabel _label;

    public UIThemeClient(IUIThemeFactory factory)
    {
        _factory = factory;
        _button = factory.CreateButton();
        _label = factory.CreateLabel();
    }

    public void Paint()
    {
        _button.Paint();
        _label.Paint();
    }
}
