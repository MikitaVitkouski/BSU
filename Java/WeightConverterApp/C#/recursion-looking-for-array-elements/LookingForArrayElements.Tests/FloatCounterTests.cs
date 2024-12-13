using NUnit.Framework;
using static LookingForArrayElements.FloatCounter;

namespace LookingForArrayElements.Tests
{
    [TestFixture]
    public sealed class FloatCounterTests
    {
        private static readonly float[] ArrayWithNineElements = { 0.1f, 0.2f, 0.3f, 0.4f, 0.5f, 0.6f, 0.7f, 0.8f, 0.9f };

        [Test]
        public void GetFloatsCount_ArrayToSearchIsNull_ThrowsArgumentNullException()
        {
            // Act
            Assert.Throws<ArgumentNullException>(
                () => GetFloatsCount(null, Array.Empty<float>(), Array.Empty<float>()),
                message: "Method throws ArgumentNullException in case an array to search is null.");
        }

        [Test]
        public void GetFloatsCount_RangeStartIsNull_ThrowsArgumentNullException()
        {
            // Act
            Assert.Throws<ArgumentNullException>(
                () => GetFloatsCount(Array.Empty<float>(), null, Array.Empty<float>()),
                message: "Method throws ArgumentNullException in case an array of range starts is null.");
        }

        [Test]
        public void GetFloatsCount_RangeEndIsNull_ThrowsArgumentNullException()
        {
            // Act
            Assert.Throws<ArgumentNullException>(
                () => GetFloatsCount(Array.Empty<float>(), Array.Empty<float>(), null),
                message: "Method throws ArgumentNullException in case an array of range ends is null.");
        }

        [Test]
        public void GetFloatsCount_ArrayToSearchIsEmpty_ReturnZeroOccurrences()
        {
            // Arrange
            float[] rangeStart = { 0.1f };
            float[] rangeEnd = { 0.1f };

            // Act
            int actual = GetFloatsCount(Array.Empty<float>(), rangeStart, rangeEnd);

            // Assert
            Assert.AreEqual(0, actual);
        }

        [Test]
        public void GetFloatsCount_RangesAreEmpty_ReturnZeroOccurrences()
        {
            // Act
            int actual = GetFloatsCount(FloatCounterTests.ArrayWithNineElements, Array.Empty<float>(), Array.Empty<float>());

            // Assert
            Assert.AreEqual(0, actual);
        }

        [Test]
        public void GetFloatsCount_RangeStartAndRangeEndHaveDifferentNumberOfElements_ThrowsArgumentException()
        {
            // Arrange
            float[] rangeStart = { 0.1f };
            float[] rangeEnd = { 0.2f, 0.9f };

            // Act
            Assert.Throws<ArgumentException>(
                () => GetFloatsCount(Array.Empty<float>(), rangeStart, rangeEnd),
                message: "Method throws ArgumentException in case an arrays of range starts and range ends contain different number of elements.");
        }

        [Test]
        public void GetFloatsCount_RangeStartValueIsGreaterThanRangeEndValue_ThrowsArgumentException()
        {
            // Arrange
            float[] rangeStart = { 0.2f, 0.9f };
            float[] rangeEnd = { 0.1f, 0.8f };

            // Act
            Assert.Throws<ArgumentException>(
                () => GetFloatsCount(Array.Empty<float>(), rangeStart, rangeEnd),
                message: "Method throws ArgumentException in case the range start value is greater than the range end value.");
        }

        [TestCase(new[] { 0.1f }, new[] { 0.1f }, new[] { 0.1f }, ExpectedResult = 1)]
        [TestCase(new[] { 0.1f, 0.2f, 0.3f, 0.4f, 0.5f, 0.6f, 0.7f, 0.8f, 0.9f }, new[] { 0.4f }, new[] { 0.6f }, ExpectedResult = 3)]
        [TestCase(new[] { 0.1f, 0.2f, 0.3f, 0.4f, 0.5f, 0.6f, 0.7f, 0.8f, 0.9f }, new[] { 0.1f, 0.8f }, new[] { 0.2f, 0.9f }, ExpectedResult = 4)]
        [TestCase(new[] { 0.1f, 0.2f, 0.3f, 0.4f, 0.5f, 0.6f, 0.7f, 0.8f, 0.9f }, new[] { 0.1f, 0.5f, 0.9f }, new[] { 0.1f, 0.5f, 0.9f }, ExpectedResult = 3)]
        [TestCase(new[] { float.Epsilon, 0.2f, -0.3f, 0.4f, 0.5f, -0.6f, 1.7f, 0.8f, float.MaxValue }, new[] { -0.1f, 0.5f, 0.9f }, new[] { 0.1f, 0.5f, 1.9f }, ExpectedResult = 3)]
        [TestCase(new[] { float.MaxValue, 0.1f, 0.2f, 0.3f, 0.4f, 0.5f, 0.6f, 0.7f, 0.8f, 0.9f, -1.1f, -2.2f, float.MaxValue, -3.3f, -4.4f, -5.5f, -6.6f, -7.7f, -8.8f, -9.9f }, new[] { float.MinValue }, new[] { float.MaxValue }, ExpectedResult = 20)]
        [TestCase(new[] { float.MaxValue, 0.1f, 0.2f, 0.3f, 0.4f, 0.5f, 0.6f, 0.7f, -0.8f, 0.9f, -1.1f, -2.2f, float.MaxValue, -3.3f, -4.4f, -5.5f, -6.6f, -7.7f, -8.8f, -9.9f }, new[] { 0.8f }, new[] { 0.8f }, ExpectedResult = 0)]
        public float GetFloatsCount_ParametersAreValid_ReturnsResult(float[] arrayToSearch, float[] rangeStart, float[] rangeEnd)
        {
            // Act
            return GetFloatsCount(arrayToSearch, rangeStart, rangeEnd);
        }

