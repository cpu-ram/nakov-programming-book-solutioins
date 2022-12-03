using System;

namespace _05._02._00_A_More_Complex_If_s_Program
{
    class Program
    {
        static void Main(string[] args)
        {
            double a = 3.15;
            double b = 1;
            double c = -3.5; 

            Console.WriteLine("a={0}, b={1}, c={2}", a, b, c);
            Console.WriteLine("Sign of a={0}, b={1}, c={2}", Math.Sign(a), Math.Sign(b), Math.Sign(c));

            if ( ((Math.Sign(a)==-1) && (Math.Sign(b)==-1) && (Math.Sign(c)==1)) 
                || ((Math.Sign(b) == -1) && (Math.Sign(c) == -1) && (Math.Sign(a) == 1))
                || ((Math.Sign(a) == -1) && (Math.Sign(c) == -1) && (Math.Sign(b) == 1))
                )
            {
                Console.WriteLine("The product of the numbers is positive.");
                
            }

            else
            {
                Console.WriteLine("The product of the numbers is negative.");
            }

        }
    }
}
