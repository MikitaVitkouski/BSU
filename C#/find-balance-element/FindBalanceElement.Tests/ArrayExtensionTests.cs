using NUnit.Framework;

namespace FindBalanceElementTask.Tests
{
    public class ArrayExtensionTests
    {
        [TestCase(new int[] { 50, int.MinValue, 25, 25 }, ExpectedResult = 1)]
        [TestCase(new int[] { 25, 25, 10, 25, 25 }, ExpectedResult = 2)]
        [TestCase(new int[] { 25, 25, int.MaxValue, 50 }, ExpectedResult = 2)]
        [TestCase(new int[] { -50, -25, -20, -5, 500, -100 }, ExpectedResult = 4)]
        [TestCase(new int[] { 1, 2, 1 }, ExpectedResult = 1)]
        [TestCase(new int[] { -1, 2, 3, 1 }, ExpectedResult = 2)]
        [TestCase(new int[] { 100, -1, 50, -1, 100 }, ExpectedResult = 2)]
        [TestCase(new int[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 }, ExpectedResult = 5)]
        [TestCase(new int[] { 0, 0, 0 }, ExpectedResult = 1)]
        [TestCase(new int[] { int.MinValue, int.MinValue, 50, int.MinValue, int.MinValue }, ExpectedResult = 2)]
        public int? FindBalanceElement_Return_IndexOfBalanceElement(int[] array)
        {
            return ArrayExtension.FindBalanceElement(array);
        }

        [TestCase(new int[] { 0, 50 }, ExpectedResult = null)]
        [TestCase(new int[] { 100 }, ExpectedResult = null)]
        [TestCase(new int[] { int.MaxValue, int.MaxValue, int.MaxValue, 50 }, ExpectedResult = null)]
        [TestCase(new int[] { int.MaxValue, 10, int.MaxValue, int.MaxValue, 50 }, ExpectedResult = null)]
        [TestCase(new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 }, ExpectedResult = null)]
        [TestCase(new int[] { 1, 2, 1, 50000 }, ExpectedResult = null)]
        [TestCase(new int[] { -1, int.MinValue, 5, int.MaxValue }, ExpectedResult = null)]
        public int? FindBalanceElement_Return_Null(int[] array)
        {
            return ArrayExtension.FindBalanceElement(array);
        }

        [Test]
        public void FindBalanceElement_ArrayIsNull_ThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => ArrayExtension.FindBalanceElement(null), message: "Array can not be null.");
        }

        [Test]
        public void FindBalanceElement_ArrayIsEmpty_ThrowArgumentException()
        {
            Assert.Throws<ArgumentException>(() => ArrayExtension.FindBalanceElement(Array.Empty<int>()), message: "Array can not be empty.");
        }
    }
}
