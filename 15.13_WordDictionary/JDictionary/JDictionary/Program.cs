using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using TextFiles;

namespace JDictionary
{
    class WordDictionary
    {
        public class WordList
        {
            private List<string> content;
            public WordList(string sourceFile)
            {
                this.Content = ImportWordList(sourceFile);
            }

            public List<string> Content { get => content; set => content = value; }
        }
        public static List<string> ImportWordList(string srcFile)
        {
            List<string> wordList = new List<string>();

            StreamReader streamReader = new StreamReader(srcFile);
            using (streamReader)
            {
                string tempString = streamReader.ReadLine();
                while (tempString != null)
                {
                    if (!wordList.Contains(tempString))
                    {
                        wordList.Add(tempString);
                    }
                    tempString = streamReader.ReadLine();
                }
            }
            return wordList;
        }

        public class OccurencesTable
        {
            public List<string> wordList;
            public SortedDictionary<string, int> occurences = new SortedDictionary<string, int>();
            public SortedDictionary<string, int> occurencesDictionary =
                new SortedDictionary<string, int>();
            public OccurencesTable(WordList wordList, string srcFile)
            {
                this.wordList = wordList.Content;

                string match = "\\w+";
                StreamReader streamReader = new StreamReader(srcFile);
                using (streamReader)
                {
                    string tempString = streamReader.ReadLine();

                    while (tempString != null)
                    {
                        MatchCollection matches = Regex.Matches(tempString, match);
                        for (int i = 0; i < matches.Count; i++)
                        {
                            string tempMatchString = Convert.ToString(matches[i]);

                            if (wordList.Content.Contains(tempMatchString))
                            {
                                if (occurences.ContainsKey(tempMatchString))
                                {
                                    occurences[tempMatchString] += 1;
                                }
                                else occurences.Add(tempMatchString, 1);
                            }

                        }
                        tempString = streamReader.ReadLine();
                        if (tempString != null) matches = Regex.Matches(tempString, match);
                    }
                }
            }
            public void Export(string location)
            {
                string text = this.Print();
                FileEditor.Write(location, text);
            }
            public string Print(bool displayResults = false)
            {
                string resultString = "";
                StringBuilder sb = new StringBuilder();
                for (int i=0; i<wordList.Count; i++)
                {
                    if (occurences.ContainsKey(this.wordList[i]))
                    {
                        sb.Append (this.wordList[i] + ": "
                            + occurences[this.wordList[i]]+ "\n");
                    }
                }
                resultString = sb.ToString();
                if (displayResults) Console.WriteLine(resultString);
                return resultString;
            }
        }

    }
}
