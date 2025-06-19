using System;
using System.Collections.Generic;

namespace SOLID
{
    /// <summary>
    /// LSP - Liskov Substitution Principle
    /// Definition: Objects of a superclass should be replaceable with objects of its subclasses 
    /// without breaking the application. Derived classes must be substitutable for their base classes.
    /// </summary>
    class LSP
    {
        public LSP()
        {
            Console.WriteLine("=== Liskov Substitution Principle (LSP) ===");
            Console.WriteLine("Derived classes must be substitutable for their base classes.\n");

            // Problem Example - Violating LSP
            Console.WriteLine("PROBLEM - Violating LSP:");
            try
            {
                var birds = new List<BirdProblem>
                {
                    new SparrowProblem(),
                    new PenguinProblem() // This will cause issues!
                };

                foreach (var bird in birds)
                {
                    bird.Fly(); // Penguin can't fly - breaks LSP!
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            Console.WriteLine();

            // Solution Example - Following LSP
            Console.WriteLine("SOLUTION - Following LSP:");
            var flyingBirds = new List<IFlyingBird>
            {
                new Sparrow(),
                new Eagle()
            };

            var swimmingBirds = new List<ISwimmingBird>
            {
                new Penguin(),
                new Duck()
            };

            Console.WriteLine("Flying birds:");
            foreach (var bird in flyingBirds)
            {
                bird.Fly();
            }

            Console.WriteLine("\nSwimming birds:");
            foreach (var bird in swimmingBirds)
            {
                bird.Swim();
            }

            // Duck can both fly and swim
            var duck = new Duck();
            Console.WriteLine("\nDuck abilities:");
            duck.Fly();
            duck.Swim();
        }
    }

    #region Problem - Violating LSP
    /// <summary>
    /// PROBLEM: This hierarchy violates LSP because not all birds can fly.
    /// Penguin is forced to implement Fly() method inappropriately.
    /// </summary>
    abstract class BirdProblem
    {
        public abstract void Fly(); // Forces all birds to implement flying
    }

    class SparrowProblem : BirdProblem
    {
        public override void Fly()
        {
            Console.WriteLine("Sparrow is flying!");
        }
    }

    class PenguinProblem : BirdProblem
    {
        public override void Fly()
        {
            // Penguins can't fly! This violates LSP
            throw new NotSupportedException("Penguins cannot fly!");
        }
    }
    #endregion

    #region Solution - Following LSP
    /// <summary>
    /// SOLUTION: Use appropriate abstractions that don't force inappropriate behavior
    /// </summary>
    
    // Base interface for all birds
    interface IBird
    {
        void Eat();
        void MakeSound();
    }

    // Separate interface for birds that can fly
    interface IFlyingBird : IBird
    {
        void Fly();
    }

    // Separate interface for birds that can swim
    interface ISwimmingBird : IBird
    {
        void Swim();
    }

    class Sparrow : IFlyingBird
    {
        public void Eat()
        {
            Console.WriteLine("Sparrow is eating seeds");
        }

        public void MakeSound()
        {
            Console.WriteLine("Sparrow: Tweet tweet!");
        }

        public void Fly()
        {
            Console.WriteLine("Sparrow is flying gracefully!");
        }
    }

    class Eagle : IFlyingBird
    {
        public void Eat()
        {
            Console.WriteLine("Eagle is hunting prey");
        }

        public void MakeSound()
        {
            Console.WriteLine("Eagle: Screech!");
        }

        public void Fly()
        {
            Console.WriteLine("Eagle is soaring high!");
        }
    }

    class Penguin : ISwimmingBird
    {
        public void Eat()
        {
            Console.WriteLine("Penguin is eating fish");
        }

        public void MakeSound()
        {
            Console.WriteLine("Penguin: Squawk!");
        }

        public void Swim()
        {
            Console.WriteLine("Penguin is swimming underwater!");
        }
    }

    // Some birds can do both!
    class Duck : IFlyingBird, ISwimmingBird
    {
        public void Eat()
        {
            Console.WriteLine("Duck is eating breadcrumbs");
        }

        public void MakeSound()
        {
            Console.WriteLine("Duck: Quack quack!");
        }

        public void Fly()
        {
            Console.WriteLine("Duck is flying to the pond!");
        }

        public void Swim()
        {
            Console.WriteLine("Duck is swimming in the pond!");
        }
    }
    #endregion
}