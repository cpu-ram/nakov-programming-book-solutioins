using System;

namespace _04._10._00_Read_Cycle_Print
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter a Max Number:");
            int maxNumber = Int32.Parse(Console.ReadLine());

            for (int x=1; x<=maxNumber; x++)
            {
                Console.WriteLine(x);
            }

        }
    }
}
