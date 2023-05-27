using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;

/**
 * Auto-generated code below aims at helping you parse
 * the standard input according to the problem statement.
 **/
class Solution
{
    static void Main(string[] args)
    {

    }

    public static int Solution_1_FindClosestToZero(string inNumber, string inString)
    {
        try
        {
            // int N = int.Parse(Console.ReadLine());
            // string[] inputs = Console.ReadLine().Split(' ');

            int N = int.Parse(inNumber);
            string[] inputs = inString.Split(' ');

            if(N > 0){
                int[] temps = new int[N];
                for (int i = 0; i < N; i++)
                {
                    temps[i] = int.Parse(inputs[i]);
                    Console.Error.WriteLine(temps[i]);
                }
                
                // Write an answer using Console.WriteLine()
                // To debug: Console.Error.WriteLine("Debug messages...");
                Console.WriteLine(Math.Abs(temps.MinBy(x => Math.Abs((long) x - 0))));
                return Math.Abs(temps.MinBy(x => Math.Abs((long) x - 0)));
            }
            else
                Console.WriteLine("0");
                return 0;
        }
        catch
        {
            Console.WriteLine("0");
            return 0;
        }
    }
}