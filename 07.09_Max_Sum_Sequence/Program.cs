using System;
namespace _07._09_Max_Sum_Sequence
{
    class Program
    {
        static void Main(string[] args)
        {
            
            int[] arr = { 700, 4, 2, 6, 10, -300, 15, 50, 0, 0, 0, 16, 40};
            int tempSum=0;
            int maxSum = 0;
            int initialEl = 0;
            int finalEl = 0;
            string resultArrString = "";

            string arrString = "";
            foreach(int g in arr)
            {
                arrString+=$"{g} ";
            }
            Console.WriteLine(arrString);

            for(int i=0; i<arr.Length; i++)
            {
                for(int k=0; k < (arr.Length -i);k++)
                {
                    int currentElementIndex = i+k;
                    tempSum += arr[currentElementIndex];

                    Console.WriteLine($"tempsum+={arr[currentElementIndex]}= {tempSum}");

                    if ((((i > 0) | (k>0)) & (tempSum > maxSum)) | ((i == 0) & (k == 0)))
                    {
                        maxSum = tempSum;

                        
                        initialEl = i;
                        finalEl = i+k;

                        Console.WriteLine($"new maxSum assigned={maxSum}, initialEl={initialEl}, finalEl={finalEl}");

                    }
                    
                }
                Console.WriteLine();

                
            }

            
            for(int j = initialEl; j <= finalEl; j++)
            {
                resultArrString += $" {arr[j]}";
            }

            Console.WriteLine($"MaxSum={maxSum}, maxSequence={resultArrString}");
        }
    }
}
