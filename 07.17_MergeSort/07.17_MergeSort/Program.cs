using System;
using System.Collections.Generic;

namespace _07._17_MergeSort
{
    class Program
    {
        static int SmallerOfTwo(int a, int b)
        {
            Exception somethingWrong = new Exception("Something is wrong!");


            if (a > b) return b;
            if (b > a) return a;
            if (b == a) return a;

            else throw somethingWrong;
        }
        static int GreaterOfTwo(int a, int b)
        {
            Exception somethingWrong = new Exception("Something is wrong!");

            if (a > b) return a;
            if (b > a) return b;
            if (b == a) return a;

            else throw somethingWrong;
        }
        static void PrintSingleDimArr(int[] entryArr)
        {
            Console.Write("\n");
            for (int i = 0; i < entryArr.Length; i++)
            {
                Console.Write(entryArr[i] + "; ");

            }

        }
        static void PrintArr(int[,] entryArr)
        {
            int[] tempArr = new int[entryArr.GetLength(1)];


            for (int i = 0; i < entryArr.GetLength(0); i++)
            {


                for (int j = 0; j < entryArr.GetLength(1); j++)
                {
                    tempArr[j] = entryArr[i, j];
                }
                PrintSingleDimArr(tempArr);
            }
        }

        static List<List<int>> MergeSortImplementation(List<List<int>> entryList)
        {
            Exception unknownReason = new Exception("Something went wrong");
            int halfCount = entryList.Count / 2 + entryList.Count % 2;
            List<List<int>> resultList = new List<List<int>>();
            int countOne = 0;
            int countTwo = 0;
            for(int i=0; i<halfCount; i++)
            {
                List<int> tempList = new List<int>();
                resultList.Add(tempList);

                countOne = 0;
                countTwo = 0;


                if (i*2==entryList.Count-1)
                {
                    for(int k=0; k<entryList[i*2].Count; k++)
                    {
                        resultList[i].Add(entryList[i * 2][k]);
                    }


                    break;

                } // last element of entryArr...

                

                for(int j=0; j<(entryList[0].Count)*2; j++)
                {
                    if (countOne == (entryList[2*i].Count))
                    {
                        while (countTwo<entryList[2*i+1].Count)
                        {
                            resultList[i].Add(entryList[(2 * i) + 1][countTwo]);
                            countTwo++;
                            
                        }
                        break;

                    }
                    if (countTwo == (entryList[2*i+1].Count))
                    {
                        while (countOne < entryList[2*i].Count)
                        {
                            resultList[i].Add(entryList[2*i][countOne]);
                            countOne++;
                            
                        }
                        break;
                    }


                    if (entryList[2*i][countOne] == GreaterOfTwo(entryList[2*i][countOne], entryList[2*i + 1][countTwo]))
                    {
                        resultList[i].Add(entryList[2*i][countOne]);
                        countOne++;
                        continue;
                    }
                    if(entryList[2*i+1][countTwo] == GreaterOfTwo(entryList[2*i][countOne], entryList[2*i+1][countTwo]))
                    {
                        resultList[i].Add(entryList[2*i + 1][countTwo]);
                        countTwo++;
                        continue;
                    }
                }
            }

            if (resultList.Count > 1)
            {
                resultList=MergeSortImplementation(resultList);
                if (resultList.Count == 1)
                {
                    return resultList;
                }
            }
            if (resultList.Count == 1)
            {
                return resultList;
            }
            else
            {
                throw unknownReason;
            }
        }

        static int[] MergeSort(int[] entryArr)
        {
            List<List<int>> convertedList = new List<List<int>>();
            for (int i = 0; i < entryArr.Length; i++)
            {
                List<int> tempList = new List<int>();
                tempList.Add(entryArr[i]);
                convertedList.Add(tempList);
                
            }
            List<List<int>> sortedList=MergeSortImplementation(convertedList);
            static int[] ConvertToIntArr(List<List<int>> entryList)
            {
                List<int> resultList = new List<int>();

                for (int i=0; i < entryList.Count; i++)
                    
                {
                    for(int j=0; j < entryList[i].Count; j++)
                    {
                        resultList.Add(entryList[i][j]);
                    }
                }

                int[] resultIntArr = new int[resultList.Count];

                for(int i=0; i<resultIntArr.Length; i++)
                {
                    resultIntArr[i] = resultList[i];
                }

                return resultIntArr;
            }
            int[] resultIntArr = ConvertToIntArr(sortedList);
            return resultIntArr;
        }




        static void TestMergeSort()
        {
            int[] intArr = { 2, 9, -55, 111, 20, 7, 2, 5 };
            
            int[] sortedArr=MergeSort(intArr);
            PrintSingleDimArr(sortedArr);


        }

        static void Main(string[] args)
        {
            TestMergeSort();
        }
    }
}
