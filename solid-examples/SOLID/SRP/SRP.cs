using System;
namespace SOLID
{
    // SRP - Single Responcible Principe - every class should have only one responsibility
    class SRP
    {
        public SRP()
        {
            Console.WriteLine("SRP - every class should have only one responsibility");
            var myCat = new Cat();
            var myDog = new Dog();
            myCat.PurrPurr();
            myDog.Whoffwhoff();
        }
    }

    class Cat
    {
        public void PurrPurr()
        {
            Console.WriteLine("Purr");
        }
    }

    class Dog
    {
        public void Whoffwhoff()
        {
            Console.WriteLine("whoff");
        }
    }
}