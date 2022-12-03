using System;

namespace _07._15_String_To_Char_Indexes
{
    class Program
    {
        
        static void Main(string[] args)
        {

            Console.WriteLine(Convert.ToInt32('a')+"\n");
            Console.WriteLine("Enter a word:");


            char[] charArray = Console.ReadLine().ToCharArray();

            foreach (char i in charArray)
            {
                Console.Write(Convert.ToInt32(i) - Convert.ToInt32('a') +" ");
            }
        }
    }
}
