using System;
using System.Collections.Generic;

namespace Sololearn
{
    class InterheritanceNPolymorphism
    {
        public InterheritanceNPolymorphism()
        {
            // Inheritance allows us to define a class based on another class. This makes creating and maintaining an application easy.
            // The class whose properties are inherited by another class is called the Base class. The class which inherits the properties is called the Derived class.
            // For example, base class Animal can be used to derive Cat and Dog classes.
            // The derived class inherits all the features from the base class, and can have its own additional features.
            Console.WriteLine("========= Protected members ==========");
            // Up to this point, we have worked exclusively with public and private access modifiers.
            // Public members may be accessed from anywhere outside of the class, while access to private members is limited to their class.
            // The protected access modifier is very similar to private with one difference; it can be accessed in the derived classes. 
            // So, a protected member is accessible only from derived classes.
            Student s = new Student("David");
            s.Speak();
            Console.WriteLine("========= Sealed ==========");
            // A class can prevent other classes from inheriting it, or any of its members, by using the sealed modifier.
            Console.WriteLine("========= Derived Class Constructor & Destructor ==========");
            // Constructors are called when objects of a class are created. With inheritance, the base class constructor and destructor are not inherited, so you should define constructors for the derived classes.
            // However, the base class constructor and destructor are being invoked automatically when an object of the derived class is created or deleted.
            Two t = new Two();
            Console.WriteLine("========= Polymorphizm ==========");
            // Simply, polymorphism means that a single method can have a number of different implementations.
            // Consider having a program that allows users to draw different shapes. Each shape is drawn differently, and you do not know which shape the user will choose.
            // Here, polymorphism can be leveraged to invoke the appropriate Draw method of any derived class by overriding the same method in the base class. 
            // Such methods must be declared using the virtual keyword in the base class.
            // Virtual methods enable you to work with groups of related objects in a uniform way.
            Shape c = new Circle();
            c.Draw();
            Shape r = new Rectangle();
            r.Draw();
            // Polymorphism can be useful in many cases. For example, we could create a game where we would have different Player types with each 
            // Player having a separate behavior for the Attack method.
            // In this case, Attack would be a virtual method of the base class Player and each derived class would override it.
            Console.WriteLine("========= Abstract Classes ==========");
            // As described in the previous example, polymorphism is used when you have different derived classes with the same method, 
            // which has different implementations in each class. This behavior is achieved through virtual methods that are overridden in the derived classes.
            // In some situations there is no meaningful need for the virtual method to have a separate definition in the base class.
            // These methods are defined using the abstract keyword and specify that the derived classes must define that method on their own.
            // You cannot create objects of a class containing an abstract method, which is why the class itself should be abstract.
            Shape c1 = new Circle();
            Console.WriteLine("========= Interfaces ==========");
            // An interface is a completely abstract class, which contains only abstract members.
            // But why use interfaces rather than abstract classes?
            // A class can inherit from just one base class, but it can implement multiple interfaces!
            // Therefore, by using interfaces you can include behavior from multiple sources in a class.
            // To implement multiple interfaces, use a comma separated list of interfaces when creating the class: class A: IShape, IAnimal, etc.
            IShape sq = new Square();
            sq.Draw();

            // Default implementation in interfaces allows to write an implementation of any method. 
            // This is useful when there is a need to provide a single implementation for common functionality.
            sq.Finish();
            Console.WriteLine("========= Nested Classes ==========");
            // C# supports nested classes: a class that is a member of another class.
            Car car = new Car("Hyundai");
            Console.WriteLine("========= Drawing Application Problem ==========");
            // Description:
            // You are creating a drawing application and currently have only 1 tool - a pencil. You want to add brush and spray to the drawing toolbar.
            // The program you are given declares an IDraw interface with the StartDraw() method, and class Draw, which performs pencil drawing by implementing the IDraw interface. 
            // It outputs "Using pencil".
            // Complete the given Brush and Spray classes by
            // - inheriting them from class Draw
            // - implementing the StartDraw() method for each tool, in order to output
            // "Using brush" for Brush, or
            // "Using spray" for Spray.

            // The Draw objects and their method calls are provided in Main().
            // Don't forget about the override keyword.
            Draw pencil = new Draw();
            Draw brush = new Brush();
            Draw spray = new Spray();

            pencil.StartDraw();
            brush.StartDraw();
            spray.StartDraw();
        }
    }

    class Car {
        string name;
        public Car(string nm) {
            Console.WriteLine("Car created");
            name = nm;
            Motor m = new Motor();
        }
        public class Motor {
            // some code
            public Motor()
            {
               Console.WriteLine("Motor Added"); 
            }           
        }
    }

    /*
    Draw => "Using pencil"
    Brush => "Using brush"
    Spray => "Using spray"
    */

    public interface IDraw
    {
        void StartDraw();
    }

    class Draw : IDraw
    {
        public virtual void StartDraw()
        {
            Console.WriteLine("Using pencil");
        }
    }

    //inherit this class from the class Draw
    class Brush : Draw
    {
        //implement the StartDraw() method
        public override void StartDraw()
        {
            Console.WriteLine("Using brush");
        }
    }

    //inherit this class from the class Draw
    class Spray : Draw
    {
        //implement the StartDraw() method
        public override void StartDraw()
        {
            Console.WriteLine("Using spray");
        }
    }

    public interface IShape
    {
        void Draw();
        void Finish()
        {
            Console.WriteLine("Done!");
        }
    }

    class Square : IShape {
        public void Draw() {
            // draw a rectangle...
            Console.WriteLine("Rect Sqare");
        }
    }

    // class Shape {
    //     public virtual void Draw() {
    //         Console.Write("Base Draw");
    //     }
    // }

    abstract class Shape {
        public abstract void Draw();
    }

    class Circle : Shape {
        public override void Draw() {
            // draw a circle...
            Console.WriteLine("Circle Draw");
        }
    }
    class Rectangle : Shape {
        public override void Draw() {
            // draw a rectangle...
            Console.WriteLine("Rect Draw");
        }
    }

    class One 
    {
        public One()
        {
            Console.WriteLine("One created");
        }
        ~One()
        {
            Console.WriteLine("One deleted");
        }
    }

    class Two : One 
    {
        public Two()
        {
            Console.WriteLine("Two created");
        }
        ~Two()
        {
            Console.WriteLine("Two deleted");
        }
    }

    class Person2{
        protected int Age{get;set;}
        protected string Name{get; set;}

    }

    class Student: Person2
    {
        public Student(string nm)
        {
            Name = nm;
        }
        public void Speak()
        {
            Console.Write("Name: " + Name);
        }
    }

    class Animal2 {
        public int Legs {get; set;}
        public int Age {get; set;}
    }

    class Dog2 : Animal2 {
        public Dog2() {
            Legs = 4;
        }
        public void Bark() {
            Console.Write("Woof");
        }
    }


}