        [Test]
        public void GetFloatsCountWithStartIndexAndCount_ArrayToSearchIsNull_ThrowsArgumentNullException()
        {
            // Act
            Assert.Throws<ArgumentNullException>(
                () => GetFloatsCount(null, Array.Empty<float>(), Array.Empty<float>(), 0, 1),
                message: "Method throws ArgumentNullException in case an array to search is null.");
        }

        [Test]
        public void GetFloatsCountWithStartIndexAndCount_RangeStartIsNull_ThrowsArgumentNullException()
        {
            // Act
            Assert.Throws<ArgumentNullException>(
                () => GetFloatsCount(Array.Empty<float>(), null, Array.Empty<float>(), 0, 1),
                message: "Method throws ArgumentNullException in case an array of range starts is null.");
        }

        [Test]
        public void GetFloatsCountWithStartIndexAndCount_RangeEndIsNull_ThrowsArgumentNullException()
        {
            // Act
            Assert.Throws<ArgumentNullException>(
                () => GetFloatsCount(Array.Empty<float>(), Array.Empty<float>(), null, 0, 1),
                message: "Method throws ArgumentNullException in case an array of range ends is null.");
        }

        [Test]
        public void GetFloatsCountWithStartIndexAndCount_RangesAreEmpty_ReturnZeroOccurrences()
        {
            // Act
            int actual = GetFloatsCount(FloatCounterTests.ArrayWithNineElements, Array.Empty<float>(), Array.Empty<float>(), 0, 1);

            // Assert
            Assert.AreEqual(0, actual);
        }

        [Test]
        public void GetFloatsCountWithStartIndexAndCount_RangeStartAndRangeEndHaveDifferentNumberOfElements_ThrowsArgumentException()
        {
            // Arrange
            float[] rangeStart = { 0.1f };
            float[] rangeEnd = { 0.2f, 0.9f };

            // Act
            Assert.Throws<ArgumentException>(
                () => GetFloatsCount(Array.Empty<float>(), rangeStart, rangeEnd, 0, 1),
                message: "Method throws ArgumentException in case an arrays of range starts and range ends contain different number of elements.");
        }

        [Test]
        public void GetFloatsCountWithStartIndexAndCount_RangeStartValueIsGreaterThanRangeEndValue_ThrowsArgumentException()
        {
            // Arrange
            float[] rangeStart = { 0.2f, 0.9f };
            float[] rangeEnd = { 0.1f, 0.8f };

            // Act
            Assert.Throws<ArgumentException>(
                () => GetFloatsCount(Array.Empty<float>(), rangeStart, rangeEnd, 0, 1),
                message: "Method throws ArgumentException in case the range start value is greater than the range end value.");
        }

        [Test]
        public void GetFloatsCountWithStartIndexAndCount_StartIndexIsNegative_ThrowArgumentOutOfRangeException()
        {
            // Act
            Assert.Throws<ArgumentOutOfRangeException>(
                () => GetFloatsCount(Array.Empty<float>(), Array.Empty<float>(), Array.Empty<float>(), -123, 1),
                message: "Method throws ArgumentOutOfRangeException in case start index is negative.");
        }

        [Test]
        public void GetFloatsCountWithStartIndexAndCount_StartIndexIsGreaterThanTheLengthOfAnArrayToSearch_ThrowArgumentOutOfRangeException()
        {
            // Arrange
            float[] rangeStart = { 0.1f, 0.8f };
            float[] rangeEnd = { 0.2f, 0.9f };

            // Act
            Assert.Throws<ArgumentOutOfRangeException>(
                () => GetFloatsCount(Array.Empty<float>(), rangeStart, rangeEnd, 123, 1),
                message: "Method throws ArgumentOutOfRangeException in case start index is greater than the length of an array to search.");
        }

