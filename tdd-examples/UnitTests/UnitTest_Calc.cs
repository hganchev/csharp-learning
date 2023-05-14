using System;
using Xunit;
namespace UnitTest
{
    public class UnitTest_Calc
    {
        Classes.Calculator myCalc = new Classes.Calculator();

        // Unit test
        [Fact]
        public void TestCalculatorAdd()
        {
            Console.WriteLine("TestCalculatorAdd");
            Assert.Equal(10, myCalc.Add(5,5));
        }

        // Series of Theory tests
        [Theory]
        [InlineData(3)]
        //[InlineData(4)]
        [InlineData(5)]
        public void TestCalculatorIsOdd(int value)
        {
            Assert.True(myCalc.isOdd(value));
        }

        //Series of theory test with expected values
        [Theory]
        [InlineData(8,4,2)]
        [InlineData(5,2,2.5)]
        [InlineData(10,2,5)]
        public void TestCalculatorDivide(double value1,double value2, double expectedValue)
        {
            // Given

            // When
        
            // Then
            Assert.Equal(expectedValue, myCalc.Divide(value1,value2));
        }
    }

}