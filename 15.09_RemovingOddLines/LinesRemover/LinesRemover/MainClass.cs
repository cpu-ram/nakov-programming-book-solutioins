using System;
using LinesRemover;

namespace LinesRemover
{
    public class MainClass
    {
        public static void Main()
        {
            string sourceFile = new string("files/sourceFile.txt");
            string fileTwo = new string("files/fileTwo.txt");
            string fileThree = new string("files/fileThree.txt");
            Program.AddLineNumbers(sourceFile, fileTwo);
            Program.RemoveOddLines(fileTwo, fileThree);
        }
    }
}
