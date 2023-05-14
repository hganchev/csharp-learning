using System;

namespace Sololearn
{
    class ConditionalsAndLoops
    {
        public ConditionalsAndLoops()
        {
            Console.WriteLine("========= If Loop ==========");
            Console.WriteLine("========= Switch Loop ==========");
            int num = 3;
            switch (num)
            {
                case 1:
                    Console.WriteLine("one");
                    break;
                case 2:
                    Console.WriteLine("two");
                    break;
                case 3:
                    Console.WriteLine("three");
                    break;
                default:
                    Console.WriteLine("Default case");
                    break;
            }
            Console.WriteLine("========= While Loop ==========");
            Console.WriteLine("========= FOR Loop ==========");
            // for ( init; condition; increment ) 
            // {
            //     statement(s);
            // }
            Console.WriteLine("========= do While Loop ==========");
            // If the condition of the do-while loop evaluates to false, the statements in the do will still run once:
            do
            {
                Console.WriteLine("do");
            }
            while(num<1);
            Console.WriteLine("========= break and continue ==========");
            // We saw the use of break in the switch statement.
            // Another use of break is in loops: When the break statement 
            // is encountered inside a loop, the loop is immediately terminated and the program execution moves on to the next statement following the loop body.

            // The continue statement is similar to the break statement, but instead of terminating the loop entirely, 
            // it skips the current iteration of the loop and continues with the next iteration.

            for(int i = 0; i < 10; i++)
            {
                if(i == 5)
                    continue;
                Console.WriteLine(i);
            }

            Console.WriteLine("========= Logical Operators ==========");
            // && - AND
            // || - OR
            // ! - NOT

            // ? - if statement
            // Exp1 ? Exp2 : Exp3;
            // if Exp1 = true then Exp2 else Exp3
            Console.WriteLine("========= Basic Calculator ==========");

            // do 
            // {
            // Console.Write("x = ");
            // int x = Convert.ToInt32(Console.ReadLine());

            // Console.Write("y = ");
            // int y = Convert.ToInt32(Console.ReadLine());

            // int sum = x+y;
            // Console.WriteLine("Result: {0}", sum);
            // }
            // while(true);

            Console.WriteLine("========= Problem ==========");
            // Description:

            // You are an elementary school teacher and explaining multiplication to students.
            // You are going to use multiplication by 3 as your example.
            // The program you are given takes N number as input. Write a program to output all numbers from 1 to N, replacing all numbers that are multiples of 3 by "*".

            int number = Convert.ToInt32(Console.ReadLine());
            
            //your code goes here
            for(int i = 1; i <= number; i++)
            {
                if(i%3==0) 
                {
                    Console.Write("*");
                }
                else
                {
                    Console.Write(i);
                }
            }
        }
    }
}