using System;

namespace _10._03_CalculatingCombinationsWithRepetition
{
    class Program
    {
        static void FindCombinationsWithDuplicates(int n, int k)
        {
            int[] dictionary = new int[n];
            for (int i = 0; i < n; i++)
            {
                dictionary[i] = i;
            }

            int[] tempCombination = new int[k];

            FindCombinations(dictionary, tempCombination);



            static void FindCombinations(int[] elementsArr, int[] tempCombination, int counter = 0)
            {
                if (counter == tempCombination.Length)
                {
                    Console.WriteLine();
                    foreach (int element in tempCombination)
                    {
                        Console.Write(element + " ");
                    }
                    Console.WriteLine();
                }

                else
                {

                    for (int j = counter; j < elementsArr.Length; j++)
                    {
                        tempCombination[counter] = elementsArr[j];
                        FindCombinations(elementsArr, tempCombination, counter + 1);

                    }

                }
            }



        }

        static void Main(string[] args)
        {
            FindCombinationsWithDuplicates(3, 3);
        }
    }
}
