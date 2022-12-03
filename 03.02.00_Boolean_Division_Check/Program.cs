using System;

namespace _03._02._00_Boolean_Division_Check
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = 46;
            Console.WriteLine("Does 'int a' divide integrally by both seven and five?");
            Console.WriteLine(((a % 7) == 0) && ((a % 5) == 0) ? "Yes" : "No");
        }
    }
}
