using System;
using System.Globalization;

namespace Numbers
{
    public static class IntegerExtensions
    {
        /// <summary>
        /// Obtains formalized information in the form of an enum <see cref="ComparisonSigns"/>
        /// about the relationship of the order of two adjacent digits for all digits of a given number.
        /// </summary>
        /// <param name="number">Source number.</param>
        /// <returns>Information in the form of an enum <see cref="ComparisonSigns"/>
        /// about the relationship of the order of two adjacent digits for all digits of a given number
        /// or null if the information is not defined.</returns>
        public static ComparisonSigns? GetTypeComparisonSigns(this long number)
        {
            ComparisonSigns? result = 0;

            if (number == long.MinValue)
            {
                return ComparisonSigns.MoreThan | ComparisonSigns.Equals | ComparisonSigns.LessThan;
            }

            if (number < 0)
            {
                number = -number;
            }

            if (number < 10)
            {
                return null;
            }

            do
            {
                byte rigthDigit = (byte)(number % 10);
                byte leftDigit = (byte)((number / 10) % 10);

                if (leftDigit < rigthDigit)
                {
                    result |= ComparisonSigns.LessThan;
                }
                else if (leftDigit > rigthDigit)
                {
                    result |= ComparisonSigns.MoreThan;
                }
                else
                {
                    result |= ComparisonSigns.Equals;
                }

                number /= 10;
            }
            while (number > 10);

            return result;
        }

        /// <summary>
        /// Gets information in the form of a string about the type of sequence that the digit of a given number represents.
        /// </summary>
        /// <param name="number">Source number.</param>
        /// <returns>The information in the form of a string about the type of sequence that the digit of a given number represents.</returns>
        public static string GetTypeOfDigitsSequence(this long number)
        {
            return GetTypeComparisonSigns(number) switch
            {
                ComparisonSigns.LessThan => "Strictly Increasing.",
                ComparisonSigns.LessThan | ComparisonSigns.Equals => "Increasing.",
                ComparisonSigns.MoreThan => "Strictly Decreasing.",
                ComparisonSigns.MoreThan | ComparisonSigns.Equals => "Decreasing.",
                ComparisonSigns.Equals => "Monotonous.",
                null => "One digit number.",
                _ => "Unordered."
            };
        }
    }
}
