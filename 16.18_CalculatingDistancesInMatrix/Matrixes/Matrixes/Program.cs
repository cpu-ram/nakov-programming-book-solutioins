using System;
using System.Text;
using System.IO;
using System.Collections.Generic;

namespace Matrices
{
    class Program
    {
        static void Main(string[] args)
        {
            Matrix matrixOne = new Matrix(3,3);
            matrixOne.EnterManually();
            matrixOne.Export("fileOne.txt");
            Matrix matrixThree = new Matrix("fileOne.txt");
            Console.WriteLine("Here is a new matrix imported from a text file:");
            matrixThree.Display();
        }
    }
}
