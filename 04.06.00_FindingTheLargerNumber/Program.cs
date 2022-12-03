using System;

namespace _04._06._00_FindingTheLargerNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = Int32.Parse(Console.ReadLine());
            int b = Int32.Parse(Console.ReadLine());

            int c = Math.Max(a, b);

            Console.WriteLine("Max number = {0}", c);
        }
    }
}
