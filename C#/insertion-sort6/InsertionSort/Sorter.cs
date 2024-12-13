using System;

namespace InsertionSort
{
    public static class Sorter
    {
        public static void InsertionSort(this int[]? array)
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array));
            }

            int n = array.Length;
            for (int i = 1; i < n; i++)
            {
                int key = array[i];
                int j = i - 1;
                while (j >= 0 && array[j] > key)
                {
                    array[j + 1] = array[j];
                    j--;
                }

                array[j + 1] = key;
            }
        }

        public static void RecursiveInsertionSort(this int[]? array)
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array));
            }

            RecursiveInsertionSortHelper(array, array.Length);
        }

        private static void RecursiveInsertionSortHelper(int[] array, int n)
        {
            if (n <= 1)
            {
                return;
            }

            RecursiveInsertionSortHelper(array, n - 1);

            int lastElement = array[n - 1];
            int j = n - 2;

            while (j >= 0 && array[j] > lastElement)
            {
                array[j + 1] = array[j];
                j--;
            }

            array[j + 1] = lastElement;
        }
    }
}
