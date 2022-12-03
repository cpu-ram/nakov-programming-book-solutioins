using System;

namespace _02._07._00_Declaring_an_object_as_a_sum_of_strings
{
    class Program
    {
        static void Main(string[] args)
        {
            string firstWord = "Hello ";
            string secondWord = "World";
            object objectOne = firstWord + secondWord;
            System.Console.WriteLine(objectOne);
            

        }
    }
}
