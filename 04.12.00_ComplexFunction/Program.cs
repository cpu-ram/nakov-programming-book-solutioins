using System;

namespace _04._12._00_ComplexFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            double x = 1;
            double s = 0;
            double prevVal;

            while(true)
            {
                prevVal = s;
                Console.WriteLine("Previous value = " + prevVal);
                Console.WriteLine("x counter = " + x);
                Console.WriteLine("Value added = 1/x = " + (1 / x));
                s = s + (1 / x);   // sum calculated

                Console.WriteLine("New value = " + s );
                Console.WriteLine("Difference between the old value and the new value = " + Math.Abs(prevVal - s) + "\n");

                x++;

                if (Math.Abs(prevVal - s) < 0.001)
                {
                    break;
                }
            }
            Console.WriteLine(s);
        }
    }
}
