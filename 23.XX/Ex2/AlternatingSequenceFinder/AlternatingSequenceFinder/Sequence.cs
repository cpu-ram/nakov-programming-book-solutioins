using System;
using System.Collections.Generic;
using System.Text;

namespace AlternatingSequenceFinder
{
    public class Sequence
    {
        private int length;
        private List<int> values;

        public Sequence(params int[] values)
        {
            this.values = new List<int>();
            this.length = 0;
            for (int i = 0; i < values.Length; i++)
            {
                int currentValue = values[i];
                AddValue(currentValue);
            }
        }
        public Sequence(Sequence templateSequence)
        {
            this.length = 0;
            this.values = new List<int>();
            for(int i=0; i<templateSequence.Length; i++)
            {
                AddValue(templateSequence.values[i]);
            }
        }

        public int Length { get => length; set => length = value; }
        public void AddValue(int entryValue)
        {
            values.Add(entryValue);
            length++;
        }

        public bool ContainsValue(int query)
        {
            for (int i = 0; i < length; i++)
            {
                if (values[i] == query)
                {
                    return true;
                }
            }
            return false;
        }
        public int Peek()
        {
            if (Length == 0) throw new ArgumentOutOfRangeException();
            int result = this.values[Length-1];
            return result;
        }
        public HashSet<int> GetElementsSet()
        {
            HashSet<int> resultSet = new HashSet<int>();
            for(int i=0; i<Length; i++)
            {
                int currentValue;
                currentValue = values[i];
                if (!resultSet.Contains(currentValue))
                {
                    resultSet.Add(currentValue);
                }
            }
            return resultSet;
        }
        
        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("\n");
            for(int i=0; i<Length; i++)
            {
                stringBuilder.Append(values[i]);
                if(i<Length-1) stringBuilder.Append("-");
            }
            string resultString = Convert.ToString(stringBuilder);
            return resultString;
        }

    }
}
