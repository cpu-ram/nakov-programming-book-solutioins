using System;

namespace _04._01._00_ConsoleReadAndSummarize
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the first number");
            int a = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter the second number");
            int b = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter the third number");
            int c = int.Parse(Console.ReadLine());

            int sum = a + b + c;
            Console.WriteLine("Sum of the numbers equals {0}", sum);
        }
    }
}
