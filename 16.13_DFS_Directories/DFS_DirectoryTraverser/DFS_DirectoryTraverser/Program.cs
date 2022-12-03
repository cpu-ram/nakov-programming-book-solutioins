using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DFS_DirectoryTraverser
{
    class Program
    {
        static void BFS()
        {

        }
        static void Main(string[] args)
        {
            DirectoryInfo entryDirectory = new DirectoryInfo("/");
            DirectoryInfo currentDirectory = entryDirectory;
            foreach (DirectoryInfo element in currentDirectory.GetDirectories())
            {
                Console.WriteLine(element);
            }
        }
    }
}
