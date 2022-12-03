using System;

namespace _05._06._00_SolvingAQuadraticEquasion
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {

                Console.WriteLine("ax^2+bx+c=0");

                Console.WriteLine("Enter the 'a' coefficient:");
                int a = Int32.Parse(Console.ReadLine());

                Console.WriteLine("Enter the 'b' coefficient:");
                int b = Int32.Parse(Console.ReadLine());

                Console.WriteLine("Enter the 'c' coefficient:");
                int c = Int32.Parse(Console.ReadLine());

                int x1 = (-b + (((b ^ 2) - 4 * a * c) ^ (1 / 2))) / (2 * a);
                int x2 = (-b - (((b ^ 2) - 4 * a * c) ^ (1 / 2))) / (2 * a);

                Console.WriteLine("x1={0}, x2={1}", x1, x2);

            }
        }
    }
}
