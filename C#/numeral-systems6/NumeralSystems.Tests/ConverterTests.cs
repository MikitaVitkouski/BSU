using System;
using NUnit.Framework;

#pragma warning disable CA1707

namespace NumeralSystems.Tests
{
    [TestFixture]
    public class ConverterTests
    {
        [TestCase(3, ExpectedResult = "3")]
        [TestCase(127, ExpectedResult = "177")]
        [TestCase(675432, ExpectedResult = "2447150")]
        [TestCase(1908345, ExpectedResult = "7217171")]
        [TestCase(int.MaxValue, ExpectedResult = "17777777777")]
        public string GetPositiveOctal_Tests(int number) => number.GetPositiveOctal();

        [TestCase(3, ExpectedResult = "3")]
        [TestCase(127, ExpectedResult = "127")]
        [TestCase(675432, ExpectedResult = "675432")]
        [TestCase(1908345, ExpectedResult = "1908345")]
        [TestCase(int.MaxValue, ExpectedResult = "2147483647")]
        public string GetPositiveDecimal_Tests(int number) => number.GetPositiveDecimal();

        [TestCase(3, ExpectedResult = "3")]
        [TestCase(127, ExpectedResult = "7F")]
        [TestCase(675432, ExpectedResult = "A4E68")]
        [TestCase(1908345, ExpectedResult = "1D1E79")]
        [TestCase(int.MaxValue, ExpectedResult = "7FFFFFFF")]
        public string GetPositiveHex_Tests(int number) => number.GetPositiveHex();

        [TestCase(675432, 8, ExpectedResult = "2447150")]
        [TestCase(1908345, 8, ExpectedResult = "7217171")]
        [TestCase(127, 10, ExpectedResult = "127")]
        [TestCase(675432, 10, ExpectedResult = "675432")]
        [TestCase(1908345, 16, ExpectedResult = "1D1E79")]
        [TestCase(int.MaxValue, 16, ExpectedResult = "7FFFFFFF")]
        public string GetPositiveRadix_Tests(int number, int radix) => number.GetPositiveRadix(radix);

        [TestCase(-3, 8, ExpectedResult = "37777777775")]
        [TestCase(-127, 8, ExpectedResult = "37777777601")]
        [TestCase(-675432, 8, ExpectedResult = "37775330630")]
        [TestCase(-1908345, 8, ExpectedResult = "37770560607")]
        [TestCase(int.MinValue, 8, ExpectedResult = "20000000000")]
        [TestCase(-3, 16, ExpectedResult = "FFFFFFFD")]
        [TestCase(-127, 16, ExpectedResult = "FFFFFF81")]
        [TestCase(-675432, 16, ExpectedResult = "FFF5B198")]
        [TestCase(-1908345, 16, ExpectedResult = "FFE2E187")]
        [TestCase(int.MinValue, 16, ExpectedResult = "80000000")]
        [TestCase(1908345, 10, ExpectedResult = "1908345")]
        [TestCase(int.MaxValue, 10, ExpectedResult = "2147483647")]
        public string GetRadix_Tests(int number, int radix) => number.GetRadix(radix);

        [TestCase(5)]
        [TestCase(0)]
        [TestCase(-6)]
        public void GetRadix_RadixIs2or8or10or16_ThrowArgumentException(int radix) =>
            Assert.Throws<ArgumentException>(() => (-675432).GetRadix(radix), $"{nameof(radix)} is 8, 10 and 16 only.");

        [TestCase(5)]
        [TestCase(0)]
        [TestCase(-6)]
        public void GetPositiveRadix_RadixIs2or8or10or16_ThrowArgumentException(int radix) =>
            Assert.Throws<ArgumentException>(() => 675432.GetPositiveRadix(radix), $"{nameof(radix)} is 8, 10 and 16 only.");

        [TestCase(int.MinValue)]
        [TestCase(-60)]
        public void GetPositiveRadix_NumberIsLessThanZero_ThrowArgumentException(int number) =>
            Assert.Throws<ArgumentException>(() => number.GetPositiveRadix(8), $"{nameof(number)} can not be less than zero.");

        [TestCase(int.MinValue)]
        [TestCase(-60)]
        public void GetPositiveOctal_NumberIsLessThanZero_ThrowArgumentException(int number) =>
            Assert.Throws<ArgumentException>(() => number.GetPositiveOctal(), $"{nameof(number)} can not be less than zero.");

        [TestCase(int.MinValue)]
        [TestCase(-60)]
        public void GetPositiveDecimal_NumberIsLessThanZero_ThrowArgumentException(int number) =>
            Assert.Throws<ArgumentException>(() => number.GetPositiveDecimal(), $"{nameof(number)} can not be less than zero.");

        [TestCase(int.MinValue)]
        [TestCase(-60)]
        public void GetPositiveHex_NumberIsLessThanZero_ThrowArgumentException(int number) =>
            Assert.Throws<ArgumentException>(() => number.GetPositiveHex(), $"{nameof(number)} can not be less than zero.");
    }
}
