using NUnit.Framework;
using static LookingForArrayElements.IntegersCounter;

namespace LookingForArrayElements.Tests
{
    [TestFixture]
    public sealed class IntegersCounterTests
    {
        [Test]
        public void GetIntegersCount_ArrayToSearchIsNull_ThrowArgumentNullException()
        {
            // Act
            Assert.Throws<ArgumentNullException>(
                () => GetIntegersCount(null, Array.Empty<int>()),
                message: "Method throws ArgumentNullException in case an array to search is null.");
        }

        [Test]
        public void GetIntegersCount_ElementsToSearchForIsNull_ThrowArgumentNullException()
        {
            // Act
            Assert.Throws<ArgumentNullException>(
                () => GetIntegersCount(Array.Empty<int>(), null),
                message: "Method throws ArgumentNullException in case an array of elements to for search is null.");
        }

        [Test]
        public void GetIntegersCount_ArrayToSearchIsEmpty_ReturnZeroOccurrences()
        {
            // Arrange
            int[] elementsToSearchFor = { 2, 5, 8 };

            // Act
            int actual = GetIntegersCount(Array.Empty<int>(), elementsToSearchFor);

            // Assert
            Assert.AreEqual(0, actual);
        }

        [Test]
        public void GetIntegersCount_ElementsToSearchForIsEmpty_ReturnZeroOccurrences()
        {
            // Arrange
            int[] arrayToSearch = { 2, 5, 8 };

            // Act
            int actual = GetIntegersCount(arrayToSearch, Array.Empty<int>());

            // Assert
            Assert.AreEqual(0, actual);
        }

        [TestCase(new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }, new[] { 2, 5, 8 }, ExpectedResult = 3)]
        [TestCase(new[] { 1, 2, 3, 2, 4, 5, 6, 5, 5, 8, 7, 8, 9 }, new[] { 2, 5, 8 }, ExpectedResult = 7)]
        [TestCase(new[] { 1, 2, 3, 2, 4, 5, 6, 5, 5, 8, 7, 8, 9 }, new[] { -2, -5, -8 }, ExpectedResult = 0)]
        [TestCase(new[] { 5, 4, 21, 38, 25, int.MaxValue, 48, 98, 14, 43, 11, 6, 81, 532, 58 }, new[] { int.MaxValue, 47, 14, 6, 532, int.MinValue }, ExpectedResult = 4)]
        [TestCase(new[] { -5, 4, -21, 38, -25, int.MinValue, 48, -98, 14, -43, 11, -6, 81, -532, -58 }, new[] { int.MaxValue, -47, 14, -6, 532, int.MinValue }, ExpectedResult = 3)]
        public int GetIntegersCount_ParametersAreValid_ReturnsResult(int[] arrayToSearch, int[] elementsToSearchFor)
        {
            // Act
            return GetIntegersCount(arrayToSearch, elementsToSearchFor);
        }

        [Test]
        public void GetIntegersCountWithStartIndexAndCount_ArrayToSearchIsNull_ThrowArgumentNullException()
        {
            // Act
            Assert.Throws<ArgumentNullException>(
                () => GetIntegersCount(null, Array.Empty<int>(), 0, 1),
                message: "Method throws ArgumentNullException in case an array to search is null.");
        }

        [Test]
        public void GetIntegersCountWithStartIndexAndCount_ElementsToSearchForIsNull_ThrowArgumentNullException()
        {
            // Act
            Assert.Throws<ArgumentNullException>(
                () => GetIntegersCount(Array.Empty<int>(), null, 0, 1),
                message: "Method throws ArgumentNullException in case an array of elements to for search is null.");
        }

        [Test]
        public void GetIntegersCountWithStartIndexAndCount_ElementsToSearchForIsEmpty_ReturnZeroOccurrences()
        {
            // Arrange
            int[] arrayToSearch = { 2, 5, 8 };

            // Act
            int actual = GetIntegersCount(arrayToSearch, Array.Empty<int>(), 0, 1);

            // Assert
            Assert.AreEqual(0, actual);
        }

