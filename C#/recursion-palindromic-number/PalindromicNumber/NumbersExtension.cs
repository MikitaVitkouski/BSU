using System;

namespace PalindromicNumberTask
{
    /// <summary>
    /// Provides static method for working with integers.
    /// </summary>
    public static class NumbersExtension
    {
        /// <summary>
        /// Determines if a number is a palindromic number, see https://en.wikipedia.org/wiki/Palindromic_number.
        /// </summary>
        /// <param name="number">Verified number.</param>
        /// <returns>true if the verified number is a palindromic number; otherwise, false.</returns>
        /// <exception cref="ArgumentException"> Thrown when the source number is less than zero. </exception>
        public static bool IsPalindromicNumber(int number)
        {
            if (number < 0)
            {
                throw new ArgumentException("Number cannot be less than zero.");
            }

            if (number < 10)
            {
                return true;
            }

            int divisor = 1;
            while (number / divisor >= 10)
            {
                divisor *= 10;
            }

            int leftDigit = number / divisor;
            int rightDigit = number % 10;

            if (leftDigit != rightDigit)
            {
                return false;
            }

            int newNumber = (number % divisor) / 10;
            return IsPalindromicNumber(newNumber);
        }
    }
}
