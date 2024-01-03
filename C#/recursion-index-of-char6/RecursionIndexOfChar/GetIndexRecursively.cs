using System;

namespace RecursionIndexOfChar
{
    public static class GetIndexRecursively
    {
        public static int GetIndexOfChar(string? str, char value)
        {
                if (str is null)
                {
                    throw new ArgumentNullException(nameof(str));
                }

                if (string.IsNullOrEmpty(str))
                {
                    return -1;
                }

                return GetIndexOfCharRecursive(str, value, 0);
        }

        public static int GetIndexOfChar(string? str, char value, int startIndex, int count)
        {
            if (str is null)
            {
                throw new ArgumentNullException(nameof(str));
            }

            if (string.IsNullOrEmpty(str) || count == 0)
            {
                return -1;
            }

            if (startIndex < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(startIndex), "startIndex is less than zero");
            }

            if (startIndex >= str.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(startIndex), "startIndex is greater or equals str.Length");
            }

            if (count < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(count), "count is less than zero");
            }

            if (startIndex + count > str.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(count), "startIndex + count > str.Length");
            }

            int firstCharIndex = startIndex;
            if (str[firstCharIndex] == value)
            {
                return firstCharIndex;
            }

            return GetIndexOfCharRecursively(str, value, startIndex + 1, count - 1);
        }

        private static int GetIndexOfCharRecursively(string str, char value, int currentIndex, int count)
        {
            if (count == 0)
            {
                return -1;
            }

            if (str[currentIndex] == value)
            {
                return currentIndex;
            }

            return GetIndexOfCharRecursively(str, value, currentIndex + 1, count - 1);
        }

        private static int GetIndexOfCharRecursive(string str, char value, int index)
        {
            if (index >= str.Length)
            {
                return -1;
            }

            if (str[index] == value)
            {
                return index;
            }

            return GetIndexOfCharRecursive(str, value, index + 1);
        }
    }
}
