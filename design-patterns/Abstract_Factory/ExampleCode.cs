public class ExampleCode
{
    private string output = String.Empty;
    public string Output
    {
        get { return output; }
        set { output = value; }
    }
    
    public void DoSomething(string type)
    {
        if (type == "A")
        {
            // Do something for type A
            Output = "this is type A";
            Console.WriteLine(Output);
        }
        else if (type == "B")
        {
            // Do something for type B
            Output = "this is type B";
            Console.WriteLine(Output);
        }
        else
        {
            throw new ArgumentException("Invalid type");
        }
    }
}
