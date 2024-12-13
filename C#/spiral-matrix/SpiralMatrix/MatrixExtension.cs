using System;

namespace SpiralMatrix
{
    public static class MatrixExtension
    {
        public static int[,] GetMatrix(int size)
        {
            if (size <= 0)
            {
                throw new ArgumentException(null, nameof(size));
            }

            int[,] matrix = new int[size, size];
            int rowStart = 0;
            int rowEnd = size - 1;
            int colStart = 0;
            int colEnd = size - 1;
            int currentNumber = 1;

            while (currentNumber <= size * size)
            {
                for (int col = colStart; col <= colEnd; col++)
                {
                    matrix[rowStart, col] = currentNumber;
                    currentNumber++;
                }

                rowStart++;

                for (int row = rowStart; row <= rowEnd; row++)
                {
                    matrix[row, colEnd] = currentNumber;
                    currentNumber++;
                }

                colEnd--;

                for (int col = colEnd; col >= colStart; col--)
                {
                    matrix[rowEnd, col] = currentNumber;
                    currentNumber++;
                }

                rowEnd--;

                for (int row = rowEnd; row >= rowStart; row--)
                {
                    matrix[row, colStart] = currentNumber;
                    currentNumber++;
                }

                colStart++;
            }

            return matrix;
        }
    }
}
