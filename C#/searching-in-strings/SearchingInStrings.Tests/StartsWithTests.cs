using System.Globalization;
using NUnit.Framework;

// ReSharper disable StringLiteralTypo
namespace SearchingInStrings.Tests
{
    [TestFixture]
    public sealed class StartsWithTests
    {
        [TestCase("aesthetic", 'a', "en-US", ExpectedResult = true)]
        [TestCase("aesthetic", 'f', "en-US", ExpectedResult = false)]
        [TestCase("aesthetic", 'A', "en-US", ExpectedResult = false)]
        [TestCase("AESTHETIC", 'a', "en-US", ExpectedResult = false)]
        [TestCase("aesthetic", 'æ', "en-US", ExpectedResult = false)]
        [TestCase("AESTHETIC", 'Æ', "en-US", ExpectedResult = false)]
        [TestCase("aesthetic", 'Æ', "en-US", ExpectedResult = false)]
        [TestCase("AESTHETIC", 'æ', "en-US", ExpectedResult = false)]
        [TestCase("aesthetic", 'æ', "se-SE", ExpectedResult = false)]
        [TestCase("AESTHETIC", 'Æ', "se-SE", ExpectedResult = false)]
        [TestCase("aesthetic", 'Æ', "se-SE", ExpectedResult = false)]
        [TestCase("AESTHETIC", 'æ', "se-SE", ExpectedResult = false)]
        public bool IsStartsWithChar(string str, char value, string culture)
        {
            // Arrange
            CultureInfo currentCulture = CultureInfo.CurrentCulture;
            CultureInfo.CurrentCulture = new CultureInfo(culture);

            try
            {
                // Act
                return StartsWith.IsStartsWith(str, value);
            }
            finally
            {
                // Tear down
                CultureInfo.CurrentCulture = currentCulture;
            }
        }

        [TestCase(null, 'a')]
        public void IsStartsWithChar_StringIsNull_ThrowsArgumentNullException(string str, char value)
        {
            // Act
            Assert.Throws<ArgumentNullException>(() => StartsWith.IsStartsWith(str, value));
        }

        [TestCase("aesthetic", "aes", "en-US", ExpectedResult = true)]
        [TestCase("aesthetic", "tic", "en-US", ExpectedResult = false)]
        [TestCase("aesthetic", "AES", "en-US", ExpectedResult = false)]
        [TestCase("AESTHETIC", "aes", "en-US", ExpectedResult = false)]
        [TestCase("aesthetic", "æs", "en-US", ExpectedResult = true)]
        [TestCase("AESTHETIC", "ÆS", "en-US", ExpectedResult = true)]
        [TestCase("aesthetic", "ÆS", "en-US", ExpectedResult = false)]
        [TestCase("AESTHETIC", "æs", "en-US", ExpectedResult = false)]
        [TestCase("aesthetic", "æs", "se-SE", ExpectedResult = false)]
        [TestCase("AESTHETIC", "ÆS", "se-SE", ExpectedResult = false)]
        [TestCase("aesthetic", "ÆS", "se-SE", ExpectedResult = false)]
        [TestCase("AESTHETIC", "æs", "se-SE", ExpectedResult = false)]
        public bool IsStartsWithString(string str, string value, string culture)
        {
            // Arrange
            CultureInfo currentCulture = CultureInfo.CurrentCulture;
            CultureInfo.CurrentCulture = new CultureInfo(culture);

            try
            {
                // Act
                return StartsWith.IsStartsWith(str, value);
            }
            finally
            {
                // Tear down
                CultureInfo.CurrentCulture = currentCulture;
            }
        }

        [TestCase(null, "aes")]
        public void IsStartsWithString_StringIsNull_ThrowsArgumentNullException(string str, string value)
        {
            // Act
            Assert.Throws<ArgumentNullException>(() => StartsWith.IsStartsWith(str, value));
        }

        [TestCase("aesthetic", "aes", "en-US", ExpectedResult = true)]
        [TestCase("aesthetic", "tic", "en-US", ExpectedResult = false)]
        [TestCase("aesthetic", "AES", "en-US", ExpectedResult = false)]
        [TestCase("AESTHETIC", "aes", "en-US", ExpectedResult = false)]
        [TestCase("aesthetic", "æs", "en-US", ExpectedResult = true)]
        [TestCase("AESTHETIC", "ÆS", "en-US", ExpectedResult = true)]
        [TestCase("aesthetic", "ÆS", "en-US", ExpectedResult = false)]
        [TestCase("AESTHETIC", "æs", "en-US", ExpectedResult = false)]
        [TestCase("aesthetic", "æs", "se-SE", ExpectedResult = true)]
        [TestCase("AESTHETIC", "ÆS", "se-SE", ExpectedResult = true)]
        [TestCase("aesthetic", "ÆS", "se-SE", ExpectedResult = false)]
        [TestCase("AESTHETIC", "æs", "se-SE", ExpectedResult = false)]
        public bool IsStartsWithStringComparison(string str, string value, string culture)
        {
            // Arrange
            CultureInfo currentCulture = CultureInfo.CurrentCulture;
            CultureInfo.CurrentCulture = new CultureInfo(culture);

            try
            {
                // Act
                return StartsWith.IsStartsWithStringComparison(str, value);
            }
            finally
            {
                // Tear down
                CultureInfo.CurrentCulture = currentCulture;
            }
        }

        [TestCase(null, "aes")]
        public void IsStartsWithStringComparison_StringIsNull_ThrowsArgumentNullException(string str, string value)
        {
            // Act
            Assert.Throws<ArgumentNullException>(() => StartsWith.IsStartsWithStringComparison(str, value));
        }
    }
}
