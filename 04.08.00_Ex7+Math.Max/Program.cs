using System;

namespace _04._08._00_Ex7_Math.Max
{
    class Program
    {
        
            static void Main(string[] args)
            {
                int x = 0;
                int[] intArray = new int[5];

                int sum = 0;

                while (x <= 4)       // reading the five numbers -- begin
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
                }                    // reading the five numbers -- end


                int max = 0;
                int z = intArray[0];
                for (int y = 0; y <= 4; y++)
                {
                    max = (Math.Max(max, intArray[y]));
                }
                Console.WriteLine("The biggest of the numbers = " + max + ".");
            }
        
    }
}
