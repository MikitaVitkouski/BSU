using System;

namespace QuickSort
{
    public static class Sorter
    {
        public static void QuickSort(this int[]? array)
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array));
            }

            QuickSortLoop(array, 0, array.Length - 1);
        }

        public static void RecursiveQuickSort(this int[]? array)
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array));
            }

            RecursiveQuickSortHelper(array, 0, array.Length - 1);
        }

        private static void RecursiveQuickSortHelper(int[] array, int left, int right)
        {
            if (left >= right)
            {
                return;
            }

            int pivotIndex = Partition(array, left, right);
            RecursiveQuickSortHelper(array, left, pivotIndex - 1);
            RecursiveQuickSortHelper(array, pivotIndex + 1, right);
        }

        private static void Swap(int[] array, int i, int j)
        {
            int temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }

        private static void QuickSortLoop(int[] array, int left, int right)
        {
            if (left >= right)
            {
                return;
            }

            int pivotIndex = Partition(array, left, right);
            QuickSortLoop(array, left, pivotIndex - 1);
            QuickSortLoop(array, pivotIndex + 1, right);
        }

        private static int Partition(int[] array, int left, int right)
        {
            int pivot = array[right];
            int i = left - 1;

            for (int j = left; j < right; j++)
            {
                if (array[j] < pivot)
                {
                    i++;
                    Swap(array, i, j);
                }
            }

            Swap(array, i + 1, right);
            return i + 1;
        }
    }
}
