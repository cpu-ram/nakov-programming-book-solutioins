using System;

namespace _03._13._00_PracticingLogicalOR
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 10;
            int origN = n; // "original 'n'"
            int p = 3;
            int v = 0;

            int m;

            m = (v == 0) ? n = n & ~(1 << p) : n = n | (1 << p);
            Console.WriteLine ("The original number equals " + origN + ", and when adjusted to have a value of " + v + " in the position of " + p + ", it equals " + m + "."); 
        }
    }
}
