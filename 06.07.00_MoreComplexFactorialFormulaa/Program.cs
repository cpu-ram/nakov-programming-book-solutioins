using System;

namespace _06._07._00_MoreComplexFactorialFormulaa
{
    class Program
    {
        static int GreaterOfTwo(int a, int b)
        {
            int greater = ((a + b) / 2) + ((Math.Abs(a - b)) / 2);
            return greater;
        }

        static int SmallerOfTwo(int a, int b)
        {
            int smaller = ((a + b) / 2) - ((Math.Abs(a - b)) / 2);
            return smaller;
        }

        static int Factorial(int a, int b)
        {

            int greater = GreaterOfTwo(a, b);
            int smaller = SmallerOfTwo(a, b);
            int factorial = 1;


            for (int i = smaller + 1; i <= greater; i++)
            {
                factorial *= i;
            }

            return factorial;
        }

        static void Main(string[] args)
        {
            int a = 4;
            int b = 6;

            int greater = GreaterOfTwo(a, b);
            int smaller = SmallerOfTwo(a, b);
            int factorial = 1;

            Console.WriteLine($"a={a}, b={b}, the greater number of the two is {greater}, the smaller one is {smaller}.");



            int result = (((Factorial(0, a))^2)*Factorial(a,b))/Factorial(0,(b-a));

            Console.WriteLine($"result={result}.");


        }
    }
}
