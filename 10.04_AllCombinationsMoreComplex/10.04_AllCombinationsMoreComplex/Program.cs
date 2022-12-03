using System;

namespace _10._04_AllCombinationsMoreComplex
{
    class Program
    {
        static void FindCombinationsWithDuplicates(int n, int k)
        {
            string[] dictionary = new string[n];
            for (int i = 0; i < n; i++)
            {
                dictionary[i] = "string"+i;
            }

            string[] tempCombination = new string[k];

            FindCombinations(dictionary, tempCombination);



            static void FindCombinations(string[] elementsArr, string[] tempCombination, int counter = 0)
            {
                if (counter == tempCombination.Length)
                {
                    Console.WriteLine();
                    foreach (string element in tempCombination)
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
