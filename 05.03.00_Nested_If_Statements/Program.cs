using System;

namespace _05._03._00_Nested_If_Statements
{
    class Program
    {
        static void Main(string[] args)
        {

            int a = 1;
            int b = 2;
            int c = 3;

            Console.WriteLine("a ={0}, b ={1}, c ={2}", a,b,c);
            Console.WriteLine("Assuming that none of these numbers are equal...");

            if (a > b)
            {
                if (a > c)
                {
                    Console.WriteLine("'a' is the biggest");
                }
                else
                {
                    Console.WriteLine("'c' is the biggest");
                }
            }

            else
            {
                if (b > c)
                {
                    Console.WriteLine("'b' is the biggest");
                }

                else
                {
                    Console.WriteLine("'c' is the biggest");
                }
            }



        }
    }
}
