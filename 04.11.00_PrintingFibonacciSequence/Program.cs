using System;

namespace _04._11._00_PrintingFibonacciSequence
{
    class Program
    {
        static int GreaterOfTwo(int a, int b)
        {
            int greater = ((a + b) / 2) + ((Math.Abs(a - b))/2);
            return greater;
        }

        static int SmallerOfTwo(int a, int b)
        {
            int smaller = ((a + b) / 2) - ((Math.Abs(a - b)) / 2);
            return smaller;
        }

        static void Main(string[] args)
        {
            int a = 4;
            int b = 6;

            int greater = GreaterOfTwo(a, b);
            int smaller = SmallerOfTwo(a, b);
            int factorial = 1;

            Console.WriteLine($"a={a}, b={b}, the greater number of the two is {greater}, the smaller one is {smaller}.");

            for(int i=smaller+1; i<=greater; i++ )
            {
                Console.WriteLine(i);
                factorial *= i;
            }

            Console.WriteLine($"b!/n!={factorial}.");

            



           
        }
    }
}
