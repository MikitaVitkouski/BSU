using NUnit.Framework;
using static LookingForArrayElements.DecimalCounter;

namespace LookingForArrayElements.Tests
{
    [TestFixture]
    public sealed class DecimalCounterTests
    {
        private static readonly decimal[] ArrayWithFiveElements = { 0.1m, 0.2m, 0.3m, 0.4m, 0.5m };
        private static readonly decimal[] ArrayWithFifteenElements = { decimal.MaxValue, -0.1m, -0.2m, decimal.One, -0.3m, -0.4m, -0.5m, decimal.Zero, 0.1m, 0.2m, 0.3m, 0.4m, 0.5m, decimal.MinusOne, decimal.MinValue };

        [Test]
        public void DecimalCounter_ArrayToSearchIsNull_ThrowArgumentNullException()
        {
            // Act
            Assert.Throws<ArgumentNullException>(
                () => GetDecimalsCount(null, Array.Empty<decimal[]>()),
                message: "Method throws ArgumentNullException in case array to search is null.");
        }

        [Test]
        public void DecimalCounter_ArrayOfRangesIsNull_ThrowArgumentNullException()
        {
            // Act
            Assert.Throws<ArgumentNullException>(
                () => GetDecimalsCount(Array.Empty<decimal>(), null),
                message: "Method throws ArgumentNullException in case array of ranges is null.");
        }

        [Test]
        public void DecimalCounter_ArrayToSearchIsEmpty_ReturnZeroOccurrences()
        {
            // Arrange
            decimal[][] ranges =
            {
                new[] { 0.1m, 0.2m },
            };

            // Act
            int actual = GetDecimalsCount(Array.Empty<decimal>(), ranges);

            // Assert
            Assert.AreEqual(0, actual);
        }

        [Test]
        public void DecimalCounter_ArrayOfRangesIsEmpty_ReturnZeroOccurrences()
        {
            // Act
            int actual = GetDecimalsCount(DecimalCounterTests.ArrayWithFiveElements, Array.Empty<decimal[]>());

            // Assert
            Assert.AreEqual(0, actual);
        }

        [Test]
        public void DecimalCounter_OneOfTheRangesIsNull_ThrowArgumentNullException()
        {
            // Arrange
            decimal[]?[] ranges =
            {
                new[] { 0.1m, 0.2m },
                null,
            };

            // Act
            Assert.Throws<ArgumentNullException>(
                () => GetDecimalsCount(Array.Empty<decimal>(), ranges),
                message: "Method throws ArgumentNullException in case one of the ranges is null.");
        }

        [Test]
        public void DecimalCounter_OneOfTheRangesIsEmpty_ReturnValidResult()
        {
            // Arrange
            decimal[][] ranges =
            {
                new[] { 0.1m, 0.2m },
                Array.Empty<decimal>(),
            };

            // Act
            int actual = GetDecimalsCount(DecimalCounterTests.ArrayWithFiveElements, ranges);

            // Assert
            Assert.AreEqual(2, actual);
        }

        [Test]
        public void DecimalCounter_OneOfTheRangesIsInvalid_ThrowArgumentException()
        {
            // Arrange
            decimal[][] ranges =
            {
                new[] { 0.1m, 0.2m },
                new[] { 0.4m, 0.5m, 0.6m },
            };

            // Act
            Assert.Throws<ArgumentException>(
                () => GetDecimalsCount(Array.Empty<decimal>(), ranges),
                message: "Method throws ArgumentException in case the length of one of the ranges is less or greater than 2.");
        }

        [Test]
        public void DecimalCounter_FiveElementsOneRange_ReturnsResult()
        {
            // Arrange
            decimal[][] ranges =
            {
                new[] { 0.1m, 0.2m },
            };

            // Act
            int actualResult = GetDecimalsCount(DecimalCounterTests.ArrayWithFiveElements, ranges);

            // Assert
            Assert.AreEqual(2, actualResult);
        }

