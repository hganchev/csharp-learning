using System;
namespace Classes
{
    class Calculator
    {
        public double Add(double x, double y)
        {
            return x+y;
        }

        public double Subscract(double x, double y)
        {
            return x-y;
        }

        public double Multiply(double x, double y)
        {
            return x*y;
        }

        public double Divide(double x, double y)
        {
            return x/y;
        }

        public bool isOdd(int x)
        {
            return x%2==1;
        }
    }
}