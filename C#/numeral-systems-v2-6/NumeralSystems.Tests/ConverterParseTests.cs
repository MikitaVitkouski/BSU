using NUnit.Framework;

namespace NumeralSystems.Tests
{
    public class ConverterParseTests
    {
        [TestCase("2447150", ExpectedResult = 675432)]
        [TestCase("127", ExpectedResult = 87)]
        [TestCase("3231704", ExpectedResult = 865220)]
        [TestCase("2147423647", ExpectedResult = 295577511)]
        public int ParsePositiveFromOctal_Tests(string source) => source.ParsePositiveFromOctal();

        [TestCase("37777777601")]
        [TestCase("37775330632")]
        [TestCase("37665330632")]
        public void ParsePositiveFromOctal_InvalidSourceString_ThrowArgumentException(string source) =>
            Assert.Throws<ArgumentException>(() => source.ParsePositiveFromOctal(), $"{nameof(source)} does not represent a positive number in the octal numeral system.");

        [TestCase("3787779")]
        [TestCase("78439$")]
        public void ParsePositiveFromOctal_InvalidSymbolsInSourceString_ThrowArgumentException(string source) =>
            Assert.Throws<ArgumentException>(() => source.ParsePositiveFromOctal(), $"{nameof(source)} does not represent a number in octal numeral system.");

        [TestCase("2047", ExpectedResult = 2047)]
        [TestCase("172911358", ExpectedResult = 172911358)]
        [TestCase("32317049", ExpectedResult = 32317049)]
        [TestCase("2147483647", ExpectedResult = 2147483647)]
        public int ParsePositiveFromDecimal_Tests(string source) => source.ParsePositiveFromDecimal();

        [TestCase("-675432")]
        [TestCase("-11497064")]
        public void ParsePositiveFromDecimal_InvalidSourceString_ThrowArgumentException(string source) =>
            Assert.Throws<ArgumentException>(() => source.ParsePositiveFromDecimal(), $"{nameof(source)} does not represent a positive number in decimal numeral system.");

        [TestCase("A675")]
        [TestCase("1FE1497#6")]
        public void ParsePositiveFromDecimal_InvalidSymbolsInSourceString_ThrowArgumentException(string source) =>
            Assert.Throws<ArgumentException>(() => source.ParsePositiveFromDecimal(), $"{nameof(source)} does not represent a number in decimal numeral system.");

        [TestCase("7FF", ExpectedResult = 2047)]
        [TestCase("A4E6AFE", ExpectedResult = 172911358)]
        [TestCase("a4e6afe", ExpectedResult = 172911358)]
        [TestCase("1ED1E79", ExpectedResult = 32317049)]
        [TestCase("7FFFFFFF", ExpectedResult = 2147483647)]
        [TestCase("7fffffff", ExpectedResult = 2147483647)]
        public int ParsePositiveFromHex_Tests(string source) => source.ParsePositiveFromHex();

        [TestCase("FFF5B198")]
        [TestCase("FFF509198")]
        public void ParsePositiveFromHex_InvalidSourceString_ThrowArgumentException(string source) =>
            Assert.Throws<ArgumentException>(() => source.ParsePositiveFromHex(), $"{nameof(source)} does not represent a positive number in hex numeral system.");

        [TestCase("FSW5B19-")]
        [TestCase("OP5Q08")]
        public void ParsePositiveFromHex_InvalidSymbolsInSourceString_ThrowArgumentException(string source) =>
            Assert.Throws<ArgumentException>(() => source.ParsePositiveFromHex(), $"{nameof(source)} does not represent a number in hex numeral system.");

        [TestCase("13421", 8, ExpectedResult = 5905)]
        [TestCase("100001", 8, ExpectedResult = 32769)]
        [TestCase("32317049", 10, ExpectedResult = 32317049)]
        [TestCase("2147483647", 10, ExpectedResult = 2147483647)]
        [TestCase("A4E6AFE", 16, ExpectedResult = 172911358)]
        [TestCase("A09912", 16, ExpectedResult = 10524946)]
        public int ParsePositiveByRadix_Tests(string source, int radix) => source.ParsePositiveByRadix(radix);

        [TestCase(5)]
        [TestCase(0)]
        [TestCase(-6)]
        public void ParsePositiveByRadix_RadixIsNot2or8or10or16_ThrowArgumentException(int radix) =>
            Assert.Throws<ArgumentException>(() => "1".ParsePositiveByRadix(radix), $"{nameof(radix)} is 8, 10 and 16 only.");

        [TestCase("37777777601", 8)]
        [TestCase("37775330632", 8)]
        [TestCase("37665330632", 8)]
        [TestCase("-575432", 10)]
        [TestCase("-11497074", 10)]
        [TestCase("FFF5B198", 16)]
        [TestCase("FFF509198", 16)]
        public void ParsePositiveByRadix_InvalidSourceString_ThrowArgumentException(string source, int radix) =>
            Assert.Throws<ArgumentException>(() => source.ParsePositiveByRadix(radix), $"{nameof(source)} does not represent a positive number in numeral system.");

        [TestCase("37789601", 8)]
        [TestCase("-5754AB2", 10)]
        [TestCase("FSW5B19-", 16)]
        public void ParsePositiveByRadix_InvalidSymbolsInSourceString_ThrowArgumentException(string source, int radix) =>
            Assert.Throws<ArgumentException>(() => source.ParsePositiveByRadix(radix), $"{nameof(source)} does not represent a positive number in numeral system.");

        [TestCase("100001", 8, ExpectedResult = 32769)]
        [TestCase("37777777601", 8, ExpectedResult = -127)]
        [TestCase("37775330632", 8, ExpectedResult = -675430)]
        [TestCase("37665330632", 8, ExpectedResult = -19549798)]
        [TestCase("-675432", 10, ExpectedResult = -675432)]
        [TestCase("-11497064", 10, ExpectedResult = -11497064)]
        [TestCase("A4E6AFE", 16, ExpectedResult = 172911358)]
        [TestCase("A09912", 16, ExpectedResult = 10524946)]
        [TestCase("FFF5B198", 16, ExpectedResult = -675432)]
        public int ParseByRadix_Tests(string source, int radix) => source.ParseByRadix(radix);

        [TestCase(5)]
        [TestCase(0)]
        [TestCase(-6)]
        public void ParseByRadix_RadixIsNot2or8or10or16_ThrowArgumentException(int radix) =>
            Assert.Throws<ArgumentException>(() => "1".ParseByRadix(radix), $"{nameof(radix)} is 8, 10 and 16 only.");

        [TestCase("37789601", 8)]
        [TestCase("-5754AB2", 10)]
        [TestCase("FSW5B19-", 16)]
        public void ParseByRadix_InvalidSymbolsInSourceString_ThrowArgumentException(string source, int radix) =>
            Assert.Throws<ArgumentException>(() => source.ParseByRadix(radix), $"{nameof(source)} does not represent a signed number in the octal, decimal or hex numeral system.");
    }
}
