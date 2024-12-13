using System;

namespace ShiftArrayElements
{
    public static class RecursiveShifter
    {
        public static int[] Shift(int[]? source, int[]? iterations)
        {
            if (source is null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            if (iterations is null)
            {
                throw new ArgumentNullException(nameof(iterations));
            }

            int[] result = source;

            ShiftElements(result, iterations, 0, 0);

            return result;
        }

        private static void ShiftElements(int[] array, int[] iterations, int index, int direction)
        {
            if (index >= iterations.Length)
            {
                return;
            }

            var currentIteration = iterations[index];

            if (direction == 0)
            {
                ShiftLeft(array, currentIteration);
            }
            else
            {
                ShiftRight(array, currentIteration);
            }

            ShiftElements(array, iterations, index + 1, 1 - direction);
        }

        private static void ShiftLeft(int[] array, int iterations)
        {
            if (iterations <= 0)
            {
                return;
            }

            var temp = array[0];
            Array.Copy(array, 1, array, 0, array.Length - 1);
            array[array.Length - 1] = temp;

            ShiftLeft(array, iterations - 1);
        }

        private static void ShiftRight(int[] array, int iterations)
        {
            if (iterations <= 0)
            {
                return;
            }

            var temp = array[array.Length - 1];
            Array.Copy(array, 0, array, 1, array.Length - 1);
            array[0] = temp;

            ShiftRight(array, iterations - 1);
        }
    }
}
