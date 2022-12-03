using System;
using System.Diagnostics;

namespace _08._14_Studies_In_Numeral_Types_Precision
{
    class Program
    {
        static void Main(string[] args)
        {
            float floatNum = 0.000001F;
            double doubleNum = 0.000001D;
            decimal decimalNum = 0.000001M;

            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();


            for (int i = 0; i < 4999999; i++)
            {
                floatNum += 0.000001F;
            }

            stopWatch.Stop();
            TimeSpan timeSpanOne = stopWatch.Elapsed;
            Console.WriteLine($"To calculate the float, it took {timeSpanOne}.");



            Stopwatch stopWatchTwo  = new Stopwatch();
            stopWatchTwo.Start();
            for (int i = 0; i < 4999999; i++)
            {
                doubleNum += 0.000001D;
            }

            stopWatchTwo.Stop();
            TimeSpan timeSpanTwo = stopWatchTwo.Elapsed;
            Console.WriteLine($"To calculate the double, it took {timeSpanOne}.");




            Stopwatch stopWatchThree = new Stopwatch();
            stopWatchThree.Start();
            for (int i = 0; i < 499999999; i++)
            { 
                decimalNum += 0.000001M;
            }


            stopWatchThree.Stop();
            TimeSpan timeSpanThree = stopWatchThree.Elapsed;
            Console.WriteLine($"To calculate the decimal, it took {timeSpanOne}.");


            Console.Write($"float: {floatNum}\ndouble: {doubleNum}\ndecimal{decimalNum}\n");


            
        }
    }
}
