using System;
using System.Collections.Generic;

namespace Queues
{
    class Program
    {
        public class WeirdSequence
        {
            int elementZero;
            int length = 0;
            Queue<int> queue = new Queue<int>();

            public WeirdSequence(int n)
            {
                elementZero = (n);
                queue.Enqueue(elementZero);
                Calculate(elementZero);

            }
            public void Calculate(int n)
            {
                int elementOne = n + 1;
                int elementTwo = n * 2;
                int elementThree = n + 2;
                int[] threeElements = { elementOne, elementTwo, elementThree };
                foreach(int element in threeElements)
                {
                    AddElement(element);
                    if (length == 50) return;
                }

                queue.Dequeue();
                Calculate(queue.Peek());

            }
            public void AddElement(int entryInt) // must be a try-type bool!
            {

                Console.WriteLine(length+ " " + entryInt);
                queue.Enqueue(entryInt);
                length++;
            }

        }
        

        static void Main(string[] args)
        {
            WeirdSequence seq = new WeirdSequence(4);
            

        }
    }
}
