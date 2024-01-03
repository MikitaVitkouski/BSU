using System;

namespace RecursionIndexOfChar
{
    public static class GetLastIndexRecursively
    {
        public static int GetLastIndexOfChar(string? str, char value)
        {
            if (str is null)
            {
                throw new ArgumentNullException(nameof(str));
            }

            if (string.IsNullOrEmpty(str))
            {
                return -1;
            }

            if (str[^1] == value)
            {
                return str.Length - 1;
            }

            return GetLastIndexRecursively.GetLastIndexOfChar(str[..^1], value);
        }

        public static int GetLastIndexOfChar(string? str, char value, int startIndex, int count)
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

            int lastCharIndex = startIndex + count - 1;
            if (str[lastCharIndex] == value)
            {
                return lastCharIndex;
            }

            return GetLastIndexRecursively.GetLastIndexOfChar(str[..lastCharIndex], value, startIndex, count - 1);
        }
    }
}
