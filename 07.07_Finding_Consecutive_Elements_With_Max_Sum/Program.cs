using System;

namespace _07._07_Finding_Consecutive_Elements_With_Max_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
            int length = 0;
            int subSeqLength = 0;
            int initialElement = 0;


            Console.WriteLine("Enter an array length:");
            length = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Enter the number of consecutive elements to constitute a max-sum subsequence:");
            subSeqLength = Int32.Parse(Console.ReadLine());
            Console.WriteLine();

            int[] arr = new int[length];

            for (int g = 0; g < length; g++)
                {
                    Console.WriteLine($"Enter the element #{g}:");
                    arr[g] = Int32.Parse(Console.ReadLine());
                }

            for (int i = 0; i < length; i++)
                {
                    Console.Write(arr[i]);
                }   
            
            Console.WriteLine();

            

            

            int sum = 0;
            int maxSum = 0;

            
                for (int i = 0; i < (length - subSeqLength + 1); i++)
                {

                    Console.WriteLine($"\nint 'i'={i}");

                    for (int f = 0; f < subSeqLength; f++)
                    {
                        Console.WriteLine($"int 'f'={f}");

                        sum += arr[i + f];
                        if (f == (subSeqLength-1))
                        {
                            Console.WriteLine($"sum={sum}");

                            if (sum > maxSum)
                            {
                                maxSum = sum;
                                initialElement = i;
                            }
                            sum = 0;
                        }
                    }
                }

                Console.WriteLine($"The sub-sequence of {subSeqLength} consecutive elements with the biggest sum is the sub-sequence that starts with the element {initialElement} ");
            }
        }
    }
}
