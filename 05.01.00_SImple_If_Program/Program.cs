using System;

namespace _05._01._00_SImple_If_Program
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = 3;
            int b = 1;

            Console.WriteLine("a={0}, b={1}", a, b);

            if (a > b)
            {
                Console.WriteLine("a>b. Replacing their values...");
                int c = a;
                a = b;
                b = c;
                Console.WriteLine("a={0}, b={1}", a, b);
            }
        }
    }
}
