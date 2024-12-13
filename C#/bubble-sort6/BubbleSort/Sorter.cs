using System;

namespace BubbleSort
{
    public static class Sorter
    {
        /// <summary>
        /// Sorts an <paramref name="array"/> with bubble sort algorithm.
        /// </summary>
        public static void BubbleSort(this int[]? array)
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array), "Input array cannot be null.");
            }

            int n = array.Length;
            bool swapped;

            do
            {
                swapped = false;

                for (int i = 0; i < n - 1; i++)
                {
                    if (array[i] > array[i + 1])
                    {
                        Swap(array, i, i + 1);
                        swapped = true;
                    }
                }

                n--;
            }
            while (swapped);
        }

        /// <summary>
        /// Sorts an <paramref name="array"/> with recursive bubble sort algorithm.
        /// </summary>
        public static void RecursiveBubbleSort(this int[]? array)
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array), "Input array cannot be null.");
            }

            RecursiveBubbleSortHelper(array, array.Length);
        }

        private static void RecursiveBubbleSortHelper(int[] array, int length)
        {
            if (length <= 1)
            {
                return;
            }

            for (int i = 0; i < length - 1; i++)
            {
                if (array[i] > array[i + 1])
                {
                    Swap(array, i, i + 1);
                }
            }

            RecursiveBubbleSortHelper(array, length - 1);
        }

        private static void Swap(int[] array, int i, int j)
        {
            int temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }
    }
}
