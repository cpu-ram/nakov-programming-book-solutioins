using System;

namespace _06._12._00_Decimal_To_Binary_Conversion
{
    class Program
    {
        static string Mask(int num)
        {
            string s;
            string mask = "";

            for (int x = 31; x >= 0; x--)
            {
                if ((x <= 29) & ((x + 1) % 3 == 0))           // number order separators
                {
                    mask = mask + "'";
                }

               


                s = Convert.ToString((num >> x) & 1);
                mask = mask + s;

                




            }
            return mask;
        }



        static void Main(string[] args)
        {
            int n = 26;
            string mask = Mask(n);
            Console.WriteLine(mask);
        }
    }
}
