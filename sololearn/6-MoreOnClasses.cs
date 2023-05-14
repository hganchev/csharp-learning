using System;
using System.Collections.Generic;

namespace Sololearn
{
    class MoreOnClasses
    {
        public MoreOnClasses()
        {
            Console.WriteLine("========= Destructors ==========");
            // As constructors are used when a class is instantiated, destructors are automatically invoked when an object is destroyed or deleted.
            // Destructors have the following attributes:
            // - A class can only have one destructor.
            // - Destructors cannot be called. They are invoked automatically.
            // - A destructor does not take modifiers or have parameters.
            // - The name of a destructor is exactly the same as the class prefixed with a tilde (~).
            Dog d = new Dog();

            Console.WriteLine("========= Static ==========");
            // Class members (variables, properties, methods) can also be declared as static. 
            // This makes those members belong to the class itself, instead of belonging to individual objects. 
            // No matter how many objects of the class are created, there is only one copy of the static member.
            Cat cat1 = new Cat();
            Cat cat2 = new Cat();
            Console.WriteLine(Cat.count);
            // Constant members are static by definition.
            Console.WriteLine(MathClass.ONE);

            Console.WriteLine(SomeClass.X);
            // An entire class can be declared as static.
            // A static class can contain only static members.
            // Example of static classes - Math, Array, DateTime
            Console.WriteLine("========= this and readonly ==========");
            // The this keyword is used inside the class and refers to the current instance of the class, meaning it refers to the current object.
            // The readonly modifier prevents a member of a class from being modified after construction. 
            // It means that the field declared as readonly can be modified only when you declare it or from within a constructor.
            Console.WriteLine("========= Indexers ==========");
            Clients c = new Clients();
            c[0] = "Dave";
            c[1] = "Bob";
            Console.WriteLine(c[1]);
            Console.WriteLine("========= Operator Overloading ==========");
            Box b1 = new Box(14,3);
            Box b2 = new Box(5,7);
            Box b3 = b1 + b2;
            Console.WriteLine(b3.Height);
            Console.WriteLine(b3.Width);
            Console.WriteLine("========= Dance Problem ==========");
            // Description:
            // In a ballroom dancing competition, each dancer from a pair is evaluated separately, and then their points are summed up to get the total pair score.
            // The program you are given takes the names and the points of each dancer as input and creates a DancerPoints objects for each dancer, using the taken 
            // name and score values as parameters for constructors.
            // Complete the given class, using overload + operator to return an new object where the names of dancers are in one string (see sample output) and 
            // the score is equal to the sum of their points.
            // The declaration of that object and the output of its points are already written in Main().
            string name1 = "Dave";//Console.ReadLine();
            int points1 = 8;//Convert.ToInt32(Console.ReadLine());
            string name2 = "Jessica";//Console.ReadLine();
            int points2 = 7;//Convert.ToInt32(Console.ReadLine());

            DancerPoints dancer1 = new DancerPoints(name1, points1);
            DancerPoints dancer2 = new DancerPoints(name2, points2);

            DancerPoints total = dancer1 + dancer2;
            Console.WriteLine(total.name);
            Console.WriteLine(total.points);


        }

    }

    class DancerPoints
    {
        public string name;
        public int points;
        public DancerPoints(string name, int points)
        {
            this.name = name;
            this.points = points;
        }

        //overload the + operator
        public static DancerPoints operator +(DancerPoints point1, DancerPoints point2)
        {
            string resName = String.Format("{0} & {1}",point1.name,point2.name);
            int resPoints = point1.points + point2.points;
            DancerPoints resDancer = new DancerPoints(resName, resPoints);
            return resDancer;
        }
    }

    class Box {
        public int Height {get; set;}
        public int Width {get; set;}
        public Box(int h, int w) {
            Height = h;
            Width = w;
        }
        public static Box operator+ (Box a, Box b) { // Operator +
            int h = a.Height + b.Height;
            int w = a.Width + b.Width;
            Box res = new Box(h, w);
            return res;
        }

        public static bool operator > (Box a, Box b) { // Operator >
            if(a.Height*a.Width > b.Height*b.Width)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool operator < (Box a, Box b) { // Operator <
            if(a.Height*a.Width < b.Height*b.Width)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    class Clients {
        private string[] names = new string[10];

        public string this[int index] {
            get {
            return names[index];
            }
            set {
            names[index] = value;
            }
        }
    }

    class SomeClass
    {
        public static int X {get;set;}
        public static int Y {get;set;}

        static SomeClass() // Static constructor
        {
            X = 10;
            Y = 20;
        }
    }

    class MathClass
    {
        public const int ONE = 1;
    }

    class Cat 
    {
        public static int count=0;
        public Cat() {
            count++;
        }
    }

    class Dog
    {
        public Dog()
        {
            Console.WriteLine("Constructor");
        }
        ~Dog()
        {
            Console.WriteLine("Desctructor");
        }
    }
}