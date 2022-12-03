using System;

namespace _06._16_Randomizing_array_order
{
    class Program
    {
        static void Main(string[] args)
        {
            Random randomGenerator = new Random();
            int input = int.Parse(Console.ReadLine());
            int[] resultArray = new int[input];

            // Initialize array
            for (int i = 0; i < input; i++)
            {
                resultArray[i] = i + 1;
            }

            // Exchange resultArray[i] with random element in resultArray[i..input-1]
            for (int i = 0; i < input; i++)
            {
                int positionOfSwapElement = i + randomGenerator.Next(0, input - i);
                int buffer = resultArray[i];

                resultArray[i] = resultArray[positionOfSwapElement];
                resultArray[positionOfSwapElement] = buffer;
            }

            for (int i = 0; i < input; i++)
            {
                Console.WriteLine(resultArray[i]);
            }

        }
    }
}
