using System;

namespace _13._08_ConvertTextToUnicodeNumbers
{
    class Program
    {
        static void ConvertToUnicodeNumbers(string entryString)
        {
            char[] charArray = entryString.ToCharArray();
            string resultString = "";

            Console.Write("\n");
            for(int i=0; i<charArray.Length; i++)
            {
                Console.Write("\\u{0:x4} ", Convert.ToInt32(charArray[i]));
            }
            Console.WriteLine();

        }

        static void Main(string[] args)
        {
            string testString = "Hello world!";
            ConvertToUnicodeNumbers(testString);
        }
    }
}
