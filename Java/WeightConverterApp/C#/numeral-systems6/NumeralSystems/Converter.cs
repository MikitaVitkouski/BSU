using System;

namespace NumeralSystems
{
    public static class Converter
    {
        public static string GetPositiveOctal(this int number)
        {
            if (number < 0)
            {
                throw new ArgumentException("Number must be positive.", nameof(number));
            }

            if (number == 0)
            {
                return "0";
            }

            string result = string.Empty;
            int quotient = number;

            while (quotient > 0)
            {
                int remainder = quotient % 8;
                result = remainder.ToString(System.Globalization.CultureInfo.CurrentCulture) + result;
                quotient /= 8;
            }

            return result;
        }

        public static string GetPositiveDecimal(this int number)
        {
            if (number < 0)
            {
                throw new ArgumentException("Number must be positive.", nameof(number));
            }

            if (number == 0)
            {
                return "0";
            }

            string result = string.Empty;
            int quotient = number;

            while (quotient > 0)
            {
                int remainder = quotient % 10;
                result = remainder.ToString(System.Globalization.CultureInfo.CurrentCulture) + result;
                quotient /= 10;
            }

            return result;
        }

        public static string GetPositiveHex(this int number)
        {
            if (number < 0)
            {
                throw new ArgumentException("Number must be positive.", nameof(number));
            }

            if (number == 0)
            {
                return "0";
            }

            string hexChars = "0123456789ABCDEF";
            string result = string.Empty;

            while (number > 0)
            {
                int remainder = number % 16;
                result = hexChars[remainder] + result;
                number /= 16;
            }

            return result;
        }

        public static string GetPositiveRadix(this int number, int radix)
        {
            if (number < 0)
            {
                throw new ArgumentException("Number must be positive.", nameof(number));
            }

            if (radix != 8 && radix != 10 && radix != 16)
            {
                throw new ArgumentException("Radix must be 8, 10, or 16.", nameof(radix));
            }

            if (number == 0)
            {
                return "0";
            }

            string result = string.Empty;
            string digits = GetRadixDigits(radix);

            while (number > 0)
            {
                int remainder = number % radix;
                result = digits[remainder] + result;
                number /= radix;
            }

            return result;
        }

        public static string GetRadix(this int number, int radix)
        {
            if (radix != 8 && radix != 10 && radix != 16)
            {
                throw new ArgumentException("Radix must be 8, 10, or 16.", nameof(radix));
            }

            if (number == 0)
            {
                return "0";
            }

            string result = string.Empty;
            string digits = GetRadixDigits(radix);
            if (number < 0)
            {
                uint unsignedNumber = (uint)-number;
                uint complement = (~unsignedNumber) + 1;

                while (complement > 0)
                {
                    uint remainder = complement % (uint)radix;
                    result = digits[(int)remainder] + result;
                    complement /= (uint)radix;
                }
            }

            if (number > 0)
            {
                while (number > 0)
                {
                    int remainder = number % radix;
                    result = digits[remainder] + result;
                    number /= radix;
                }
            }

            return result;
        }

        private static string GetRadixDigits(int radix)
        {
            string digits;

            if (radix == 8)
            {
                digits = "01234567";
            }
            else if (radix == 10)
            {
                digits = "0123456789";
            }
            else if (radix == 16)
            {
                digits = "0123456789ABCDEF";
            }
            else
            {
                throw new ArgumentException("Radix must be 8, 10, or 16.");
            }

            return digits;
        }
    }
}
