using System;

namespace _03._03._00_Checking_a_digit_of_a_number
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = 34733;
            int b = a / 100;
            int c = b % 10;
            Console.WriteLine("Is the third digit of the number 7?");
            Console.WriteLine((c == 7) ? "Yes" : "No");
        }
    }
}
