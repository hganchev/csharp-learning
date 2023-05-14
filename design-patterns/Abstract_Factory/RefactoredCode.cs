public interface IFactory
{
    ITypeProcessor CreateTypeProcessor(string type);
}

public interface ITypeProcessor
{
    public string Output { get; set; }

    void Process();
}

public class TypeAProcessor : ITypeProcessor
{
    private string output = String.Empty;
    public string Output
    {
        get { return output; }
        set { output = value; }
    }
    public void Process()
    {
        // Do something for type A
        Output = "Process for type A";
        Console.WriteLine(Output);
    }
}

public class TypeBProcessor : ITypeProcessor
{
    private string output = String.Empty;
    public string Output
    {
        get { return output; }
        set { output = value; }
    }
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
        switch (type)
        {
            case "A":
                return new TypeAProcessor();
            case "B":
                return new TypeBProcessor();
            default:
                throw new ArgumentException("Invalid type");
        }
    }
}
