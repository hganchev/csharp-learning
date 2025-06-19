// Abstract Factory Pattern Example
// This pattern provides an interface for creating families of related objects
// without specifying their concrete classes.

namespace DesignPatterns.AbstractFactory
{
    // The Abstract Factory interface
    public interface IUIThemeFactory
    {
        IButton CreateButton();
        ILabel CreateLabel();
        ITextBox CreateTextBox();
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

        public ITextBox CreateTextBox()
        {
            return new LightTextBox();
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

        public ITextBox CreateTextBox()
        {
            return new DarkTextBox();
        }
    }

    // The Abstract Product interfaces
    public interface IButton
    {
        string Color { get; set; }
        void Paint();
        void Click();
    }

    public interface ILabel
    {
        string Color { get; set; }
        void Paint();
        void SetText(string text);
    }

    public interface ITextBox
    {
        string Color { get; set; }
        void Paint();
        void SetText(string text);
        string GetText();
    }

    // Light Theme Products
    public class LightButton : IButton
    {
        public string Color { get; set; } = "Light Gray";

        public void Paint()
        {
            Console.WriteLine($"Light theme button painted with {Color} background");
        }

        public void Click()
        {
            Console.WriteLine("Light button clicked with subtle animation");
        }
    }

    public class LightLabel : ILabel
    {
        public string Color { get; set; } = "Black";
        private string _text = "";

        public void Paint()
        {
            Console.WriteLine($"Light theme label painted with {Color} text");
        }

        public void SetText(string text)
        {
            _text = text;
            Console.WriteLine($"Light label text set to: {text}");
        }
    }

    public class LightTextBox : ITextBox
    {
        public string Color { get; set; } = "White";
        private string _text = "";

        public void Paint()
        {
            Console.WriteLine($"Light theme textbox painted with {Color} background");
        }

        public void SetText(string text)
        {
            _text = text;
            Console.WriteLine($"Light textbox text set to: {text}");
        }

        public string GetText()
        {
            return _text;
        }
    }

    // Dark Theme Products
    public class DarkButton : IButton
    {
        public string Color { get; set; } = "Dark Gray";

        public void Paint()
        {
            Console.WriteLine($"Dark theme button painted with {Color} background");
        }

        public void Click()
        {
            Console.WriteLine("Dark button clicked with glow effect");
        }
    }

    public class DarkLabel : ILabel
    {
        public string Color { get; set; } = "Light Gray";
        private string _text = "";

        public void Paint()
        {
            Console.WriteLine($"Dark theme label painted with {Color} text");
        }

        public void SetText(string text)
        {
            _text = text;
            Console.WriteLine($"Dark label text set to: {text}");
        }
    }

    public class DarkTextBox : ITextBox
    {
        public string Color { get; set; } = "Black";
        private string _text = "";

        public void Paint()
        {
            Console.WriteLine($"Dark theme textbox painted with {Color} background");
        }

        public void SetText(string text)
        {
            _text = text;
            Console.WriteLine($"Dark textbox text set to: {text}");
        }

        public string GetText()
        {
            return _text;
        }
    }

    // The Client class
    public class UIThemeClient
    {
        private readonly IUIThemeFactory _factory;
        public IButton Button { get; private set; }
        public ILabel Label { get; private set; }
        public ITextBox TextBox { get; private set; }

        public UIThemeClient(IUIThemeFactory factory)
        {
            _factory = factory;
            Button = factory.CreateButton();
            Label = factory.CreateLabel();
            TextBox = factory.CreateTextBox();
        }

        public void Paint()
        {
            Console.WriteLine("Painting UI components:");
            Button.Paint();
            Label.Paint();
            TextBox.Paint();
        }

        public void InteractWithUI()
        {
            Button.Click();
            Label.SetText("Welcome to the application!");
            TextBox.SetText("Type your message here...");
        }
    }

    // Demo class
    public class AbstractFactoryPatternDemo
    {
        public static void RunDemo()
        {
            Console.WriteLine("=== Abstract Factory Pattern Demo ===");

            // Light Theme
            Console.WriteLine("\n--- Light Theme ---");
            var lightThemeFactory = new LightThemeFactory();
            var lightClient = new UIThemeClient(lightThemeFactory);
            lightClient.Paint();
            lightClient.InteractWithUI();

            // Dark Theme
            Console.WriteLine("\n--- Dark Theme ---");
            var darkThemeFactory = new DarkThemeFactory();
            var darkClient = new UIThemeClient(darkThemeFactory);
            darkClient.Paint();
            darkClient.InteractWithUI();
        }
    }
}
