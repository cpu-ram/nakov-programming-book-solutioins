using System;

namespace _11._01_GeneratingRandomNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            Random randomOne = new Random();
            for(int i=0; i<10; i++)
            {
                int currentNumber = randomOne.Next(100, 200);
                Console.WriteLine(currentNumber);
            }
        }
    }
}
