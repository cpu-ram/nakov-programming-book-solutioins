using System;
using TextFiles;
namespace JDictionary
{
    public class MainClass
    {
        static void Main()
        {
            string directory = "files/";
            string sourceWordList=directory+"wordList.txt";
            string sourceText = directory+"sourceFile.txt";
            string occurencesTableFile = directory+"occurencesTable.txt";

            WordDictionary.WordList wordList= new WordDictionary.WordList(sourceWordList);
            WordDictionary.OccurencesTable occurencesTable =
                new WordDictionary.OccurencesTable(wordList, sourceText);
            occurencesTable.Export(occurencesTableFile);
        }
    }
}
