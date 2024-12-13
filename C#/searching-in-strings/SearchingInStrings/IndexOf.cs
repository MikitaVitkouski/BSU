using System;

namespace SearchingInStrings
{
    public static class IndexOf
    {
        /// <summary>
        /// Reports the zero-based index of the first occurrence of the specified Unicode character in this string.
        /// </summary>
        /// <returns>The zero-based index position of <see cref="value"/> if that character is found, or -1 if it is not.</returns>
        public static int GetIndexOfChar(string str, char value)
        {
            // TODO #1-1. Implement the method using String.IndexOf instance method.
            // See String.IndexOf method documentation page: https://docs.microsoft.com/en-us/dotnet/api/system.string.indexof
            throw new NotImplementedException();
        }

        /// <summary>
        /// Reports the zero-based index of the first occurrence of the specified Unicode character in this string. A parameter specifies the type of search to use for the specified character.
        /// </summary>
        /// <returns>The zero-based index position of <see cref="value"/> if that character is found, or -1 if it is not.</returns>
        public static int GetIndexOfCharInvariantCultureIgnoreCase(string str, char value)
        {
            // TODO #1-2. Implement the method using String.IndexOf instance method. Analyze the unit tests, and use the correct StringComparison enumeration value.
            // See String.IndexOf and StringComparison documentation pages:
            // * https://docs.microsoft.com/en-us/dotnet/api/system.string.indexof
            // * https://docs.microsoft.com/en-us/dotnet/api/system.stringcomparison
            throw new NotImplementedException();
        }

        /// <summary>
        /// Reports the zero-based index of the first occurrence of the specified Unicode character in this string. A parameter specifies the type of search to use for the specified character.
        /// </summary>
        /// <returns>The zero-based index position of <see cref="value"/> if that character is found, or -1 if it is not.</returns>
        public static int GetIndexOfCharWithStringComparison(string str, char value)
        {
            // TODO #1-3. Implement the method using String.IndexOf instance method. Analyze the unit tests, and use the correct StringComparison enumeration value.
            // See String.IndexOf and StringComparison documentation pages:
            // * https://docs.microsoft.com/en-us/dotnet/api/system.string.indexof
            // * https://docs.microsoft.com/en-us/dotnet/api/system.stringcomparison
            throw new NotImplementedException();
        }

        /// <summary>
        /// Reports the zero-based index of the first occurrence of the specified Unicode character in this string. The search starts at a specified character position.
        /// </summary>
        /// <returns>The zero-based index position of <paramref name="value"/> from the start of the string if that character is found, or -1 if it is not.</returns>
        public static int GetIndexOfChar(string str, char value, int startIndex)
        {
            // TODO #1-4. Implement the method using String.IndexOf instance method.
            // See String.IndexOf method documentation page: https://docs.microsoft.com/en-us/dotnet/api/system.string.indexof
            throw new NotImplementedException();
        }

        /// <summary>
        /// Reports the zero-based index of the first occurrence of the specified character in this instance. The search starts at a specified character position and examines a specified number of character positions.
        /// </summary>
        /// <returns>The zero-based index position of <paramref name="value"/> from the start of the string if that character is found, or -1 if it is not.</returns>
        public static int GetIndexOfChar(string str, char value, int startIndex, int count)
        {
            // TODO #1-5. Implement the method using String.IndexOf instance method.
            // See String.IndexOf method documentation page: https://docs.microsoft.com/en-us/dotnet/api/system.string.indexof
            throw new NotImplementedException();
        }

        /// <summary>
        /// Reports the zero-based index of the first occurrence of the specified string in this instance.
        /// </summary>
        /// <returns>The zero-based index position of <paramref name="value"/> if that string is found, or -1 if it is not. If value is <see cref="string.Empty"/>, the return <paramref name="value"/> is 0.</returns>
        public static int GetIndexOfString(string str, string value)
        {
            // TODO #1-6. Implement the method using String.IndexOf instance method.
            // See String.IndexOf method documentation page: https://docs.microsoft.com/en-us/dotnet/api/system.string.indexof
            throw new NotImplementedException();
        }

        /// <summary>
        /// Reports the zero-based index of the first occurrence of the specified string in the current String object. A parameter specifies the type of search to use for the specified string.
        /// </summary>
        /// <returns>The index position of the <paramref name="value"/> parameter if that string is found, or -1 if it is not. If <paramref name="value"/> is <see cref="string.Empty"/>, the return value is 0.</returns>
        public static int GetIndexOfStringOrdinal(string str, string value)
        {
            // TODO #1-7. Implement the method using String.IndexOf instance method. Analyze the unit tests, and use the correct StringComparison enumeration value.
            // See String.IndexOf and StringComparison documentation pages:
            // * https://docs.microsoft.com/en-us/dotnet/api/system.string.indexof
            // * https://docs.microsoft.com/en-us/dotnet/api/system.stringcomparison
            throw new NotImplementedException();
        }

        /// <summary>
        /// Reports the zero-based index of the first occurrence of the specified string in the current String object. A parameter specifies the type of search to use for the specified string.
        /// </summary>
        /// <returns>The index position of the <paramref name="value"/> parameter if that string is found, or -1 if it is not. If <paramref name="value"/> is <see cref="string.Empty"/>, the return value is 0.</returns>
        public static int GetIndexOfStringWithStringComparison(string str, string value)
        {
            // TODO #1-8. Implement the method using String.IndexOf instance method. Analyze the unit tests, and use the correct StringComparison enumeration value.
            // See String.IndexOf and StringComparison documentation pages:
            // * https://docs.microsoft.com/en-us/dotnet/api/system.string.indexof
            // * https://docs.microsoft.com/en-us/dotnet/api/system.stringcomparison
            throw new NotImplementedException();
        }

