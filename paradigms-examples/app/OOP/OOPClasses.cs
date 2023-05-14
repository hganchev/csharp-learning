using System;
namespace app.OOP
{
    class Flowers // the class is the object
    {
        // Access modifiers
        // Modifier	Description
            // public	    The code is accessible for all classes
            // private	    The code is only accessible within the same class
            // protected	The code is accessible within the same class, or in a class that is inherited from that class. You will learn more about inheritance in a later chapter
            // internal	    The code is only accessible within its own assembly, but not from another assembly. You will learn more about this in a later chapter
        private int leafs = 10; // field of a class

        public void LeafsCount() // method of a class
        {
            Console.WriteLine("The flower has: " + leafs + " leafs");
        }

        // Properties and Encapsulation
        //     The meaning of Encapsulation, is to make sure that "sensitive" data is hidden from users. To achieve this, you must:
        //     declare fields/variables as private
        //     provide public get and set methods, through properties, to access and update the value of a private field
        private string color = "yellow"; // field of a class
        public string Color // property of the class
        {
            get { return color; }
            set { color = value; }
        }

        // Automatic Properties (Short Hand)
        public string family { get; set; }

        // Why Encapsulation?
        //     Better control of class members (reduce the possibility of yourself (or others) to mess up the code)
        //     Fields can be made read-only (if you only use the get method), or write-only (if you only use the set method)
        //     Flexible: the programmer can change one part of the code without affecting other parts
        //     Increased security of data

        // public Flowers(string flowerFamilyName) // Contstructor of a class
        // {
        //     family = flowerFamilyName;
        // }

        public virtual void AddWater()
        {
            Console.WriteLine("Adding 100 ml of water");
        }
    }

    // Inheritance (Derived and Base Class)
        //     In C#, it is possible to inherit fields and methods from one class to another. We group the "inheritance concept" into two categories:
        //     Derived Class (child) - the class that inherits from another class
        //     Base Class (parent) - the class being inherited from
        //     To inherit from a class, use the : symbol.
    class Rose : Flowers// derived class (child)
    {
        public bool hasThorns = true;
        private string color = "red"; // field of a class
        public string Color // property of the class
        {
            get { return color; }
            set { color = value; }
        }
    }

    //Polymorphism and Overriding Methods
        // Polymorphism means "many forms", and it occurs when we have many classes that are related to each other by inheritance.
        // Like we specified in the previous chapter; Inheritance lets us inherit fields and methods from another class. 
        // Polymorphism uses those methods to perform different tasks. This allows us to perform a single action in different ways.
    class Orchid : Flowers// derived class (child)
    {
        public bool hasThorns = false;
        private int leafs = 5; // field of a class
        public void LeafsCount()
        {
            Console.WriteLine("The flower has: " + leafs + " leafs");
        }
    }

    // C# provides an option to override the base class method, 
    // by adding the virtual keyword to the method inside the base class, 
    // and by using the override keyword for each derived class methods:

    class Daisy : Flowers
    {
        public override void AddWater()
        {
            Console.WriteLine("adding 200 ml of water");
        }
    }

    // Abstract Classes and Methods
    //     Data abstraction is the process of hiding certain details and showing only essential information to the user.
    //     Abstraction can be achieved with either abstract classes or interfaces (which you will learn more about in the next chapter).
    //     The abstract keyword is used for classes and methods:
    //     Abstract class: is a restricted class that cannot be used to create objects (to access it, it must be inherited from another class).
    //     Abstract method: can only be used in an abstract class, and it does not have a body. The body is provided by the derived class (inherited from).
    abstract class Bike
    {
        public abstract void GetWeight(); // abstract method
    }
    class RoadBike : Bike
    {
        public override void GetWeight()
        {
            Console.WriteLine("The RoadBike weight is from 4 to 10kg");
        }
    }

    // Interfaces
    // Another way to achieve abstraction in C#, is with interfaces.
    // An interface is a completely "abstract class", which can only contain abstract methods and properties (with empty bodies):

    interface IFlower
    {
        void AddWater(); // interface method (does not have a body)
        void LeafsCount(); // interface method (does not have a body)
    }

    class Magnolia : IFlower
    {
        public void AddWater()
        {
            Console.WriteLine("adding 300 ml of water");
        }

        public void LeafsCount()
        {
            Console.WriteLine("it has 9 leafs");
        }
    }

    // C# Enums
    // An enum is a special "class" that represents a group of constants (unchangeable/read-only variables).
    // To create an enum, use the enum keyword (instead of class or interface), and separate the enum items with a comma:
    enum WaterLevel
    {
        Low,
        Medium,
        High
    }
}

     