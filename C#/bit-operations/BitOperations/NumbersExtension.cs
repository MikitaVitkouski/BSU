using System;

namespace BitOperationsTask
{
    /// <summary>
    /// Provides static method for working with integers.
    /// </summary>
    public static class NumbersExtension
    {
        /// <summary>
        /// Inserts first (j - i + 1), (i less or equals j) bits sequence from second number into first number from i to j position.
        /// </summary>
        /// <param name="destinationNumber">Destination number.</param>
        /// <param name="sourceNumber">Source number.</param>
        /// <param name="i">i position in source number.</param>
        /// <param name="j">j position in source number.</param>
        /// <returns>Changed first number (see summary).</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when i or j is less than 0 or more than 31.</exception>
        /// <exception cref="ArgumentException">Thrown when i is more than j.</exception>
        public static int InsertNumberIntoAnother(int destinationNumber, int sourceNumber, int i, int j)
        {
            if (i < 0 || i > 31 || j < 0 || j > 31)
            {
                throw new ArgumentOutOfRangeException(nameof(i));
            }

            if (i > j)
            {
                throw new ArgumentException("i cannot be greater than j.");
            }

            if (i == 0 && j == 31)
            {
                return sourceNumber;
            }

            int mask = ~(((1 << (j - i + 1)) - 1) << i);

            destinationNumber &= mask;

            int bitsToInsert = (sourceNumber & ((1 << (j - i + 1)) - 1)) << i;

            destinationNumber |= bitsToInsert;

            return destinationNumber;
        }
    }
}
