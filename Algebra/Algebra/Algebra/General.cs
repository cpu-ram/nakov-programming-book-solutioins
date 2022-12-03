using System;
using System.Text;
using System.Collections.Generic;

namespace Algebra
{
    public static class General
    {

        public static StringBuilder GetCopy(this StringBuilder stringBuilderToCopy)
        {
            char[] charArray;
            List<char> charList = new List<char>();
            for (int i = 0; i < stringBuilderToCopy.Length; i++)
            {
                char currentChar = charList[i];
                charList.Add(currentChar);
            }
            charArray = charList.ToArray();
            string resultString = charArray.ToString();
            StringBuilder resultStringBuilder = new StringBuilder(resultString);
            return resultStringBuilder;
        }
    }
}
