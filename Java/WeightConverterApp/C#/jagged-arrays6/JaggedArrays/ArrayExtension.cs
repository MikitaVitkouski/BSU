using System;

namespace JaggedArrays
{
    public static class ArrayExtension
    {
        /// <summary>
        /// Orders the rows in a jagged-array by ascending sum of the elements in them.
        /// </summary>
        /// <param name="array">The jagged-array to sort.</param>
        public static void OrderByAscendingBySum(this int[][] array)
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array));
            }

            Array.Sort(array, (x, y) =>
            {
                if (x == null && y == null)
                {
                    return 0;
                }

                if (x == null)
                {
                    return -1;
                }

                if (y == null)
                {
                    return 1;
                }

                return x.Sum().CompareTo(y.Sum());
            });
        }

        /// <summary>
        /// Orders the rows in a jagged-array by descending sum of the elements in them.
        /// </summary>
        /// <param name="array">The jagged-array to sort.</param>
        public static void OrderByDescendingBySum(this int[][] array)
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array));
            }

            Array.Sort(array, (x, y) =>
            {
                if (x == null && y == null)
                {
                    return 0;
                }

                if (x == null)
                {
                    return 1;
                }

                if (y == null)
                {
                    return -1;
                }

                return y.Sum().CompareTo(x.Sum());
            });
        }

        /// <summary>
        /// Orders the rows in a jagged-array by ascending maximum of the elements in them.
        /// </summary>
        /// <param name="array">The jagged-array to sort.</param>
        public static void OrderByAscendingByMax(this int[][] array)
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array));
            }

            Array.Sort(array, (x, y) =>
            {
                if (x == null && y == null)
                {
                    return 0;
                }

                if (x == null)
                {
                    return -1;
                }

                if (y == null)
                {
                    return 1;
                }

                return x.Max().CompareTo(y.Max());
            });
        }

        /// <summary>
        /// Orders the rows in a jagged-array by descending maximum of the elements in them.
        /// </summary>
        /// <param name="array">The jagged-array to sort.</param>
        public static void OrderByDescendingByMax(this int[][] array)
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array));
            }

            Array.Sort(array, (x, y) =>
            {
                if (x == null && y == null)
                {
                    return 0;
                }

                if (x == null)
                {
                    return 1;
                }

                if (y == null)
                {
                    return -1;
                }

                return y.Max().CompareTo(x.Max());
            });
        }
    }
}
