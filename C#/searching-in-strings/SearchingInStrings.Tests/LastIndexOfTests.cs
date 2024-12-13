using System.Globalization;
using NUnit.Framework;

// ReSharper disable StringLiteralTypo
namespace SearchingInStrings.Tests
{
    [TestFixture]
    public sealed class LastIndexOfTests
    {
        [TestCase("encyclopaedia", 'c', "en-US", ExpectedResult = 4)]
        [TestCase("encyclopaedia", 'a', "en-US", ExpectedResult = 12)]
        [TestCase("encyclopaedia", 'f', "en-US", ExpectedResult = -1)]
        [TestCase("encyclopaedia", 'C', "en-US", ExpectedResult = -1)]
        [TestCase("ENCYCLOPAEDIA", 'c', "en-US", ExpectedResult = -1)]
        [TestCase("encyclopaedia", 'æ', "en-US", ExpectedResult = -1)]
        [TestCase("ENCYCLOPAEDIA", 'Æ', "en-US", ExpectedResult = -1)]
        [TestCase("encyclopaedia", 'Æ', "en-US", ExpectedResult = -1)]
        [TestCase("ENCYCLOPAEDIA", 'æ', "en-US", ExpectedResult = -1)]
        [TestCase("encyclopaedia", 'æ', "se-SE", ExpectedResult = -1)]
        [TestCase("ENCYCLOPAEDIA", 'Æ', "se-SE", ExpectedResult = -1)]
        [TestCase("encyclopaedia", 'Æ', "se-SE", ExpectedResult = -1)]
        [TestCase("ENCYCLOPAEDIA", 'æ', "se-SE", ExpectedResult = -1)]
        public int GetIndexOfChar(string str, char value, string culture)
        {
            // Arrange
            CultureInfo currentCulture = CultureInfo.CurrentCulture;
            CultureInfo.CurrentCulture = new CultureInfo(culture);

            try
            {
                // Act
                return LastIndexOf.GetLastIndexOfChar(str, value);
            }
            finally
            {
                // Tear down
                CultureInfo.CurrentCulture = currentCulture;
            }
        }

        [TestCase("encyclopaedia", 'c', 12, "en-US", ExpectedResult = 4)]
        [TestCase("encyclopaedia", 'c', 3, "en-US", ExpectedResult = 2)]
        [TestCase("encyclopaedia", 'c', 1, "en-US", ExpectedResult = -1)]
        [TestCase("encyclopaedia", 'a', 12, "en-US", ExpectedResult = 12)]
        [TestCase("encyclopaedia", 'a', 8, "en-US", ExpectedResult = 8)]
        [TestCase("encyclopaedia", 'a', 7, "en-US", ExpectedResult = -1)]
        [TestCase("encyclopaedia", 'f', 12, "en-US", ExpectedResult = -1)]
        [TestCase("encyclopaedia", 'C', 12, "en-US", ExpectedResult = -1)]
        [TestCase("ENCYCLOPAEDIA", 'c', 12, "en-US", ExpectedResult = -1)]
        [TestCase("encyclopaedia", 'æ', 12, "en-US", ExpectedResult = -1)]
        [TestCase("ENCYCLOPAEDIA", 'Æ', 12, "en-US", ExpectedResult = -1)]
        [TestCase("encyclopaedia", 'Æ', 12, "en-US", ExpectedResult = -1)]
        [TestCase("ENCYCLOPAEDIA", 'æ', 12, "en-US", ExpectedResult = -1)]
        [TestCase("encyclopaedia", 'æ', 12, "se-SE", ExpectedResult = -1)]
        [TestCase("ENCYCLOPAEDIA", 'Æ', 12, "se-SE", ExpectedResult = -1)]
        [TestCase("encyclopaedia", 'Æ', 12, "se-SE", ExpectedResult = -1)]
        [TestCase("ENCYCLOPAEDIA", 'æ', 12, "se-SE", ExpectedResult = -1)]
        public int GetIndexOfChar_StartIndex(string str, char value, int startIndex, string culture)
        {
            // Arrange
            CultureInfo currentCulture = CultureInfo.CurrentCulture;
            CultureInfo.CurrentCulture = new CultureInfo(culture);

            try
            {
                // Act
                return LastIndexOf.GetLastIndexOfChar(str, value, startIndex);
            }
            finally
            {
                // Tear down
                CultureInfo.CurrentCulture = currentCulture;
            }
        }

