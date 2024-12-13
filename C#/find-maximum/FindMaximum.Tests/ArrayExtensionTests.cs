using NUnit.Framework;
using static FindMaximum.ArrayExtension;

namespace FindMaximum.Tests
{
    public class ArrayExtensionTests
    {
        private int[]? array;
        private int max;

        [SetUp]
        public void Setup()
        {
            this.max = 10_000_000;
            this.array = Enumerable.Range(1, this.max).ToArray();
        }

        [Order(3)]
        [TestCase(new int[] { 0, 50 }, ExpectedResult = 50)]
        [TestCase(new int[] { 100 }, ExpectedResult = 100)]
        [TestCase(new int[] { int.MaxValue, int.MaxValue, int.MinValue, 50 }, ExpectedResult = int.MaxValue)]
        [TestCase(new int[] { 50, int.MinValue, 25, 25 }, ExpectedResult = 50)]
        [TestCase(new int[] { 25, 25, 10, 25, 25, 100 }, ExpectedResult = 100)]
        [TestCase(new int[] { -50, -25, -20, -5, 500, -100 }, ExpectedResult = 500)]
        [TestCase(new int[] { -50, -25, -20, -5, -500, -100 }, ExpectedResult = -5)]
        [TestCase(new int[] { -50, -25, -20, 0, -500, -100 }, ExpectedResult = 0)]
        [TestCase(new int[] { 0, 0, 0, 0, 0, 0 }, ExpectedResult = 0)]
        [TestCase(new int[] { 0, 1, 0, 0, 0, 0 }, ExpectedResult = 1)]
        public int FindMaximumItem_ReturnMaximumElement(int[] source) => GetMax(source);

        [Test]
        public void FindMaximum_ArrayIsNull_ThrowArgumentNullException() =>
            Assert.Throws<ArgumentNullException>(() => GetMax(null), message: "source cannot be null.");

        [Test]
        public void FindMaximum_ArrayIsEmpty_ThrowArgumentException() =>
            Assert.Throws<ArgumentException>(() => GetMax(Array.Empty<int>()), message: "source cannot be empty.");

        [Test]
        public void FindMaximum_TestForLargeArray()
        {
            int expected = this.max;
            int actual = GetMax(this.array);
            Assert.AreEqual(expected, actual);
        }
    }
}
