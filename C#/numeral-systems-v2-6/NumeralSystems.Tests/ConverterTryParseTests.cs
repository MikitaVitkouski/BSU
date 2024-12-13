using NUnit.Framework;

namespace NumeralSystems.Tests
{
    public class ConverterTryParseTests
    {
        [TestCase("2447150", 675432)]
        [TestCase("127", 87)]
        [TestCase("3231704", 865220)]
        [TestCase("2147423647", 295577511)]
        public void TryParsePositiveFromOctal_ReturnTrue_Tests(string source, int expectedValue)
        {
            bool actual = source.TryParsePositiveFromOctal(out int value);
            Assert.Multiple(() =>
            {
                Assert.IsTrue(actual);
                Assert.AreEqual(expectedValue, value);
            });
        }

        [TestCase("37777777601")]
        [TestCase("37775330632")]
        [TestCase("37665330632")]
        [TestCase("3787779")]
        [TestCase("78439$")]
        public void TryParsePositiveFromOctal_ReturnFalse_Tests(string source)
        {
            bool actual = source.TryParsePositiveFromOctal(out int _);
            Assert.IsFalse(actual);
        }

        [TestCase("2047", 2047)]
        [TestCase("172911358", 172911358)]
        [TestCase("32317049", 32317049)]
        [TestCase("2147483647", 2147483647)]
        public void TryParsePositiveFromDecimal_ReturnTrue_Tests(string source, int expectedValue)
        {
            bool actual = source.TryParsePositiveFromDecimal(out int value);
            Assert.Multiple(() =>
            {
                Assert.IsTrue(actual);
                Assert.AreEqual(expectedValue, value);
            });
        }

        [TestCase("-675432")]
        [TestCase("-11497064")]
        [TestCase("A675")]
        [TestCase("1FE1497#6")]
        public void TryParsePositiveFromDecimal_ReturnFalse_Tests(string source)
        {
            bool actual = source.TryParsePositiveFromDecimal(out int _);
            Assert.IsFalse(actual);
        }

        [TestCase("7FF", 2047)]
        [TestCase("A4E6AFE", 172911358)]
        [TestCase("a4e6afe", 172911358)]
        [TestCase("1ED1E79", 32317049)]
        [TestCase("7FFFFFFF", 2147483647)]
        [TestCase("7fffffff", 2147483647)]
        public void TryParsePositiveFromHex_ReturnTrue_Tests(string source, int expectedValue)
        {
            bool actual = source.TryParsePositiveFromHex(out int value);
            Assert.Multiple(() =>
            {
                Assert.IsTrue(actual);
                Assert.AreEqual(expectedValue, value);
            });
        }

        [TestCase("FFF5B198")]
        [TestCase("FFF509198")]
        [TestCase("FSW5B19-")]
        [TestCase("OP5Q08")]
        public void TryParsePositiveFromHex_ReturnFalse_Tests(string source)
        {
            bool actual = source.TryParsePositiveFromHex(out int _);
            Assert.IsFalse(actual);
        }

        [TestCase("13421", 8, 5905)]
        [TestCase("100001", 8, 32769)]
        [TestCase("32317049", 10, 32317049)]
        [TestCase("2147483647", 10, 2147483647)]
        [TestCase("A4E6AFE", 16, 172911358)]
        [TestCase("A09912", 16, 10524946)]
        public void TryParsePositiveByRadix_ReturnTrue_Tests(string source, int radix, int expectedValue)
        {
            bool actual = source.TryParsePositiveByRadix(radix, out int value);
            Assert.Multiple(() =>
            {
                Assert.IsTrue(actual);
                Assert.AreEqual(expectedValue, value);
            });
        }

        [TestCase("37789601", 8)]
        [TestCase("-5754AB2", 10)]
        [TestCase("FSW5B19-", 16)]
        public void TryParsePositiveByRadix_ReturnFalse_Tests(string source, int radix)
        {
            bool actual = source.TryParsePositiveByRadix(radix, out int _);
            Assert.IsFalse(actual);
        }

        [TestCase(5)]
        [TestCase(0)]
        [TestCase(-6)]
        public void TryParsePositiveByRadix_RadixIsNot2or8or10or16_ThrowArgumentException(int radix) =>
            Assert.Throws<ArgumentException>(
                () => "1".TryParsePositiveByRadix(radix, out int _),
                $"{nameof(radix)} is 8, 10 and 16 only.");

        [TestCase("100001", 8, 32769)]
        [TestCase("37777777601", 8, -127)]
        [TestCase("37775330632", 8, -675430)]
        [TestCase("37665330632", 8, -19549798)]
        [TestCase("-675432", 10, -675432)]
        [TestCase("-11497064", 10, -11497064)]
        [TestCase("A4E6AFE", 16, 172911358)]
        [TestCase("A09912", 16, 10524946)]
        [TestCase("FFF5B198", 16, -675432)]
        public void TryParseByRadix_Tests(string source, int radix, int expectedValue)
        {
            bool actual = source.TryParseByRadix(radix, out int value);
            Assert.Multiple(() =>
            {
                Assert.IsTrue(actual);
                Assert.AreEqual(expectedValue, value);
            });
        }

        [TestCase("37789601", 8)]
        [TestCase("-5754AB2", 10)]
        [TestCase("FSW5B19-", 16)]
        public void TryParseByRadix_ReturnFalse_Tests(string source, int radix)
        {
            bool actual = source.TryParseByRadix(radix, out int _);
            Assert.IsFalse(actual);
        }
    }
}
