using System;

// ReSharper disable InconsistentNaming
namespace SelectionSort
{
    public static class Sorter
    {
        public static void SelectionSort(this int[]? array)
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array));
            }

            int n = array.Length;
            for (int i = 0; i < n - 1; i++)
            {
                int minIndex = i;
                for (int j = i + 1; j < n; j++)
                {
                    if (array[j] < array[minIndex])
                    {
                        minIndex = j;
                    }
                }

                Swap(array, i, minIndex);
            }
        }

        public static void RecursiveSelectionSort(this int[]? array)
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array));
            }

            RecursiveSelectionSortHelper(array, 0);
        }

        private static void Swap(int[] array, int i, int j)
        {
            int temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }

        private static void RecursiveSelectionSortHelper(int[] array, int start)
        {
            if (start >= array.Length - 1)
            {
                return;
            }

            int minIndex = start;
            for (int i = start + 1; i < array.Length; i++)
            {
                if (array[i] < array[minIndex])
                {
                    minIndex = i;
                }
            }

            Swap(array, start, minIndex);

            RecursiveSelectionSortHelper(array, start + 1);
        }
    }
}
