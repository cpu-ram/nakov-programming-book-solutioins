using System;

namespace _11._01_CheckingForLeapYear
{
    class Program
    {
        static int EnterInt(string entryName="integer")
        {
            Console.WriteLine($"Enter an {entryName}:", entryName);
            int year = Convert.ToInt32(Console.ReadLine());
            return year;
        }

        static void Main(string[] args)
        {
            
            int year = EnterInt();
            bool isLeapYear = DateTime.IsLeapYear(year);
            Console.WriteLine(isLeapYear);
        }
    }
}
