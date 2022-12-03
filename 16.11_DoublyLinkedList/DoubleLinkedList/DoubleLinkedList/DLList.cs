using System;
using System.Collections.Generic;
namespace CustomCollections
{
    class DLList<T>
        where T : IComparable<T>
    {
        int count;
        DLListNode firstNode;
        DLListNode lastNode;

        public int Count { get => count; set => count = value; }


        public class DLListNode
        {
            T value;
            private DLListNode prev;
            private DLListNode next;

            internal DLListNode Prev { get => prev; set => prev = value; }
            internal DLListNode Next { get => next; set => next = value; }
            public T Value { get => value; set => this.value = value; }

            public DLListNode(T value, DLListNode prev, DLListNode next)
            {
                this.Value = value;
                this.Prev = prev;
                this.Next = next;
            }

        }
        public void AddFirst(T value)
        {
            if (firstNode == null)
            {
                DLListNode newElement = new DLListNode(value, null, lastNode);
                firstNode = lastNode = newElement;
            }
            else
            {
                DLListNode newElement = new DLListNode(value, null, firstNode);
                firstNode.Prev = newElement;
                firstNode = newElement;
            }
            Count++;
        }
        public void AddLast(T value)
        {
            if (lastNode == null)
            {
                DLListNode newElement = new DLListNode(value, null, null);
                this.lastNode = this.firstNode = newElement;
            }
            else
            {
                DLListNode newElement = new DLListNode(value, lastNode, null);
                lastNode.Next = newElement;
                lastNode = newElement;
            }
            Count++;
        }
        public DLListNode ElementAt(int index)
        {
            if (index >= this.Count)
            {
                throw new IndexOutOfRangeException();
            }
            if (index == 0)
            {
                return firstNode;
            }
            int counter = 0;
            DLListNode currentElement = this.firstNode;
            while (counter < index)
            {
                currentElement = currentElement.Next;
                counter++;
            }
            if (index == counter)
            {
                return currentElement;
            }
            return null;

        }
        public void InsertAtPosition(T entry, int index)
        {
            if (index >= count) throw new IndexOutOfRangeException();
            DLListNode currentIndexHolder = ElementAt(index);
            DLListNode elementBeforeCurrent = currentIndexHolder.Prev;
            DLListNode newElement = new DLListNode(entry, elementBeforeCurrent, currentIndexHolder);
            currentIndexHolder.Prev = newElement;
            elementBeforeCurrent.Next = newElement;
            Count++;
        }
        public void RemoveAt(int index)
        {
            DLListNode currentIndexHolder = ElementAt(index);
            DLListNode elementBefore = currentIndexHolder.Prev;
            DLListNode nextElement = currentIndexHolder.Next;
            elementBefore.Next = nextElement;
            nextElement.Prev = elementBefore;
            Count--;
        }
        public int[] Search(T query, bool printResults = true)
        {
            int currentIndex = 0;
            List<int> positionsFoundList = new List<int>();
            int[] positionsFoundIntArr;
            DLListNode entryElement = this.firstNode;
            DLListNode currentElement = entryElement;
            while (currentIndex < Count)
            {
                if (currentElement.Value.Equals(query)) positionsFoundList.Add(currentIndex);
                currentElement = currentElement.Next;
                currentIndex++;
            }
            positionsFoundIntArr = positionsFoundList.ToArray();
            return positionsFoundIntArr;
        }
        public string Print()
        {
            string resultString = "";
            int currentPosition = 0;
            DLListNode currentElement = firstNode;
            Console.WriteLine(currentElement.Value);
            resultString += currentElement.Value;
            while (currentPosition < Count - 1)
            {
                currentElement = currentElement.Next;
                currentPosition++;
                Console.WriteLine(currentElement.Value);
                resultString += currentElement.Value;
            }
            Console.WriteLine();
            return resultString;
        }

        public void BubbleSort()
        {
            bool changesMade;
            DLListNode currentElement;
            while (true)
            {
                this.Print();
                currentElement = firstNode;
                changesMade = false;
                while (currentElement.Next != null)
                {
                    DLListNode nextElement = currentElement.Next;
                    T currentElementValue = currentElement.Value;
                    T nextElementValue = nextElement.Value;
                    if ((currentElementValue.CompareTo(nextElementValue))
                        > 0)
                    {
                        currentElement.Value = nextElementValue;
                        nextElement.Value = currentElementValue;
                        changesMade = true;
                    }
                    currentElement = currentElement.Next;
                }
                if (changesMade == false) break;
            }
        }
    }
}
