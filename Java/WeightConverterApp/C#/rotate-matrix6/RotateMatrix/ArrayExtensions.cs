using System;

namespace RotateMatrix
{
    public static class ArrayExtensions
    {
        public static void Rotate90DegreesClockwise(this int[,]? matrix)
        {
            if (matrix == null)
            {
                throw new ArgumentNullException(nameof(matrix));
            }

            int n = matrix.GetLength(0);

            for (int i = 0; i < n / 2; i++)
            {
                for (int j = i; j < n - i - 1; j++)
                {
                    int temp = matrix[i, j];
                    matrix[i, j] = matrix[n - 1 - j, i];
                    matrix[n - 1 - j, i] = matrix[n - 1 - i, n - 1 - j];
                    matrix[n - 1 - i, n - 1 - j] = matrix[j, n - 1 - i];
                    matrix[j, n - 1 - i] = temp;
                }
            }
        }

        public static void Rotate90DegreesCounterClockwise(this int[,]? matrix)
        {
            if (matrix == null)
            {
                throw new ArgumentNullException(nameof(matrix));
            }

            int n = matrix.GetLength(0);

            for (int i = 0; i < n / 2; i++)
            {
                for (int j = i; j < n - i - 1; j++)
                {
                    int temp = matrix[i, j];
                    matrix[i, j] = matrix[j, n - 1 - i];
                    matrix[j, n - 1 - i] = matrix[n - 1 - i, n - 1 - j];
                    matrix[n - 1 - i, n - 1 - j] = matrix[n - 1 - j, i];
                    matrix[n - 1 - j, i] = temp;
                }
            }
        }

        public static void Rotate180DegreesClockwise(this int[,]? matrix)
        {
            if (matrix == null)
            {
                throw new ArgumentNullException(nameof(matrix));
            }

            matrix.Rotate90DegreesClockwise();
            matrix.Rotate90DegreesClockwise();
        }

        public static void Rotate180DegreesCounterClockwise(this int[,]? matrix)
        {
            if (matrix == null)
            {
                throw new ArgumentNullException(nameof(matrix));
            }

            matrix.Rotate90DegreesCounterClockwise();
            matrix.Rotate90DegreesCounterClockwise();
        }

        public static void Rotate270DegreesClockwise(this int[,]? matrix)
        {
            if (matrix == null)
            {
                throw new ArgumentNullException(nameof(matrix));
            }

            matrix.Rotate90DegreesClockwise();
            matrix.Rotate90DegreesClockwise();
            matrix.Rotate90DegreesClockwise();
        }

        public static void Rotate270DegreesCounterClockwise(this int[,]? matrix)
        {
            if (matrix == null)
            {
                throw new ArgumentNullException(nameof(matrix));
            }

            matrix.Rotate90DegreesCounterClockwise();
            matrix.Rotate90DegreesCounterClockwise();
            matrix.Rotate90DegreesCounterClockwise();
        }

        public static void Rotate360DegreesClockwise(this int[,]? matrix)
        {
            if (matrix == null)
            {
                throw new ArgumentNullException(nameof(matrix));
            }
        }

        public static void Rotate360DegreesCounterClockwise(this int[,]? matrix)
        {
            if (matrix == null)
            {
                throw new ArgumentNullException(nameof(matrix));
            }
        }
    }
}
