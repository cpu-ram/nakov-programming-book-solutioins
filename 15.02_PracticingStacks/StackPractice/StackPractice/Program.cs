using System;
using System.Collections;

namespace StackPractice
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack testStack = new Stack();

            string entryString = "one,two,three,four,five";
            string[] stringArr = entryString.Split(",");
            foreach(string element in stringArr)
            {
                testStack.Push(element);
            }
            int stackLength = testStack.Count;
            for(int i=0; i<stackLength; i++)
            {
                Console.WriteLine(testStack.Pop());
            }
        }
    }
}
