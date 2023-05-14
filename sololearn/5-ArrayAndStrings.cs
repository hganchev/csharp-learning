using System;
using System.Collections.Generic;

namespace Sololearn
{
    class ArraysAndStrings
    {
        int[] myArray;
        string[] names;
        public ArraysAndStrings()
        {
            Console.WriteLine("========= Arrays ==========");
            myArray = new int[5];
            myArray[0] = 23;
            names = new string[3]{
                "John", "Mary", "Jessica"
            };

            Console.WriteLine("========= Arrays & Loops ==========");
            int[ ] a = new int[10];
            for (int k = 0; k < 10; k++) 
            {
                a[k] = k*2;
            }
            Console.WriteLine("========= The foreach ==========");
            foreach(int k in a)
            {
                Console.WriteLine(k);
            }

            int[ ] arr = {8, 2, 6};
            int y=0;
            foreach (int x1 in arr) {
                y+=x1/2;
            }
            Console.WriteLine(y);
            Console.WriteLine("========= Multidimentional Array ==========");
            int[ , ] x = new int[3,4]; // two dimentional array
            int[ , ] someNums = { {2, 3}, {5, 6}, {4, 6} }; 
            Console.WriteLine("========= Jagged Arrays ==========");
            // A jagged array is an array-of-arrays, so an int[ ][ ] is an array of int[ ], each of which can be of different lengths and occupy their own block in memory.
            // A multidimensional array (int[,]) is a single block of memory (essentially a matrix). It always has the same amount of columns for every row.
            int[ ][ ] jaggedArr = new int[3][ ];
            int[ ][ ] jaggedArr2 = new int[ ][ ] 
            {
            new int[ ] {1,8,2,7,9},
            new int[ ] {2,4,6},
            new int[ ] {33,42}
            };
            Console.WriteLine("========= Arrays properties ==========");
            // For example, the Length and Rank properties return the number of elements and the number of dimensions of the array, respectively. 
            // You can access them using the dot syntax, just like any class members:
            Console.WriteLine(jaggedArr2.Length);
            Console.WriteLine(jaggedArr2.Rank);
            Console.WriteLine("========= Arrays Methods ==========");
            // Max returns the largest value.
            // Min returns the smallest value.
            // Sum returns the sum of all elements.
            Console.WriteLine(jaggedArr.Max());
            Console.WriteLine(jaggedArr.Min());
            Console.WriteLine("========= Strings ==========");
            // It’s common to think of strings as arrays of characters. In reality, strings in C# are objects.
            // When you declare a string variable, you basically instantiate an object of type String.
            // String objects support a number of useful properties and methods:
            // Length returns the length of the string.
            // IndexOf(value) returns the index of the first occurrence of the value within the string.
            // Insert(index, value) inserts the value into the string starting from the specified index.
            // Remove(index) removes all characters in the string from the specified index.
            // Replace(oldValue, newValue) replaces the specified value in the string.
            // Substring(index, length) returns a substring of the specified length, starting from the specified index. If length is not specified, the operation continues to the end of the string.
            // Contains(value) returns true if the string contains the specified value.
            string str = "some string";
            Console.WriteLine(str.Length);
            Console.WriteLine(str.IndexOf('t'));
            str = str.Insert(0, "This is ");
            Console.WriteLine(str);
            str = str.Replace("This is", "I am");
            Console.WriteLine(str);
            if(str.Contains("some"))
                Console.WriteLine("found");
            str = str.Remove(4);
            Console.WriteLine(str);
            str = str.Substring(2);
            Console.WriteLine(str);
            Console.WriteLine("========= Words Problem ==========");
            // Description: 
            // The program you are given defines an array with 10 words and takes a letter as input.
            // Write a program to iterate through the array and output words containing the taken letter.
            // If there is no such word, the program should output "No match".
            string[] words = {
                "home",
                "programming",
                "victory",
                "C#",
                "football",
                "sport",
                "book",
                "learn",
                "dream",
                "fun"
            };

            string letter = Console.ReadLine();

            int count = 0;
            
            //your code goes here
            foreach(string word in words)
            {
                if(word.Contains(letter)){Console.WriteLine(word);count ++; }   
            }
            if (count == 0){Console.WriteLine("No match");}

        }
    }
}