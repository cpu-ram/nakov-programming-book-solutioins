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
    class IntCollection
    {
        int[] corpusArray;
        OccurenceDictionary occurences;
        public OccurenceDictionary Occurences { get => occurences; set => occurences = value; }
        public IntCollection(params int[] corpus)
        {
            this.corpusArray = corpus;
            Occurences = new OccurenceDictionary(corpus);
        }
        public class OccurenceDictionary
        {
            private List<int> keysList = new List<int>();
            public SortedDictionary<int, int> occurencesDictionary = new SortedDictionary<int, int>();
            public SortedDictionary<int, int>.KeyCollection dictionaryKeys;

            public List<int> KeysList { get => keysList; set => keysList = value; }

            public OccurenceDictionary(int[] sourceArray)
            {
                BuildOccurenceDictionary(sourceArray);
            }
            public OccurenceDictionary(string entryString)
            {
                string[] stringArr = entryString.Split(',');
                int[] resultIntArr = new int[stringArr.Length];
                for (int i=0; i<stringArr.Length; i++)
                {
                    resultIntArr[i] = Convert.ToInt32(stringArr[i]);
                }
                BuildOccurenceDictionary(resultIntArr);
            }
            public int CountOf(int entryKey)
            {
                int resultInt = occurencesDictionary[entryKey];
                return resultInt;
            }
            public bool ContainsKey(int key)
            {
                if (occurencesDictionary.ContainsKey(key)) return true;
                else return false;
            }
            public void BuildOccurenceDictionary(int[] sourceArray)
            {

                foreach (int element in sourceArray)
                {
                    if (occurencesDictionary.ContainsKey(element))
                    {
                        occurencesDictionary[element] += 1;
                    }
                    else
                    {
                        occurencesDictionary.Add(element, 1);
                        KeysList.Add(element);
                    }
                }
                dictionaryKeys = occurencesDictionary.Keys;
            }
        }
        public void DisplayCorpus()
        {
            string resultString = "";
            for(int i=0; i < corpusArray.Length; i++)
            {
                if (i == 0) resultString += corpusArray[i];
                else resultString += $",{corpusArray[i]}";
            }
            Console.WriteLine(resultString);
        }
        public void DisplayOccurenceDictionary()
        {
            string resultString = "";
            List<int> keysList = occurences.KeysList;
            for(int i=0; i<occurences.KeysList.Count; i++)
            {
                int tempInt = occurences.CountOf(keysList[i]);
                string tempString = $"{keysList[i]}: {tempInt} occurences\n";
                resultString += tempString;
            }
            Console.WriteLine(resultString);
        }
        public void DisplayMajorant()
        {
            int corpusLength = corpusArray.Length;
            int halfCorpusLength = corpusLength / 2;
            int keysLength = Occurences.KeysList.Count;
            for(int i=0; i<keysLength; i++)
            {
                int tempKey = Occurences.KeysList[i];
                int currentQuantity = Occurences.CountOf(tempKey);
                if (currentQuantity > halfCorpusLength)
                {
                    Console.WriteLine("Majorant found: '{0}"', tempKey);
                    return;
                }
                Console.WriteLine("Majorant does not exist.");
            }
        }
        public IntCollection RemoveOddOccurenceElements()
        {
            List<int> resultList = new List<int>();
            for(int i=0; i<corpusArray.Length; i++)
            {
                if (occurences.CountOf(corpusArray[i]) % 2 == 0)
                {
                    resultList.Add(corpusArray[i]);
                }
            }
            int[] resultIntArr = resultList.ToArray();
            IntCollection resultCollection = new IntCollection(resultIntArr);
            return resultCollection;
        }
    }
}
