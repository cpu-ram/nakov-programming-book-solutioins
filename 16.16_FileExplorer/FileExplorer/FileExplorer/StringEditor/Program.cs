using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace StringEditor
{
    public class StringSearcher
    {
        public string source;
        public StringBuilder sourceSB = new StringBuilder();
        const char Whitespace = ' ';
        public enum UnitType
        {
            Word, Sentence, Paragraph
        }

        public StringSearcher(string entryString, bool DisplayResults = true)
        {
            source = entryString;
            sourceSB.Append(source);
        }

        static public bool IsSeparatorCharacter(char entryChar, UnitType entryUnitType)
        {
            Regex wordSeparator = new Regex("[^a-zA-Z]");
            Regex sentenceSeparator = new Regex("[.?!]");

            switch (entryUnitType)
            {
                case UnitType.Word:

                    if (wordSeparator.IsMatch(Convert.ToString(entryChar)))
                    {
                        return true;
                    }
                    else return false;
                case UnitType.Sentence:
                    if (sentenceSeparator.IsMatch(Convert.ToString(entryChar)))
                    {
                        return true;
                    }
                    else return false;
                default:
                    throw new Exception("Error: unsupported text unit type entered.");
            }
        }
        static public Tuple<int, int> FindBoundaries(string entryString, UnitType unitType, int position, bool displayResults = true)
        {
            StringBuilder sb = new StringBuilder();

            if (position == -1)
            {
                throw new Exception("Error: search start position not set.");
            }

            char separator;
            Tuple<int, int> boundaries = null;
            int initialPosition = position;
            int tempPosition = initialPosition;
            int leftBoundary = -1;
            int rightBoundary = -1;

            for (tempPosition = initialPosition; tempPosition >= 0; tempPosition--)
            {
                if (IsSeparatorCharacter(entryString[tempPosition], unitType))
                {
                    leftBoundary = tempPosition + 1;
                    break;
                }
                if (tempPosition == 0)
                {
                    leftBoundary = 0;
                }
            }
            for (tempPosition = initialPosition; tempPosition <= entryString.Length; tempPosition++)
            {
                if (IsSeparatorCharacter(entryString[tempPosition], unitType))
                {
                    rightBoundary = tempPosition;
                    break;
                }
                if (tempPosition == entryString.Length - 1)
                {
                    rightBoundary = entryString.Length - 1;
                }
            }
            boundaries = new Tuple<int, int>(leftBoundary, rightBoundary);

            if (displayResults)
            {
                Console.WriteLine(boundaries.ToString());
                HighlightSectionsInString(entryString, boundaries);
            }
            return boundaries;
        }

        public static int[] SearchInsideString(string entryString, string query, bool caseSensitive = true)
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
            bool caseSensitive = false)
        {
            int indexAdjustment = 0;
            int tempPosition = 0;
            string openingBracket = "->[";
            string closingBracket = "]<-";

            StringBuilder tempSB = new StringBuilder();
            tempSB.Append(entryString);

            int[] positions = SearchInsideString(entryString, query, caseSensitive);

            for (int i = 0; i < positions.Length; i++)
            {
                tempPosition = positions[i] + indexAdjustment;
                tempSB.Insert(tempPosition, openingBracket);
                indexAdjustment += openingBracket.Length;
                tempPosition += query.Length + openingBracket.Length;
                tempSB.Insert(tempPosition, closingBracket);
                indexAdjustment += closingBracket.Length;
            }
            Console.WriteLine(tempSB);

        }

        public static void RemoveProhibitedWords(string entryString, params string[] prohibitedWords)
        {
            StringBuilder sb = new StringBuilder();
            bool[] prohibitedCharactersBoolArr = new bool[entryString.Length];

            for(int i=0; i<prohibitedWords.Length; i++) // for each of the forbidden words
            {
                int[] tempIndeces = SearchInsideString(entryString, prohibitedWords[i]);
                    //find all instances of it in the text
                for(int j=0; j<tempIndeces.Length; j++)
                    // and for each instance...
                {
                    int currentInstanceIndex=tempIndeces[j];
                    for(int k=0; k<prohibitedWords[i].Length; k ++)
                        // and for each of the characters of the instance...
                    {
                        int currentCharacterIndex = currentInstanceIndex + k;
                        prohibitedCharactersBoolArr[currentCharacterIndex] = true;
                    }
                }
                
            }

            for(int l=0; l<entryString.Length; l++)
            {
                if (prohibitedCharactersBoolArr[l] == true)
                {
                    sb.Append("*");
                    continue;
                }
                else
                {
                    sb.Append(entryString[l]);
                }
            }
            Console.WriteLine(sb);
        }

        public static void HighlightSectionsInString(string entryString,
            params Tuple<int,int>[] boundaries)
        {
            StringBuilder sb = new StringBuilder();
            int sourcePosition = 0;
            int tupleCounter = 0;

            string openingBracket = "\n->[";
            string closingBracket = "]<-\n";

            for (int i=0; i<entryString.Length; i++)
            {
                if (tupleCounter < boundaries.Length && i == boundaries[tupleCounter].Item1)
                {
                    sb.Append(openingBracket);
                }

                sb.Append(entryString[i]);

                if (tupleCounter < boundaries.Length && i == boundaries[tupleCounter].Item2)
                {
                    sb.Append(closingBracket);
                    tupleCounter++;
                }
                
            }
            Console.WriteLine(sb);
        }

        public static void HighlightSentencesContainingAWord(string entrySourceString, string query)
        {
            int[] intArr = SearchInsideString(entrySourceString, query);
            Tuple<int, int>[] sentenceBoundaries = new Tuple<int, int>[intArr.Length];
            for(int i=0; i<intArr.Length; i++)
            {
                Tuple<int, int> currentSentenceBoundaries = FindBoundaries(entrySourceString, UnitType.Sentence, intArr[i], false);
                sentenceBoundaries[i] = currentSentenceBoundaries;
            }
            HighlightSectionsInString(entrySourceString, sentenceBoundaries);
        }
    }
    public class ConsoleEntry
    {
        public static string EnterString(string stringName="string")
        {
            Console.WriteLine("Enter {0}:", stringName);
            string resultString = Console.ReadLine();
            return resultString;
        }
    }


    class Program
    {
        static void Test()
        {
            string testString = "Моя музыка всегда со мной, Noize MC is always ready to make some noize";
            StringSearcher.RemoveProhibitedWords(testString, "noize", "Noize", "MC");

        }

        static void TestTwo()
        {
            string testString = "Won't you come here people. " +
               "Won't you listen to my tale? I will sing you about " +
               "the great battles of the Civil War.";
            StringSearcher stringSearcherOne = new StringSearcher(testString);
            StringSearcher.SearchInsideString(testString, "you");
        }

        static void NotMain(string[] args)
        {
            Test();
        }
    }
}