        [TestCase("encyclopaedia", 'c', 12, 13, "en-US", ExpectedResult = 4)]
        [TestCase("encyclopaedia", 'c', 4, 5, "en-US", ExpectedResult = 4)]
        [TestCase("encyclopaedia", 'c', 3, 4, "en-US", ExpectedResult = 2)]
        [TestCase("encyclopaedia", 'c', 1, 2, "en-US", ExpectedResult = -1)]
        [TestCase("encyclopaedia", 'a', 11, 3, "en-US", ExpectedResult = -1)]
        [TestCase("encyclopaedia", 'a', 11, 4, "en-US", ExpectedResult = 8)]
        [TestCase("encyclopaedia", 'f', 12, 13, "en-US", ExpectedResult = -1)]
        [TestCase("encyclopaedia", 'C', 12, 13, "en-US", ExpectedResult = -1)]
        [TestCase("ENCYCLOPAEDIA", 'c', 12, 13, "en-US", ExpectedResult = -1)]
        [TestCase("encyclopaedia", 'æ', 12, 13, "en-US", ExpectedResult = -1)]
        [TestCase("ENCYCLOPAEDIA", 'Æ', 12, 13, "en-US", ExpectedResult = -1)]
        [TestCase("encyclopaedia", 'Æ', 12, 13, "en-US", ExpectedResult = -1)]
        [TestCase("ENCYCLOPAEDIA", 'æ', 12, 13, "en-US", ExpectedResult = -1)]
        [TestCase("encyclopaedia", 'æ', 12, 13, "se-SE", ExpectedResult = -1)]
        [TestCase("ENCYCLOPAEDIA", 'Æ', 12, 13, "se-SE", ExpectedResult = -1)]
        [TestCase("encyclopaedia", 'Æ', 12, 13, "se-SE", ExpectedResult = -1)]
        [TestCase("ENCYCLOPAEDIA", 'æ', 12, 13, "se-SE", ExpectedResult = -1)]
        public int GetIndexOfChar_StartIndexCount(string str, char value, int startIndex, int count, string culture)
        {
            // Arrange
            CultureInfo currentCulture = CultureInfo.CurrentCulture;
            CultureInfo.CurrentCulture = new CultureInfo(culture);

            try
            {
                // Act
                return LastIndexOf.GetLastIndexOfChar(str, value, startIndex, count);
            }
            finally
            {
                // Tear down
                CultureInfo.CurrentCulture = currentCulture;
            }
        }

        [TestCase("encyclopaedia", 'f', 8, 10)]
        public void GetIndexOfChar_CountIsInvalid_ThrowsArgumentOutOfRangeException(string str, char value, int startIndex, int count)
        {
            // Act
            Assert.Throws<ArgumentOutOfRangeException>(() => LastIndexOf.GetLastIndexOfChar(str, value, startIndex, count));
        }

        [TestCase("encyclopaedia", "enc", "en-US", ExpectedResult = 0)]
        [TestCase("encyclopaedia", "dia", "en-US", ExpectedResult = 10)]
        [TestCase("encyclopaedia", "fen", "en-US", ExpectedResult = -1)]
        [TestCase("encyclopaedia", "ENC", "en-US", ExpectedResult = -1)]
        [TestCase("ENCYCLOPAEDIA", "enc", "en-US", ExpectedResult = -1)]
        [TestCase("encyclopaedia", "pæd", "en-US", ExpectedResult = 7)]
        [TestCase("ENCYCLOPAEDIA", "PÆD", "en-US", ExpectedResult = 7)]
        [TestCase("encyclopaedia", "PÆD", "en-US", ExpectedResult = -1)]
        [TestCase("ENCYCLOPAEDIA", "pæd", "en-US", ExpectedResult = -1)]
        [TestCase("encyclopaedia", "pæd", "se-SE", ExpectedResult = -1)]
        [TestCase("ENCYCLOPAEDIA", "PÆD", "se-SE", ExpectedResult = -1)]
        [TestCase("encyclopaedia", "PÆD", "se-SE", ExpectedResult = -1)]
        [TestCase("ENCYCLOPAEDIA", "pæd", "se-SE", ExpectedResult = -1)]
        public int GetIndexOfString(string str, string value, string culture)
        {
            // Arrange
            CultureInfo currentCulture = CultureInfo.CurrentCulture;
            CultureInfo.CurrentCulture = new CultureInfo(culture);

            try
            {
                // Act
                return LastIndexOf.GetLastIndexOfString(str, value);
            }
            finally
            {
                // Tear down
                CultureInfo.CurrentCulture = currentCulture;
            }
        }

