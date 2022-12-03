using System;

namespace _07._12_Creating_Matrixes
{
    class Program
    {
        
            static int[,] DoMatrixC(int dim)
            {
                int[,] matrix = new int[dim, dim];
                matrix[dim - 1, 0] = 1;
                int counter = 1;
                for (int row = dim - 2; row >= 0; row--)
                {
                    matrix[row, 0] = matrix[row + 1, 0] + counter;
                    int newRow = row;
                    for (int diagonal = 1; diagonal <= counter; diagonal++)
                    {
                        matrix[newRow + 1, diagonal] = matrix[newRow, diagonal - 1] + 1;
                        newRow++;
                    }
                    counter++;
                }

            matrix[0, dim - 1] = dim * dim;
            int diagonalLength = 2;
            int posX = 1;
            int posY = dim - 1;
            int prevX = 0;
            int prevY = dim - 1;

            for (int i = 1; i < counter - 1; i++)
            {
                for (int j = 1; j <= diagonalLength; j++)
                {
                    matrix[posX, posY] = matrix[prevX, prevY] - 1;
                    prevX = posX;
                    prevY = posY;
                    posX--;
                    posY--;
                }
                diagonalLength++;
                posX = i + 1;
                posY = dim - 1;
            }

            return matrix;
            }





        
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            int[,] matrix = DoMatrixC(4);

            for(int i = 0; i < 4; i++)
            {
                for (int j=0; j<4; j++)
                {
                    Console.Write("{0,3} ", matrix[i, j]);
                }
                Console.WriteLine();
            }
        }
    }
}
