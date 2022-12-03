using System;

namespace _07._02_Reading_and_comparing_arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            bool equalLength = true;


            Console.WriteLine("Enter the first string of numbers, separated by spaces.");
            string entryOne = Console.ReadLine();

            string[] stringArrayOne = entryOne.Split(' ');
            

            Console.WriteLine("Enter the first string of numbers, separated by spaces.");
            string entryTwo = Console.ReadLine();

            string[] stringArrayTwo = entryTwo.Split(' ');

            if(stringArrayOne.Length != stringArrayTwo.Length)
            {
                equalLength = false;
            }

            if (!equalLength)
            {
                Console.WriteLine("Arrays' lengths are different; arrays are not equal;");
            }

            else
            {
                int[] intArrayOne = new int[stringArrayOne.Length];
                int[] intArrayTwo = new int[stringArrayTwo.Length];

                int length = intArrayOne.Length;


                for (int i = 0; i < length; i++)
                {
                    intArrayOne[i] = Int32.Parse(stringArrayOne[i]);
                }

                for (int i = 0; i < length; i++)
                {
                    intArrayTwo[i] = Int32.Parse(stringArrayTwo[i]);
                }

                bool equalArrays = true;

                for (int i=0; i < length; i++)
                {
                    if (intArrayOne[i] != intArrayTwo[i])
                    {
                        equalArrays = false;
                        break;
                    }

                }

                switch (equalArrays)
                {
                    case true:
                        Console.WriteLine("Result: Arrays are equal.");
                        break;
                    case false:
                        Console.WriteLine("Result: Arrays' length are equal, but not the elements in them. Arrays are not equal.");
                        break;
                        
                }
            }
            

        }
    }
}
