using System;
using System.Collections.Generic;
using System.IO;
using TextFiles;

namespace NamesSorter
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> sortedNames = new List<string>();
            string sourceFile = "names.txt";
            string resultFile = "sortedNames.txt";
            StreamReader streamReader = new StreamReader(sourceFile);
            StreamWriter streamWriter = new StreamWriter(resultFile);
            using (streamReader)
            {
                using (streamWriter)
                {
                    string tempString = streamReader.ReadLine();
                    while (tempString != null)
                    {
                        sortedNames.Add(tempString);
                        tempString = streamReader.ReadLine();
                    }
                    sortedNames.Sort();
                    for (int i = 0; i < sortedNames.Count; i++)
                    {
                        streamWriter.WriteLine(sortedNames[i]);
                    }

                }
            }
            FileEditor.Read(resultFile);

        }
    }
}
