using System;

namespace _10._07_FindPermutations
{
    class Program
    {
        static void FindPermutations(int n, int permIndex, bool[] usedNumbers, int[] permutation)
        {
            if (permIndex == n)
            {
                Print(permutation);
                return;
            }
            for (int i = 0; i < n; i++)
            {
                if (usedNumbers[i] == false)
                {
                    permutation[permIndex] = i + 1;
                    usedNumbers[i] = true;
                    FindPermutations(n, permIndex + 1, usedNumbers, permutation);
                    usedNumbers[i] = false;
                }
            }
        }
        static void Print(int[] permutation)
        {
            for (int i = 0; i < permutation.Length; i++)
            {
                Console.Write(permutation[i]);
                if (i < permutation.Length - 1)
                {
                    Console.Write(" ");
                }
            }
            Console.WriteLine();
        }
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            bool[] usedNumbers = new bool[n];
            int[] permutation = new int[n];
            FindPermutations(n, 0, usedNumbers, permutation);
        }
    }
}
