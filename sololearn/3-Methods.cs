using System;

namespace Sololearn
{
    class Methods
    {
        public Methods()
        {
            Print(55);
            Console.WriteLine("=============== Passing Arguments =========");
            int a = 10;
            Sqr(a);
            Print(a);
            Console.WriteLine("=============== Passing by Reference =========");        
            // Pass by reference copies an argument's memory address into the formal parameter. 
            // Inside the method, the address is used to access the actual argument used in the call.
            // This means that changes made to the parameter affect the argument.
            Sqr2(ref a);
            Print(a);
            Console.WriteLine("=============== Passing by Output =========");
            // Output parameters are similar to reference parameters, except that they transfer 
            // data out of the method rather than accept data in. They are defined using the out keyword.
            int c, b;
            GetValues(out c, out b);
            Console.WriteLine(c);
            Console.WriteLine(b);

            Console.WriteLine("=============== Method Overloading =========");
            // Method overloading is when multiple methods have the same name, but different parameters.
            Print(15);
            Print("15");

            Console.WriteLine("=============== Recursion =========");
            // A recursive method is a method that calls itself.
            // One of the classic tasks that can be solved easily by recursion is calculating the factorial of a number.
            int f = Fact(10);
            Console.WriteLine(f);
            Console.WriteLine("=============== Draw Pyramid =========");
            DrawPyramide(10);
            Console.WriteLine("=============== Level Points Problem =========");
            // Description:
            // Passing the first level of a video game awards the player 1 point. For each subsequent level passed, 
            // the points awarded increment by 1 (2 for the 2nd level, 3 for the 3rd, and so on).
            // The program you are given takes the number of passed levels as input. Complete the given function to take 
            // that number as an argument, and recursively calculate and return the total number of points given for all passed levels.
            int levels = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine(Points(levels));

        }

        private int Points(int levels)
        {
            int points = 0;
            for (int i = 0; i <=levels; i++)
            {
                points +=i;
            }
            return points;
        }

        // Method void - non type return
        private void Print(int x)
        {
            Console.WriteLine(x);
        }

        private void Print(string str)
        {
            Console.WriteLine(str);
        }

        private void Sqr(int x)
        {
            x = x*x;
        }

        private void Sqr2(ref int x)
        {
            x = x*x;
        }

        private void GetValues(out int x, out int y)
        {
            x = 5;
            y = 42;
        }

        private int Fact(int number)
        {
            if(number == 1)
                return 1;
            return number * Fact(number - 1);
        }

        private void DrawPyramide(int n)
        {
            for(int i = 0; i<=n; i++)
            {
                for(int j = 0; j <=n; j++)
                {
                    Console.Write("  ");
                }
                for(int k = 0; k <=2*i-1; k++)
                {
                    Console.Write("*" + " ");
                }
                Console.WriteLine();
            }
        }
    }
}