        /// <summary>
        /// Reports the zero-based index of the first occurrence of the specified string in this instance. The search starts at a specified character position.
        /// </summary>
        /// <returns>The zero-based index position of <paramref name="value"/> from the start of the current instance if that string is found, or -1 if it is not. If value is Empty, the return <paramref name="value"/> is <paramref name="startIndex"/>.</returns>
        public static int GetIndexOfString(string str, string value, int startIndex)
        {
            // TODO #1-9. Implement the method using String.IndexOf instance method.
            // See String.IndexOf method documentation page: https://docs.microsoft.com/en-us/dotnet/api/system.string.indexof
            throw new NotImplementedException();
        }

        /// <summary>
        /// Reports the zero-based index of the first occurrence of the specified string in the current String object. Parameters specify the starting search position in the current string and the type of search to use for the specified string.
        /// </summary>
        /// <returns>The zero-based index position of <paramref name="value"/> from the start of the current instance if that string is found, or -1 if it is not. If value is Empty, the return <paramref name="value"/> is <paramref name="startIndex"/>.</returns>
        public static int GetIndexOfStringCurrentCultureIgnoreCase(string str, string value, int startIndex)
        {
            // TODO #1-10. Implement the method using String.IndexOf instance method. Analyze the unit tests, and use the correct StringComparison enumeration value.
            // See String.IndexOf and StringComparison documentation pages:
            // * https://docs.microsoft.com/en-us/dotnet/api/system.string.indexof
            // * https://docs.microsoft.com/en-us/dotnet/api/system.stringcomparison
            throw new NotImplementedException();
        }

        /// <summary>
        /// Reports the zero-based index of the first occurrence of the specified string in the current String object. Parameters specify the starting search position in the current string and the type of search to use for the specified string.
        /// </summary>
        /// <returns>The zero-based index position of <paramref name="value"/> from the start of the current instance if that string is found, or -1 if it is not. If value is Empty, the return <paramref name="value"/> is <paramref name="startIndex"/>.</returns>
        public static int GetIndexOfStringWithStringComparison(string str, string value, int startIndex)
        {
            // TODO #1-11. Implement the method using String.IndexOf instance method. Analyze the unit tests, and use the correct StringComparison enumeration value.
            // See String.IndexOf and StringComparison documentation pages:
            // * https://docs.microsoft.com/en-us/dotnet/api/system.string.indexof
            // * https://docs.microsoft.com/en-us/dotnet/api/system.stringcomparison
            throw new NotImplementedException();
        }

        /// <summary>
        /// Reports the zero-based index of the first occurrence of the specified string in this instance. The search starts at a specified character position and examines a specified number of character positions.
        /// </summary>
        /// <returns>The zero-based index position of <paramref name="value"/> from the start of the current instance if that string is found, or -1 if it is not. If value is Empty, the return <paramref name="value"/> is <paramref name="startIndex"/>.</returns>
        public static int GetIndexOfString(string str, string value, int startIndex, int count)
        {
            // TODO #1-12. Implement the method using String.IndexOf instance method.
            // See String.IndexOf method documentation page: https://docs.microsoft.com/en-us/dotnet/api/system.string.indexof
            throw new NotImplementedException();
        }

        /// <summary>
        /// Reports the zero-based index of the first occurrence of the specified string in the current String object. Parameters specify the starting search position in the current string, the number of characters in the current string to search, and the type of search to use for the specified string.
        /// </summary>
        /// <returns>The zero-based index position of <paramref name="value"/> from the start of the current instance if that string is found, or -1 if it is not. If value is Empty, the return <paramref name="value"/> is <paramref name="startIndex"/>.</returns>
        public static int GetIndexOfStringInvariantCulture(string str, string value, int startIndex, int count)
        {
            // TODO #1-13. Implement the method using String.IndexOf instance method. Analyze the unit tests, and use the correct StringComparison enumeration value.
            // See String.IndexOf and StringComparison documentation pages:
            // * https://docs.microsoft.com/en-us/dotnet/api/system.string.indexof
            // * https://docs.microsoft.com/en-us/dotnet/api/system.stringcomparison
            throw new NotImplementedException();
        }

        /// <summary>
        /// Reports the zero-based index of the first occurrence of the specified string in the current String object. Parameters specify the starting search position in the current string, the number of characters in the current string to search, and the type of search to use for the specified string.
        /// </summary>
        /// <returns>The zero-based index position of <paramref name="value"/> from the start of the current instance if that string is found, or -1 if it is not. If value is Empty, the return <paramref name="value"/> is <paramref name="startIndex"/>.</returns>
        public static int GetIndexOfStringWithStringComparison(string str, string value, int startIndex, int count)
        {
            // TODO #1-14. Implement the method using String.IndexOf instance method. Analyze the unit tests, and use the correct StringComparison enumeration value.
            // See String.IndexOf and StringComparison documentation pages:
            // * https://docs.microsoft.com/en-us/dotnet/api/system.string.indexof
            // * https://docs.microsoft.com/en-us/dotnet/api/system.stringcomparison
            throw new NotImplementedException();
        }
    }
}
