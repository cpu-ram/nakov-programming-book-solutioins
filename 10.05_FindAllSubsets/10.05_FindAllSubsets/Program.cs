using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;


namespace _10._05_FindAllSubsets
{
    class Program
    {
        static string[] strings, str;
        static int[] tempIntArr, elementsArr;
        static int length;
        static List<List<int>> resultList = new List<List<int>>();


        static void Cycle(int iter, int index, int k)
        {
            if (iter == k)
            {
                for (int i = 0; i < length; i++)
                    Console.Write("{0} ", str[i]);
                Console.WriteLine();



                return;
            }

            for (int i = index; i < strings.Length; i++)
            {
                str[iter] = Convert.ToString(elementsArr[i]);
                Cycle(iter + 1, i + 1, k);
            }
        }

        static void Main(string[] args)
        {
            Console.Write("Enter words length: ");
            length = Int32.Parse(Console.ReadLine());

            strings = new string[length];
            elementsArr = new int[length];

            for (int i = 0; i < length; i++)
            {
                elementsArr[i] = i;
            }

            for (int i = 0; i <= length; i++)
            {
                str = new string[length];

                tempIntArr = new int[i];
                Cycle(0, 0, i);
            }
        }
    }
}
