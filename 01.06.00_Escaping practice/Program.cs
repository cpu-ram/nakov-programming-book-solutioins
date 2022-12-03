using System;

namespace Escaping_practice
{
    class Program
    {
        static void Main(string[] args)
        {
            string verbatim = @"The \ is not escaped as \\. 
                                I am at a new line.";      
            Console.WriteLine(verbatim);
        }
    }
}