        [Test]
        public void DecimalCounter_FiveElementsTwoRanges_ReturnsResult()
        {
            // Arrange
            decimal[][] ranges =
            {
                new[] { 0.1m, 0.2m },
                new[] { 0.4m, 0.5m },
            };

            // Act
            int actualResult = GetDecimalsCount(DecimalCounterTests.ArrayWithFiveElements, ranges);

            // Assert
            Assert.AreEqual(4, actualResult);
        }

        [Test]
        public void DecimalCounter_FiveElementsThreeRanges_ReturnsResult()
        {
            // Arrange
            decimal[][] ranges =
            {
                new[] { 0.1m, 0.2m },
                new[] { 0.4m, 0.5m },
                new[] { decimal.Zero, decimal.One },
            };

            // Act
            int actualResult = GetDecimalsCount(DecimalCounterTests.ArrayWithFiveElements, ranges);

            // Assert
            Assert.AreEqual(5, actualResult);
        }

        [Test]
        public void DecimalCounter_FifteenElementsOneRange_ReturnsResult()
        {
            // Arrange
            decimal[][] ranges =
            {
                new[] { -0.1m, 0.2m },
            };

            // Act
            int actualResult = GetDecimalsCount(DecimalCounterTests.ArrayWithFifteenElements, ranges);

            // Assert
            Assert.AreEqual(4, actualResult);
        }

        [Test]
        public void DecimalCounter_FifteenElementsTwoRanges_ReturnsResult()
        {
            // Arrange
            decimal[][] ranges =
            {
                new[] { -0.1m, 0.2m },
                new[] { 0.4m, 0.5m },
            };

            // Act
            int actualResult = GetDecimalsCount(DecimalCounterTests.ArrayWithFifteenElements, ranges);

            // Assert
            Assert.AreEqual(6, actualResult);
        }

        [Test]
        public void DecimalCounter_FifteenElementsThreeRanges_ReturnsResult()
        {
            // Arrange
            decimal[][] ranges =
            {
                new[] { -0.1m, 0.2m },
                new[] { 0.4m, 0.5m },
                new[] { decimal.Zero, decimal.One },
            };

            // Act
            int actualResult = GetDecimalsCount(DecimalCounterTests.ArrayWithFifteenElements, ranges);

            // Assert
            Assert.AreEqual(8, actualResult);
        }

        [Test]
        public void DecimalCounterWithStartIndexAndCount_ArrayToSearchIsNull_ThrowArgumentNullException()
        {
            // Act
            Assert.Throws<ArgumentNullException>(
                () => GetDecimalsCount(null, Array.Empty<decimal[]>(), 0, 1),
                message: "Method throws ArgumentNullException in case array to search is null.");
        }

        [Test]
        public void DecimalCounterWithStartIndexAndCount_ArrayOfRangesIsNull_ThrowArgumentNullException()
        {
            // Act
            Assert.Throws<ArgumentNullException>(
                () => GetDecimalsCount(Array.Empty<decimal>(), null, 0, 1),
                message: "Method throws ArgumentNullException in case array of ranges is null.");
        }

        [Test]
        public void DecimalCounterWithStartIndexAndCount_ArrayOfRangesIsEmpty_ReturnZeroOccurrences()
        {
            // Act
            int actual = GetDecimalsCount(DecimalCounterTests.ArrayWithFiveElements, Array.Empty<decimal[]>(), 0, 1);

            // Assert
            Assert.AreEqual(0, actual);
        }

        [Test]
        public void DecimalCounterWithStartIndexAndCount_OneOfTheRangesIsNull_ThrowArgumentNullException()
        {
            // Arrange
            decimal[]?[] ranges =
            {
                new[] { 0.1m, 0.2m },
                null,
            };

            // Act
            Assert.Throws<ArgumentNullException>(
                () => GetDecimalsCount(Array.Empty<decimal>(), ranges, 0, 1),
                message: "Method throws ArgumentNullException in case one of the ranges is null.");
        }

