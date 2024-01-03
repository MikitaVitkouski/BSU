using System.Globalization;
using NUnit.Framework;

// ReSharper disable StringLiteralTypo
namespace SearchingInStrings.Tests
{
    [TestFixture]
    public sealed class IndexOfAnyTests
    {
        [TestCase("encyclopaedia", new char[] { 'c' }, "en-US", ExpectedResult = 2)]
        [TestCase("encyclopaedia", new char[] { 'a' }, "en-US", ExpectedResult = 8)]
        [TestCase("encyclopaedia", new char[] { 'f' }, "en-US", ExpectedResult = -1)]
        [TestCase("encyclopaedia", new char[] { 'C' }, "en-US", ExpectedResult = -1)]
        [TestCase("ENCYCLOPAEDIA", new char[] { 'c' }, "en-US", ExpectedResult = -1)]
        [TestCase("encyclopaedia", new char[] { 'æ' }, "en-US", ExpectedResult = -1)]
        [TestCase("ENCYCLOPAEDIA", new char[] { 'Æ' }, "en-US", ExpectedResult = -1)]
        [TestCase("encyclopaedia", new char[] { 'Æ' }, "en-US", ExpectedResult = -1)]
        [TestCase("ENCYCLOPAEDIA", new char[] { 'æ' }, "en-US", ExpectedResult = -1)]
        [TestCase("encyclopaedia", new char[] { 'æ' }, "se-SE", ExpectedResult = -1)]
        [TestCase("ENCYCLOPAEDIA", new char[] { 'Æ' }, "se-SE", ExpectedResult = -1)]
        [TestCase("encyclopaedia", new char[] { 'Æ' }, "se-SE", ExpectedResult = -1)]
        [TestCase("ENCYCLOPAEDIA", new char[] { 'æ' }, "se-SE", ExpectedResult = -1)]
        public int GetIndexOfChar(string str, char[] anyOf, string culture)
        {
            // Arrange
            CultureInfo currentCulture = CultureInfo.CurrentCulture;
            CultureInfo.CurrentCulture = new CultureInfo(culture);

            try
            {
                // Act
                return IndexOfAny.GetIndexOfAnyChar(str, anyOf);
            }
            finally
            {
                // Tear down
                CultureInfo.CurrentCulture = currentCulture;
            }
        }

        [TestCase("encyclopaedia", new char[] { 'c' }, 0, "en-US", ExpectedResult = 2)]
        [TestCase("encyclopaedia", new char[] { 'c' }, 2, "en-US", ExpectedResult = 2)]
        [TestCase("encyclopaedia", new char[] { 'c' }, 3, "en-US", ExpectedResult = 4)]
        [TestCase("encyclopaedia", new char[] { 'c' }, 5, "en-US", ExpectedResult = -1)]
        [TestCase("encyclopaedia", new char[] { 'a' }, 0, "en-US", ExpectedResult = 8)]
        [TestCase("encyclopaedia", new char[] { 'a' }, 8, "en-US", ExpectedResult = 8)]
        [TestCase("encyclopaedia", new char[] { 'a' }, 9, "en-US", ExpectedResult = 12)]
        [TestCase("encyclopaedia", new char[] { 'f' }, 0, "en-US", ExpectedResult = -1)]
        [TestCase("encyclopaedia", new char[] { 'C' }, 0, "en-US", ExpectedResult = -1)]
        [TestCase("ENCYCLOPAEDIA", new char[] { 'c' }, 0, "en-US", ExpectedResult = -1)]
        [TestCase("encyclopaedia", new char[] { 'æ' }, 0, "en-US", ExpectedResult = -1)]
        [TestCase("ENCYCLOPAEDIA", new char[] { 'Æ' }, 0, "en-US", ExpectedResult = -1)]
        [TestCase("encyclopaedia", new char[] { 'Æ' }, 0, "en-US", ExpectedResult = -1)]
        [TestCase("ENCYCLOPAEDIA", new char[] { 'æ' }, 0, "en-US", ExpectedResult = -1)]
        [TestCase("encyclopaedia", new char[] { 'æ' }, 0, "se-SE", ExpectedResult = -1)]
        [TestCase("ENCYCLOPAEDIA", new char[] { 'Æ' }, 0, "se-SE", ExpectedResult = -1)]
        [TestCase("encyclopaedia", new char[] { 'Æ' }, 0, "se-SE", ExpectedResult = -1)]
        [TestCase("ENCYCLOPAEDIA", new char[] { 'æ' }, 0, "se-SE", ExpectedResult = -1)]
        public int GetIndexOfChar_StartIndex(string str, char[] anyOf, int startIndex, string culture)
        {
            // Arrange
            CultureInfo currentCulture = CultureInfo.CurrentCulture;
            CultureInfo.CurrentCulture = new CultureInfo(culture);

            try
            {
                // Act
                return IndexOfAny.GetIndexOfAnyChar(str, anyOf, startIndex);
            }
            finally
            {
                // Tear down
                CultureInfo.CurrentCulture = currentCulture;
            }
        }

        [TestCase("encyclopaedia", new char[] { 'c' }, 0, 13, "en-US", ExpectedResult = 2)]
        [TestCase("encyclopaedia", new char[] { 'c' }, 3, 10, "en-US", ExpectedResult = 4)]
        [TestCase("encyclopaedia", new char[] { 'c' }, 5, 8, "en-US", ExpectedResult = -1)]
        [TestCase("encyclopaedia", new char[] { 'a' }, 0, 7, "en-US", ExpectedResult = -1)]
        [TestCase("encyclopaedia", new char[] { 'a' }, 9, 4, "en-US", ExpectedResult = 12)]
        [TestCase("encyclopaedia", new char[] { 'f' }, 0, 13, "en-US", ExpectedResult = -1)]
        [TestCase("encyclopaedia", new char[] { 'C' }, 0, 13, "en-US", ExpectedResult = -1)]
        [TestCase("ENCYCLOPAEDIA", new char[] { 'c' }, 0, 13, "en-US", ExpectedResult = -1)]
        [TestCase("encyclopaedia", new char[] { 'æ' }, 0, 13, "en-US", ExpectedResult = -1)]
        [TestCase("ENCYCLOPAEDIA", new char[] { 'Æ' }, 0, 13, "en-US", ExpectedResult = -1)]
        [TestCase("encyclopaedia", new char[] { 'Æ' }, 0, 13, "en-US", ExpectedResult = -1)]
        [TestCase("ENCYCLOPAEDIA", new char[] { 'æ' }, 0, 13, "en-US", ExpectedResult = -1)]
        [TestCase("encyclopaedia", new char[] { 'æ' }, 0, 13, "se-SE", ExpectedResult = -1)]
        [TestCase("ENCYCLOPAEDIA", new char[] { 'Æ' }, 0, 13, "se-SE", ExpectedResult = -1)]
        [TestCase("encyclopaedia", new char[] { 'Æ' }, 0, 13, "se-SE", ExpectedResult = -1)]
        [TestCase("ENCYCLOPAEDIA", new char[] { 'æ' }, 0, 13, "se-SE", ExpectedResult = -1)]
        public int GetIndexOfChar_StartIndexCount(string str, char[] anyOf, int startIndex, int count, string culture)
        {
            // Arrange
            CultureInfo currentCulture = CultureInfo.CurrentCulture;
            CultureInfo.CurrentCulture = new CultureInfo(culture);

            try
            {
                // Act
                return IndexOfAny.GetIndexOfAnyChar(str, anyOf, startIndex, count);
            }
            finally
            {
                // Tear down
                CultureInfo.CurrentCulture = currentCulture;
            }
        }
    }
}
