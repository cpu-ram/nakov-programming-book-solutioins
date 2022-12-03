using System;

namespace _11._06_CalculatingAreaOfTriangle
{
    class Program
    {
        static int EnterInt(string intName = "integer")
        {
            Console.WriteLine("Enter {0}:", intName);
            int resultInt=0;
            resultInt = Convert.ToInt32(Console.ReadLine());
            return resultInt;
        }

        static void Main(string[] args)
        {
            double a = Convert.ToDouble(EnterInt("a"));
            double b = Convert.ToDouble(EnterInt("b"));
            double c = Convert.ToDouble(EnterInt("c"));

            double x = (Math.Pow(a, 2d) - Math.Pow(b, 2d) + Math.Pow(c, 2d))/(2*c);
            double area = (Math.Sqrt(Math.Pow(a, 2d) - Math.Pow(x, 2d)) * c) / 2;

            Console.WriteLine(area);

            
        }
    }
}
