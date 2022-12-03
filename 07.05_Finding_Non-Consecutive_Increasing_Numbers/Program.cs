using System;

namespace _07._05_Finding_Non_Consecutive_Increasing_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputArrayOne = Console.ReadLine();
            char[] delimiter = new char[] { ',', ' ' };
            string[] inputOne = inputArrayOne.Split(delimiter, StringSplitOptions.RemoveEmptyEntries);

            int[] arr = new int[inputOne.Length];
            for (int i = 0; i < inputOne.Length; i++)
            {
                arr[i] = int.Parse(inputOne[i]);
            }
            int counter = 0;
            int maxSequence = 0;
            int index = 0;

            for (int i = 0; i < arr.Length - 1; i++)
            {
                counter = 1;
                int j = i + 1;
                int k = i;

                while (arr[k] < arr[j])
                {
                    counter++;
                    j++;
                    k++;
                    if (j >= arr.Length)
                    {
                        break;
                    }
                }
                if (counter > maxSequence)
                {
                    maxSequence = counter;
                    index = i;
                }
            }

            for (int i = index; i <= index + maxSequence - 1; i++)
            {
                if (i != index + maxSequence - 1)
                {
                    Console.Write(arr[i] + ", ");
                }
                else
                {
                    Console.WriteLine(arr[i]);
                }
            }

        }
    }
}