        [Test]
        public void GetIntegersCountWithStartIndexAndCount_StartIndexIsNegative_ThrowArgumentOutOfRangeException()
        {
            // Act
            Assert.Throws<ArgumentOutOfRangeException>(
                () => GetIntegersCount(Array.Empty<int>(), Array.Empty<int>(), -1, 1),
                message: "Method throws ArgumentOutOfRangeException in case start index is negative.");
        }

        [Test]
        public void GetIntegersCountWithStartIndexAndCount_StartIndexIsGreaterThanTheLengthOfAnArrayToSearch_ThrowArgumentOutOfRangeException()
        {
            // Act
            Assert.Throws<ArgumentOutOfRangeException>(
                () => GetIntegersCount(Array.Empty<int>(), Array.Empty<int>(), 12, 1),
                message: "Method throws ArgumentOutOfRangeException in case start index is greater than the length of an array to search.");
        }

        [Test]
        public void GetIntegersCountWithStartIndexAndCount_CountIsLessThanZero_ReturnValidResult()
        {
            // Act
            Assert.Throws<ArgumentOutOfRangeException>(
                () => GetIntegersCount(Array.Empty<int>(), Array.Empty<int>(), 2, -1),
                message: "Method throws ArgumentOutOfRangeException in case count is less than zero.");
        }

        [Test]
        public void GetIntegersCountWithStartIndexAndCount_TheNumberOfElementsToSearchIsGreaterThanTheNumberOfElementsAvailableInTheArrayStartingFromTheStartIndexPosition_ThrowArgumentOutOfRangeException()
        {
            // Act
            Assert.Throws<ArgumentOutOfRangeException>(
                () => GetIntegersCount(Array.Empty<int>(), Array.Empty<int>(), 6, 44),
                message: "Method throws ArgumentOutOfRangeException in case the number of elements to search is greater than the number of elements available in the array starting from the startIndex position.");
        }

        [TestCase(new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }, new[] { 2, 5, 8 }, 5, 0, ExpectedResult = 0)]
        [TestCase(new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }, new[] { 2, 5, 8 }, 0, 9, ExpectedResult = 3)]
        [TestCase(new[] { 1, 2, 3, 2, 4, 5, 6, 5, 5, 8, 7, 8, 9 }, new[] { 2, 5, 8 }, 0, 13, ExpectedResult = 7)]
        [TestCase(new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }, new[] { 2, 5, 8 }, 2, 5, ExpectedResult = 1)]
        [TestCase(new[] { 1, 2, 3, 2, 4, 5, 6, 5, 5, 8, 7, 8, 9 }, new[] { 2, 5, 8 }, 3, 7, ExpectedResult = 5)]
        [TestCase(new[] { 1, 2, 3, 2, 4, 5, 6, 5, 5, 8, 7, 8, 9 }, new[] { -2, -5, -8 }, 5, 3, ExpectedResult = 0)]
        [TestCase(new[] { 5, 4, 21, 38, 25, int.MaxValue, 48, 98, 14, 43, 11, 6, 81, 532, 58 }, new[] { int.MaxValue, 47, 14, 6, 532, int.MinValue }, 0, 8, ExpectedResult = 1)]
        [TestCase(new[] { -5, 4, -21, 38, -25, int.MinValue, 48, -98, 14, -43, 11, -6, 81, -532, -58 }, new[] { int.MaxValue, -47, 14, -6, 532, int.MinValue }, 4, 10, ExpectedResult = 3)]
        public int GetIntegersCount_ParametersAreValid_ReturnsResult(int[] arrayToSearch, int[] elementsToSearchFor, int startIndex, int count)
        {
            // Act
            return GetIntegersCount(arrayToSearch, elementsToSearchFor, startIndex, count);
        }
    }
}
