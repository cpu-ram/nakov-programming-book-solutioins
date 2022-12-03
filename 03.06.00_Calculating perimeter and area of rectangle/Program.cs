using System;

namespace _03._06._00_Calculating_perimeter_and_area_of_rectangle
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the height of the rectangle");
            string a = Console.ReadLine();
            int aInt = Convert.ToInt32(a);


            Console.WriteLine("Enter the width of the rectangle");
            string b = Console.ReadLine();
            int bInt = Convert.ToInt32(b);

            int P = (aInt + bInt) * 2;
            int S = (aInt * bInt);
            Console.WriteLine = "P='" + P + "' S='"
        }
    }
}
