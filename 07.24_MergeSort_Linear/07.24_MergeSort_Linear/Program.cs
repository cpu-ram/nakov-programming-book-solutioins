using System;

namespace _07._24_MergeSort_Linear
{
    class Program
    {


        static int[] MergeSort(int[] entryArr)
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
                for (int i=0; i<entryArr.Length; i++)
                {
                    Console.Write(entryArr[i] + "; ");
                    
                }
                
            }
            static void PrintArr(int[,] entryArr)
            {
                int[] tempArr = new int[entryArr.GetLength(1)];

                
                for(int i=0; i<entryArr.GetLength(0); i++)
                {

                    
                    for (int j=0; j<entryArr.GetLength(1); j++)
                    {
                        tempArr[j] = entryArr[i, j];
                    }
                    PrintSingleDimArr(tempArr);
                }
            }


            int[] sourceArr = entryArr;

            int i = sourceArr.Length;
            int doubleCount = (i / 2) + (i % 2);

            if (true)
            {

                int[,] twoDimArr = new int[doubleCount, 2];

                for (int j = 0; j < twoDimArr.GetLength(0); j++)
                {
                    if ((2 * j+1) < sourceArr.Length)
                    {
                    twoDimArr[j, 0] = GreaterOfTwo(sourceArr[2*j], sourceArr[2*j + 1]);
                    twoDimArr[j, 1] = SmallerOfTwo(sourceArr[2*j], sourceArr[2*j + 1]);
                    }
                    else
                    {
                        Console.WriteLine("Something went wrong!");
                    }

                }
                
                PrintArr(twoDimArr);
            }


            static int[,] MergeSortStepTwo()
            {

                return null;
            }

            return null;
        }



        static void TestMergeSort()
        {
            int[] intArr = { 5, 4, 3, 2, 1, 0 };
            MergeSort(intArr);
        }

        static void Main(string[] args)
        {
            TestMergeSort();
        }
    }
}