        [TestCase("encyclopaedia", "enc", "en-US", ExpectedResult = 0)]
        [TestCase("encyclopaedia", "dia", "en-US", ExpectedResult = 10)]
        [TestCase("encyclopaedia", "fen", "en-US", ExpectedResult = -1)]
        [TestCase("encyclopaedia", "ENC", "en-US", ExpectedResult = -1)]
        [TestCase("ENCYCLOPAEDIA", "enc", "en-US", ExpectedResult = -1)]
        [TestCase("encyclopaedia", "pæd", "en-US", ExpectedResult = -1)]
        [TestCase("ENCYCLOPAEDIA", "PÆD", "en-US", ExpectedResult = -1)]
        [TestCase("encyclopaedia", "PÆD", "en-US", ExpectedResult = -1)]
        [TestCase("ENCYCLOPAEDIA", "pæd", "en-US", ExpectedResult = -1)]
        [TestCase("encyclopaedia", "pæd", "se-SE", ExpectedResult = -1)]
        [TestCase("ENCYCLOPAEDIA", "PÆD", "se-SE", ExpectedResult = -1)]
        [TestCase("encyclopaedia", "PÆD", "se-SE", ExpectedResult = -1)]
        [TestCase("ENCYCLOPAEDIA", "pæd", "se-SE", ExpectedResult = -1)]
        public int GetIndexOfStringOrdinal(string str, string value, string culture)
        {
            // Arrange
            CultureInfo currentCulture = CultureInfo.CurrentCulture;
            CultureInfo.CurrentCulture = new CultureInfo(culture);

            try
            {
                // Act
                return LastIndexOf.GetLastIndexOfStringOrdinal(str, value);
            }
            finally
            {
                // Tear down
                CultureInfo.CurrentCulture = currentCulture;
            }
        }

        [TestCase("encyclopaedia", "enc", "en-US", ExpectedResult = 0)]
        [TestCase("encyclopaedia", "dia", "en-US", ExpectedResult = 10)]
        [TestCase("encyclopaedia", "fen", "en-US", ExpectedResult = -1)]
        [TestCase("encyclopaedia", "ENC", "en-US", ExpectedResult = -1)]
        [TestCase("ENCYCLOPAEDIA", "enc", "en-US", ExpectedResult = -1)]
        [TestCase("encyclopaedia", "pæd", "en-US", ExpectedResult = 7)]
        [TestCase("ENCYCLOPAEDIA", "PÆD", "en-US", ExpectedResult = 7)]
        [TestCase("encyclopaedia", "PÆD", "en-US", ExpectedResult = -1)]
        [TestCase("ENCYCLOPAEDIA", "pæd", "en-US", ExpectedResult = -1)]
        [TestCase("encyclopaedia", "pæd", "se-SE", ExpectedResult = 7)]
        [TestCase("ENCYCLOPAEDIA", "PÆD", "se-SE", ExpectedResult = 7)]
        [TestCase("encyclopaedia", "PÆD", "se-SE", ExpectedResult = -1)]
        [TestCase("ENCYCLOPAEDIA", "pæd", "se-SE", ExpectedResult = -1)]
        public int GetIndexOfStringWithStringComparison(string str, string value, string culture)
        {
            // Arrange
            CultureInfo currentCulture = CultureInfo.CurrentCulture;
            CultureInfo.CurrentCulture = new CultureInfo(culture);

            try
            {
                // Act
                return LastIndexOf.GetLastIndexOfStringWithStringComparison(str, value);
            }
            finally
            {
                // Tear down
                CultureInfo.CurrentCulture = currentCulture;
            }
        }

