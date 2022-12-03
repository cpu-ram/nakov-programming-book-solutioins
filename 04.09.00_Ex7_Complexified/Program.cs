using System;

namespace _04._09._00_Ex7_Complexified
{
    class Program
    {
        static void Main(string[] args)
        {
            int x = 0;
            int[] intArray = new int[5];

            int sum = 0;

            Console.WriteLine("Enter a number of numbers to be summarized:");
            int maxNum = Int32.Parse(Console.ReadLine());

            while (x <= (maxNum-1))
            {
                Console.WriteLine("Input an integral number #" + (x + 1) + ".");
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
            Console.WriteLine("Sum of the numbers = " + sum + ".");
        }
    }
}
