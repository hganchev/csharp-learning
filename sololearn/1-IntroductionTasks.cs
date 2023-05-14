// Types
// int - integer.
// float - floating point number.
// double - double-precision version of float.
// char - a single character.
// bool - Boolean that can have only one of two values: True or False.
// string - a sequence of characters.
using System;
namespace Sololearn
{
    class IntroductionTasks
    {
        public IntroductionTasks()
        {
         //output "C# is cool"
            Console.WriteLine("C# is cool");

            int x = 89;
            Console.WriteLine(x);

            double y = 20;
            Console.WriteLine("x = {0}; y={1};", x, y);

            Console.WriteLine("========= User Input ==========");
            // string yourName;
            // Console.WriteLine("What is your name?");
            // yourName = Console.ReadLine();
            // Console.WriteLine("Hello {0}", yourName);

            // Console.WriteLine("What is your age?");
            // int age = Convert.ToInt32(Console.ReadLine());
            // Console.WriteLine("You are {0} years old", age);

            CatchException(); // test for try catch with return

            Console.WriteLine("========= var keyword ==========");
            var num = 15;

            Console.WriteLine("========= constant ==========");
            // Constants store a value that cannot be changed from their initial assignment.
            // To declare a constant, use the const modifier
            const double PI = 3.14; 
            // PI = 8; // error

            Console.WriteLine("========= Arithmetic Operations ==========");
            // Addition +
            // Substraction -
            // Multiplocation *
            // Division /
            // Modulus %
            x += 5; // equivalent to x = x + 5
            x *= 8; // equivalent to x = x * 8
            x /= 5; // equivalent to x = x / 5
            x %= 2; // equivalent to x = x % 2
            x++; // equivalent to x = x + 1

            // Prefix
            x = 3;
            y = ++x;
            Console.WriteLine(x);
            Console.WriteLine(y);
            y = x++;
            Console.WriteLine(x);
            Console.WriteLine(y);

            Console.WriteLine("========= Area Of Circles Problem ==========");
            const double pi = 3.14;
            double radius;
            
            //your code goes here
            Console.WriteLine("Radius:");
            radius = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine(Convert.ToDouble(pi*radius*radius));
        }

        static bool CatchException()
        {
            try
            {
                Console.WriteLine("try");
                throw new Exception("exception try");
            }
            catch(Exception ex)
            {
                Console.WriteLine("catch");
                return false;
            }
            finally{
               Console.WriteLine("finally"); 
            }

            Console.WriteLine("after catch, return");
            return true;
        }
    }
   
}