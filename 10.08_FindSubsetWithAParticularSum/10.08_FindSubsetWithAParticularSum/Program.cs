using System;
using System.Collections.Generic;


namespace _10._08_FindSubsetWithAParticularSum
{
    class Program
    {
        static string[] strings, str;
        static int[] tempIntArr, elementsArr;
        static int length;
        static public List<List<int>> subsetMasks = new List<List<int>>();
        static List<List<int>> filteredResultList = new List<List<int>>();
        static List<int> tempIntList = new List<int>();

        static List<int> CreateAnIntList(params int[] elements)
        {
            List<int> resultList = new List<int>();

            foreach(int element in elements)
            {
                resultList.Add(element);
            }

            return resultList;
        }
        static void PrintIntList(List<int> entryList)
        {
            
            for(int i=0; i< entryList.Count; i++)
            {
                Console.Write($"{entryList[i]} ");
            }
            Console.WriteLine();
        }
        static bool firstElementAdded = false;
        static bool ListHasSum(List<int> intList, int sum)
        {
            int tempSum = 0;

            for(int i=0; i<intList.Count; i++)
            {
                tempSum += intList[i];
            }

            if (tempSum == sum) return true;
            else return false;
        }
        static int[] enterInts()
        {
            Console.WriteLine("Enter number of integers:");
            int intNum = Convert.ToInt32(Console.ReadLine());
            int[] resultIntArr = new int[intNum];
            for(int i=0; i<intNum; i++)
            {
                Console.WriteLine($"Enter integer element #{i}:");
                resultIntArr[i] = Convert.ToInt32(Console.ReadLine());
            }
            return resultIntArr;
        }
        static int enterInt(string name = "integer")
        {
            Console.WriteLine($"Enter {name}:");
            int resultInt = Convert.ToInt32(Console.ReadLine());
            return resultInt;
        }
        static List<int> CopyList(List<int> entryList)
        {
            List<int> resultList = new List<int>();

            foreach (int element in entryList)
            {
                resultList.Add(element);
            }

            
            return resultList;
        }


        static List<List<int>> FindAllSubsetMasks(int length)
        {
            static void Cycle(int iter, int index, int k)
            {
                if (iter == k && firstElementAdded)
                {
                    //PrintIntList(tempIntList);
                    subsetMasks.Add(CopyList(tempIntList));
                    //Console.WriteLine();
                    return;
                }
                for (int i = index; i < strings.Length; i++)
                {
                    if (!firstElementAdded) firstElementAdded = true;
                    str[iter] = Convert.ToString(elementsArr[i]);
                    tempIntList.RemoveRange(iter, tempIntList.Count - iter);
                    tempIntList.Add(elementsArr[i]);
                    Cycle(iter + 1, i + 1, k);
                }
                

            }
            strings = new string[length];
            elementsArr = new int[length];

            for (int i = 0; i < length; i++)
            {
                elementsArr[i] = i;
            } // declaring a 'dictionary'
            for (int i = 0; i <= length; i++)
            {
                str = new string[length];
                tempIntList.Clear();

                Cycle(0, 0, i);
            } // iterating through combination lengths
            return subsetMasks;
        }
        static List<List<int>> FindAllSubsets(int[] entryArr)
        {
            List<List<int>> mask = FindAllSubsetMasks(entryArr.Length);
            List<List<int>> resultList = new List<List<int>>();

            foreach(List<int> element in mask)
            {
                List<int> tempList = new List<int>();
                for(int i=0; i< element.Count; i++)
                {
                    tempList.Add(entryArr[(element[i])]);
                }
                resultList.Add(CopyList(tempList));
                tempList.Clear();
            }
            return resultList;
        }
        static void FindSubsetsWithSumOf(int[] entryIntArr, int sum)
        {
            List<List<int>> allSubsetsList=FindAllSubsets(entryIntArr);
            List<List<int>> filteredSubsets = new List<List<int>>();

            foreach(List<int> element in allSubsetsList)
            {
                if (ListHasSum(element, sum))
                {
                    filteredSubsets.Add(element);
                }
            }

            foreach(List<int> element in filteredSubsets)
            {
                PrintIntList(element);
            }
            

        }




        static void Test()
        {
            int[] intArr = enterInts();
            int sum = enterInt("sum");


            FindSubsetsWithSumOf(intArr, sum);
        }
        static void Main(string[] args)
        {
            Test();
        }
    }
}
