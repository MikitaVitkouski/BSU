using System;

namespace SearchingInStrings
{
    public static class StartsWith
    {
        /// <summary>
        /// Determines whether this string instance starts with the specified character.
        /// </summary>
        /// <returns>true if <paramref name="value"/> matches the beginning of this string; otherwise, false.</returns>
        public static bool IsStartsWith(string str, char value)
        {
            // TODO #6-1. Implement the method using String.StartsWith instance method.
            // See String.StartsWith method documentation page: https://docs.microsoft.com/en-us/dotnet/api/system.string.startswith
            throw new NotImplementedException();
        }

        /// <summary>
        /// Determines whether the beginning of this string instance matches the specified string.
        /// </summary>
        /// <returns>true if <paramref name="value"/> matches the beginning of this string; otherwise, false.</returns>
        public static bool IsStartsWith(string str, string value)
        {
            // TODO #6-2. Implement the method using String.StartsWith instance method.
            // See String.StartsWith method documentation page: https://docs.microsoft.com/en-us/dotnet/api/system.string.startswith
            throw new NotImplementedException();
        }

        /// <summary>
        /// Determines whether the beginning of this string instance matches the specified string when compared using the specified comparison option.
        /// </summary>
        /// <returns>true if <paramref name="value"/> matches the beginning of this string; otherwise, false.</returns>
        public static bool IsStartsWithStringComparison(string str, string value)
        {
            // TODO #6-3. Implement the method using String.StartsWith instance method. Analyze the unit tests, and use the correct StringComparison enumeration value.
            // See String.StartsWith and StringComparison documentation pages:
            // * https://docs.microsoft.com/en-us/dotnet/api/system.string.startswith
            // * https://docs.microsoft.com/en-us/dotnet/api/system.stringcomparison
            throw new NotImplementedException();
        }
    }
}
