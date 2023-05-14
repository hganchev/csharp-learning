using System;
using System.Collections.Generic;
using System.IO;

namespace Sololearn
{
    class StructsEnumsFiles
    {
        public StructsEnumsFiles()
        {
            Console.WriteLine("========= Structures ==========");
            // A struct type is a value type that is typically used to encapsulate small groups of related variables, 
            // such as the coordinates of a rectangle or the characteristics of an item in an inventory. The following example shows a simple struct declaration:
            Book b;
            b.title = "Test Book";
            b.price = 5.99;
            b.author = "David";

            Console.WriteLine(b.title);
            // Structs can contain methods, properties, indexers, and so on. Structs cannot contain default constructors (a constructor without parameters), 
            // but they can have constructors that take parameters. 
            // In that case the new keyword is used to instantiate a struct object, similar to class objects.
            Point p = new Point(10, 15);
            Console.WriteLine(p.x);

            // In general, classes are used to model more complex behavior, or data, that is intended to be modified after a class object is created. 
            // Structs are best suited for small data structures that contain primarily data that is not intended to be modified after the struct is created. 
            // Consider defining a struct instead of a class if you are trying to represent a simple set of data.
            Console.WriteLine("========= Enums ==========");
            // The enum keyword is used to declare an enumeration: a type that consists of a set of named constants called the enumerator list.
            // By default, the first enumerator has the value 0, and the value of each successive enumerator is increased by 1.
            int day = (int)Days.Fri;
            Console.WriteLine(day);

            // Enums are often used with switch statements.
            TrafiicLights tl = TrafiicLights.Red;
            switch(tl) 
            {
                case TrafiicLights.Green:
                    Console.WriteLine("Go!");
                    break;
                case TrafiicLights.Yellow:
                    Console.WriteLine("Coution!");
                    break;
                case TrafiicLights.Red:
                    Console.WriteLine("Stop!");
                    break;
            }

            Console.WriteLine("========= Exceptions ==========");
            // An exception is a problem that occurs during program execution. Exceptions cause abnormal termination of the program.
            // An exception can occur for many different reasons. Some examples:
            // - A user has entered invalid data.
            // - A file that needs to be opened cannot be found.
            // - A network connection has been lost in the middle of communications.
            // - Insufficient memory and other issues related to physical resources.
            try
            {
                int[] arr = new int[]{4,5,8};
                Console.WriteLine(arr[8]);
            }
            catch(Exception e)
            {
                Console.WriteLine("an Error occure: " + e.ToString());
            }
            finally
            {
                Console.WriteLine("Executes every time");
            }
            Console.WriteLine("========= Files ==========");
            // The System.IO namespace has various classes that are used for performing numerous operations with files, such as creating and deleting files, 
            // reading from or writing to a file, closing a file, and more.
            // The File class is one of them.
            string str = "Some text";
            File.WriteAllText("test.txt", str);
            string txt = File.ReadAllText("test.txt");
            Console.WriteLine(txt);

            // The following methods are available in the File class:
            // AppendAllText() - appends text to the end of the file.
            // Create() - creates a file in the specified location.
            // Delete() - deletes the specified file.
            // Exists() - determines whether the specified file exists.
            // Copy() - copies a file to a new location.
            // Move() - moves a specified file to a new location
            Console.WriteLine("========= Robot-barman Problem ==========");
            // Description:
            // You have a robot-barman and his goal is to neatly arrange drinks on the shelves of the bar. He is very smart and takes as many drinks 
            // as are necessary to evenly distribute them on the shelves, but he still has problems with division.
            // The program installed in the robot takes the number of drinks and the number of the shelves as input.
            // Complete the program to evenly distribute the drinks on shelves: by dividing the number of drinks by the number of shelves and outputting the result.
            // The program must also, handle those two possible problems:
            // 1. the divider (the number of shelves) should never be zero
            // 2. both inputs should be integers.
            // For the first exception, the program should output "At least 1 shelf" and for the second, "Please insert an integer".
            try
            {
                int drinks = 6;//Convert.ToInt32(Console.ReadLine());
                int shelves = Convert.ToInt32("two");//Convert.ToInt32(Console.ReadLine());

                //your code goes here
                int shelf = drinks/shelves;
                Console.WriteLine(shelf);
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("At least 1 shelf");
            }
            catch (FormatException)
            {
                Console.WriteLine("Please insert an integer");
            }
            /*
             * 1. DivideByZeroException => "At least 1 shelf"
             * 2. FormatException => "Please insert an integer"
            */

        }
        enum Days {Sun = 1, Mon, Tue, Wed, Thu, Fri, Sat};

        enum TrafiicLights {Green, Red, Yellow};
    }

    struct Point{
        public int x;
        public int y;
        public Point(int x, int y){
            this.x = x;
            this.y = y;
        }
    }
    struct Book {
        public string title;  
        public double price;
        public string author;
    }
}