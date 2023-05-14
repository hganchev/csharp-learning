using System;
namespace app
{
    class Program
    {
        static void Main(string[] args)
        {
            // ========================= OOP Programming examples ============================================== 
            // Object-oriented programming (OOP) is a programming paradigm that is based on the concept of "objects", which are instances of 
            // classes that encapsulate data and behavior. OOP is used for a variety of purposes, including:
            // ~ Modeling real-world objects and their relationships: OOP can be used to create software that mirrors the structure and behavior 
            // of real-world objects, making it easier to understand and reason about the system.
            // ~ Encapsulation and data hiding: OOP allows developers to encapsulate data and behavior within objects, making it easy to hide 
            // implementation details and protect the integrity of the data.
            // ~ Reusability and extensibility: OOP encourages the use of reusable and extensible code, by allowing developers to create classes 
            // and objects that can be reused across multiple projects.
            // ~ Modularity and maintainability: OOP promotes the development of modular, maintainable code by allowing developers to organize their 
            // code into self-contained objects.
            // ~ Concurrency and parallelism: OOP can be used to develop concurrent and parallel systems, by creating objects that can be executed 
            // independently of each other.
            #region OOP Examples
            OOP.Flowers myFlower = new OOP.Flowers(); // example of instantiation of the object(class)
            Console.WriteLine(myFlower.Color);
            myFlower.LeafsCount();
            myFlower.AddWater();

            OOP.Rose myRose = new OOP.Rose(); // example of instantiation child class
            Console.WriteLine(myRose.Color);
            myRose.LeafsCount();

            OOP.Orchid myOrchid = new OOP.Orchid(); // example of instantiation child class
            Console.WriteLine(myOrchid.Color);
            myOrchid.LeafsCount();

            OOP.Daisy myDaisy = new OOP.Daisy(); // example of instantiation child class
            Console.WriteLine(myDaisy.Color);
            myDaisy.AddWater();

            OOP.RoadBike myBike = new OOP.RoadBike(); // example of instantiation child class
            myBike.GetWeight();

            OOP.Magnolia myMagnolia = new OOP.Magnolia(); // example of instantiation child class
            myMagnolia.AddWater();
            myMagnolia.LeafsCount();

            OOP.WaterLevel myVar = OOP.WaterLevel.Medium; // You can access enum with dot syntax
            Console.WriteLine(myVar);
            #endregion
            // ========================= Functional Programming examples =======================================
            // Functional programming is a programming paradigm that emphasizes the use of pure functions, immutability, and the avoidance of side-effects. 
            // It is based on the mathematical concept of a function and the idea that a program can be thought of as a set of functions that transform data.
            // n functional programming, functions are first-class citizens, which means that they can be assigned to variables, passed as arguments to other 
            // functions, and returned as values from functions. Functions are also pure, meaning that they do not have any side-effects and always return the same 
            // output for the same input.
            // n this example, the function Factorial takes an integer as input and returns an integer as output. It does not have any side-effects and always 
            // return the same output for the same input.
            // unctional programming is used for a variety of purposes, including:

            // ~ Simplifying code: Functional programming can make code simpler and easier to understand by breaking it down into smaller, pure functions that 
            // are easy to reason about.

            // ~ Improving code quality: Functional programming can improve the quality of code by promoting the use of immutability, which can make it easier 
            // to test, debug, and reason about.

            // ~ Concurrency and parallelism: Functional programming can make it easier to write concurrent and parallel code by promoting the use of pure 
            // functions, which do not have side-effects and are easy to reason about.

            // ~ Data processing: Functional programming can be used to efficiently process large amounts of data by using functional concepts such as map, 
            // filter, and reduce.

            // ~ Reusability: Functional programming allows to create reusable components, it can help to keep the codebase clean and maintainable by breaking 
            // it down into small, focused, and testable functions.

            // Functional programming is a powerful paradigm that can be used to improve the quality and maintainability of code, especially when working with 
            // large or complex systems. It can be used in combination with other paradigms like object-oriented programming or imperative programming.
            #region Functional Examples
            var myFunc = new Functional.Functions();
            #endregion
            // ========================= Procedural Programming examples =======================================
            #region Procediral Examples
            var myProcedure = new Imperative.Procedural();
            #endregion
            // ========================= Event driven Programming examples =======================================
            // Event-driven programming is a programming paradigm that is based on the concept of events and event handlers. 
            // In event-driven programming, the program waits for events to occur, and then it responds to those events by executing one or more event handlers.

            // An event is a message that is sent by an object, often a system object, to indicate that something has happened. An event handler is a method that 
            // is executed in response to an event. Event handlers can be registered with the system or with an object, so that they are called when the event occurs.
            // Event-driven programming is used for a variety of purposes, including:

            // User interface programming: Event-driven programming is often used for user interface programming, where the program responds to user 
            // input such as button clicks, key presses, and mouse movements.

            // Network programming: Event-driven programming is used for network programming, where the program responds to network events such as incoming 
            // connections, incoming data, and disconnections.

            // Concurrency and parallelism: Event-driven programming can be used to improve the performance of concurrent and parallel systems by allowing the 
            // program to handle multiple events simultaneously.

            // Reusability and extensibility: Event-driven programming allows developers to create reusable and extensible code by allowing them to create 
            // event-driven components that can be used in different parts of the program.

            // Maintainability: Event-driven programming allows for a separation
            #region Event-Driven Examples
            var myPub = new EventDriven.Publisher();
            var mySub = new EventDriven.Subscriber();

            mySub.Subscribe(myPub);
            myPub.OnEvent();

            #endregion

             // ========================= Structured Programming examples =======================================
            #region Structured Examples
            var myStruct = new Structured.Structures();
            #endregion
        }
    }
}