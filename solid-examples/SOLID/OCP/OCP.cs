using System;
using System.Collections.Generic;

namespace SOLID
{
    /// <summary>
    /// OCP - Open/Closed Principle
    /// Definition: Software entities (classes, modules, functions) should be OPEN for extension 
    /// but CLOSED for modification.
    /// </summary>
    class OCP
    {
        public OCP()
        {
            Console.WriteLine("=== Open/Closed Principle (OCP) ===");
            Console.WriteLine("Classes should be open for extension but closed for modification.\n");

            // Problem Example - Violating OCP
            Console.WriteLine("PROBLEM - Violating OCP:");
            var calculator = new AreaCalculatorProblem();
            var circle = new CircleProblem(5);
            var rectangle = new RectangleProblem(4, 6);
            
            Console.WriteLine($"Circle area: {calculator.CalculateArea(circle)}");
            Console.WriteLine($"Rectangle area: {calculator.CalculateArea(rectangle)}");
            Console.WriteLine("Adding a new shape requires modifying the AreaCalculator class!\n");

            // Solution Example - Following OCP
            Console.WriteLine("SOLUTION - Following OCP:");
            var betterCalculator = new AreaCalculatorSolution();
            var shapes = new List<IShape>
            {
                new Circle(5),
                new Rectangle(4, 6),
                new Triangle(3, 8) // New shape added without modifying existing code!
            };

            foreach (var shape in shapes)
            {
                Console.WriteLine($"{shape.GetType().Name} area: {betterCalculator.CalculateArea(shape)}");
            }
        }
    }

    #region Problem - Violating OCP
    /// <summary>
    /// PROBLEM: This calculator violates OCP because every time we add a new shape,
    /// we need to modify this class by adding new if-else conditions.
    /// </summary>
    class AreaCalculatorProblem
    {
        public double CalculateArea(object shape)
        {
            if (shape is CircleProblem circle)
            {
                return Math.PI * circle.Radius * circle.Radius;
            }
            else if (shape is RectangleProblem rectangle)
            {
                return rectangle.Width * rectangle.Height;
            }
            // Every new shape requires modifying this method!
            // else if (shape is TriangleProblem triangle)
            // {
            //     return 0.5 * triangle.Base * triangle.Height;
            // }
            
            throw new ArgumentException("Unknown shape type");
        }
    }

    class CircleProblem
    {
        public double Radius { get; set; }
        public CircleProblem(double radius) => Radius = radius;
    }

    class RectangleProblem
    {
        public double Width { get; set; }
        public double Height { get; set; }
        public RectangleProblem(double width, double height)
        {
            Width = width;
            Height = height;
        }
    }
    #endregion

    #region Solution - Following OCP
    /// <summary>
    /// SOLUTION: Using abstraction to follow OCP
    /// </summary>
    
    // Abstract interface that all shapes must implement
    interface IShape
    {
        double CalculateArea();
    }

    // Calculator that works with any shape implementing IShape
    // This class is CLOSED for modification but OPEN for extension
    class AreaCalculatorSolution
    {
        public double CalculateArea(IShape shape)
        {
            return shape.CalculateArea(); // Polymorphism handles the rest
        }

        public double CalculateTotalArea(IEnumerable<IShape> shapes)
        {
            double total = 0;
            foreach (var shape in shapes)
            {
                total += shape.CalculateArea();
            }
            return total;
        }
    }

    // Each shape implements its own area calculation
    class Circle : IShape
    {
        public double Radius { get; set; }
        public Circle(double radius) => Radius = radius;

        public double CalculateArea()
        {
            return Math.PI * Radius * Radius;
        }
    }

    class Rectangle : IShape
    {
        public double Width { get; set; }
        public double Height { get; set; }
        
        public Rectangle(double width, double height)
        {
            Width = width;
            Height = height;
        }

        public double CalculateArea()
        {
            return Width * Height;
        }
    }

    // New shape can be added without modifying existing code!
    class Triangle : IShape
    {
        public double Base { get; set; }
        public double Height { get; set; }
        
        public Triangle(double baseLength, double height)
        {
            Base = baseLength;
            Height = height;
        }

        public double CalculateArea()
        {
            return 0.5 * Base * Height;
        }
    }
    #endregion
}