using System;

namespace _02._09._00_Practicing_methods_of_using_double_quotes
{
    class Program
    {
        static void Main(string[] args)
        {
            // one of the things I practice here is the use of Unicode, and the new line "\n" symbol. The book also suggests to use Verbatim but I don't see how that's applicable
            string stringOne = "The \"use\" of quotations causes difficulties.";
            string stringTwo = "The" + '\u0022' + "use" + '\u0022' + "of quotations causes difficulties.";

            System.Console.WriteLine(stringOne + "\n" + stringTwo);


        }
    }
}