        [Test]
        public void DecimalCounterWithStartIndexAndCount_OneOfTheRangesIsEmpty_ReturnValidResult()
        {
            // Arrange
            decimal[][] ranges =
            {
                new[] { 0.1m, 0.2m },
                Array.Empty<decimal>(),
            };

            // Act
            int actual = GetDecimalsCount(DecimalCounterTests.ArrayWithFiveElements, ranges, 0, 1);

            // Assert
            Assert.AreEqual(1, actual);
        }

        [Test]
        public void DecimalCounterWithStartIndexAndCount_OneOfTheRangesIsInvalid_ThrowArgumentException()
        {
            // Arrange
            decimal[][] ranges =
            {
                new[] { 0.1m, 0.2m },
                new[] { 0.4m, 0.5m, 0.6m },
            };

            // Act
            Assert.Throws<ArgumentException>(
                () => GetDecimalsCount(Array.Empty<decimal>(), ranges, 0, 1),
                message: "Method throws ArgumentException in case the length of one of the ranges is less or greater than 2.");
        }

        [Test]
        public void DecimalCounterWithStartIndexAndCount_StartIndexIsNegative_ThrowArgumentOutOfRangeException()
        {
            // Arrange
            decimal[][] ranges =
            {
                new[] { 0.1m, 0.2m },
                new[] { 0.4m, 0.5m },
            };

            // Act
            Assert.Throws<ArgumentOutOfRangeException>(
                () => GetDecimalsCount(Array.Empty<decimal>(), ranges, -1234, 1),
                message: "Method throws ArgumentOutOfRangeException in case start index is negative.");
        }

        [Test]
        public void DecimalCounterWithStartIndexAndCount_StartIndexIsGreaterThanTheLengthOfAnArrayToSearch_ThrowArgumentOutOfRangeException()
        {
            // Arrange
            decimal[][] ranges =
            {
                new[] { 0.1m, 0.2m },
                new[] { 0.4m, 0.5m },
            };

            // Act
            Assert.Throws<ArgumentOutOfRangeException>(
                () => GetDecimalsCount(Array.Empty<decimal>(), ranges, 1234, 1),
                message: "Method throws ArgumentOutOfRangeException in case start index is greater than the length of an array to search.");
        }

        [Test]
        public void DecimalCounterWithStartIndexAndCount_CountIsLessThanZero_ThrowArgumentOutOfRangeException()
        {
            // Arrange
            decimal[][] ranges =
            {
                new[] { 0.1m, 0.2m },
                new[] { 0.4m, 0.5m },
            };

            // Act
            Assert.Throws<ArgumentOutOfRangeException>(
                () => GetDecimalsCount(Array.Empty<decimal>(), ranges, 4, -1),
                message: "Method throws ArgumentOutOfRangeException in case count is less than zero.");
        }

        [Test]
        public void DecimalCounterWithStartIndexAndCount_TheNumberOfElementsToSearchIsGreaterThanTheNumberOfElementsAvailableInTheArrayStartingFromTheStartIndexPosition_ThrowArgumentOutOfRangeException()
        {
            // Arrange
            decimal[][] ranges =
            {
                new[] { 0.1m, 0.2m },
                new[] { 0.4m, 0.5m },
            };

            // Act
            Assert.Throws<ArgumentOutOfRangeException>(
                () => GetDecimalsCount(DecimalCounterTests.ArrayWithFiveElements, ranges, 0, 100000),
                message: "Method throws ArgumentOutOfRangeException in case the number of elements to search is greater than the number of elements available in the array starting from the startIndex position.");
        }

