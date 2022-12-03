using System;
using System.Collections.Generic;
using System.Text;

namespace _13._05_SearchingInsideString
{
    class Program
    {

        static int[] SearchInsideString(string entryString, string query, bool caseSensitive=true)
        {
            string tempString = entryString;
            string tempQuery = query;

            if (caseSensitive == false)
            {
                tempString = tempString.ToLower();
                tempQuery = tempQuery.ToLower();
            }

            List<int> positionsFound = new List<int>();
            int startIndex = 0;
            while (startIndex != -1)
            {
                startIndex = tempString.IndexOf(tempQuery, startIndex);
                if (startIndex != -1)
                {
                    positionsFound.Add(startIndex);
                    if (startIndex != tempString.Length - 1)
                    {
                        startIndex += 1;
                    }
                }
                
            }
            if (positionsFound.Count > 0)
            {
                int[] resultIntArr = new int[positionsFound.Count];
                for (int i = 0; i < positionsFound.Count; i++)
                {
                    resultIntArr[i] = positionsFound[i];
                }
                return resultIntArr;
            }
            else return null;


        }
        static void HighlightQueryInString(string entryString, string query,
            bool caseSensitive=false)
        {
            int indexAdjustment = 0;
            int tempPosition = 0;
            string openingBracket = "->[";
            string closingBracket = "]<-";

            StringBuilder tempSB = new StringBuilder();
            tempSB.Append(entryString);

            int[] positions = SearchInsideString(entryString, query, caseSensitive);

            for(int i=0; i<positions.Length; i++)
            {
                tempPosition = positions[i]+indexAdjustment;
                tempSB.Insert(tempPosition, openingBracket);
                indexAdjustment += openingBracket.Length;
                tempPosition += query.Length + openingBracket.Length;
                tempSB.Insert(tempPosition, closingBracket);
                indexAdjustment += closingBracket.Length;
            }
            Console.WriteLine(tempSB);

        }


        static void TestOne()
        {
            string tempString = "We are living in a yellow submarine. " +
                "We don't have anything else. Inside the submarine is very tight. " +
                    "So we are drinking all the day. We will move out of it in 5 days.";

            string query = "in";
            HighlightQueryInString(tempString, query);
        }
        static void TestTwo()
        {
            string tempString = "We are living in a yellow submarine. " +
                "We don't have anything else. Inside the submarine is very tight. " +
                    "So we are drinking all the day. We will move out of it in 5 days.";

            string query = "in";
            int[] positions = SearchInsideString(tempString, query);
            foreach (int element in positions)
            {
                Console.WriteLine(element);
            }

        }
        static void TestStringInsert()
        {
            string testString = "Hello world";
            string exclamationPoint = "!";
            testString=testString.Insert(testString.Length, exclamationPoint);
            Console.WriteLine(testString);
        }
        static void Main(string[] args)
        {
            TestOne();
        }
    }
}
