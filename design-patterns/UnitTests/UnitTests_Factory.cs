using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class UnitTests_Factory
{
    [TestMethod]
    public void TestTypeAProcessor()
    {
        IFactory factory = new Factory();
        ITypeProcessor typeProcessor = factory.CreateTypeProcessor("A");

        Assert.IsInstanceOfType(typeProcessor, typeof(TypeAProcessor));

        typeProcessor.Process();

        string expectedOutput = "Process for type A";
        string actualOutput = typeProcessor.Output;
        Assert.AreEqual(expectedOutput, actualOutput);
    }

    [TestMethod]
    public void TestTypeBProcessor()
    {
        IFactory factory = new Factory();
        ITypeProcessor typeProcessor = factory.CreateTypeProcessor("B");

        Assert.IsInstanceOfType(typeProcessor, typeof(TypeBProcessor));

        typeProcessor.Process();

        string expectedOutput = "Process for type B";
        string actualOutput = typeProcessor.Output;
        Assert.AreEqual(expectedOutput, actualOutput);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void TestInvalidType()
    {
        IFactory factory = new Factory();
        ITypeProcessor typeProcessor = factory.CreateTypeProcessor("C");
    }
}
