using System;

namespace _07._16_Input_Sort_Query_Search
{
    class Program
    {

        static int BinarySeach(int[] arr, int query)
        {
            int searchResult = 0;

            for(int i=1; i<arr.Length; i++)
            {
                if (arr[i] < arr[i - 1])
                {
                    Console.WriteLine("Error: Array not sorted.");
                    break;
                    
                }

                if (i == arr.Length - 1) 
                {
                    Console.WriteLine("Array is sorted, proceeding with search..."); 
                }
                               
            } // checking if the 'corpus' array is sorted

            // setting values for a search cycle

            int minVal = 0;
            int maxVal = arr.Length-1;

            int mid = 0;

            bool searchOver = false;
            bool resultFound = false;

            while (!searchOver)
            {
                

                if (!((query > arr[minVal]) & (query < arr[maxVal])))  // Checking if the query is still within the minVal and maxVal values
                {
                    if (query == arr[minVal])
                    {
                        Console.WriteLine($"Number found, arr[{minVal}]={query}.");
                    }

                    if (query == arr[maxVal])
                    {
                        Console.WriteLine($"Number found, arr[{maxVal}]={query}.");
                    }

                    if (!((query == arr[maxVal]) | (query == arr[minVal])))
                    {
                        Console.WriteLine("Error #1: Query outside of bounds of the array.");
                        break;
                    }
                    break;
                }

                if ((maxVal - minVal) < 2) // checking whether there are no more elements between the minVal and maxVal
                {
                    searchOver = true;
                    Console.WriteLine("Search is over. Element not found.");
                    break;
                }

                // calculating a new "middle spot"

                if ((maxVal - minVal) % 2 == 0)
                {
                    mid = maxVal - ((maxVal - minVal) / 2);
                    Console.WriteLine($"mid={mid}.");
                }

                if ((maxVal - minVal) % 2 == 1)
                {
                    mid =  maxVal - ((maxVal - 1 - minVal) / 2); // #mightCauseError

                    Console.WriteLine($"mid={mid}.");

                }

                // found the medium, now determining if the query is bigger than it or smaller

                if (query == arr[mid])
                {
                    Console.WriteLine($"Element found. Location: arr[{mid}].");
                    searchOver = true;
                    break;
                }
                if(query != arr[mid])
                {
                    Console.WriteLine("query != arr[mid].");
                }


                if (query > arr[mid])
                {
                    minVal = mid;
                    Console.WriteLine($"arr[mid]={arr[mid]}, minVal=mid={minVal}], maxVal={maxVal}.");
                }

                if(query < arr[mid])
                {
                    maxVal = mid;
                    Console.WriteLine($"arr[mid] ={ arr[mid]}, minVal={minVal}, maxVal=mid={maxVal}.");
                }

            }

            

     

            return searchResult;
        }
        static int[] SelectionSort(int[] arr)
        {


            int minVal = 0;
            bool minValIsSet = false;
            int minValIndex = 0;

            int[] sortedArr = new int[arr.Length];
            bool[] checkedElements = new bool[arr.Length]; // 'logs' for the numbers of the checked elements of the array


            int checkedElementsNum = 0;

            minVal = arr[0];

            for (int h = 0; h < arr.Length; h++)
            {


                for (int i = 0; i < arr.Length; i++)
                {
                    


                    if (!(checkedElements[i] == true))
                    {
                        if (minValIsSet == false)
                        {
                            minVal = arr[i];
                            minValIsSet = true;

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
                        
                        minValIsSet = false;
                    }

                }
            }

            Console.Write("Sorted array:\n");
            foreach(int x in sortedArr)
            {
                Console.Write("{0,-3}",x);
            }

            Console.Write("\n");
            for (int i=0; i<arr.Length; i++)
            {
                Console.Write("{0,-3}",i);
            }

            return sortedArr;
        }
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("_________\nEnter the array of integral numbers separated by space.");

                string entryString = Console.ReadLine();

                string[] stringArr = entryString.Split(" ");


                int[] intArr = new int[stringArr.Length];

                int x = 0;
                foreach (string i in stringArr)
                {
                    intArr[x] = Convert.ToInt32(i);
                    x++;

                }

                int[] sortedArr = SelectionSort(intArr);

                Console.WriteLine("\nEnter the number you're searching for:");
                int query = Convert.ToInt32(Console.ReadLine());


                BinarySeach(sortedArr, query);

            }
        }
    }
}
