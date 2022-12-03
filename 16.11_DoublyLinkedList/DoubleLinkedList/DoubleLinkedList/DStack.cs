using System;
namespace CustomCollections
{
    class DStack<T>
    {
        int count;
        StackNode<T> lastNode;
        public int Count { get => count; set => count = value; }
        public class StackNode<T>
        {
            T value;
            private StackNode<T> prev;

            internal StackNode<T> Prev { get => prev; set => prev = value; }
            public T Value { get => value; set => this.value = value; }

            public StackNode(T value, StackNode<T> prev)
            {
                this.Value = value;
                this.Prev = prev;
            }

        }
        public void Push(T entry)
        {
            StackNode<T> newNode = new StackNode<T>(entry, lastNode);
            lastNode = newNode;
            count++;
        }
        public T Pop()
        {
            T resultValue = lastNode.Value;
            StackNode<T> deeperNode = lastNode.Prev;
            lastNode = deeperNode;
            return resultValue;
        }
        public T Peek()
        {
            T result = lastNode.Value;
            return result;
        }
        public void Clear()
        {
            lastNode = null;
        }
    }
}
