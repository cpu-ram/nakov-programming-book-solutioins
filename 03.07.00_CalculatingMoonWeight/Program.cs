using System;

namespace _03._07._00_CalculatingMoonWeight
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Console.WriteLine("Input your Earth weight in pounds:");
            string earthWeightString = Console.ReadLine();

           
            double earthWeight = Convert.ToDouble(earthWeightString);
            
            double moonWeight = (earthWeight / 100)*17;
            Console.WriteLine(moonWeight);
        }
    }
}
