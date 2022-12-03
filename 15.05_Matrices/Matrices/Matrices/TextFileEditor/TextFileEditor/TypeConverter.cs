using System;
using System.Collections.Generic;
namespace Converter
{
    public class ArrToList
    {
        public static List<int> IntArrToIntList(int[] entryIntArr)
        {
            List<int> intList = new List<int>();
            for (int i = 0; i < entryIntArr.Length; i++)
            {
                intList.Add(entryIntArr[i]);
            }
            return intList;
        }
    }
}
