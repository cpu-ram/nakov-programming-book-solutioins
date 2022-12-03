using System;
using System.IO;
using ConsoleTools;
using System.Collections.Generic;

namespace FileTools
{
    public class FileExplorerTwo
    {
        public static void TraverseManually()
        {
            //Console.WriteLine("In order to see the documentation, type '-documentation'");
            string startDirectory = "/";
            DirectoryInfo currentDirectory = new DirectoryInfo(startDirectory);
            string directories = "";
            string directoryString;
            foreach (DirectoryInfo directory in currentDirectory.GetDirectories())
            {
                directoryString = directory.ToString();
                directories += directoryString+"\n";
            }
            
            while (true)
            {
                Console.WriteLine("Directories:\n");
                Console.WriteLine(directories);
                directories = "";

                bool properCommandEntered = false;
                while (!properCommandEntered)
                {
                    string nextStep = ConsoleReader.EnterString("next step");
                    if (nextStep != default(String))
                    {
                        string currentDirectoryPath = currentDirectory.ToString();
                        string newDirectoryPath = currentDirectoryPath + nextStep;
                        DirectoryInfo newDirectory = new DirectoryInfo(newDirectoryPath);
                        if (newDirectory.Exists)
                        {
                            currentDirectory = newDirectory;
                            try
                            {
                                foreach (DirectoryInfo directory in currentDirectory.GetDirectories())
                                {
                                    directories += directory + "\n";
                                }
                            }
                            catch (System.UnauthorizedAccessException)
                            {
                                Console.WriteLine("The directory you entered is not accessible. Try again.");
                                continue;
                            }
                            properCommandEntered = true;
                        }
                        else
                        {
                            Console.WriteLine("Incorrect command or non-existent directory entered. Try again.");
                        }
                    }
                }
                
            }
        }
        public static void TraverseBFS()
        {
            string initialDirectory = "/";
            DirectoryInfo newDirectory = new DirectoryInfo(initialDirectory);
            Queue<DirectoryInfo> directories = new Queue<DirectoryInfo>();
            directories.Enqueue(newDirectory);
            Console.WriteLine(newDirectory+"\n");
            while (directories.Count>0)
            {
                DirectoryInfo currentDirectory = directories.Dequeue();
                try
                {
                    foreach (DirectoryInfo directory in currentDirectory.GetDirectories())
                    {
                        directories.Enqueue(directory);
                        Console.WriteLine(directory);
                    }
                }
                catch (System.UnauthorizedAccessException)
                {
                    Console.WriteLine($">> Error: {currentDirectory} is unaccessible.");
                    continue;
                }
                
                Console.WriteLine();
            }
        }
        public static void TraverseDFS()
        {
            string initialDirectory = "/";
            DirectoryInfo newDirectory = new DirectoryInfo(initialDirectory);
            Stack<DirectoryInfo> directories = new Stack<DirectoryInfo>();
            directories.Push(newDirectory);
            Console.WriteLine(newDirectory + "\n");
            while (directories.Count > 0)
            {
                DirectoryInfo currentDirectory = directories.Pop();
                try
                {
                    foreach (DirectoryInfo directory in currentDirectory.GetDirectories())
                    {
                        directories.Push(directory);
                        Console.WriteLine(directory);
                    }
                }
                catch (System.UnauthorizedAccessException)
                {
                    Console.WriteLine($">> Error: {currentDirectory} is unaccessible.");
                    continue;
                }

                Console.WriteLine();
            }
        }
    }
}
