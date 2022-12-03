using System;

namespace _02._08._00__Type_casting__object_to_string
{
    class Program
    {
        static void Main(string[] args)
        {
            // copied some code from the previous exercize

            string firstWord = "Hello ";
            string secondWord = "World";
            object objectOne = firstWord + secondWord;
            
            string stringOne = (string)objectOne;
            System.Console.WriteLine(stringOne);
        }
    }
}
