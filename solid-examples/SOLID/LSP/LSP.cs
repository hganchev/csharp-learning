using System;
namespace SOLID
{
    // LSP - Liskov Substitution Principle - when an instance of a class is passed/extended to another class, the inheriting class should have a use case for all the properties and behavior of the inherited class
    class LSP
    {
        public LSP()
        {
            Console.WriteLine(@"LSP - when an instance of a class is passed/extended to another class, 
            the inheriting class should have a use case for all the properties and behavior of the inherited class");
            var myLion = new Lion();
            myLion.Carnivarous();
            myLion.Herbivorous(); // not useful for this class
        }
    }

    public class Animal
    {
        public void Carnivarous()
        {

        }
        public void Herbivorous()
        {

        }
    }

    public class Lion: Animal
    {
        public void Carnivarous()
        {
            Console.WriteLine("The Lion is carnivarous animal");
        }
        public void Herbivorous() // not useful for this class
        {
            Console.WriteLine("The Lion is not Herbivorous animal: Not Useful!");
        }
    }

    // The solution to this is simple: create interfaces that match the needs of the inheriting class.
    public interface Predator
    {
        public void Carnivarous();
    }

    public interface Mammal
    {
        public void Herbivorous();
    }
}