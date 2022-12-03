using System;

namespace _07._03_Alphabetical_sorting
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {

                // The program doesn't have input validation, therefore errors are possible if the input has a wrong format.

                Console.WriteLine("Enter the first string of characters, separated by spaces.");
                string entryOne = Console.ReadLine();

                string[] stringArrayOne = entryOne.Split(' ');


                Console.WriteLine("Enter the second string of characters, separated by spaces.");
                string entryTwo = Console.ReadLine();

                string[] stringArrayTwo = entryTwo.Split(' ');

                char[] charArrayOne = new char[stringArrayOne.Length];
                char[] charArrayTwo = new char[stringArrayTwo.Length];


                for (int i = 0; i < charArrayOne.Length; i++)
                {
                    charArrayOne[i] = Char.Parse(stringArrayOne[i]);
                }

                for (int i = 0; i < charArrayTwo.Length; i++)
                {
                    charArrayTwo[i] = Char.Parse(stringArrayTwo[i]);
                }

                bool firstArrayIsLonger = false;  // array length booleans
                bool secondArrayIsLonger = false;
                bool arrayLengthsAreEqual = false;

                int length = 0; //the value used for the further-written cycle iterations number;

                bool oneArrayPrecedesAnother;       // precedes booleans;
                bool firstArrayPrecedes = false;
                bool secondArrayPrecedes = false;
                bool arraysHaveEqualPosition = false;

                if (charArrayOne.Length == charArrayTwo.Length)
                {
                    arrayLengthsAreEqual = true;
                    length = charArrayOne.Length;
                }

                if (charArrayOne.Length > charArrayTwo.Length)
                {
                    firstArrayIsLonger = true;
                    length = charArrayTwo.Length;
                    Console.WriteLine("First array's length is bigger.");
                }

                if (charArrayOne.Length < charArrayTwo.Length)
                {
                    secondArrayIsLonger = true;
                    length = charArrayOne.Length;
                    Console.WriteLine("Second array's length is bigger.");
                }

                for (int i = 0; i < length; i++)
                {
                    Console.WriteLine($"Iteration={i}, arrayOne[i]={charArrayOne[i]}," +
                        $" arrayTwo[i]={charArrayTwo[i]}");

                    if (charArrayOne[i] > charArrayTwo[i])
                    {
                        secondArrayPrecedes = true;
                        Console.WriteLine("Cycle breaks here ///");
                        break;
                    }

                    if (charArrayOne[i] < charArrayTwo[i])
                    {
                        firstArrayPrecedes = true;
                        Console.WriteLine("Cycle breaks here ///");
                        break;
                    }
                }

                

                if (!firstArrayPrecedes & !secondArrayPrecedes)
                {
                    if (arrayLengthsAreEqual)
                    {
                        arraysHaveEqualPosition = true;
                    }

                    if (firstArrayIsLonger)
                    {
                        secondArrayPrecedes = true;
                    }

                    if (secondArrayIsLonger)
                    {
                        firstArrayPrecedes = true;
                    }

                    
                }
                if (firstArrayPrecedes)
                {
                    Console.WriteLine("First array precedes the second alphabetically.");
                }

                if (secondArrayPrecedes)
                {
                    Console.WriteLine("Second array precedes the second alphabetically.");
                }

                if (arraysHaveEqualPosition)
                {
                    Console.WriteLine("Arrays are equal.");
                }

                Console.WriteLine();
            }
        }
    }
}
