using System;
namespace ConsoleTools
{
    public class ConsoleReader
    {
        public static string EnterString(string stringName = "string")
        {
            Console.WriteLine("Enter {0}:", stringName);
            string resultString = Console.ReadLine();
            return resultString;
        }
    }
}
