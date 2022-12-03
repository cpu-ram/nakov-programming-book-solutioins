using System;

namespace _06._09._00_CalculatingAComplexFormula
{
    class Program
    {
        static double Factorial(int a)
        {
            int factorial = 1;
            for (int i = 1; i <= a; i++)
            {
                factorial *= i;
                
            }
            return factorial;
        }
        static void Main(string[] args)
        {
            double x = 3;
            int n = 10;
            int sum = 1;
            int element = 0;
            

            for(double j=1; j<=n; j++)
            {
                
                element = Factorial(j) / (x ^ (j));
                sum += element;
            }
            Console.WriteLine($"sum={sum}");
        }
    }
}
