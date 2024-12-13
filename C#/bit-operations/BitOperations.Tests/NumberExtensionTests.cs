using NUnit.Framework;
using static BitOperationsTask.NumbersExtension;

namespace BitOperationsTask.Tests
{
    public class NumberExtensionTests
    {
        [TestCase(2728, 655, 3, 8, ExpectedResult = 2680)]
        [TestCase(554216104, 15, 0, 31, ExpectedResult = 15)]
        [TestCase(-55465467, 345346, 0, 31, ExpectedResult = 345346)]
        [TestCase(554216104, 4460559, 11, 18, ExpectedResult = 554203816)]
        [TestCase(-1, 0, 31, 31, ExpectedResult = 2147483647)]
        [TestCase(-2147483648, 2147483647, 0, 30, ExpectedResult = -1)]
        [TestCase(-2223, 5440, 18, 23, ExpectedResult = -16517295)]
        [TestCase(2147481425, 5440, 18, 23, ExpectedResult = 2130966353)]
        public int InsertNumberIntoAnother_ReturnChangedNumber(int destinationNumber, int sourceNumber, int i, int j)
        => InsertNumberIntoAnother(destinationNumber, sourceNumber, i, j);

        [Test]
        public void InsertNumberIntoAnother_IfiMoreThanj_ThrowArgumentException() =>
            Assert.Throws<ArgumentException>(() => InsertNumberIntoAnother(8, 15, 8, 3), message: $"i should be less than or equal to j.");

        [Test]
        public void InsertNumberIntoAnother_IfiEqualsMinusOne_ThrowArgumentOutOfRangeException() =>
            Assert.Throws<ArgumentOutOfRangeException>(() => InsertNumberIntoAnother(8, 15, -1, 3), message: "i range is from 0 to 31 (including).");

        [Test]
        public void InsertNumberIntoAnother_IfiEquals32_ThrowArgumentOutOfRangeException() =>
            Assert.Throws<ArgumentOutOfRangeException>(() => InsertNumberIntoAnother(8, 15, 32, 32), message: "i range is from 0 to 31 (including).");

        [Test]
        public void InsertNumberIntoAnother_IfjEquals32_Throw_ArgumentOutOfRangeException() =>
            Assert.Throws<ArgumentOutOfRangeException>(() => InsertNumberIntoAnother(8, 15, 0, 32), message: "j range is from 0 to 31 (including).");
    }
}
