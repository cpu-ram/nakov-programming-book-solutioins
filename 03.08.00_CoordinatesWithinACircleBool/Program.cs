using System;

namespace _03._08._00_CoordinatesWithinACircleBool
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Input the x coordinate");
            string x = Console.ReadLine();
            Console.WriteLine("Input the y coordinate");
            string y = Console.ReadLine();

            double xDouble = Convert.ToDouble(x);
            xDouble = Math.Abs(xDouble);

            double yDouble = Convert.ToDouble(y);
            yDouble = Math.Abs(yDouble);

            double hypothenuse = Math.Sqrt((xDouble * xDouble) + (yDouble * xDouble));

            Console.WriteLine(hypothenuse <= 5 ? "The point is within the circle with a 5 radius." : "The point is outside the circle with a 5 radius.");
        }
    }
}
