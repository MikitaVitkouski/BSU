using System;

namespace SearchingInStrings
{
    public static class IndexOfAny
    {
        /// <summary>
        /// Reports the zero-based index of the first occurrence in this instance of any character in a specified array of Unicode characters.
        /// </summary>
        /// <returns>The zero-based index position of the first occurrence in this instance where any character in <paramref name="anyOf"/> was found; -1 if no character in <paramref name="anyOf"/> was found.</returns>
        public static int GetIndexOfAnyChar(string str, char[] anyOf)
        {
            // TODO #2-1. Implement the method using String.IndexOfAny instance method.
            // See String.IndexOfAny method documentation page: https://docs.microsoft.com/en-us/dotnet/api/system.string.indexofany
            throw new NotImplementedException();
        }

        /// <summary>
        /// Reports the zero-based index of the first occurrence in this instance of any character in a specified array of Unicode characters. The search starts at a specified character position.
        /// </summary>
        /// <returns>The zero-based index position of the first occurrence in this instance where any character in <paramref name="anyOf"/> was found; -1 if no character in <paramref name="anyOf"/> was found.</returns>
        public static int GetIndexOfAnyChar(string str, char[] anyOf, int startIndex)
        {
            // TODO #2-2. Implement the method using String.IndexOfAny instance method.
            // See String.IndexOfAny method documentation page: https://docs.microsoft.com/en-us/dotnet/api/system.string.indexofany
            throw new NotImplementedException();
        }

        /// <summary>
        /// Reports the zero-based index of the first occurrence in this instance of any character in a specified array of Unicode characters. The search starts at a specified character position and examines a specified number of character positions.
        /// </summary>
        /// <returns>The zero-based index position of the first occurrence in this instance where any character in anyOf was found; -1 if no character in anyOf was found.</returns>
        public static int GetIndexOfAnyChar(string str, char[] anyOf, int startIndex, int count)
        {
            // TODO #2-3. Implement the method using String.IndexOfAny instance method.
            // See String.IndexOfAny method documentation page: https://docs.microsoft.com/en-us/dotnet/api/system.string.indexofany
            throw new NotImplementedException();
        }
    }
}
