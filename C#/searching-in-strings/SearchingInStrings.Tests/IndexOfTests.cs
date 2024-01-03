using System.Globalization;
using NUnit.Framework;

// ReSharper disable StringLiteralTypo
namespace SearchingInStrings.Tests
{
    [TestFixture]
    public sealed class IndexOfTests
    {
        [TestCase("encyclopaedia", 'c', "en-US", ExpectedResult = 2)]
        [TestCase("encyclopaedia", 'a', "en-US", ExpectedResult = 8)]
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
                return IndexOf.GetIndexOfChar(str, value);
            }
            finally
            {
                // Tear down
                CultureInfo.CurrentCulture = currentCulture;
            }
        }

        [TestCase("encyclopaedia", 'c', "en-US", ExpectedResult = 2)]
        [TestCase("encyclopaedia", 'a', "en-US", ExpectedResult = 8)]
        [TestCase("encyclopaedia", 'f', "en-US", ExpectedResult = -1)]
        [TestCase("encyclopaedia", 'C', "en-US", ExpectedResult = 2)]
        [TestCase("ENCYCLOPAEDIA", 'c', "en-US", ExpectedResult = 2)]
        [TestCase("encyclopaedia", 'æ', "en-US", ExpectedResult = 8)]
        [TestCase("ENCYCLOPAEDIA", 'Æ', "en-US", ExpectedResult = 8)]
        [TestCase("encyclopaedia", 'Æ', "en-US", ExpectedResult = 8)]
        [TestCase("ENCYCLOPAEDIA", 'æ', "en-US", ExpectedResult = 8)]
        [TestCase("encyclopaedia", 'æ', "se-SE", ExpectedResult = 8)]
        [TestCase("ENCYCLOPAEDIA", 'Æ', "se-SE", ExpectedResult = 8)]
        [TestCase("encyclopaedia", 'Æ', "se-SE", ExpectedResult = 8)]
        [TestCase("ENCYCLOPAEDIA", 'æ', "se-SE", ExpectedResult = 8)]
        public int GetIndexOfCharInvariantCultureIgnoreCase(string str, char value, string culture)
        {
            // Arrange
            CultureInfo currentCulture = CultureInfo.CurrentCulture;
            CultureInfo.CurrentCulture = new CultureInfo(culture);

            try
            {
                // Act
                return IndexOf.GetIndexOfCharInvariantCultureIgnoreCase(str, value);
            }
            finally
            {
                // Tear down
                CultureInfo.CurrentCulture = currentCulture;
            }
        }

        [TestCase("encyclopaedia", 'c', "en-US", ExpectedResult = 2)]
        [TestCase("encyclopaedia", 'a', "en-US", ExpectedResult = 8)]
        [TestCase("encyclopaedia", 'f', "en-US", ExpectedResult = -1)]
        [TestCase("encyclopaedia", 'C', "en-US", ExpectedResult = 2)]
        [TestCase("ENCYCLOPAEDIA", 'c', "en-US", ExpectedResult = 2)]
        [TestCase("encyclopaedia", 'æ', "en-US", ExpectedResult = -1)]
        [TestCase("ENCYCLOPAEDIA", 'Æ', "en-US", ExpectedResult = -1)]
        [TestCase("encyclopaedia", 'Æ', "en-US", ExpectedResult = -1)]
        [TestCase("ENCYCLOPAEDIA", 'æ', "en-US", ExpectedResult = -1)]
        [TestCase("encyclopaedia", 'æ', "se-SE", ExpectedResult = -1)]
        [TestCase("ENCYCLOPAEDIA", 'Æ', "se-SE", ExpectedResult = -1)]
        [TestCase("encyclopaedia", 'Æ', "se-SE", ExpectedResult = -1)]
        [TestCase("ENCYCLOPAEDIA", 'æ', "se-SE", ExpectedResult = -1)]
        public int GetIndexOfCharWithStringComparison(string str, char value, string culture)
        {
            // Arrange
            CultureInfo currentCulture = CultureInfo.CurrentCulture;
            CultureInfo.CurrentCulture = new CultureInfo(culture);

            try
            {
                // Act
                return IndexOf.GetIndexOfCharWithStringComparison(str, value);
            }
            finally
            {
                // Tear down
                CultureInfo.CurrentCulture = currentCulture;
            }
        }

        [TestCase("encyclopaedia", 'c', 0, "en-US", ExpectedResult = 2)]
        [TestCase("encyclopaedia", 'c', 2, "en-US", ExpectedResult = 2)]
        [TestCase("encyclopaedia", 'c', 3, "en-US", ExpectedResult = 4)]
        [TestCase("encyclopaedia", 'c', 5, "en-US", ExpectedResult = -1)]
        [TestCase("encyclopaedia", 'a', 0, "en-US", ExpectedResult = 8)]
        [TestCase("encyclopaedia", 'a', 8, "en-US", ExpectedResult = 8)]
        [TestCase("encyclopaedia", 'a', 9, "en-US", ExpectedResult = 12)]
        [TestCase("encyclopaedia", 'f', 0, "en-US", ExpectedResult = -1)]
        [TestCase("encyclopaedia", 'C', 0, "en-US", ExpectedResult = -1)]
        [TestCase("ENCYCLOPAEDIA", 'c', 0, "en-US", ExpectedResult = -1)]
        [TestCase("encyclopaedia", 'æ', 0, "en-US", ExpectedResult = -1)]
        [TestCase("ENCYCLOPAEDIA", 'Æ', 0, "en-US", ExpectedResult = -1)]
        [TestCase("encyclopaedia", 'Æ', 0, "en-US", ExpectedResult = -1)]
        [TestCase("ENCYCLOPAEDIA", 'æ', 0, "en-US", ExpectedResult = -1)]
        [TestCase("encyclopaedia", 'æ', 0, "se-SE", ExpectedResult = -1)]
        [TestCase("ENCYCLOPAEDIA", 'Æ', 0, "se-SE", ExpectedResult = -1)]
        [TestCase("encyclopaedia", 'Æ', 0, "se-SE", ExpectedResult = -1)]
        [TestCase("ENCYCLOPAEDIA", 'æ', 0, "se-SE", ExpectedResult = -1)]
        public int GetIndexOfChar_StartIndex(string str, char value, int startIndex, string culture)
        {
            // Arrange
            CultureInfo currentCulture = CultureInfo.CurrentCulture;
            CultureInfo.CurrentCulture = new CultureInfo(culture);

            try
            {
                // Act
                return IndexOf.GetIndexOfChar(str, value, startIndex);
            }
            finally
            {
                // Tear down
                CultureInfo.CurrentCulture = currentCulture;
            }
        }

        [TestCase("encyclopaedia", 'c', 0, 13, "en-US", ExpectedResult = 2)]
        [TestCase("encyclopaedia", 'c', 3, 10, "en-US", ExpectedResult = 4)]
        [TestCase("encyclopaedia", 'c', 5, 8, "en-US", ExpectedResult = -1)]
        [TestCase("encyclopaedia", 'a', 0, 7, "en-US", ExpectedResult = -1)]
        [TestCase("encyclopaedia", 'a', 9, 4, "en-US", ExpectedResult = 12)]
        [TestCase("encyclopaedia", 'f', 0, 13, "en-US", ExpectedResult = -1)]
        [TestCase("encyclopaedia", 'C', 0, 13, "en-US", ExpectedResult = -1)]
        [TestCase("ENCYCLOPAEDIA", 'c', 0, 13, "en-US", ExpectedResult = -1)]
        [TestCase("encyclopaedia", 'æ', 0, 13, "en-US", ExpectedResult = -1)]
        [TestCase("ENCYCLOPAEDIA", 'Æ', 0, 13, "en-US", ExpectedResult = -1)]
        [TestCase("encyclopaedia", 'Æ', 0, 13, "en-US", ExpectedResult = -1)]
        [TestCase("ENCYCLOPAEDIA", 'æ', 0, 13, "en-US", ExpectedResult = -1)]
        [TestCase("encyclopaedia", 'æ', 0, 13, "se-SE", ExpectedResult = -1)]
        [TestCase("ENCYCLOPAEDIA", 'Æ', 0, 13, "se-SE", ExpectedResult = -1)]
        [TestCase("encyclopaedia", 'Æ', 0, 13, "se-SE", ExpectedResult = -1)]
        [TestCase("ENCYCLOPAEDIA", 'æ', 0, 13, "se-SE", ExpectedResult = -1)]
        public int GetIndexOfChar_StartIndexCount(string str, char value, int startIndex, int count, string culture)
        {
            // Arrange
            CultureInfo currentCulture = CultureInfo.CurrentCulture;
            CultureInfo.CurrentCulture = new CultureInfo(culture);

            try
            {
                // Act
                return IndexOf.GetIndexOfChar(str, value, startIndex, count);
            }
            finally
            {
                // Tear down
                CultureInfo.CurrentCulture = currentCulture;
            }
        }

        [TestCase("encyclopaedia", 'f', 8, 6)]
        public void GetIndexOfChar_CountIsInvalid_ThrowsArgumentOutOfRangeException(string str, char value, int startIndex, int count)
        {
            // Act
            Assert.Throws<ArgumentOutOfRangeException>(() => IndexOf.GetIndexOfChar(str, value, startIndex, count));
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
                return IndexOf.GetIndexOfString(str, value);
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
                return IndexOf.GetIndexOfStringOrdinal(str, value);
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
                return IndexOf.GetIndexOfStringWithStringComparison(str, value);
            }
            finally
            {
                // Tear down
                CultureInfo.CurrentCulture = currentCulture;
            }
        }

        [TestCase("encyclopaedia", "enc", 0, "en-US", ExpectedResult = 0)]
        [TestCase("ENCYCLOPAEDIA", "DIA", 0, "en-US", ExpectedResult = 10)]
        [TestCase("encyclopaedia", "ENC", 0, "en-US", ExpectedResult = -1)]
        [TestCase("ENCYCLOPAEDIA", "dia", 0, "en-US", ExpectedResult = -1)]
        [TestCase("encyclopaedia", "pæd", 0, "en-US", ExpectedResult = 7)]
        [TestCase("ENCYCLOPAEDIA", "PÆD", 0, "en-US", ExpectedResult = 7)]
        [TestCase("encyclopaedia", "PÆD", 0, "en-US", ExpectedResult = -1)]
        [TestCase("ENCYCLOPAEDIA", "pæd", 0, "en-US", ExpectedResult = -1)]
        [TestCase("encyclopaedia", "PÆD", 0, "se-SE", ExpectedResult = -1)]
        [TestCase("ENCYCLOPAEDIA", "pæd", 0, "se-SE", ExpectedResult = -1)]
        [TestCase("encyclopaedia", "pæd", 0, "se-SE", ExpectedResult = -1)]
        [TestCase("ENCYCLOPAEDIA", "PÆD", 0, "se-SE", ExpectedResult = -1)]
        public int GetIndexOfString_StartIndex(string str, string value, int startIndex, string culture)
        {
            // Arrange
            CultureInfo currentCulture = CultureInfo.CurrentCulture;
            CultureInfo.CurrentCulture = new CultureInfo(culture);

            try
            {
                // Act
                return IndexOf.GetIndexOfString(str, value, startIndex);
            }
            finally
            {
                // Tear down
                CultureInfo.CurrentCulture = currentCulture;
            }
        }

        [TestCase("encyclopaedia", "enc", 0, "en-US", ExpectedResult = 0)]
        [TestCase("ENCYCLOPAEDIA", "DIA", 0, "en-US", ExpectedResult = 10)]
        [TestCase("encyclopaedia", "ENC", 0, "en-US", ExpectedResult = 0)]
        [TestCase("ENCYCLOPAEDIA", "dia", 0, "en-US", ExpectedResult = 10)]
        [TestCase("encyclopaedia", "pæd", 0, "en-US", ExpectedResult = 7)]
        [TestCase("ENCYCLOPAEDIA", "PÆD", 0, "en-US", ExpectedResult = 7)]
        [TestCase("encyclopaedia", "PÆD", 0, "en-US", ExpectedResult = 7)]
        [TestCase("ENCYCLOPAEDIA", "pæd", 0, "en-US", ExpectedResult = 7)]
        [TestCase("encyclopaedia", "PÆD", 0, "se-SE", ExpectedResult = -1)]
        [TestCase("ENCYCLOPAEDIA", "pæd", 0, "se-SE", ExpectedResult = -1)]
        [TestCase("encyclopaedia", "pæd", 0, "se-SE", ExpectedResult = -1)]
        [TestCase("ENCYCLOPAEDIA", "PÆD", 0, "se-SE", ExpectedResult = -1)]
        public int GetIndexOfStringCurrentCultureIgnoreCase_StartIndex(string str, string value, int startIndex, string culture)
        {
            // Arrange
            CultureInfo currentCulture = CultureInfo.CurrentCulture;
            CultureInfo.CurrentCulture = new CultureInfo(culture);

            try
            {
                // Act
                return IndexOf.GetIndexOfStringCurrentCultureIgnoreCase(str, value, startIndex);
            }
            finally
            {
                // Tear down
                CultureInfo.CurrentCulture = currentCulture;
            }
        }

        [TestCase("encyclopaedia", "enc", 0, "en-US", ExpectedResult = 0)]
        [TestCase("ENCYCLOPAEDIA", "DIA", 0, "en-US", ExpectedResult = 10)]
        [TestCase("encyclopaedia", "ENC", 0, "en-US", ExpectedResult = -1)]
        [TestCase("ENCYCLOPAEDIA", "dia", 0, "en-US", ExpectedResult = -1)]
        [TestCase("encyclopaedia", "pæd", 0, "en-US", ExpectedResult = 7)]
        [TestCase("ENCYCLOPAEDIA", "PÆD", 0, "en-US", ExpectedResult = 7)]
        [TestCase("encyclopaedia", "PÆD", 0, "en-US", ExpectedResult = -1)]
        [TestCase("ENCYCLOPAEDIA", "pæd", 0, "en-US", ExpectedResult = -1)]
        [TestCase("encyclopaedia", "pæd", 0, "se-SE", ExpectedResult = -1)]
        [TestCase("ENCYCLOPAEDIA", "PÆD", 0, "se-SE", ExpectedResult = -1)]
        [TestCase("encyclopaedia", "PÆD", 0, "se-SE", ExpectedResult = -1)]
        [TestCase("ENCYCLOPAEDIA", "pæd", 0, "se-SE", ExpectedResult = -1)]
        public int GetIndexOfStringWithStringComparison_StartIndex(string str, string value, int startIndex, string culture)
        {
            // Arrange
            CultureInfo currentCulture = CultureInfo.CurrentCulture;
            CultureInfo.CurrentCulture = new CultureInfo(culture);

            try
            {
                // Act
                return IndexOf.GetIndexOfStringWithStringComparison(str, value, startIndex);
            }
            finally
            {
                // Tear down
                CultureInfo.CurrentCulture = currentCulture;
            }
        }

        [TestCase("encyclopaedia", "enc", 0, 13, "en-US", ExpectedResult = 0)]
        [TestCase("encyclopaedia", "enc", 1, 12, "en-US", ExpectedResult = -1)]
        [TestCase("ENCYCLOPAEDIA", "DIA", 0, 13, "en-US", ExpectedResult = 10)]
        [TestCase("ENCYCLOPAEDIA", "DIA", 0, 12, "en-US", ExpectedResult = -1)]
        [TestCase("encyclopaedia", "ENC", 0, 13, "en-US", ExpectedResult = -1)]
        [TestCase("ENCYCLOPAEDIA", "dia", 0, 13, "en-US", ExpectedResult = -1)]
        [TestCase("encyclopaedia", "pæd", 0, 13, "en-US", ExpectedResult = 7)]
        [TestCase("ENCYCLOPAEDIA", "PÆD", 0, 13, "en-US", ExpectedResult = 7)]
        [TestCase("encyclopaedia", "PÆD", 0, 13, "en-US", ExpectedResult = -1)]
        [TestCase("ENCYCLOPAEDIA", "pæd", 0, 13, "en-US", ExpectedResult = -1)]
        [TestCase("encyclopaedia", "pæd", 0, 13, "se-SE", ExpectedResult = -1)]
        [TestCase("ENCYCLOPAEDIA", "PÆD", 0, 13, "se-SE", ExpectedResult = -1)]
        [TestCase("encyclopaedia", "PÆD", 0, 13, "se-SE", ExpectedResult = -1)]
        [TestCase("ENCYCLOPAEDIA", "pæd", 0, 13, "se-SE", ExpectedResult = -1)]
        public int GetIndexOfString_StartIndexCount(string str, string value, int startIndex, int count, string culture)
        {
            // Arrange
            CultureInfo currentCulture = CultureInfo.CurrentCulture;
            CultureInfo.CurrentCulture = new CultureInfo(culture);

            try
            {
                // Act
                return IndexOf.GetIndexOfString(str, value, startIndex, count);
            }
            finally
            {
                // Tear down
                CultureInfo.CurrentCulture = currentCulture;
            }
        }

        [TestCase("encyclopaedia", "enc", 0, 13, "en-US", ExpectedResult = 0)]
        [TestCase("encyclopaedia", "enc", 1, 12, "en-US", ExpectedResult = -1)]
        [TestCase("ENCYCLOPAEDIA", "DIA", 0, 13, "en-US", ExpectedResult = 10)]
        [TestCase("ENCYCLOPAEDIA", "DIA", 0, 12, "en-US", ExpectedResult = -1)]
        [TestCase("encyclopaedia", "ENC", 0, 13, "en-US", ExpectedResult = -1)]
        [TestCase("ENCYCLOPAEDIA", "dia", 0, 13, "en-US", ExpectedResult = -1)]
        [TestCase("encyclopaedia", "pæd", 0, 13, "en-US", ExpectedResult = 7)]
        [TestCase("ENCYCLOPAEDIA", "PÆD", 0, 13, "en-US", ExpectedResult = 7)]
        [TestCase("encyclopaedia", "PÆD", 0, 13, "en-US", ExpectedResult = -1)]
        [TestCase("ENCYCLOPAEDIA", "pæd", 0, 13, "en-US", ExpectedResult = -1)]
        [TestCase("encyclopaedia", "pæd", 0, 13, "se-SE", ExpectedResult = 7)]
        [TestCase("ENCYCLOPAEDIA", "PÆD", 0, 13, "se-SE", ExpectedResult = 7)]
        [TestCase("encyclopaedia", "PÆD", 0, 13, "se-SE", ExpectedResult = -1)]
        [TestCase("ENCYCLOPAEDIA", "pæd", 0, 13, "se-SE", ExpectedResult = -1)]
        public int GetIndexOfStringInvariantCulture_StartIndexCount(string str, string value, int startIndex, int count, string culture)
        {
            // Arrange
            CultureInfo currentCulture = CultureInfo.CurrentCulture;
            CultureInfo.CurrentCulture = new CultureInfo(culture);

            try
            {
                // Act
                return IndexOf.GetIndexOfStringInvariantCulture(str, value, startIndex, count);
            }
            finally
            {
                // Tear down
                CultureInfo.CurrentCulture = currentCulture;
            }
        }

        [TestCase("encyclopaedia", "enc", 1, 12, "en-US", ExpectedResult = -1)]
        [TestCase("ENCYCLOPAEDIA", "DIA", 0, 12, "en-US", ExpectedResult = -1)]
        [TestCase("encyclopaedia", "ENC", 0, 13, "en-US", ExpectedResult = 0)]
        [TestCase("ENCYCLOPAEDIA", "dia", 0, 13, "en-US", ExpectedResult = 10)]
        [TestCase("encyclopaedia", "pæd", 0, 13, "en-US", ExpectedResult = 7)]
        [TestCase("ENCYCLOPAEDIA", "PÆD", 0, 13, "en-US", ExpectedResult = 7)]
        [TestCase("encyclopaedia", "PÆD", 0, 13, "en-US", ExpectedResult = 7)]
        [TestCase("ENCYCLOPAEDIA", "pæd", 0, 13, "en-US", ExpectedResult = 7)]
        [TestCase("encyclopaedia", "pæd", 0, 13, "se-SE", ExpectedResult = -1)]
        [TestCase("ENCYCLOPAEDIA", "PÆD", 0, 13, "se-SE", ExpectedResult = -1)]
        [TestCase("encyclopaedia", "PÆD", 0, 13, "se-SE", ExpectedResult = -1)]
        [TestCase("ENCYCLOPAEDIA", "pæd", 0, 13, "se-SE", ExpectedResult = -1)]
        public int GetIndexOfStringWithStringComparison_StartIndexCount(string str, string value, int startIndex, int count, string culture)
        {
            // Arrange
            CultureInfo currentCulture = CultureInfo.CurrentCulture;
            CultureInfo.CurrentCulture = new CultureInfo(culture);

            try
            {
                // Act
                return IndexOf.GetIndexOfStringWithStringComparison(str, value, startIndex, count);
            }
            finally
            {
                // Tear down
                CultureInfo.CurrentCulture = currentCulture;
            }
        }
    }
}
