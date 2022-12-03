using System;

namespace _06._01._00_SimpleCycle
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the top limit number N:"); // not doing a validity check
            int limit = Int32.Parse(Console.ReadLine());

            for(int i = 1; i <= limit; i++)
            {
                Console.WriteLine(i);
            }
        }
    }
}
