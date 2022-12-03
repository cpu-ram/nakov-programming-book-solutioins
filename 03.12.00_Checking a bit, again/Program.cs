using System;

namespace _03._12._00_Checking_a_bit__again
{
    class Program
    {
        static void Main(string[] args)
        {
            int v = 5;

            int i = 1;
            int p = 5;
            int mask = i << p;

            bool bitP= (v & mask) != 0;
            Console.WriteLine(bitP);
        }
    }
}

