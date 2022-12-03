using System;
using System.Collections.Generic;

namespace CustomCollections
{
    class Program
    {
        static void Test()
        {
            int capacity = 4;
            DLList<int> myList = new DLList<int>();
            int[] intArr = { 0, 1, 2, 3, 4, 5, 6, 7 };
            Array.Reverse(intArr);
            foreach(int element in intArr)
            {
                myList.AddLast(element);
            }
            Console.Clear();
            myList.BubbleSort();
            myList.Print();
        }
        static void Main(string[] args)
        {
            Test();
        }
    }
}
