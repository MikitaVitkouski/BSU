using System;

namespace NumeralSystems
{
    public static class Converter
    {
        public static int ParsePositiveFromOctal(this string source)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            int result = 0;
            foreach (char c in source)
            {
                if (c < '0' || c > '7')
                {
                    throw new ArgumentException("Invalid characters in the source string.", nameof(source));
                }

                int digit = c - '0';
                result = (result * 8) + digit;
            }

            return result;
        }

        public static int ParsePositiveFromDecimal(this string source)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            int result = 0;
            foreach (char c in source)
            {
                if (c < '0' || c > '9')
                {
                    throw new ArgumentException("Invalid characters in the source string.", nameof(source));
                }

                int digit = c - '0';
                result = (result * 10) + digit;
            }

            return result;
        }

        public static int ParsePositiveFromHex(this string source)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            int result = 0;

            foreach (char c in source)
            {
                if (c >= '0' && c <= '9')
                {
                    int digit = c - '0';
                    result = (result * 16) + digit;
                }
                else if (c >= 'A' && c <= 'F')
                {
                    int digit = c - 'A' + 10;
                    result = (result * 16) + digit;
                }
                else if (c >= 'a' && c <= 'f')
                {
                    int digit = c - 'a' + 10;
                    result = (result * 16) + digit;
                }
                else
                {
                    throw new ArgumentException("Invalid characters in the source string.", nameof(source));
                }
            }

            return result;
        }

        public static int ParsePositiveByRadix(this string source, int radix)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            if (radix != 8 && radix != 10 && radix != 16)
            {
                throw new ArgumentException("Radix must be 8, 10, or 16.", nameof(radix));
            }

            int result = 0;
            foreach (char c in source)
            {
                int digit;
                if (c >= '0' && c <= '9')
                {
                    digit = c - '0';
                }
                else if (c >= 'A' && c <= 'F')
                {
                    digit = c - 'A' + 10;
                }
                else if (c >= 'a' && c <= 'f')
                {
                    digit = c - 'a' + 10;
                }
                else
                {
                    throw new ArgumentException("Radix must be 8, 10, or 16.", nameof(source));
                }

                if (digit >= radix)
                {
                    throw new ArgumentException("Radix must be 8, 10, or 16.", nameof(source));
                }

                result = (result * radix) + digit;
            }

            return result;
        }

        public static int ParseByRadix(this string source, int radix)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            if (radix != 8 && radix != 10 && radix != 16)
            {
                throw new ArgumentException("Radix must be 8, 10, or 16.", nameof(radix));
            }

            bool isNegative = false;

            if (source.StartsWith("-"))
            {
                isNegative = true;
                source = source[1..];
            }

            if (isNegative)
            {
                return -ParsePositiveByRadix(source, radix);
            }
            else
            {
                return ParsePositiveByRadix(source, radix);
            }
        }

        public static bool TryParsePositiveFromOctal(this string source, out int value)
        {
            value = 0;
            try
            {
                value = ParsePositiveFromOctal(source);
                return true;
            }
            catch (ArgumentException)
            {
                return false;
            }
        }

        public static bool TryParsePositiveFromDecimal(this string source, out int value)
        {
            value = 0;
            try
            {
                value = ParsePositiveFromDecimal(source);
                return true;
            }
            catch (ArgumentException)
            {
                return false;
            }
        }

        public static bool TryParsePositiveFromHex(this string source, out int value)
        {
            value = 0;
            try
            {
                value = ParsePositiveFromHex(source);
                return true;
            }
            catch (ArgumentException)
            {
                return false;
            }
        }

        public static bool TryParsePositiveByRadix(this string source, int radix, out int value)
        {
            value = 0;
            try
            {
                value = ParsePositiveByRadix(source, radix);
                return true;
            }
            catch (ArgumentException)
            {
                return false;
            }
        }

        public static bool TryParseByRadix(this string source, int radix, out int value)
        {
            value = 0;
            try
            {
                value = ParseByRadix(source, radix);
                return true;
            }
            catch (ArgumentException)
            {
                return false;
            }
        }
    }
}
