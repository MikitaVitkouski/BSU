using System.Globalization;
using NUnit.Framework;

// ReSharper disable StringLiteralTypo
namespace SearchingInStrings.Tests
{
    [TestFixture]
    public sealed class EndsWithTests
    {
        [TestCase("sundae", 'e', "en-US", ExpectedResult = true)]
        [TestCase("sundae", 'f', "en-US", ExpectedResult = false)]
        [TestCase("sundae", 'E', "en-US", ExpectedResult = false)]
        [TestCase("SUNDAE", 'e', "en-US", ExpectedResult = false)]
        [TestCase("sundae", 'æ', "en-US", ExpectedResult = false)]
        [TestCase("SUNDAE", 'Æ', "en-US", ExpectedResult = false)]
        [TestCase("sundae", 'Æ', "en-US", ExpectedResult = false)]
        [TestCase("SUNDAE", 'æ', "en-US", ExpectedResult = false)]
        [TestCase("sundae", 'æ', "se-SE", ExpectedResult = false)]
        [TestCase("SUNDAE", 'Æ', "se-SE", ExpectedResult = false)]
        [TestCase("sundae", 'Æ', "se-SE", ExpectedResult = false)]
        [TestCase("SUNDAE", 'æ', "se-SE", ExpectedResult = false)]
        public bool IsEndsWithChar(string str, char value, string culture)
        {
            // Arrange
            CultureInfo currentCulture = CultureInfo.CurrentCulture;
            CultureInfo.CurrentCulture = new CultureInfo(culture);

            try
            {
                // Act
                return EndsWith.IsEndsWith(str, value);
            }
            finally
            {
                // Tear down
                CultureInfo.CurrentCulture = currentCulture;
            }
        }

        [TestCase(null, 'a')]
        public void IsEndsWithChar_StringIsNull_ThrowsArgumentNullException(string str, char value)
        {
            // Act
            Assert.Throws<ArgumentNullException>(() => EndsWith.IsEndsWith(str, value));
        }

        [TestCase("sundae", "dae", "en-US", ExpectedResult = true)]
        [TestCase("sundae", "sun", "en-US", ExpectedResult = false)]
        [TestCase("sundae", "DAE", "en-US", ExpectedResult = false)]
        [TestCase("SUNDAE", "dae", "en-US", ExpectedResult = false)]
        [TestCase("sundae", "dæ", "en-US", ExpectedResult = true)]
        [TestCase("SUNDAE", "DÆ", "en-US", ExpectedResult = true)]
        [TestCase("sundae", "DÆ", "en-US", ExpectedResult = false)]
        [TestCase("SUNDAE", "dæ", "en-US", ExpectedResult = false)]
        [TestCase("sundae", "dæ", "se-SE", ExpectedResult = false)]
        [TestCase("SUNDAE", "DÆ", "se-SE", ExpectedResult = false)]
        [TestCase("sundae", "DÆ", "se-SE", ExpectedResult = false)]
        [TestCase("SUNDAE", "dæ", "se-SE", ExpectedResult = false)]
        public bool IsEndsWithSrting(string str, string value, string culture)
        {
            // Arrange
            CultureInfo currentCulture = CultureInfo.CurrentCulture;
            CultureInfo.CurrentCulture = new CultureInfo(culture);

            try
            {
                // Act
                return EndsWith.IsEndsWith(str, value);
            }
            finally
            {
                // Tear down
                CultureInfo.CurrentCulture = currentCulture;
            }
        }

        [TestCase(null, "dae")]
        public void IsEndsWithString_StringIsNull_ThrowsArgumentNullException(string str, string value)
        {
            // Act
            Assert.Throws<ArgumentNullException>(() => EndsWith.IsEndsWith(str, value));
        }

        [TestCase("sundae", "dae", "en-US", ExpectedResult = true)]
        [TestCase("sundae", "sun", "en-US", ExpectedResult = false)]
        [TestCase("sundae", "DAE", "en-US", ExpectedResult = false)]
        [TestCase("SUNDAE", "dae", "en-US", ExpectedResult = false)]
        [TestCase("sundae", "dæ", "en-US", ExpectedResult = true)]
        [TestCase("SUNDAE", "DÆ", "en-US", ExpectedResult = true)]
        [TestCase("sundae", "DÆ", "en-US", ExpectedResult = false)]
        [TestCase("SUNDAE", "dæ", "en-US", ExpectedResult = false)]
        [TestCase("sundae", "dæ", "se-SE", ExpectedResult = true)]
        [TestCase("SUNDAE", "DÆ", "se-SE", ExpectedResult = true)]
        [TestCase("sundae", "DÆ", "se-SE", ExpectedResult = false)]
        [TestCase("SUNDAE", "dæ", "se-SE", ExpectedResult = false)]
        public bool IsEndsWithStringComparison(string str, string value, string culture)
        {
            // Arrange
            CultureInfo currentCulture = CultureInfo.CurrentCulture;
            CultureInfo.CurrentCulture = new CultureInfo(culture);

            try
            {
                // Act
                return EndsWith.IsEndsWithStringComparison(str, value);
            }
            finally
            {
                // Tear down
                CultureInfo.CurrentCulture = currentCulture;
            }
        }

        [TestCase(null, "dae")]
        public void IsEndsWithStringComparison_StringIsNull_ThrowsArgumentNullException(string str, string value)
        {
            // Act
            Assert.Throws<ArgumentNullException>(() => EndsWith.IsEndsWithStringComparison(str, value));
        }
    }
}
