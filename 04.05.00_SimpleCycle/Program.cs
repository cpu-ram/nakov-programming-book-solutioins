using System;

namespace _04._05._00_SimpleCycle
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Write("Enter the lower limit natural number:");
                int a = Int32.Parse(Console.ReadLine());

                Console.Write("Enter the higher limit natural number:");
                int b = Int32.Parse(Console.ReadLine());

                int y = 0;
                int z = 0;

                for (int x = a + 1; x < b; x++)
                {
                    if (x % 5 == 0)
                    {
                        y += 1;
                    }
                }




                int dif = b - a - 1;
                if (dif < 5)
                {
                    for (int x = a + 1; x < b; x++)
                    {
                        if (x % 5 == 0)
                        {
                            z += 1;
                        }
                    }
                }
                else
                {
                    z = dif % 5;
                }




                Console.WriteLine("Y={0}", y);
                Console.WriteLine("Z={0}", y);
            }
        }
    }
}
