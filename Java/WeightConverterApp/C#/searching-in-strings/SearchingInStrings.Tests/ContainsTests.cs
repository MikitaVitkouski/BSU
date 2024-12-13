using System.Globalization;
using NUnit.Framework;

// ReSharper disable StringLiteralTypo
namespace SearchingInStrings.Tests
{
    [TestFixture]
    public sealed class ContainsTests
    {
        [TestCase("encyclopaedia", 'c', "en-US", ExpectedResult = true)]
        [TestCase("encyclopaedia", 'f', "en-US", ExpectedResult = false)]
        [TestCase("encyclopaedia", 'C', "en-US", ExpectedResult = false)]
        [TestCase("ENCYCLOPAEDIA", 'c', "en-US", ExpectedResult = false)]
        [TestCase("encyclopaedia", 'æ', "en-US", ExpectedResult = false)]
        [TestCase("ENCYCLOPAEDIA", 'Æ', "en-US", ExpectedResult = false)]
        [TestCase("encyclopaedia", 'Æ', "en-US", ExpectedResult = false)]
        [TestCase("ENCYCLOPAEDIA", 'æ', "en-US", ExpectedResult = false)]
        [TestCase("encyclopaedia", 'æ', "se-SE", ExpectedResult = false)]
        [TestCase("ENCYCLOPAEDIA", 'Æ', "se-SE", ExpectedResult = false)]
        [TestCase("encyclopaedia", 'Æ', "se-SE", ExpectedResult = false)]
        [TestCase("ENCYCLOPAEDIA", 'æ', "se-SE", ExpectedResult = false)]
        public bool IsContainsChar(string str, char value, string culture)
        {
            // Arrange
            CultureInfo currentCulture = CultureInfo.CurrentCulture;
            CultureInfo.CurrentCulture = new CultureInfo(culture);

            try
            {
                // Act
                return Contains.IsContainsChar(str, value);
            }
            finally
            {
                // Tear down
                CultureInfo.CurrentCulture = currentCulture;
            }
        }

        [TestCase(null, "c")]
        public void IsContainsChar_StringIsNull_ThrowsArgumentNullException(string str, char value)
        {
            // Act
            Assert.Throws<ArgumentNullException>(() => Contains.IsContainsChar(str, value));
        }

        [TestCase("encyclopaedia", 'c', "en-US", ExpectedResult = true)]
        [TestCase("encyclopaedia", 'f', "en-US", ExpectedResult = false)]
        [TestCase("encyclopaedia", 'C', "en-US", ExpectedResult = false)]
        [TestCase("ENCYCLOPAEDIA", 'c', "en-US", ExpectedResult = false)]
        [TestCase("encyclopaedia", 'æ', "en-US", ExpectedResult = true)]
        [TestCase("ENCYCLOPAEDIA", 'Æ', "en-US", ExpectedResult = true)]
        [TestCase("encyclopaedia", 'Æ', "en-US", ExpectedResult = false)]
        [TestCase("ENCYCLOPAEDIA", 'æ', "en-US", ExpectedResult = false)]
        [TestCase("encyclopaedia", 'æ', "se-SE", ExpectedResult = true)]
        [TestCase("ENCYCLOPAEDIA", 'Æ', "se-SE", ExpectedResult = true)]
        [TestCase("encyclopaedia", 'Æ', "se-SE", ExpectedResult = false)]
        [TestCase("ENCYCLOPAEDIA", 'æ', "se-SE", ExpectedResult = false)]
        public bool IsContainsCharStringComparison(string str, char value, string culture)
        {
            // Arrange
            CultureInfo currentCulture = CultureInfo.CurrentCulture;
            CultureInfo.CurrentCulture = new CultureInfo(culture);

            try
            {
                // Act
                return Contains.IsContainsCharWithStringComparison(str, value);
            }
            finally
            {
                // Tear down
                CultureInfo.CurrentCulture = currentCulture;
            }
        }

        [TestCase(null, "c")]
        public void IsContainsCharComparison_StringIsNull_ThrowsArgumentNullException(string str, char value)
        {
            // Act
            Assert.Throws<ArgumentNullException>(() => Contains.IsContainsCharWithStringComparison(str, value));
        }

