using System;

namespace FindBalanceElementTask
{
    public static class ArrayExtension
    {
        public static int? FindBalanceElement(int[]? array)
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array));
            }

            if (array.Length == 0)
            {
                throw new ArgumentException(nameof(array.Length));
            }

            if (array.Length == 1 || array.Length == 2)
            {
                return null;
            }

            long totalSum = 0;
            long leftSum = 0;

            foreach (int num in array)
            {
                totalSum += num;
            }

            if (totalSum == 0)
            {
                return 1;
            }

            for (int i = 0; i < array.Length; i++)
            {
                totalSum -= array[i];

                if (leftSum == totalSum)
                {
                    return i;
                }

                leftSum += array[i];
            }

            return null;
        }
    }
}
