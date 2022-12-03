using System;

namespace _03._15._00_ReplacingSeveralBits
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = 353;
            int origNum = num;

            int num3 = ((num >> 3) & 1);
            int num4 = ((num >> 4) & 1);
            int num5 = ((num >> 5) & 1);

            int num24 = ((num >> 24) & 1);
            int num25 = ((num >> 25) & 1);
            int num26 = ((num >> 26) & 1);

            num = num3 == 0 ? (num & ((~1) << 24)) : num | (1 << 24);
            num = num24 == 0 ? (num & ((~1) << 3)) : num | (1 << 3);

            num = num4 == 0 ? (num & ((~1) << 25)) : num | (1 << 25);
            num = num25 == 0 ? (num & ((~1) << 4)) : num | (1 << 4);

            num = num5 == 0 ? (num & ((~1) << 26)) : num | (1 << 26);
            num = num26 == 0 ? (num & ((~1) << 5)) : num | (1 << 5);

            Console.WriteLine("Original number = {0}, adjusted number = {1}.", origNum, num);



        }
    }
}