        [TestCase("encyclopaedia", "enc", 12, "en-US", ExpectedResult = 0)]
        [TestCase("ENCYCLOPAEDIA", "DIA", 12, "en-US", ExpectedResult = 10)]
        [TestCase("encyclopaedia", "ENC", 12, "en-US", ExpectedResult = -1)]
        [TestCase("ENCYCLOPAEDIA", "dia", 12, "en-US", ExpectedResult = -1)]
        [TestCase("encyclopaedia", "pæd", 12, "en-US", ExpectedResult = 7)]
        [TestCase("ENCYCLOPAEDIA", "PÆD", 12, "en-US", ExpectedResult = 7)]
        [TestCase("encyclopaedia", "PÆD", 12, "en-US", ExpectedResult = -1)]
        [TestCase("ENCYCLOPAEDIA", "pæd", 12, "en-US", ExpectedResult = -1)]
        [TestCase("encyclopaedia", "PÆD", 12, "se-SE", ExpectedResult = -1)]
        [TestCase("ENCYCLOPAEDIA", "pæd", 12, "se-SE", ExpectedResult = -1)]
        [TestCase("encyclopaedia", "pæd", 12, "se-SE", ExpectedResult = -1)]
        [TestCase("ENCYCLOPAEDIA", "PÆD", 12, "se-SE", ExpectedResult = -1)]
        public int GetIndexOfString_StartIndex(string str, string value, int startIndex, string culture)
        {
            // Arrange
            CultureInfo currentCulture = CultureInfo.CurrentCulture;
            CultureInfo.CurrentCulture = new CultureInfo(culture);

            try
            {
                // Act
                return LastIndexOf.GetLastIndexOfString(str, value, startIndex);
            }
            finally
            {
                // Tear down
                CultureInfo.CurrentCulture = currentCulture;
            }
        }

        [TestCase("encyclopaedia", "enc", 12, "en-US", ExpectedResult = 0)]
        [TestCase("ENCYCLOPAEDIA", "DIA", 12, "en-US", ExpectedResult = 10)]
        [TestCase("encyclopaedia", "ENC", 12, "en-US", ExpectedResult = 0)]
        [TestCase("ENCYCLOPAEDIA", "dia", 12, "en-US", ExpectedResult = 10)]
        [TestCase("encyclopaedia", "pæd", 12, "en-US", ExpectedResult = 7)]
        [TestCase("ENCYCLOPAEDIA", "PÆD", 12, "en-US", ExpectedResult = 7)]
        [TestCase("encyclopaedia", "PÆD", 12, "en-US", ExpectedResult = 7)]
        [TestCase("ENCYCLOPAEDIA", "pæd", 12, "en-US", ExpectedResult = 7)]
        [TestCase("encyclopaedia", "PÆD", 12, "se-SE", ExpectedResult = -1)]
        [TestCase("ENCYCLOPAEDIA", "pæd", 12, "se-SE", ExpectedResult = -1)]
        [TestCase("encyclopaedia", "pæd", 12, "se-SE", ExpectedResult = -1)]
        [TestCase("ENCYCLOPAEDIA", "PÆD", 12, "se-SE", ExpectedResult = -1)]
        public int GetIndexOfStringCurrentCultureIgnoreCase_StartIndex(string str, string value, int startIndex, string culture)
        {
            // Arrange
            CultureInfo currentCulture = CultureInfo.CurrentCulture;
            CultureInfo.CurrentCulture = new CultureInfo(culture);

            try
            {
                // Act
                return LastIndexOf.GetLastIndexOfStringCurrentCultureIgnoreCase(str, value, startIndex);
            }
            finally
            {
                // Tear down
                CultureInfo.CurrentCulture = currentCulture;
            }
        }

