using System;
using System.Text;

namespace _13._02_StringReverser
{
    class Program
    {
        static string ReverseString(string entryString)
        {
            StringBuilder sb = new StringBuilder(entryString);
            int sbLength = sb.Length;

            for(int i=0; i<sbLength/2; i++)
            {
                StringBuilder tempSB = new StringBuilder();
                tempSB = new StringBuilder();
                tempSB.Append(sb[i]);
                sb[i] = sb[sb.Length - 1 - i];
                sb[sb.Length - 1 - i] = tempSB[0];

            }
            string resultString = sb.ToString();
            return resultString;
        }

        static void Main(string[] args)
        {
            string testString = "Hello world";
            string resultString = ReverseString(testString);
            Console.WriteLine(resultString);
        }
    }
}
