using System;

namespace _03._14._00_IntegralDivisionFORCycle
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = 72;
            bool isPrime = true;
            if (number > 2)
                for (int i = 2; i <= Math.Ceiling(Math.Sqrt(number)); ++i)
                {
                    if (number % i == 0) isPrime = false;
                }
            Console.WriteLine("{0} is prime?: {1}", number, isPrime);
        }
    }
}
