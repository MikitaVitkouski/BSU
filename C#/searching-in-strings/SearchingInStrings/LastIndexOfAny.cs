using System;

namespace SearchingInStrings
{
    public static class LastIndexOfAny
    {
        /// <summary>
        /// Reports the zero-based index position of the last occurrence in this instance of one or more characters specified in a Unicode array.
        /// </summary>
        /// <returns>The index position of the last occurrence in this instance where any character in <paramref value="anyOf" />was found; -1 if no character in <paramref value="anyOf" />was found or if the current instance equals Empty.</returns>
        public static int GetLastIndexOfAny(string str, char[] anyOf)
        {
            // TODO #4-1. Implement the method using String.LastIndexOfAny instance method.
            // See String.IndexOfAny method documentation page: https://docs.microsoft.com/en-us/dotnet/api/system.string.lastindexofany
            throw new NotImplementedException();
        }

        /// <summary>
        /// Reports the zero-based index position of the last occurrence in this instance of one or more characters specified in a Unicode array. The search starts at a specified character position and proceeds backward toward the beginning of the string.
        /// </summary>
        /// <returns>The index position of the last occurrence in this instance where any character in <paramref value="anyOf" />was found; -1 if no character in <paramref value="anyOf" />was found or if the current instance equals Empty.</returns>
        public static int GetLastIndexOfAny(string str, char[] anyOf, int startIndex)
        {
            // TODO #4-2. Implement the method using String.LastIndexOfAny instance method.
            // See String.IndexOfAny method documentation page: https://docs.microsoft.com/en-us/dotnet/api/system.string.lastindexofany
            throw new NotImplementedException();
        }

        /// <summary>
        /// Reports the zero-based index position of the last occurrence in this instance of one or more characters specified in a Unicode array. The search starts at a specified character position and proceeds backward toward the beginning of the string for a specified number of character positions.
        /// </summary>
        /// <returns>The index position of the last occurrence in this instance where any character in <paramref value="anyOf" />was found; -1 if no character in <paramref value="anyOf" />was found or if the current instance equals Empty.</returns>
        public static int GetLastIndexOfAny(string str, char[] anyOf, int startIndex, int count)
        {
            // TODO #4-3. Implement the method using String.LastIndexOfAny instance method.
            // See String.IndexOfAny method documentation page: https://docs.microsoft.com/en-us/dotnet/api/system.string.lastindexofany
            throw new NotImplementedException();
        }
    }
}
