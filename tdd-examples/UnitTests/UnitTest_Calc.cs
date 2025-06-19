using System;
using Xunit;

namespace UnitTest
{
    public class UnitTest_Calc
    {
        private readonly Classes.Calculator _calculator;

        public UnitTest_Calc()
        {
            _calculator = new Classes.Calculator();
        }

        #region Add Tests
        
        [Fact]
        public void Add_WithPositiveNumbers_ReturnsCorrectSum()
        {
            // Arrange
            double x = 5;
            double y = 5;
            double expected = 10;

            // Act
            double result = _calculator.Add(x, y);

            // Assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(0, 0, 0)]
        [InlineData(1, 2, 3)]
        [InlineData(-1, 1, 0)]
        [InlineData(-5, -3, -8)]
        [InlineData(10.5, 2.3, 12.8)]
        public void Add_WithVariousInputs_ReturnsCorrectSum(double x, double y, double expected)
        {
            // Act
            double result = _calculator.Add(x, y);

            // Assert
            Assert.Equal(expected, result, 10); // 10 decimal places precision
        }

        [Fact]
        public void Add_WithInfiniteValues_ThrowsArgumentException()
        {
            // Arrange & Act & Assert
            Assert.Throws<ArgumentException>(() => _calculator.Add(double.PositiveInfinity, 5));
            Assert.Throws<ArgumentException>(() => _calculator.Add(5, double.NegativeInfinity));
        }

        #endregion

        #region Subtract Tests

        [Theory]
        [InlineData(10, 5, 5)]
        [InlineData(0, 0, 0)]
        [InlineData(-5, -3, -2)]
        [InlineData(3.7, 1.2, 2.5)]
        public void Subtract_WithVariousInputs_ReturnsCorrectDifference(double x, double y, double expected)
        {
            // Act
            double result = _calculator.Subtract(x, y);

            // Assert
            Assert.Equal(expected, result, 10);
        }

        #endregion

        #region Divide Tests

        [Theory]
        [InlineData(8, 4, 2)]
        [InlineData(5, 2, 2.5)]
        [InlineData(10, 2, 5)]
        [InlineData(-10, 2, -5)]
        [InlineData(10, -2, -5)]
        public void Divide_WithValidInputs_ReturnsCorrectQuotient(double dividend, double divisor, double expected)
        {
            // Act
            double result = _calculator.Divide(dividend, divisor);

            // Assert
            Assert.Equal(expected, result, 10);
        }

        [Fact]
        public void Divide_ByZero_ThrowsDivideByZeroException()
        {
            // Arrange & Act & Assert
            Assert.Throws<DivideByZeroException>(() => _calculator.Divide(10, 0));
        }

        #endregion

        #region Multiply Tests

        [Theory]
        [InlineData(3, 4, 12)]
        [InlineData(0, 5, 0)]
        [InlineData(-2, 3, -6)]
        [InlineData(-2, -3, 6)]
        [InlineData(2.5, 4, 10)]
        public void Multiply_WithVariousInputs_ReturnsCorrectProduct(double x, double y, double expected)
        {
            // Act
            double result = _calculator.Multiply(x, y);

            // Assert
            Assert.Equal(expected, result, 10);
        }

        #endregion

        #region IsOdd Tests

        [Theory]
        [InlineData(3)]
        [InlineData(5)]
        [InlineData(1)]
        [InlineData(-1)]
        [InlineData(-3)]
        public void IsOdd_WithOddNumbers_ReturnsTrue(int value)
        {
            // Act
            bool result = _calculator.IsOdd(value);

            // Assert
            Assert.True(result);
        }

        [Theory]
        [InlineData(2)]
        [InlineData(4)]
        [InlineData(0)]
        [InlineData(-2)]
        [InlineData(-4)]
        public void IsOdd_WithEvenNumbers_ReturnsFalse(int value)
        {
            // Act
            bool result = _calculator.IsOdd(value);

            // Assert
            Assert.False(result);
        }

        #endregion

        #region IsEven Tests

        [Theory]
        [InlineData(2)]
        [InlineData(4)]
        [InlineData(0)]
        [InlineData(-2)]
        public void IsEven_WithEvenNumbers_ReturnsTrue(int value)
        {
            // Act
            bool result = _calculator.IsEven(value);

            // Assert
            Assert.True(result);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(3)]
        [InlineData(-1)]
        [InlineData(-3)]
        public void IsEven_WithOddNumbers_ReturnsFalse(int value)
        {
            // Act
            bool result = _calculator.IsEven(value);

            // Assert
            Assert.False(result);
        }

        #endregion

        #region Power Tests

        [Theory]
        [InlineData(2, 3, 8)]
        [InlineData(5, 2, 25)]
        [InlineData(10, 0, 1)]
        [InlineData(0, 5, 0)]
        [InlineData(2, -2, 0.25)]
        public void Power_WithValidInputs_ReturnsCorrectResult(double baseNumber, double exponent, double expected)
        {
            // Act
            double result = _calculator.Power(baseNumber, exponent);

            // Assert
            Assert.Equal(expected, result, 10);
        }

        [Fact]
        public void Power_WithNegativeBaseAndFractionalExponent_ThrowsArgumentException()
        {
            // Arrange & Act & Assert
            Assert.Throws<ArgumentException>(() => _calculator.Power(-2, 0.5));
        }

        #endregion

        #region SquareRoot Tests

        [Theory]
        [InlineData(9, 3)]
        [InlineData(16, 4)]
        [InlineData(25, 5)]
        [InlineData(0, 0)]
        [InlineData(2, 1.4142135623730951)]
        public void SquareRoot_WithPositiveNumbers_ReturnsCorrectResult(double input, double expected)
        {
            // Act
            double result = _calculator.SquareRoot(input);

            // Assert
            Assert.Equal(expected, result, 10);
        }

        [Fact]
        public void SquareRoot_WithNegativeNumber_ThrowsArgumentException()
        {
            // Arrange & Act & Assert
            Assert.Throws<ArgumentException>(() => _calculator.SquareRoot(-1));
        }

        #endregion
    }
}