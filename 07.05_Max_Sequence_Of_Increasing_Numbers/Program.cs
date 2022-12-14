using System;

namespace _07._05_Max_Sequence_Of_Increasing_Numbers
{
    class Program
    {
        static int[] DataEntry()
        {

            Console.WriteLine("Input a sequence of numbers separated by a space.");

            string entryString = Console.ReadLine();
            string[] entryStringArray = entryString.Split(" ");


            int[] entryIntArray = new int[entryStringArray.Length];
            for (int i = 0; i < entryStringArray.Length; i++)
            {
                entryIntArray[i] = Int32.Parse(entryStringArray[i]);
            }

            Console.WriteLine();
            for (int i = 0; i < entryIntArray.Length; i++)
            {
                Console.Write($"{i} ");
            }

            Console.WriteLine();

            return entryIntArray;
        }

        static string[] ParseTheSequence()
        {

            int[] entryIntArray = DataEntry();



            int length = 1; // the length of the longest sequence of the equal elements
            int maxLength = 1;
            bool currentlyCounting = false;

            string currentInitialElement = "";
            string firstElementsOfSequences = "";


            Console.WriteLine();

            for (int i = 1; i < entryIntArray.Length; i++)
            {
                Console.WriteLine($"iteration i={i}"); // display this iteration's number
                Console.WriteLine($"element #i={entryIntArray[i]} \n"); // display the current iteration's element of the array

                if (currentlyCounting == true)
                {
                    if (entryIntArray[i] > entryIntArray[i - 1])
                    {
                        length++;
                        Console.WriteLine($"length = length+1 = {length}.");





                    }
                    if (entryIntArray[i] <= entryIntArray[i - 1]) // nullifies the count of the current number if((currently counting) & (array[i]>array[i-1]))
                    {
                        currentlyCounting = false;
                        length = 1;
                        Console.WriteLine("Last element of the sequence reached, stopping to count.");

                    }


                }

                if (currentlyCounting == false)
                {
                    if (entryIntArray[i] > entryIntArray[i - 1])
                    {

                        currentlyCounting = true;
                        Console.WriteLine("Starting to count the consecutive numbers.");
                        length++;
                        Console.WriteLine($"length = length+1 = {length}.");
                    }


                }




                if (length == maxLength)
                {

                    currentInitialElement = $"{i - (length - 1)}";
                    firstElementsOfSequences += $", {currentInitialElement}";

                    Console.WriteLine($"New sequence of length equal to the former MaxLength is found. MaxLength={maxLength }");
                    Console.WriteLine($"First element of the sequence is the element #{currentInitialElement}.");


                }

                if (length > maxLength)
                {
                    maxLength = length;

                    firstElementsOfSequences = $"{i - (length - 1)}";
                    Console.WriteLine($"New MaxLength is assigned={maxLength }");

                }
                Console.WriteLine("__________________");
            }

            string[] parseResults = new string[2];
            parseResults[0] = Convert.ToString(maxLength);
            parseResults[1] = firstElementsOfSequences;

            return parseResults;
        }
        static void Main(string[] args)
        {


            string[] parseResults = ParseTheSequence();
            int maxLength;
            string firstElementsOfSequences;

            maxLength = Int32.Parse(parseResults[0]);
            firstElementsOfSequences = parseResults[1];

            Console.WriteLine($"Max sequence length={maxLength}, the initial element number(s)=" + $"{firstElementsOfSequences}.");


        }
    }
}
