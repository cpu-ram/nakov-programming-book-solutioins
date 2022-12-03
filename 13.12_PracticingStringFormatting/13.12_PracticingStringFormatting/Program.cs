using System;
using StringEditor;

namespace _13._12_PracticingStringFormatting
{
    class Program
    {
        static void Main(string[] args)
        {
            ///string entryString = StringEditor.ConsoleEntry.EnterString();
            int entryInt = 33;
            Console.WriteLine("{0:d15}", 33);
            Console.WriteLine("{0:x15}", entryInt);
            Console.WriteLine("{0:p15}", entryInt);
            Console.WriteLine("{0:c15}", entryInt);
            Console.WriteLine("{0:e15}", entryInt);
        }
    }
}
