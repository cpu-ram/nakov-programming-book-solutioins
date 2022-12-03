using System;

namespace _06._05._00_FibonacciSum
{
    class Program
    {
        static void Main(string[] args)
        {
            ulong c = 0;
            ulong a = 0;
            ulong b = 1;
            ulong sum = 1;

            Console.WriteLine("Enter the number of Fibonacci sequence' numbers to be summed:");
            int lim = Int32.Parse(Console.ReadLine());



            Console.WriteLine("\n" + a + "\n" + b);

            for (int x = 0; x < (lim-2); x++)
            {
                c = b; // saves the last preceeding value for later use as an int c
                b = a + b; // creates a new value, equal to a sum of the last two numbers
                Console.WriteLine(b); // prints the new value b
                sum += b;
                a = c; // sets the new "first value" equal to the previously saved int c
            }
            Console.WriteLine("\n The sum of these numbers={0}", sum);
        }
    }
}
