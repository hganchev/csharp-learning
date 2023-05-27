using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class Tests
{
    
    [TestMethod]
    public void TestMethod1_OnlyPositive()
    {
        // Arrange
        string input = "5";
        string input2 = "11 21 35 4 25";

        // Act
        int result = Solution.Solution_1_FindClosestToZero(input, input2);
        int expected = 4;

        // Assert
        Assert.AreEqual(expected, result);
    }

    [TestMethod]
    public void TestMethod2_OnlyNegative()
    {
        // Arrange
        string input = "5";
        string input2 = "-10 -12 -31 -45 -5";

        // Act
        int result = Solution.Solution_1_FindClosestToZero(input, input2);
        int expected = -5;


        // Assert
        Assert.AreEqual(expected, result);
    }

    [TestMethod]
    public void TestMethod3_NegativeAndPositive()
    {
        // Arrange
        string input = "5";
        string input2 = "-10 -12 -31 45 -5";

        // Act
        int result = Solution.Solution_1_FindClosestToZero(input, input2);
        int expected = -5;

        // Assert
        Assert.AreEqual(expected, result);
    }

    [TestMethod]
    public void TestMethod4_EmptyStringInput()
    {
        // Arrange
        string input = "";
        string input2 = "";

        // Act
        int result = Solution.Solution_1_FindClosestToZero(input, input2);
        int expected = 0;

        // Assert
        Assert.AreEqual(expected, result);
    }
}