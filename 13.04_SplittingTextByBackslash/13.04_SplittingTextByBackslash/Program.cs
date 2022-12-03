using System;
using System.Collections.Generic;

namespace _13._04_SplittingTextByBackslash
{
    class Program
    {
        static string[] SplitTextByBackslash(string entryString)
        {
            string tempString = entryString;
            string[] stringArray = tempString.Split("\\");
            return stringArray;
        }

        static void Main(string[] args)
        {
            string exampleString = @"One\Two\Three\Four";
            string[] stringArray=SplitTextByBackslash(exampleString);
            foreach(string element in stringArray)
            {
                Console.WriteLine(element);
            }
        }
    }
}
