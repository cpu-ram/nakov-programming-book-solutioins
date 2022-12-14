using System;
using System.Text;
using System.IO;
namespace Matrices
{
    public class Matrix
    {
        public class SectionBoundaries
        {
            Tuple<int, int> topLeftCorner;
            Tuple<int, int> bottomRightCorner;
            public SectionBoundaries(Tuple<int, int> topLeftCorner, Tuple<int, int> bottomRightCorner)
            {
                this.TopLeftCorner = topLeftCorner;
                this.BottomRightCorner = bottomRightCorner;
            }

            public Tuple<int, int> TopLeftCorner { get => topLeftCorner; set => topLeftCorner = value; }
            public Tuple<int, int> BottomRightCorner { get => bottomRightCorner; set => bottomRightCorner = value; }
        }
        int yDim;
        int xDim;
        int[,] elements;
        bool hasDimentionsAssigned;
        bool hasElementsAssigned;
        public Matrix(int yDim, int xDim)
        {
            this.HasDimentionsAssigned = true;
            this.XDim = xDim;
            this.YDim = yDim;
            Elements = new int[this.YDim, this.XDim];
        }
        public Matrix(int[,] matrix)
        {
            YDim = matrix.GetLength(0);
            XDim = matrix.GetLength(1);
            this.Elements = new int[YDim, XDim];
            for (int i = 0; i < YDim; i++)
            {
                for (int j = 0; j < XDim; j++)
                {
                    Elements[i, j] = matrix[i, j];
                }
            }
            this.hasDimentionsAssigned = true;
            this.hasElementsAssigned = true;
        }
        public Matrix(string sourceFile)
        {
            StreamReader streamReader = new StreamReader(sourceFile);
            using (streamReader)
            {
                string dimensionsString = streamReader.ReadLine();
                string[] dimensionsArr = dimensionsString.Split(",");
                int height = Convert.ToInt32(dimensionsArr[0]);
                int width = Convert.ToInt32(dimensionsArr[1]);
                YDim = height;
                XDim = width;
                elements = new int[height, width];

                for (int i = 0; i < YDim; i++)
                {
                    StringBuilder sb = new StringBuilder(streamReader.ReadLine());
                    for (int j = 0; j < xDim; j++)
                    {
                        elements[i, j] = Convert.ToInt32(sb[j]);
                    }
                }
            }

            hasDimentionsAssigned = hasElementsAssigned = true;
        }
        public bool HasDimentionsAssigned { get => hasDimentionsAssigned; set => hasDimentionsAssigned = value; }
        public bool HasElementsAssigned { get => hasElementsAssigned; set => hasElementsAssigned = value; }
        public int[,] Elements { get => elements; set => elements = value; }
        public int YDim { get => yDim; set => yDim = value; }
        public int XDim { get => xDim; set => xDim = value; }
        public void EnterManually()
        {
            Console.WriteLine("The current matrix has the following dimensions: xDim={0}, yDim={1}", XDim, YDim);
            for (int i = 0; i < YDim; i++)
            {
                for (int j = 0; j < XDim; j++)
                {
                    Console.WriteLine($"Enter the element [{i},{j}]");
                    Elements[i, j] = Int32.Parse(Console.ReadLine());
                }
            }
            HasElementsAssigned = true;
        }
        public void Display()
        {
            Console.WriteLine();
            for (int i = 0; i < Elements.GetLength(0); i++)
            {
                for (int j = 0; j < Elements.GetLength(1); j++)
                {
                    Console.Write("{0,3} ", Elements[i, j]);
                }
                Console.WriteLine();
            }
            Console.WriteLine("___");

        }
        public static Matrix ExtractSection(Matrix sourceMatrix, SectionBoundaries sectionBoundaries)
        {
            Tuple<int, int> topLeftCorner = sectionBoundaries.TopLeftCorner;
            Tuple<int, int> bottomRightCorner = sectionBoundaries.BottomRightCorner;
            int yDim = bottomRightCorner.Item1 - topLeftCorner.Item1 + 1;
            int xDim = bottomRightCorner.Item2 - topLeftCorner.Item2 + 1;
            int yStartPosition = topLeftCorner.Item1;
            int xStartPosition = topLeftCorner.Item2;
            int yEndPosition = bottomRightCorner.Item1;
            int xEndPosition = bottomRightCorner.Item2;
            int[,] matrix = new int[xDim, yDim];
            for (int i = 0; i < yDim; i++)
            {
                for (int j = 0; j < xDim; j++)
                {
                    matrix[i, j] = sourceMatrix.Elements[yStartPosition + i, xStartPosition + j];
                }
            }
            Matrix resultMatrix = new Matrix(matrix);
            return resultMatrix;
        }
        public Matrix FindGreatestPlatform(int size)
        {
            Matrix sourceMatrix = this;
            Matrix greatestPlatform = new Matrix(size, size);
            SectionBoundaries platformBoundaries;
            Tuple<int, int> firstTuple = null;
            Tuple<int, int> secondTuple = null;

            int yDim = this.YDim;
            int xDim = this.XDim;

            int sum = 0;
            int maxSum = 0;
            string boundariesString = "";
            for (int y = 0; y < yDim - (size - 1); y++)
            {
                for (int x = 0; x < xDim - (size - 1); x++)
                {
                    sum = 0;
                    for (int addY = 0; addY < size; addY++)
                    {
                        for (int addX = 0; addX < size; addX++)
                        {
                            sum += this.Elements[y + addY, x + addX];
                            if ((addY == size - 1) & (addX == size - 1))
                            {
                                if (sum > maxSum)
                                {
                                    maxSum = sum;
                                    boundariesString = $"[{y},{x}]->[{y + addY},{x + addX}]";

                                    firstTuple = new Tuple<int, int>(y, x);
                                    secondTuple = new Tuple<int, int>(y + addY, x + addX);

                                }
                            }
                        }
                    }
                }
            }
            platformBoundaries = new SectionBoundaries(firstTuple, secondTuple);
            greatestPlatform = ExtractSection(this, platformBoundaries);
            return greatestPlatform;
        }
        public void Export(string fileName)
        {
            StreamWriter fileSaver = new StreamWriter(fileName);
            string tempString = "";
            using (fileSaver)
            {
                fileSaver.WriteLine($"{YDim},{XDim}");
                for (int i = 0; i < elements.GetLength(0); i++)
                {
                    StringBuilder sb = new StringBuilder();
                    for (int j = 0; j < elements.GetLength(1); j++)
                    {
                        sb.Append($"{elements[i, j]}");
                    }
                    fileSaver.WriteLine(sb);
                }
            }
        }
        public void CalculateDistances()
        {

        }
    }
}
