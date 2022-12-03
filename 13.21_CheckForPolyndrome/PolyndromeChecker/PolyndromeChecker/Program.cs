using System;
using System.Text;
using System.Collections.Generic;
using StringEditor;
using System.Text.RegularExpressions;

namespace PalyndromeChecker
{
    class Program
    {
        static bool IsPalyndrome(string entryString)
        {
            string tempString = entryString.ToLower();
            int forwardCounter = 0;
            int reverseCounter = entryString.Length-1;

            while (forwardCounter < reverseCounter)
            {
                if (tempString[forwardCounter] != tempString[reverseCounter])
                {
                    return false;
                }
                forwardCounter++;
                reverseCounter--;
            }

            return true;
        }

        static void Test()
        {
            List<string> resultList = new List<string>();

            string text = "Write a program abba that reads a string from exe the console and prints " +
                "in alphabetical order all letters from the input string and how loooool many times " +
                "each one of aha them occurs i ohoho the string.";
            string pattern = "[a-zA-Z]+";
            MatchCollection words = Regex.Matches(text, pattern);
            for(int i=0; i < words.Count; i++)
            {
                string tempString;
                tempString = Convert.ToString(words[i]);

                if (IsPalyndrome(tempString))
                {
                    resultList.Add(tempString);
                }
            }
            for(int i=0; i<resultList.Count; i++)
            {
                Console.WriteLine(resultList[i]);
            }
            
        }

        static void Main(string[] args)
        {
            Test();
        }
    }
}
