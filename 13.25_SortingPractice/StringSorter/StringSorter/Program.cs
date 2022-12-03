using System;
using StringEditor;

namespace StringSorter
{
    class Program
    {
        static void Main(string[] args)
        {
            string entryString=StringEditor.ConsoleEntry.EnterString();
            string[] stringArr = entryString.Split(",", StringSplitOptions.TrimEntries);
            Array.Sort(stringArr);
            foreach (string element in stringArr) Console.WriteLine(element);
        
        }
    }
}
