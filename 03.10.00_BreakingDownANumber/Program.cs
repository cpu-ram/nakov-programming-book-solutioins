using System;

namespace _03._10._00_BreakingDownANumber
{
    class Program
    {
        static void Main(string[] args)
        {
            // ASSUMPTION: the number entered is always four numbers. REASON: don't want to write a check
            Console.WriteLine("Input a four-digit number");
            string input = Console.ReadLine();
            int fourDigit = Convert.ToInt32(input);

            int a = fourDigit % 10;
            int b = (fourDigit / 10) % 10;
            int c = (fourDigit / 100) % 10;
            int d = (fourDigit / 1000) % 10;

            int res1 = a+b+c+d;
            string res2 = d.ToString() + c.ToString() + b.ToString() + a.ToString();
            string res3 = d.ToString() + a.ToString() + b.ToString() + c.ToString();
            string res4 = a.ToString() + c.ToString() + b.ToString() + d.ToString();

            Console.WriteLine(res1 + " " + res2 + " " + res3 + " " + res4);

        }
    }
}