        [TestCase("encyclopaedia", "enc", 12, "en-US", ExpectedResult = 0)]
        [TestCase("ENCYCLOPAEDIA", "DIA", 12, "en-US", ExpectedResult = 10)]
        [TestCase("encyclopaedia", "ENC", 12, "en-US", ExpectedResult = -1)]
        [TestCase("ENCYCLOPAEDIA", "dia", 12, "en-US", ExpectedResult = -1)]
        [TestCase("encyclopaedia", "pæd", 12, "en-US", ExpectedResult = 7)]
        [TestCase("ENCYCLOPAEDIA", "PÆD", 12, "en-US", ExpectedResult = 7)]
        [TestCase("encyclopaedia", "PÆD", 12, "en-US", ExpectedResult = -1)]
        [TestCase("ENCYCLOPAEDIA", "pæd", 12, "en-US", ExpectedResult = -1)]
        [TestCase("encyclopaedia", "pæd", 12, "se-SE", ExpectedResult = -1)]
        [TestCase("ENCYCLOPAEDIA", "PÆD", 12, "se-SE", ExpectedResult = -1)]
        [TestCase("encyclopaedia", "PÆD", 12, "se-SE", ExpectedResult = -1)]
        [TestCase("ENCYCLOPAEDIA", "pæd", 12, "se-SE", ExpectedResult = -1)]
        public int GetIndexOfStringWithStringComparison_StartIndex(string str, string value, int startIndex, string culture)
        {
            // Arrange
            CultureInfo currentCulture = CultureInfo.CurrentCulture;
            CultureInfo.CurrentCulture = new CultureInfo(culture);

            try
            {
                // Act
                return LastIndexOf.GetLastIndexOfStringWithStringComparison(str, value, startIndex);
            }
            finally
            {
                // Tear down
                CultureInfo.CurrentCulture = currentCulture;
            }
        }

        [TestCase("encyclopaedia", "enc", 12, 13, "en-US", ExpectedResult = 0)]
        [TestCase("encyclopaedia", "enc", 12, 12, "en-US", ExpectedResult = -1)]
        [TestCase("ENCYCLOPAEDIA", "DIA", 12, 13, "en-US", ExpectedResult = 10)]
        [TestCase("ENCYCLOPAEDIA", "DIA", 11, 12, "en-US", ExpectedResult = -1)]
        [TestCase("encyclopaedia", "ENC", 12, 13, "en-US", ExpectedResult = -1)]
        [TestCase("ENCYCLOPAEDIA", "dia", 12, 13, "en-US", ExpectedResult = -1)]
        [TestCase("encyclopaedia", "pæd", 12, 13, "en-US", ExpectedResult = 7)]
        [TestCase("ENCYCLOPAEDIA", "PÆD", 12, 13, "en-US", ExpectedResult = 7)]
        [TestCase("encyclopaedia", "PÆD", 12, 13, "en-US", ExpectedResult = -1)]
        [TestCase("ENCYCLOPAEDIA", "pæd", 12, 13, "en-US", ExpectedResult = -1)]
        [TestCase("encyclopaedia", "pæd", 12, 13, "se-SE", ExpectedResult = -1)]
        [TestCase("ENCYCLOPAEDIA", "PÆD", 12, 13, "se-SE", ExpectedResult = -1)]
        [TestCase("encyclopaedia", "PÆD", 12, 13, "se-SE", ExpectedResult = -1)]
        [TestCase("ENCYCLOPAEDIA", "pæd", 12, 13, "se-SE", ExpectedResult = -1)]
        public int GetIndexOfString_StartIndexCount(string str, string value, int startIndex, int count, string culture)
        {
            // Arrange
            CultureInfo currentCulture = CultureInfo.CurrentCulture;
            CultureInfo.CurrentCulture = new CultureInfo(culture);

            try
            {
                // Act
                return LastIndexOf.GetLastIndexOfString(str, value, startIndex, count);
            }
            finally
            {
                // Tear down
                CultureInfo.CurrentCulture = currentCulture;
            }
        }

