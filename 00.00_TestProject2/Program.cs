using System;



namespace _00._00_TestProject2
{
    class SubsetSum
    {
        static long sum = 0;
        static int s;
        static int numbersAdded = 0;

        static bool FindSubsetSum(int[] numbers, int currIndex)
        {
            if (currIndex == numbers.Length)
            {
                if (sum == s && numbersAdded > 0)
                {
                    return true;
                }
                else return false;
            }
            sum = sum + numbers[currIndex];
            numbersAdded++;
            if (FindSubsetSum(numbers, currIndex + 1))
            {
                return true;
            }
            sum = sum - numbers[currIndex];
            numbersAdded--;
            if (FindSubsetSum(numbers, currIndex + 1))
            {
                return true;
            }
            return false;
        }
        static void Main()
        {
            s = int.Parse(Console.ReadLine());
            int n = int.Parse(Console.ReadLine());
            int[] numbers = new int[n];
            for (int i = 0; i < n; i++)
            {
                numbers[i] = int.Parse(Console.ReadLine());
            }
            Console.WriteLine(FindSubsetSum(numbers, 0));
        }
    }
} 