using System;
using System.Collections;
using System.Collections.Generic;
namespace Hashtables
{
    static public class Test
    {
        public static void TestHashTable()
        {
            HashDictionary<int, string> dict = new HashDictionary<int, string>();
            for(int i=0; i<20; i++)
            {
                string currentString = $">{i}<";
                dict.Add(i, currentString);
            }
            IEnumerator enumerator = dict.GetEnumerator();
            while (enumerator.MoveNext())
            {
                KeyValuePair<int,string> currentKeyValuePair = (KeyValuePair<int,string>)enumerator.Current;
                int currentKey = currentKeyValuePair.Key;
                string currentString = currentKeyValuePair.Value;
                Console.WriteLine(currentKey + " -> " + currentString);
            }
        }
    }
}
