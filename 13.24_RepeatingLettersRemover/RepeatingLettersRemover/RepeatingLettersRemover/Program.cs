using System;
using System.Text;
using System.Text.RegularExpressions;

namespace RepeatingLettersRemover
{
    class Program
    {
        static void RemoveRepeatingLetters(string entryString)
        {
            StringBuilder sb = new StringBuilder();
            StringBuilder resultSB = new StringBuilder();

            sb.Append(entryString);
            bool[] keepCharacter = new bool[sb.Length];
            for (int i = 0; i < keepCharacter.Length; i++) keepCharacter[i] = true;
            bool countingRepeatedCharacters = false;
            bool streakCutConditions = false;
            int streakLength = 1;
            int exampleCharId = 0;
            char exampleChar = sb[exampleCharId];
            for(int i=1; i<sb.Length; i++)
            {
                if (sb[i] == exampleChar)
                {
                    if (i == sb.Length - 1)
                    {
                        for(int j=exampleCharId+1; j < sb.Length; j++)
                        {
                            keepCharacter[j] = false;
                        }
                        break;
                    }
                    streakLength++;
                    continue;
                }
                if (sb[i] != exampleChar)
                {
                    if (streakLength > 1)
                    {
                        for (int j = exampleCharId+1; j < i; j++)
                        {
                            keepCharacter[j] = false;
                        }

                    }
                    exampleCharId = i;
                    exampleChar = sb[i];
                    streakLength = 1;
                }

            }
            for(int i=0; i<sb.Length; i++)
            {
                if (keepCharacter[i]) resultSB.Append(sb[i]);
            }
            Console.WriteLine(resultSB);

        }

        static void Main()
        {
            string randomString = "aaaaa bbbb abccccd eeee";
            RemoveRepeatingLetters(randomString);
        }
    }
}
