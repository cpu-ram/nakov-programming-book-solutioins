using System;
using System.Text;
namespace PriorityQueues
{
    public class Test
    {
        public Test()
        {
        }

        public static void Run()
        {
            PriorityQueue<int> priorityQueue = new PriorityQueue<int>
                (PriorityQueue<int>.SortOrder.Standard);
            StringBuilder stringBuilder = new StringBuilder();

            int[] entryNumbers = new int[10] { 4, 1, 0, 7, 2, 6, 20, 11, 100, 5 };
            for(int i=0; i<10; i++)
            {
                priorityQueue.Add(entryNumbers[i]);
            }
            int queueCount = priorityQueue.Count;
            for(int i=0; i<queueCount; i++)
            {
                int tempInt = priorityQueue.Dequeue();
                stringBuilder.Append(tempInt + "\n");
            }
            Console.WriteLine(stringBuilder);
        }
    }
}
