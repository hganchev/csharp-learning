using System;
namespace SOLID
{
    // ISP - Interface Segregation Principle -Many client-specific interfaces are better than one general-purpose interface
    class ISP
    {
        public ISP()
        {
            Console.WriteLine(@"ISP - Many client-specific interfaces are better than one general-purpose interface. 
            Interface of a program should be split in a way that the 
            user/client would only have access to the necessary methods related to their needs");
            var myTiger = new Tiger();
            myTiger.Carnivarous();
            var myRacoon = new Raccoon();
            myRacoon.Carnivarous();
            myRacoon.Herbivorous();
        }
    }

    // We will take the interfaces from exaple of LSP - Predator and Mamal
    public interface bothMammalAndPredator: Predator
    {
         public void Herbivorous();
    }
    class Tiger : Predator
    {
        public void Carnivarous()
        {
            Console.WriteLine("The tiger is predator and eat meat");
        }
    }

    class Raccoon: bothMammalAndPredator
    {
        public void Carnivarous()
        {
            Console.WriteLine("The Raccoon is predator and eat meat");
        }

        public void Herbivorous()
        {
            Console.WriteLine("The Raccoon is mammal and eat grass");
        }
    }
}