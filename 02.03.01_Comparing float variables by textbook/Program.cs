using System;

namespace _02._03._01_Comparing_float_variables_by_textbook
{
    class Program
    {
        static void Main(string[] args)
        {
            double a = 0.001;
            double b = 0.0000000000012;
            bool equal = Math.Abs(a - b) < 0.000001;
            string message;
            if (equal == true)
            {
                message = "The two variables are equal.";

            }
            else
            {
                message = "The two variables are not equal.";
            }
                    System.Console.WriteLine(message);
        }
    }
}
