using System;

namespace SearchingInStrings
{
    public static class Contains
    {
        /// <summary>
        /// Returns a value indicating whether a specified character occurs within this string.
        /// </summary>
        /// <returns>true if the <paramref name="value"/> parameter occurs within this string; otherwise, false.</returns>
        public static bool IsContainsChar(string str, char value)
        {
            // TODO #5-1. Implement the method using String.Contains instance method.
            // See String.Contains method documentation page: https://docs.microsoft.com/en-us/dotnet/api/system.string.contains
            throw new NotImplementedException();
        }

        /// <summary>
        /// Returns a value indicating whether a specified character occurs within this string, using the specified comparison rules.
        /// </summary>
        /// <returns>true if the <paramref name="value"/> parameter occurs within this string; otherwise, false.</returns>
        public static bool IsContainsCharWithStringComparison(string str, char value)
        {
            // TODO #5-2. Implement the method using String.Contains instance method. Analyze the unit tests, and use the correct StringComparison enumeration value.
            // See String.Contains and StringComparison documentation pages:
            // * https://docs.microsoft.com/en-us/dotnet/api/system.string.contains
            // * https://docs.microsoft.com/en-us/dotnet/api/system.stringcomparison
            throw new NotImplementedException();
        }

        /// <summary>
        /// Returns a value indicating whether a specified substring occurs within this string.
        /// </summary>
        /// <returns>true if the <paramref name="value"/> parameter occurs within this string, or if <paramref name="value"/> is the <see cref="string.Empty"/>; otherwise, false.</returns>
        public static bool IsContainsString(string str, string value)
        {
            // TODO #5-3. Implement the method using String.Contains instance method.
            // See String.Contains method documentation page: https://docs.microsoft.com/en-us/dotnet/api/system.string.contains
            throw new NotImplementedException();
        }

        /// <summary>
        /// Returns a value indicating whether a specified string occurs within this string, using the specified comparison rules.
        /// </summary>
        /// <returns>true if the <paramref name="value"/> parameter occurs within this string, or if <paramref name="value"/> is the <see cref="string.Empty"/>; otherwise, false.</returns>
        public static bool IsContainsStringWithStringComparison(string str, string value)
        {
            // TODO #5-4. Implement the method using String.Contains instance method. Analyze the unit tests, and use the correct StringComparison enumeration value.
            // See String.Contains and StringComparison documentation pages:
            // * https://docs.microsoft.com/en-us/dotnet/api/system.string.contains
            // * https://docs.microsoft.com/en-us/dotnet/api/system.stringcomparison
            throw new NotImplementedException();
        }
    }
}
