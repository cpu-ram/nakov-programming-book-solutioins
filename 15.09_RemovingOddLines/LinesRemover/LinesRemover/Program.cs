using System;
using System.IO;
using TextFiles;

namespace LinesRemover
{
    class Program
    {
        static public void AddLineNumbers(string sourceFile, string resultFile)
        {
            StreamReader sourceReader = new StreamReader(sourceFile);
            StreamWriter lineNumberAdder = new StreamWriter(resultFile);
            using (sourceReader)
            {
                int counter = 0;
                string tempString = sourceReader.ReadLine();
                using (lineNumberAdder)
                {
                    while(tempString != null)
                    {
                        tempString = counter + $" {tempString}";
                        lineNumberAdder.WriteLine(tempString);
                        tempString = sourceReader.ReadLine();
                        counter++;
                    }
                }
            }
        }
        static public void RemoveOddLines(string sourceFile, string resultFile)
        {
            StreamReader sourceReader = new StreamReader(sourceFile);
            StreamWriter evenLineWriter = new StreamWriter(resultFile);
            using (sourceReader)
            {
                using (evenLineWriter)
                {
                    string currentLine = sourceReader.ReadLine();
                    int lineCounter = 0;
                    while (currentLine != null)
                    {
                        if (lineCounter % 2 == 1)
                        {
                            evenLineWriter.WriteLine(currentLine);
                        }
                        currentLine = sourceReader.ReadLine();
                        lineCounter++;
                    }
                }
            }
        }       
    }
}
