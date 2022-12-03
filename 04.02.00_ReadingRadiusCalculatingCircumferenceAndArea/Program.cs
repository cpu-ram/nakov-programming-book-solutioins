using System;

namespace _04._02._00_ReadingRadiusCalculatingCircumferenceAndArea
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter radius!");
            double r = double.Parse(Console.ReadLine());

            double circ = r * 2 * Math.PI;
            double area = r * ((Math.PI) *Math.PI);

            Console.WriteLine("r={0}, C={1}, S={2}", r, circ, area);

        }
    }
}