        [TestCase("encyclopaedia", "enc", "en-US", ExpectedResult = true)]
        [TestCase("encyclopaedia", "dia", "en-US", ExpectedResult = true)]
        [TestCase("encyclopaedia", "fen", "en-US", ExpectedResult = false)]
        [TestCase("encyclopaedia", "ENC", "en-US", ExpectedResult = false)]
        [TestCase("ENCYCLOPAEDIA", "enc", "en-US", ExpectedResult = false)]
        [TestCase("encyclopaedia", "pæd", "en-US", ExpectedResult = false)]
        [TestCase("ENCYCLOPAEDIA", "PÆD", "en-US", ExpectedResult = false)]
        [TestCase("encyclopaedia", "PÆD", "en-US", ExpectedResult = false)]
        [TestCase("ENCYCLOPAEDIA", "pæd", "en-US", ExpectedResult = false)]
        [TestCase("encyclopaedia", "pæd", "se-SE", ExpectedResult = false)]
        [TestCase("ENCYCLOPAEDIA", "PÆD", "se-SE", ExpectedResult = false)]
        [TestCase("encyclopaedia", "PÆD", "se-SE", ExpectedResult = false)]
        [TestCase("ENCYCLOPAEDIA", "pæd", "se-SE", ExpectedResult = false)]
        public bool IsContainsString(string str, string value, string culture)
        {
            // Arrange
            CultureInfo currentCulture = CultureInfo.CurrentCulture;
            CultureInfo.CurrentCulture = new CultureInfo(culture);

            try
            {
                // Act
                return Contains.IsContainsString(str, value);
            }
            finally
            {
                // Tear down
                CultureInfo.CurrentCulture = currentCulture;
            }
        }

        [TestCase(null, "enc")]
        public void IsContainsString_StringIsNull_ThrowsArgumentNullException(string str, string value)
        {
            // Act
            Assert.Throws<ArgumentNullException>(() => Contains.IsContainsString(str, value));
        }

        [TestCase("encyclopaedia", "enc", "en-US", ExpectedResult = true)]
        [TestCase("encyclopaedia", "dia", "en-US", ExpectedResult = true)]
        [TestCase("encyclopaedia", "fen", "en-US", ExpectedResult = false)]
        [TestCase("encyclopaedia", "ENC", "en-US", ExpectedResult = false)]
        [TestCase("ENCYCLOPAEDIA", "enc", "en-US", ExpectedResult = false)]
        [TestCase("encyclopaedia", "pæd", "en-US", ExpectedResult = true)]
        [TestCase("ENCYCLOPAEDIA", "PÆD", "en-US", ExpectedResult = true)]
        [TestCase("encyclopaedia", "PÆD", "en-US", ExpectedResult = false)]
        [TestCase("ENCYCLOPAEDIA", "pæd", "en-US", ExpectedResult = false)]
        [TestCase("encyclopaedia", "pæd", "se-SE", ExpectedResult = true)]
        [TestCase("ENCYCLOPAEDIA", "PÆD", "se-SE", ExpectedResult = true)]
        [TestCase("encyclopaedia", "PÆD", "se-SE", ExpectedResult = false)]
        [TestCase("ENCYCLOPAEDIA", "pæd", "se-SE", ExpectedResult = false)]
        public bool IsContainsStringWithStringComparison(string str, string value, string culture)
        {
            // Arrange
            CultureInfo currentCulture = CultureInfo.CurrentCulture;
            CultureInfo.CurrentCulture = new CultureInfo(culture);

            try
            {
                // Act
                return Contains.IsContainsStringWithStringComparison(str, value);
            }
            finally
            {
                // Tear down
                CultureInfo.CurrentCulture = currentCulture;
            }
        }

        [TestCase(null, "enc")]
        public void IsContainsStringWithStringComparison_StringIsNull_ThrowsArgumentNullException(string str, string value)
        {
            // Act
            Assert.Throws<ArgumentNullException>(() => Contains.IsContainsStringWithStringComparison(str, value));
        }
    }
}
