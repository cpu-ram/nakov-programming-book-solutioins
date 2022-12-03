using System;

namespace _07._11_Find_A_Specified_Sum_Of_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 1, 4, 6, 7, 0, -2, 5, 0, 0, 3 };

            foreach(int i in arr)
            {
                Console.Write($"{i} ");
            }
            Console.WriteLine();
            int requiredSum = 3;
            Console.WriteLine($"requiredSum={requiredSum}");

            int sum = 0;
            string displayString = "";
            bool resultFound = false;

            for(int i = 0; i < arr.Length; i++)
            {
                Console.Write("i=" + i +"\n");
                for(int j = i; j < arr.Length; j++)
                {
                    sum += arr[j];
                    if (sum == requiredSum)
                    {
                        for(int k = i; k <= j; k++)
                        {
                            displayString += arr[k] +" ";
                        }
                        Console.WriteLine("A sequence with sum=requiredSum found:" + displayString);
                        resultFound = true;
                        break;
                    }
                    
                }
                if (resultFound) break;
                sum = 0;
                Console.WriteLine();
            }


        }

    }
}
