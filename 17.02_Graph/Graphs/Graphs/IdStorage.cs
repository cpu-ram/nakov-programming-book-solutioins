using System;
using System.Collections.Generic;
namespace Graphs
{
    
    public class IdStorage<T>
    {
        internal SortedSet<int> presentIDs;
        internal SortedSet<int> absentIDs;
        internal int capacity;

        public IdStorage()
        {
            presentIDs = new SortedSet<int>();
            absentIDs = new SortedSet<int>();
            capacity = 0;
        }

        public int Add()
        {
            if (absentIDs.Count > 0)
            {
                int resultID = absentIDs.Min;
                absentIDs.Remove(resultID);
                presentIDs.Add(resultID);
                capacity++;
                return resultID;
            } 
            else
            {
                presentIDs.Add(capacity);
                int resultId = capacity;
                capacity++;
                return resultId;
            }
        }
        public void Remove(int id)
        {
            if (!presentIDs.Contains(id)) throw new ArgumentOutOfRangeException();
            else
            {
                int tempMaxPresentID = presentIDs.Max;
                presentIDs.Remove(id);
                if (tempMaxPresentID == id)
                {
                    capacity--;
                    return;
                }
                else
                {
                    absentIDs.Add(id);
                    return;
                }
                
            }
        }
        public bool Contains(int id)
        {
            if (presentIDs.Contains(id)) return true;
            else return false;
        }
        public int[] GetIDs()
        {
            List<int> tempList = new List<int>();
            IEnumerator<int> enumerator = presentIDs.GetEnumerator();
            while (enumerator.MoveNext())
            {
                tempList.Add(enumerator.Current);
            }
            int totalCount = tempList.Count;
            int[] resultArray = new int[totalCount];
            for(int i=0; i<totalCount; i++)
            {
                resultArray[i] = tempList[i];
            }
            return resultArray;
        }
        public int Capacity
        {
            get
            {
                return this.capacity;
            }
        }

        public int Count { get => presentIDs.Count; }
    }
}