        [TestCase("encyclopaedia", "enc", 12, 13, "en-US", ExpectedResult = 0)]
        [TestCase("encyclopaedia", "enc", 12, 12, "en-US", ExpectedResult = -1)]
        [TestCase("ENCYCLOPAEDIA", "DIA", 12, 13, "en-US", ExpectedResult = 10)]
        [TestCase("ENCYCLOPAEDIA", "DIA", 11, 11, "en-US", ExpectedResult = -1)]
        [TestCase("encyclopaedia", "ENC", 12, 13, "en-US", ExpectedResult = -1)]
        [TestCase("ENCYCLOPAEDIA", "dia", 12, 13, "en-US", ExpectedResult = -1)]
        [TestCase("encyclopaedia", "pæd", 12, 13, "en-US", ExpectedResult = 7)]
        [TestCase("ENCYCLOPAEDIA", "PÆD", 12, 13, "en-US", ExpectedResult = 7)]
        [TestCase("encyclopaedia", "PÆD", 12, 13, "en-US", ExpectedResult = -1)]
        [TestCase("ENCYCLOPAEDIA", "pæd", 12, 13, "en-US", ExpectedResult = -1)]
        [TestCase("encyclopaedia", "pæd", 12, 13, "se-SE", ExpectedResult = 7)]
        [TestCase("ENCYCLOPAEDIA", "PÆD", 12, 13, "se-SE", ExpectedResult = 7)]
        [TestCase("encyclopaedia", "PÆD", 12, 13, "se-SE", ExpectedResult = -1)]
        [TestCase("ENCYCLOPAEDIA", "pæd", 12, 13, "se-SE", ExpectedResult = -1)]
        public int GetIndexOfStringCurrentCultureIgnoreCase_StartIndexCount(string str, string value, int startIndex, int count, string culture)
        {
            // Arrange
            CultureInfo currentCulture = CultureInfo.CurrentCulture;
            CultureInfo.CurrentCulture = new CultureInfo(culture);

            try
            {
                // Act
                return LastIndexOf.GetLastIndexOfStringInvariantCulture(str, value, startIndex, count);
            }
            finally
            {
                // Tear down
                CultureInfo.CurrentCulture = currentCulture;
            }
        }

        [TestCase("encyclopaedia", "enc", 12, 12, "en-US", ExpectedResult = -1)]
        [TestCase("ENCYCLOPAEDIA", "DIA", 11, 11, "en-US", ExpectedResult = -1)]
        [TestCase("encyclopaedia", "ENC", 12, 13, "en-US", ExpectedResult = 0)]
        [TestCase("ENCYCLOPAEDIA", "dia", 12, 13, "en-US", ExpectedResult = 10)]
        [TestCase("encyclopaedia", "pæd", 12, 13, "en-US", ExpectedResult = 7)]
        [TestCase("ENCYCLOPAEDIA", "PÆD", 12, 13, "en-US", ExpectedResult = 7)]
        [TestCase("encyclopaedia", "PÆD", 12, 13, "en-US", ExpectedResult = 7)]
        [TestCase("ENCYCLOPAEDIA", "pæd", 12, 13, "en-US", ExpectedResult = 7)]
        [TestCase("encyclopaedia", "pæd", 12, 13, "se-SE", ExpectedResult = -1)]
        [TestCase("ENCYCLOPAEDIA", "PÆD", 12, 13, "se-SE", ExpectedResult = -1)]
        [TestCase("encyclopaedia", "PÆD", 12, 13, "se-SE", ExpectedResult = -1)]
        [TestCase("ENCYCLOPAEDIA", "pæd", 12, 13, "se-SE", ExpectedResult = -1)]
        public int GetIndexOfStringWithStringComparison_StartIndexCount(string str, string value, int startIndex, int count, string culture)
        {
            // Arrange
            CultureInfo currentCulture = CultureInfo.CurrentCulture;
            CultureInfo.CurrentCulture = new CultureInfo(culture);

            try
            {
                // Act
                return LastIndexOf.GetLastIndexOfStringWithStringComparison(str, value, startIndex, count);
            }
            finally
            {
                // Tear down
                CultureInfo.CurrentCulture = currentCulture;
            }
        }
    }
}
