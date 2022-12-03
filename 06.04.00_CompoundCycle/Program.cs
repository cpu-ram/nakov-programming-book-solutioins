using System;

namespace _06._04._00_CompoundCycle
{
    class Program
    {
        static void Main(string[] args)
        {
            

            string[] letters = { "A", "B", "C", "D" }; 
            for(int i=0; i<=13; i++)
            {
                for(int f=0; f<=3; f++)
                {
                    Console.WriteLine($"{letters[f]}{i} ");
                }
            }
        }
    }
}
