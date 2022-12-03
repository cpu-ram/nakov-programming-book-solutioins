using System;

namespace _05._04._00_DescendingOrderWithCyclesAndArray
{
    class Program
    {
        static void ReplVal(ref int a, ref int b)                           // functional method -- begins
        {

            int c = a;
            a = b;
            b = c;


        }
        static void Main(string[] args)
        {

            int a = 1;
            int b = 2;
            int c = 3;

            Console.WriteLine("a={0}, b={1}, c={2}", a, b, c);

            if (a < b) { ReplVal(ref a, ref b); }
            if (b < c) { ReplVal(ref b, ref c); }
            if (a < b) { ReplVal(ref a, ref b); }


            Console.WriteLine("The variables were assorted in a descending order. Now, a={0}, b={1}, c={2}.", a,b,c);

        }
    }
}
