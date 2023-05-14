using System;
namespace Imperative
{
    class Procedural
    {
        // Procedural programming can also be referred to as imperative programming. 
        // It is a programming paradigm based upon the concept of procedure calls, 
        // They are a list of instructions to tell the computer what to do step by step, 
        // Procedural programming languages are known as top-down languages. Most of the early 
        // programming languages are all procedural.
        public Procedural()
        {
            StepOne();
            StepTwo();
            StepThree();
        }

        void StepOne()
        {
            Console.WriteLine("This is step One");
        }

        void StepTwo()
        {
            Console.WriteLine("This is step Two");
        }

        void StepThree()
        {
            Console.WriteLine("This is step Three");
        }

    }
}