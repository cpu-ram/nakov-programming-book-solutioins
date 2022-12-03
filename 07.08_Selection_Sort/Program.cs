using System;

namespace _07._08_Selection_Sort
{
    class Program
    {
        static int[] SelectionSort(int[] arr)
        {
            

            int minVal = 0;
            bool minValIsSet = false;
            int minValIndex = 0;

            int[] sortedArr = new int[arr.Length];
            bool[] checkedElements = new bool[arr.Length]; // 'logs' for the numbers of the checked elements of the array


            int checkedElementsNum = 0;

            minVal = arr[0];
            //Console.WriteLine($"minVal={minVal}.");

            for (int h = 0; h < arr.Length; h++)
            {
                

                for (int i = 0; i < arr.Length; i++)
                {
                    //Console.WriteLine($"Arr[i]={arr[i]}.");


                    if (!(checkedElements[i] == true))
                    {
                        if (minValIsSet == false)
                        {
                            minVal = arr[i];
                            minValIsSet = true;

                            //Console.WriteLine($"Min Value is reset to {arr[i]}.");
                        }


                        if (arr[i] <= minVal)
                        {
                            minVal = arr[i];


                            minValIndex = i;
                        }


                    }

                    

                    if (i == arr.Length - 1)
                    {
                        checkedElementsNum++;
                        checkedElements[minValIndex] = true;
                        sortedArr[checkedElementsNum - 1] = minVal;

                        //Console.WriteLine($"Element #{minValIndex} with a value of '{minVal}' is marked out and added to the sorted array.");
                        minValIsSet = false;   
                    }

                }
            }

            return sortedArr;
        }
        static void Main(string[] args)
        {
            int[] arr = { 4, 3, 20, 1 };
            int[] sortedArr = new int[4];

            foreach (int i in arr)
            {
                Console.Write($" {i}");
            }

            Console.WriteLine();

            sortedArr = SelectionSort(arr);

            Console.WriteLine();

            foreach (int i in sortedArr)
            {
                Console.Write($"{i} ");
            }





        }
    }
}
