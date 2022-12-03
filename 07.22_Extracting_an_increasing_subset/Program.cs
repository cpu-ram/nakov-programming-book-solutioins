using System;

namespace _07._22_Extracting_an_increasing_subset
{
    class Program
    {

        static int[] EnterIntArray()
        {
            

            Console.WriteLine("Enter the integer array, separated by spaces");
            string entry = Console.ReadLine();

            string[] entryArrString = entry.Split(" ");

            int[] intArr=new int[entryArrString.Length];

            int counter = 0;
            foreach(string i in entryArrString)
            {
                intArr[counter] = Convert.ToInt32(i);
                Console.Write(intArr[counter] + " ");
                counter++;
            }
            Console.WriteLine();

            return intArr;

        }

        static int[] ExtractIncreasingSubarray(int arr)
        {



        }


        static void Main(string[] args)
        {
            int[] intArr = EnterIntArray();


        }
    }
}
