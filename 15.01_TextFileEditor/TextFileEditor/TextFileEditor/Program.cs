using System;
using System.Text;
using System.IO;
using System.Collections.Generic;

namespace TextFileEditor
{
    class Program
    {
        static void Read(string fileName)
        {
            StreamReader textReader = new StreamReader(fileName);
            using (textReader)
            {
                int lineNumber = 0;
                string line = textReader.ReadLine();
                Console.WriteLine(line);
                while (line != null)
                {
                    lineNumber++;
                    line = textReader.ReadLine();
                    Console.WriteLine(line);
                }
            }
            Console.WriteLine("_____");
        }
        static void CombineFiles(string fileNameOne, string fileNameTwo, string resultFileName)
        {
            StreamWriter writerOne = new StreamWriter(resultFileName, false);
            StreamWriter writerTwo = new StreamWriter(resultFileName, true);
            StreamReader readerOne = new StreamReader(fileNameOne);
            StreamReader readerTwo = new StreamReader(fileNameTwo);
            using (readerOne)
            {
                using (writerOne)
                {
                    string tempString = readerOne.ReadLine();
                    while (tempString != null)
                    {
                        writerOne.WriteLine(tempString);
                        tempString = readerOne.ReadLine();
                    }
                }
            }
            using (readerTwo)
            {
                using (writerTwo = new StreamWriter(resultFileName, true))
                {
                    string tempString = readerTwo.ReadLine();
                    while (tempString != null)
                    {
                        writerTwo.WriteLine(tempString);
                        tempString = readerTwo.ReadLine();
                    }
                }
            }

        }
        static void ExtractLines(string sourceDocument, int[] lineNumbers, string resultFileName,
            bool append = false)
        {
            List<int> convertedList = TypeConverter.IntArrToIntList(lineNumbers);
            ExtractLines(sourceDocument, convertedList, resultFileName, append);
        }
        static void ExtractLines(string sourceDocument, List<int> lineNumbers, string resultFileName,
            bool append = false)
        {
            lineNumbers.Sort();
            int linesExtracted = 0;

            StreamWriter streamWriter = new StreamWriter(resultFileName, append);
            StreamReader streamReader = new StreamReader(sourceDocument);


            int lineNumber = 0;
            using (streamReader)
            {
                using (streamWriter)
                {
                    string tempString = "";
                    while (tempString != null)
                    {
                        tempString = streamReader.ReadLine();
                        if (lineNumbers.Contains(lineNumber))
                        {
                            streamWriter.WriteLine(tempString);
                        }
                        lineNumber++;
                    }
                }
            }
        }
        static void CompareFiles(string fileNameOne, string fileNameTwo)
        {
            List<bool> equalLines = new List<bool>();
            StreamReader readerOne = new StreamReader(fileNameOne);
            StreamReader readerTwo = new StreamReader(fileNameTwo);
            bool tempBool = false;
            using (readerOne)
            {
                using (readerTwo)
                {
                    string tempStringOne = readerOne.ReadLine();
                    string tempStringTwo = readerTwo.ReadLine();
                    while (tempStringOne != null || tempStringTwo != null)
                    {
                        if (tempStringOne == tempStringTwo) tempBool = true;
                        else tempBool = false;
                        equalLines.Add(tempBool);
                        tempStringOne = readerOne.ReadLine();
                        tempStringTwo = readerTwo.ReadLine();
                    }
                }
            }
            foreach (bool element in equalLines) Console.WriteLine(element);

        }

        static void InsertLineNumbers() { }

        static void ReadMatrix()
        {

        }
        static void Test()
        {
            ReadMatrix();
        }
        static void Main(string[] args)
        {
            
        }
    }
}
