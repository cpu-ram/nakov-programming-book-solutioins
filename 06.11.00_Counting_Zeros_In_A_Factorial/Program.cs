using System;

namespace _06._11._00_Counting_Zeros_In_A_Factorial
{
    class Program
    {
        static int Factorial(int b)
        {
            int factorial = 1;
            for (int i = 1; i <= b; i++)
            {
                factorial *= i;
            }
            return factorial;
        }

        static int ZeroCounter(int a)
        {
            int x = a;
            int opX = x;
            int counter = 0;
            int remainder;
            bool finish = false;

            while (true)
            {
                remainder = opX % 10;

                switch (remainder)
                {
                    case 0:
                        counter++;
                        opX = (opX - remainder) / 10;
                        break;
                    default:
                        finish = true;
                        break;
                }
                if (finish == true)
                {
                    break;
                }
            }
            return counter;
        }

        static void Main(string[] args)                        // main method -- begins
        {
            int a = 6;
            int factorial = Factorial(a);
            int zeroCount = ZeroCounter(factorial);

            Console.WriteLine(zeroCount);

        }
    }
}
