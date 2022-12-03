using System;

namespace HelloCSharp
{
    class Console_Interaction
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Hello. Please state your First Name.");
            string res1 = Console.ReadLine();

            Console.WriteLine("Please state your Second Name.");
            string res2 = Console.ReadLine();



            Console.WriteLine("How do you do, {0} {1}?", res1, res2);


        }
    }
}
