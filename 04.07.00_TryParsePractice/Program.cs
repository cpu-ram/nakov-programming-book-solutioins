using System;

namespace _04._07._00_TryParsePractice
{
    class Program
    {
        static void Main(string[] args)
        {
            int x = 0;
            int[] intArray = new int[5];

            int sum = 0;

            while (x<=4)
            {
                Console.WriteLine("Input an integral number #" + (x+1) +".");
                string inputStr = Console.ReadLine();
                bool validInput = Int32.TryParse(inputStr, out int inputInt);

                if (validInput == false)
                {
                    Console.WriteLine("You didn't input a valid integral number");
                }

                else 
                {
                    intArray[x] = inputInt;
                    x++; 
                }
            }

            for (int y = 0; y <= 4; y++)
            {
                sum += intArray[y];
            }
            Console.WriteLine("Sum of the numbers = " + sum +".");
        }
    }
}
