using System;

namespace _03._08._00_CoordinatesWithinTwoFiguresCheck
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


            // ((xDouble >= -1) && (xDouble <= 5) && (yDouble >= 1) && (yDouble <= 5))
            bool bigBool = ((xDouble >= -1) && (xDouble <= 5) && (yDouble >= 1) && (yDouble <= 5));

            Console.WriteLine(hypothenuse <= 5 & bigBool ? "The point is within the circle with a 5 radius and a rectangle" : "The point is not simultaniously within the circle and a rectangle.");



        }


    }
        
    }