        [TestCase(0, 5, ExpectedResult = 2)]
        [TestCase(0, 2, ExpectedResult = 2)]
        [TestCase(2, 3, ExpectedResult = 0)]
        public int DecimalCounter_FiveElementsOneRange_ReturnsResult(int startIndex, int count)
        {
            // Arrange
            decimal[][] ranges =
            {
                new[] { 0.1m, 0.2m },
            };

            // Act
            return GetDecimalsCount(DecimalCounterTests.ArrayWithFiveElements, ranges, startIndex, count);
        }

        [TestCase(0, 5, ExpectedResult = 4)]
        [TestCase(0, 0, ExpectedResult = 0)]
        [TestCase(0, 2, ExpectedResult = 2)]
        [TestCase(2, 3, ExpectedResult = 2)]
        [TestCase(2, 1, ExpectedResult = 0)]
        public int DecimalCounter_FiveElementsTwoRanges_ReturnsResult(int startIndex, int count)
        {
            // Arrange
            decimal[][] ranges =
            {
                new[] { 0.1m, 0.2m },
                new[] { 0.4m, 0.5m },
            };

            // Act
            return GetDecimalsCount(DecimalCounterTests.ArrayWithFiveElements, ranges, startIndex, count);
        }

        [TestCase(0, 5, ExpectedResult = 5)]
        [TestCase(0, 0, ExpectedResult = 0)]
        [TestCase(0, 2, ExpectedResult = 2)]
        [TestCase(2, 3, ExpectedResult = 3)]
        [TestCase(2, 1, ExpectedResult = 1)]
        public int DecimalCounter_FiveElementsThreeRanges_ReturnsResult(int startIndex, int count)
        {
            // Arrange
            decimal[][] ranges =
            {
                new[] { 0.1m, 0.2m },
                new[] { 0.4m, 0.5m },
                new[] { decimal.Zero, decimal.One },
            };

            // Act
            return GetDecimalsCount(DecimalCounterTests.ArrayWithFiveElements, ranges, startIndex, count);
        }

        [TestCase(0, 15, ExpectedResult = 4)]
        [TestCase(0, 2, ExpectedResult = 1)]
        [TestCase(0, 0, ExpectedResult = 0)]
        [TestCase(2, 3, ExpectedResult = 0)]
        public int DecimalCounter_FifteenElementsOneRange_ReturnsResult(int startIndex, int count)
        {
            // Arrange
            decimal[][] ranges =
            {
                new[] { -0.1m, 0.2m },
            };

            // Act
            return GetDecimalsCount(DecimalCounterTests.ArrayWithFifteenElements, ranges, startIndex, count);
        }

        [TestCase(0, 15, ExpectedResult = 6)]
        [TestCase(0, 2, ExpectedResult = 1)]
        [TestCase(2, 3, ExpectedResult = 0)]
        [TestCase(10, 5, ExpectedResult = 2)]
        [TestCase(10, 0, ExpectedResult = 0)]
        public int DecimalCounter_FifteenElementsTwoRanges_ReturnsResult(int startIndex, int count)
        {
            // Arrange
            decimal[][] ranges =
            {
                new[] { -0.1m, 0.2m },
                new[] { 0.4m, 0.5m },
            };

            // Act
            return GetDecimalsCount(DecimalCounterTests.ArrayWithFifteenElements, ranges, startIndex, count);
        }

        [TestCase(0, 15, ExpectedResult = 8)]
        [TestCase(0, 2, ExpectedResult = 1)]
        [TestCase(2, 3, ExpectedResult = 1)]
        [TestCase(10, 5, ExpectedResult = 3)]
        [TestCase(10, 0, ExpectedResult = 0)]
        public int DecimalCounter_FifteenElementsThreeRanges_ReturnsResult(int startIndex, int count)
        {
            // Arrange
            decimal[][] ranges =
            {
                new[] { -0.1m, 0.2m },
                new[] { 0.4m, 0.5m },
                new[] { decimal.Zero, decimal.One },
            };

            // Act
            return GetDecimalsCount(DecimalCounterTests.ArrayWithFifteenElements, ranges, startIndex, count);
        }
    }
}
