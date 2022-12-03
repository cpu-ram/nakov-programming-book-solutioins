using System;

namespace _11._04_TickTime
{
    class Program
    {
        static void Main(string[] args)
        {
            long tickCount = Environment.TickCount;
            long remainder = tickCount;

            int[] ratios = new int[5];
            ratios[0] = 1;
            ratios[1] = 1000;
            ratios[2] = 60;
            ratios[3] = 60;
            ratios[4] = 24;
            long[] values = new long[5];


            long tempRatio = 1;
            foreach(int element in ratios)
            {
                tempRatio *= element;
            }

            int currentDivisible = 0;
            for(int i=0; i<ratios.Length; i++)
            {
                values[i] = remainder / tempRatio;
                remainder = remainder - tempRatio * values[i];
                tempRatio = tempRatio/ratios[ratios.Length-i-1];
                Console.WriteLine(values[i]);
            }

        }
    }
}
