using System;

namespace _10._02_FindingVariationsWithDuplicatesRecursive
{
    class Program
    {


        static void FindVariationsWithDuplicates(int n, int k)
        {
            int[] dictionary = new int[n];
            for (int i=0; i<n; i++)
            {
                dictionary[i] = i;
            }

            int[] tempVariation = new int[k];

            FindVariations(dictionary, tempVariation);


            static void FindVariations(int[] elementsArr, int[] tempVariation, int counter = 0)
            {
                if (counter == tempVariation.Length)
                {
                    Console.WriteLine();
                    foreach(int element in tempVariation)
                    {
                        Console.Write(element + " ");
                    }
                    Console.WriteLine();
                }

                else
                { 

                    for(int j=0; j < elementsArr.Length; j++)
                    {
                        tempVariation[counter] = elementsArr[j];
                        FindVariations(elementsArr, tempVariation, counter + 1);

                    }

                }
            }



        }

        static void Main(string[] args)
        {
            FindVariationsWithDuplicates(3, 3);
        }
    }
}
