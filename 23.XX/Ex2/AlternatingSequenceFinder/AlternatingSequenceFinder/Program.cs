using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace AlternatingSequenceFinder
{
    class Program
    {
        static void Main(string[] args)
        {
            RunTest();
        }

        static void RunTest()
        {
            int[] valuesSet = new int[10] { 1, 4, 5, 12, 40, 80, 100, 10000, 445, 64 };
            FindAlternatingSequences(valuesSet, 4);
        }

        enum SequenceDirection
        {
            Increase, Decrease
        }

        static void FindAlternatingSequences(int[] values, int sequenceMaxLength)
        {
            List<Sequence> sequencesFound = new List<Sequence>();
            SortedSet<int> valuesSet = new SortedSet<int>(values);
            Queue<Sequence> queue = new Queue<Sequence>();
            Sequence emptySequence = new Sequence();
            queue.Enqueue(emptySequence);

            SequenceDirection currentDirection;
            while (queue.Count > 0)
            {
                Sequence parentSequence = queue.Dequeue();
                int parentSequenceLength = parentSequence.Length;
                if (parentSequenceLength == sequenceMaxLength)
                {
                    sequencesFound.Add(parentSequence);
                    continue;
                }
                int doubleDivisionQuotient = parentSequenceLength % 2;

                SortedSet<int> filteredValues = new SortedSet<int>();
                switch (doubleDivisionQuotient)
                {
                    case 0:
                        currentDirection = SequenceDirection.Decrease;
                        break;
                    case 1:
                        currentDirection = SequenceDirection.Increase;
                        break;
                    default:
                        throw new Exception();
                }

                if (parentSequence.Length > 0)
                {
                    int topValue = parentSequence.Peek();
                    switch (currentDirection)
                    {
                        case SequenceDirection.Increase:
                            filteredValues = valuesSet.GetViewBetween(topValue + 1, int.MaxValue);
                            break;
                        case SequenceDirection.Decrease:
                            filteredValues = valuesSet.GetViewBetween(int.MinValue, topValue - 1);
                            break;
                        default:
                            throw new Exception();
                    }
                }
                else
                {
                    filteredValues = valuesSet;
                }
                HashSet<int> parentSequenceSet = parentSequence.GetElementsSet();

                IEnumerator enumerator = filteredValues.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    int currentInteger = Convert.ToInt32(enumerator.Current);
                    if (!parentSequenceSet.Contains(currentInteger))
                    {
                        Sequence childSequence = new Sequence(parentSequence);
                        childSequence.AddValue(currentInteger);
                        queue.Enqueue(childSequence);
                    }
                    else continue;
                }
            }

            StringBuilder output = new StringBuilder();
            foreach(Sequence sequence in sequencesFound)
            {
                string currentSequenceString = sequence.ToString();
                output.Append(currentSequenceString);
            }
            Console.WriteLine(output);
        }
    }
}
