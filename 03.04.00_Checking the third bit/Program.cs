using System;

namespace _03._04._00_Checking_the_third_bit
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = 25;
            
            int i = 1;
            int bitNumber = 6;
            int mask = i << bitNumber;

            bool bit3 = (num & mask) != 0;
            Console.WriteLine(bit3 ? "Third bit of the 'num' mumber is 1." : "Third bit of the 'num' mumber is 0.");
        }
    }
}
