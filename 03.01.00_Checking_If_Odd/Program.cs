using System;

namespace _03._01._00_Checking_If_Odd
{
    class Program
    {

        public static bool isNumeric(string s)
        {
            return int.TryParse(s, out int n);
        }


        static void Main(string[] args)
        {
            Console.WriteLine("Hello. This program checks if a number is odd or even. \nPlease enter your number.");
            string res1 = Console.ReadLine();

            if (isNumeric(res1))
            {
                
                int remainder = ((int.Parse(res1)) % 2);
                if(remainder==0)
                {
                    Console.WriteLine("Your number is even.");
                }
                if(remainder==1)
                {
                    Console.WriteLine("Your number is odd");
                }
            }
            else 
            {
                Console.WriteLine("The number you entered is not numeric, please enter the number.");
            }



           
        }
    }
}
