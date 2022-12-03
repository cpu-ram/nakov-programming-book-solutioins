using System;
using System.Collections;
using System.Collections.Generic;
namespace Graphs
{
    public class SimpleGraph<T>
    {
        IdStorage<T> idList;
        Dictionary<int, HashSet<int>> edges;

        public SimpleGraph()
        {
            edges = new Dictionary<int, HashSet<int>>();
        }
        public int AddVertice()
        {
            int resultID=idList.Add();
            return resultID;
        }
        public void RemoveVertice(int id)
        {
            HashSet<int> childrenSet = edges[id];
            HashSet<int>.Enumerator childrenEnumerator = childrenSet.GetEnumerator();
            List<int> childrenList = new List<int>();
            while (childrenEnumerator.MoveNext())
            {
                childrenList.Add(childrenEnumerator.Current);
            }
            for(int i=0; i<childrenList.Count; i++)
            {
                RemoveEdge(id, childrenEnumerator.Current);
            }

            idList.Remove(id);
        }
        public void AddEdge(int pointOne, int pointTwo)
        {
            edges[pointOne].Add(pointTwo);
            edges[pointTwo].Add(pointOne);
        }
        public void RemoveEdge(int pointOne, int pointTwo)
        {
            if(!idList.Contains(pointOne) || !idList.Contains(pointTwo))
            {
                throw new ArgumentOutOfRangeException();
            }
            edges[pointOne].Remove(pointTwo);
            edges[pointTwo].Remove(pointOne);
        }
        public int[] GetChildren(int id)
        {
            if (!idList.Contains(id)) throw new ArgumentOutOfRangeException();
            List<int> childrenList = new List<int>();
            HashSet<int>.Enumerator enumerator = edges[id].GetEnumerator();
            while (enumerator.MoveNext())
            {
                childrenList.Add(enumerator.Current);
            }
            int[] resultArr = new int[childrenList.Count];
            for(int i=0; i<childrenList.Count; i++)
            {
                resultArr[i] = childrenList[i];
            }
            return resultArr;
        }
        public bool EdgeExists(int idOne, int idTwo)
        {
            if(!idList.Contains(idOne) || !idList.Contains(idTwo))
            {
                throw new ArgumentOutOfRangeException();
            }
            if (edges[idOne].Contains(idTwo))
            {
                return true;
            }
            else return false;
        }
    }
}
