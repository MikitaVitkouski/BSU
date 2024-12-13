using System;

namespace ShiftArrayElements
{
    public static class RecursiveEnumShifter
    {
        public static int[] Shift(int[]? source, Direction[]? directions)
        {
            if (source is null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            if (directions is null)
            {
                throw new ArgumentNullException(nameof(directions));
            }

            int[] result = source;

            ShiftElements(result, directions, 0);

            return result;
        }

        private static void ShiftElements(int[] array, Direction[] directions, int index)
        {
            if (index >= directions.Length)
            {
                return;
            }

            var currentDirection = directions[index];

            if (currentDirection == Direction.Left)
            {
                ShiftLeft(array);
            }
            else if (currentDirection == Direction.Right)
            {
                ShiftRight(array);
            }
            else
            {
                throw new InvalidOperationException($"Incorrect {currentDirection} enum value.");
            }

            ShiftElements(array, directions, index + 1);
        }

        private static void ShiftLeft(int[] array)
        {
            var temp = array[0];
            Array.Copy(array, 1, array, 0, array.Length - 1);
            array[array.Length - 1] = temp;
        }

        private static void ShiftRight(int[] array)
        {
            var temp = array[array.Length - 1];
            Array.Copy(array, 0, array, 1, array.Length - 1);
            array[0] = temp;
        }
    }
}