        [Test]
        public void GetFloatsCountWithStartIndexAndCount_CountIsLessThanZero_ThrowArgumentOutOfRangeException()
        {
            // Arrange
            float[] rangeStart = { 0.1f, 0.8f };
            float[] rangeEnd = { 0.2f, 0.9f };

            // Act
            Assert.Throws<ArgumentOutOfRangeException>(
                () => GetFloatsCount(Array.Empty<float>(), rangeStart, rangeEnd, 3, -1),
                message: "Method throws ArgumentOutOfRangeException in case count is less than zero.");
        }

        [Test]
        public void GetFloatsCountWithStartIndexAndCount_TheNumberOfElementsToSearchIsGreaterThanTheNumberOfElementsAvailableInTheArrayStartingFromTheStartIndexPosition_ThrowArgumentOutOfRangeException()
        {
            // Arrange
            float[] rangeStart = { 0.1f, 0.8f };
            float[] rangeEnd = { 0.2f, 0.9f };

            // Act
            Assert.Throws<ArgumentOutOfRangeException>(
                () => GetFloatsCount(Array.Empty<float>(), rangeStart, rangeEnd, 3, 110),
                message: "Method throws ArgumentOutOfRangeException in case the number of elements to search is greater than the number of elements available in the array starting from the startIndex position.");
        }

        [TestCase(new[] { 0.1f, 0.2f, 0.3f, 0.4f, 0.5f, 0.6f, 0.7f, 0.8f, 0.9f }, new[] { 0.4f }, new[] { 0.6f }, 0, 9, ExpectedResult = 3)]
        [TestCase(new[] { 0.1f, 0.2f, 0.3f, 0.4f, 0.5f, 0.6f, 0.7f, 0.8f, 0.9f }, new[] { 0.4f }, new[] { 0.6f }, 2, 0, ExpectedResult = 0)]
        [TestCase(new[] { 0.1f, 0.2f, 0.3f, 0.4f, 0.5f, 0.6f, 0.7f, 0.8f, 0.9f }, new[] { 0.4f }, new[] { 0.6f }, 4, 1, ExpectedResult = 1)]
        [TestCase(new[] { 0.1f, 0.2f, 0.3f, 0.4f, 0.5f, 0.6f, 0.7f, 0.8f, 0.9f }, new[] { 0.1f, 0.7f }, new[] { 0.3f, 0.9f }, 2, 5, ExpectedResult = 2)]
        [TestCase(new[] { 0.1f, 0.2f, 0.3f, 0.4f, 0.5f, 0.6f, 0.7f, 0.8f, 0.9f }, new[] { 0.1f, 0.8f }, new[] { 0.2f, 0.9f }, 0, 8, ExpectedResult = 3)]
        [TestCase(new[] { 0.1f, 0.2f, 0.3f, 0.4f, 0.5f, 0.6f, 0.7f, 0.8f, 0.9f }, new[] { 0.1f, 0.5f, 0.9f }, new[] { 0.1f, 0.5f, 0.9f }, 4, 2, ExpectedResult = 1)]
        [TestCase(new[] { float.Epsilon, 0.2f, -0.3f, 0.4f, 0.5f, -0.6f, 1.7f, 0.8f, float.MaxValue }, new[] { -0.1f, 0.5f, 0.9f }, new[] { 0.1f, 0.5f, 1.9f }, 0, 1, ExpectedResult = 1)]
        [TestCase(new[] { float.MaxValue, 0.1f, 0.2f, 0.3f, 0.4f, 0.5f, 0.6f, 0.7f, 0.8f, 0.9f, -1.1f, -2.2f, float.MaxValue, -3.3f, -4.4f, -5.5f, -6.6f, -7.7f, -8.8f, -9.9f }, new[] { float.MinValue }, new[] { float.MaxValue }, 6, 7, ExpectedResult = 7)]
        [TestCase(new[] { float.MaxValue, 0.1f, 0.2f, 0.3f, 0.4f, 0.5f, 0.6f, 0.7f, -0.8f, 0.9f, -1.1f, -2.2f, float.MaxValue, -3.3f, -4.4f, -5.5f, -6.6f, -7.7f, -0.8f, 0.8f }, new[] { 0.8f }, new[] { 0.8f }, 19, 1, ExpectedResult = 1)]
        public int GetFloatsCount_ParametersAreValid_ReturnsResult(float[] arrayToSearch, float[] rangeStart, float[] rangeEnd, int startIndex, int count)
        {
            // Act
            return GetFloatsCount(arrayToSearch, rangeStart, rangeEnd, startIndex, count);
        }
    }
}
