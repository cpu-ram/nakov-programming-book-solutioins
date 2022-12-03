using System;

namespace _05._09._00_All_Combinations
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] list = { 3, -2, 1, 1, 8 };


            int sum = 0;
            int counter = 0;

            for (int a = 0; a <= 1; a++)
            {
                
                
                for (int b = 0; b <= 1; b++)
                {
                    for (int c = 0; c <= 1; c++)
                    {
                        for (int d = 0; d <= 1; d++)
                        {
                            for (int e = 0; e <= 1; e++)
                            {
                                counter++;

                                int a1 = a * list[0];
                                int b1 = b * list[1];
                                int c1 = c * list[2];
                                int d1 = d * list[3];
                                int e1 = e * list[4];

                                sum = a1+b1+c1+d1+e1;
                                
                                if (sum == 0)
                                {
                                    
                                    Console.WriteLine($"sum=0 when a={a1}, b={b1}, c={c1}, d={d1}, e={e1}");
                                }
                            }
                        }
                    }
                }
            }


            Console.WriteLine($"Number of cycle iterations={counter}");




        }
    }
}
