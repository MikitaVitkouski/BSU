using System.Globalization;
using NUnit.Framework;

// ReSharper disable StringLiteralTypo
namespace SearchingInStrings.Tests
{
    [TestFixture]
    public sealed class LastIndexOfAnyTests
    {
        [TestCase("encyclopaedia", new char[] { 'c' }, "en-US", ExpectedResult = 4)]
        [TestCase("encyclopaedia", new char[] { 'a' }, "en-US", ExpectedResult = 12)]
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
        public int GetLastIndexOfAny(string str, char[] anyOf, string culture)
        {
            // Arrange
            CultureInfo currentCulture = CultureInfo.CurrentCulture;
            CultureInfo.CurrentCulture = new CultureInfo(culture);

            try
            {
                // Act
                return LastIndexOfAny.GetLastIndexOfAny(str, anyOf);
            }
            finally
            {
                // Tear down
                CultureInfo.CurrentCulture = currentCulture;
            }
        }

        [TestCase("encyclopaedia", new char[] { 'c' }, 12, "en-US", ExpectedResult = 4)]
        [TestCase("encyclopaedia", new char[] { 'c' }, 3, "en-US", ExpectedResult = 2)]
        [TestCase("encyclopaedia", new char[] { 'c' }, 1, "en-US", ExpectedResult = -1)]
        [TestCase("encyclopaedia", new char[] { 'a' }, 12, "en-US", ExpectedResult = 12)]
        [TestCase("encyclopaedia", new char[] { 'a' }, 8, "en-US", ExpectedResult = 8)]
        [TestCase("encyclopaedia", new char[] { 'a' }, 7, "en-US", ExpectedResult = -1)]
        [TestCase("encyclopaedia", new char[] { 'f' }, 12, "en-US", ExpectedResult = -1)]
        [TestCase("encyclopaedia", new char[] { 'C' }, 12, "en-US", ExpectedResult = -1)]
        [TestCase("ENCYCLOPAEDIA", new char[] { 'c' }, 12, "en-US", ExpectedResult = -1)]
        [TestCase("encyclopaedia", new char[] { 'æ' }, 12, "en-US", ExpectedResult = -1)]
        [TestCase("ENCYCLOPAEDIA", new char[] { 'Æ' }, 12, "en-US", ExpectedResult = -1)]
        [TestCase("encyclopaedia", new char[] { 'Æ' }, 12, "en-US", ExpectedResult = -1)]
        [TestCase("ENCYCLOPAEDIA", new char[] { 'æ' }, 12, "en-US", ExpectedResult = -1)]
        [TestCase("encyclopaedia", new char[] { 'æ' }, 12, "se-SE", ExpectedResult = -1)]
        [TestCase("ENCYCLOPAEDIA", new char[] { 'Æ' }, 12, "se-SE", ExpectedResult = -1)]
        [TestCase("encyclopaedia", new char[] { 'Æ' }, 12, "se-SE", ExpectedResult = -1)]
        [TestCase("ENCYCLOPAEDIA", new char[] { 'æ' }, 12, "se-SE", ExpectedResult = -1)]
        public int GetLastIndexOfAny_StartIndex(string str, char[] anyOf, int startIndex, string culture)
        {
            // Arrange
            CultureInfo currentCulture = CultureInfo.CurrentCulture;
            CultureInfo.CurrentCulture = new CultureInfo(culture);

            try
            {
                // Act
                return LastIndexOfAny.GetLastIndexOfAny(str, anyOf, startIndex);
            }
            finally
            {
                // Tear down
                CultureInfo.CurrentCulture = currentCulture;
            }
        }

        [TestCase("encyclopaedia", new char[] { 'c' }, 12, 13, "en-US", ExpectedResult = 4)]
        [TestCase("encyclopaedia", new char[] { 'c' }, 4, 5, "en-US", ExpectedResult = 4)]
        [TestCase("encyclopaedia", new char[] { 'c' }, 3, 4, "en-US", ExpectedResult = 2)]
        [TestCase("encyclopaedia", new char[] { 'c' }, 1, 2, "en-US", ExpectedResult = -1)]
        [TestCase("encyclopaedia", new char[] { 'a' }, 11, 3, "en-US", ExpectedResult = -1)]
        [TestCase("encyclopaedia", new char[] { 'a' }, 11, 4, "en-US", ExpectedResult = 8)]
        [TestCase("encyclopaedia", new char[] { 'f' }, 12, 13, "en-US", ExpectedResult = -1)]
        [TestCase("encyclopaedia", new char[] { 'C' }, 12, 13, "en-US", ExpectedResult = -1)]
        [TestCase("ENCYCLOPAEDIA", new char[] { 'c' }, 12, 13, "en-US", ExpectedResult = -1)]
        [TestCase("encyclopaedia", new char[] { 'æ' }, 12, 13, "en-US", ExpectedResult = -1)]
        [TestCase("ENCYCLOPAEDIA", new char[] { 'Æ' }, 12, 13, "en-US", ExpectedResult = -1)]
        [TestCase("encyclopaedia", new char[] { 'Æ' }, 12, 13, "en-US", ExpectedResult = -1)]
        [TestCase("ENCYCLOPAEDIA", new char[] { 'æ' }, 12, 13, "en-US", ExpectedResult = -1)]
        [TestCase("encyclopaedia", new char[] { 'æ' }, 12, 13, "se-SE", ExpectedResult = -1)]
        [TestCase("ENCYCLOPAEDIA", new char[] { 'Æ' }, 12, 13, "se-SE", ExpectedResult = -1)]
        [TestCase("encyclopaedia", new char[] { 'Æ' }, 12, 13, "se-SE", ExpectedResult = -1)]
        [TestCase("ENCYCLOPAEDIA", new char[] { 'æ' }, 12, 13, "se-SE", ExpectedResult = -1)]
        public int GetLastIndexOfAny_StartIndexCount(string str, char[] anyOf, int startIndex, int count, string culture)
        {
            // Arrange
            CultureInfo currentCulture = CultureInfo.CurrentCulture;
            CultureInfo.CurrentCulture = new CultureInfo(culture);

            try
            {
                // Act
                return LastIndexOfAny.GetLastIndexOfAny(str, anyOf, startIndex, count);
            }
            finally
            {
                // Tear down
                CultureInfo.CurrentCulture = currentCulture;
            }
        }

        [TestCase("encyclopaedia", new char[] { 'f' }, 4, 10)]
        public void GetLastIndexOfAny_CountIsInvalid_ThrowsArgumentOutOfRangeException(string str, char[] anyOf, int startIndex, int count)
        {
            // Act
            Assert.Throws<ArgumentOutOfRangeException>(() => LastIndexOfAny.GetLastIndexOfAny(str, anyOf, startIndex, count));
        }
    }
}
