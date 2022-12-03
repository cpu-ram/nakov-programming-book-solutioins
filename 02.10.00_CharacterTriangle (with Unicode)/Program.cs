using System;

namespace _02._10._00_CharacterTriangle__with_Unicode_
{
    class Program
    {
        static void Main(string[] args)
        {
            string a = "\u00A9";
            Console.WriteLine("   " + a + "   ");
            Console.WriteLine("  " + a + " " + a);
            Console.WriteLine(" " + a+a+a+a+a);
        }
    }
}
