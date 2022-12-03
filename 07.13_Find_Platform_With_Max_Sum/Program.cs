using System;

namespace _07._13_Find_Platform_With_Max_Sum
{
    public class Matrix
    {
        public class SectionBoundaries
        {
            Tuple<int, int> topLeftCorner;
            Tuple<int, int> bottomRightCorner;
            public SectionBoundaries(Tuple<int,int> topLeftCorner, Tuple<int,int> bottomRightCorner)
            {
                this.TopLeftCorner = topLeftCorner;
                this.BottomRightCorner = bottomRightCorner;
            }

            public Tuple<int, int> TopLeftCorner { get => topLeftCorner; set => topLeftCorner = value; }
            public Tuple<int, int> BottomRightCorner { get => bottomRightCorner; set => bottomRightCorner = value; }
        }

        int xDim;
        int yDim;
        int[,] elements;
        bool hasDimentionsAssigned;
        bool hasElementsAssigned;
        public Matrix(int yDim, int xDim)
        {
            this.HasDimentionsAssigned = true;
            this.xDim = xDim;
            this.yDim = yDim;
            Elements = new int[this.yDim, this.xDim];
        }
        public Matrix(int[,] matrix)
        {
            yDim = matrix.GetLength(0);
            xDim = matrix.GetLength(1);
            this.Elements = new int[yDim, xDim];
            for (int i = 0; i < yDim; i++)
            {
                for (int j = 0; j < xDim; j++)
                {
                    Elements[i, j] = matrix[i, j];
                }
            }
            this.hasDimentionsAssigned = true;
            this.hasElementsAssigned = true;
        }
        public bool HasDimentionsAssigned { get => hasDimentionsAssigned; set => hasDimentionsAssigned = value; }
        public bool HasElementsAssigned { get => hasElementsAssigned; set => hasElementsAssigned = value; }
        public int[,] Elements { get => elements; set => elements = value; }

        public void EnterManually()
        {
            for (int i = 0; i < yDim; i++)
            {
                for (int j = 0; j < xDim; j++)
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
            int yDim = bottomRightCorner.Item1 - topLeftCorner.Item1+1;
            int xDim = bottomRightCorner.Item2 - topLeftCorner.Item2+1;
            int yStartPosition = topLeftCorner.Item1;
            int xStartPosition = topLeftCorner.Item2;
            int yEndPosition = bottomRightCorner.Item1;
            int xEndPosition = bottomRightCorner.Item2;
            int[,] matrix = new int[xDim, yDim];
            for (int i=0; i<yDim; i++)
            {
                for(int j=0; j<xDim; j++)
                {
                    matrix[i, j] = sourceMatrix.Elements[yStartPosition + i, xStartPosition + j];
                }
            }
            Matrix resultMatrix = new Matrix(matrix);
            return resultMatrix;
        }
        public static Matrix FindGreatestPlatform(Matrix sourceMatrix, int size)
        {
            Matrix greatestPlatform = new Matrix(size, size);
            SectionBoundaries platformBoundaries;
            Tuple<int, int> firstTuple = null;
            Tuple<int, int> secondTuple = null;

            int yDim = sourceMatrix.yDim;
            int xDim = sourceMatrix.xDim;

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
                            sum += sourceMatrix.Elements[y + addY, x + addX];
                            if ((addY == size-1) & (addX == size-1))
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
            greatestPlatform = ExtractSection(sourceMatrix, platformBoundaries);
            return greatestPlatform;
        }

    }
    class Program
    {
       
    }
}
