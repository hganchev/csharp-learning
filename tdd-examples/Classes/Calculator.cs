using System;

namespace Classes
{
    /// <summary>
    /// A calculator class demonstrating TDD principles with proper error handling and validation
    /// </summary>
    public class Calculator
    {
        public double Add(double x, double y)
        {
            if (double.IsInfinity(x) || double.IsInfinity(y))
                throw new ArgumentException("Cannot perform operation with infinite values");
            
            var result = x + y;
            if (double.IsInfinity(result))
                throw new OverflowException("Operation resulted in overflow");
                
            return result;
        }

        public double Subtract(double x, double y)
        {
            if (double.IsInfinity(x) || double.IsInfinity(y))
                throw new ArgumentException("Cannot perform operation with infinite values");
                
            var result = x - y;
            if (double.IsInfinity(result))
                throw new OverflowException("Operation resulted in overflow");
                
            return result;
        }

        public double Multiply(double x, double y)
        {
            if (double.IsInfinity(x) || double.IsInfinity(y))
                throw new ArgumentException("Cannot perform operation with infinite values");
                
            var result = x * y;
            if (double.IsInfinity(result))
                throw new OverflowException("Operation resulted in overflow");
                
            return result;
        }

        public double Divide(double x, double y)
        {
            if (double.IsInfinity(x) || double.IsInfinity(y))
                throw new ArgumentException("Cannot perform operation with infinite values");
                
            if (y == 0)
                throw new DivideByZeroException("Cannot divide by zero");
                
            return x / y;
        }

        public bool IsOdd(int x)
        {
            return x % 2 == 1;
        }

        public bool IsEven(int x)
        {
            return x % 2 == 0;
        }

        public double Power(double baseNumber, double exponent)
        {
            if (double.IsInfinity(baseNumber) || double.IsInfinity(exponent))
                throw new ArgumentException("Cannot perform operation with infinite values");
                
            var result = Math.Pow(baseNumber, exponent);
            
            if (double.IsInfinity(result))
                throw new OverflowException("Operation resulted in overflow");
            if (double.IsNaN(result))
                throw new ArgumentException("Invalid operation resulted in NaN");
                
            return result;
        }

        public double SquareRoot(double x)
        {
            if (x < 0)
                throw new ArgumentException("Cannot calculate square root of negative number");
                
            return Math.Sqrt(x);
        }
    }
}