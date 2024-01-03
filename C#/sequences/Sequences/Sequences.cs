using System;

namespace Sequences
{
    public static class Sequences
    {
        /// <summary>
        /// Find all the contiguous substrings of "length" length in given string of digits in the order that they appear.
        /// </summary>
        /// <param name="numbers">Source string.</param>
        /// <param name="length">Length of substring.</param>
        /// <returns>All the contiguous substrings of length n in that string in the order that they appear.</returns>
        /// <exception cref="ArgumentException">
        /// Throw if length of substring less and equals zero
        /// -or-
        /// more than length of source string
        /// - or-
        /// source string containing a non-digit character
        /// - or
        /// source string is null or empty or white space.
        /// </exception>
        public static string[] GetSubstrings(string numbers, int length)
        {
            if (length <= 0 || length > numbers.Length || string.IsNullOrEmpty(numbers) || string.IsNullOrWhiteSpace(numbers) || !numbers.All(char.IsDigit))
            {
                throw new ArgumentException(nameof(numbers.Length));
            }

            List<string> substrings = new List<string>();

            for (int i = 0; i <= numbers.Length - length; i++)
            {
                string substring = numbers.Substring(i, length);
                substrings.Add(substring);
            }

            return substrings.ToArray();
        }
    }
}
