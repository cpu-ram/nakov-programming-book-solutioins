using System;

namespace _07._01_Simple_Array
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] simpleArr = new int[20];
            for (int i = 0; i < 20; i++)
            {
                simpleArr[i] = (i + 1) * 5;
                Console.Write($"{(i+1)*5} ");
            }
        }
    }
}
