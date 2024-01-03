using NUnit.Framework;

// ReSharper disable StringLiteralTypo
namespace QuickSort.Tests
{
    [TestFixture]
    public class SorterTests
    {
        [Test]
        public void QuickSort_ArrayIsNull_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => (null as int[]).QuickSort());
        }

        [TestCase(new int[] { }, ExpectedResult = new int[] { })]
        [TestCase(new int[] { 1 }, ExpectedResult = new int[] { 1 })]
        [TestCase(new int[] { 1, 2 }, ExpectedResult = new int[] { 1, 2 })]
        [TestCase(new int[] { 2, 1 }, ExpectedResult = new int[] { 1, 2 })]
        [TestCase(new int[] { 1, 2, 3 }, ExpectedResult = new int[] { 1, 2, 3 })]
        [TestCase(new int[] { 2, 1, 3 }, ExpectedResult = new int[] { 1, 2, 3 })]
        [TestCase(new int[] { 2, 3, 1 }, ExpectedResult = new int[] { 1, 2, 3 })]
        [TestCase(new int[] { 3, 2, 1 }, ExpectedResult = new int[] { 1, 2, 3 })]
        [TestCase(new int[] { 3, 2, 1, 3, 2, 1, 3, 2, 1 }, ExpectedResult = new int[] { 1, 1, 1, 2, 2, 2, 3, 3, 3 })]
        [TestCase(new int[] { 1, 6, 2, 6, 3, 6, 4, 6, 5, 6, 7, 6 }, ExpectedResult = new int[] { 1, 2, 3, 4, 5, 6, 6, 6, 6, 6, 6, 7 })]
        [TestCase(new int[] { 7, 6, 5, 4, 3, 2, 1 }, ExpectedResult = new int[] { 1, 2, 3, 4, 5, 6, 7 })]
        public int[] QuickSort_ArrayIsNotNull_ReturnsSortedArray(int[] array)
        {
            array.QuickSort();

            return array;
        }

        [Test]
        public void RecursiveQuickSort_ArrayIsNull_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => (null as int[]).RecursiveQuickSort());
        }

        [TestCase(new int[] { }, ExpectedResult = new int[] { })]
        [TestCase(new int[] { 1 }, ExpectedResult = new int[] { 1 })]
        [TestCase(new int[] { 1, 2 }, ExpectedResult = new int[] { 1, 2 })]
        [TestCase(new int[] { 2, 1 }, ExpectedResult = new int[] { 1, 2 })]
        [TestCase(new int[] { 1, 2, 3 }, ExpectedResult = new int[] { 1, 2, 3 })]
        [TestCase(new int[] { 2, 1, 3 }, ExpectedResult = new int[] { 1, 2, 3 })]
        [TestCase(new int[] { 2, 3, 1 }, ExpectedResult = new int[] { 1, 2, 3 })]
        [TestCase(new int[] { 3, 2, 1 }, ExpectedResult = new int[] { 1, 2, 3 })]
        [TestCase(new int[] { 3, 2, 1, 3, 2, 1, 3, 2, 1 }, ExpectedResult = new int[] { 1, 1, 1, 2, 2, 2, 3, 3, 3 })]
        [TestCase(new int[] { 1, 6, 2, 6, 3, 6, 4, 6, 5, 6, 7, 6 }, ExpectedResult = new int[] { 1, 2, 3, 4, 5, 6, 6, 6, 6, 6, 6, 7 })]
        [TestCase(new int[] { 7, 6, 5, 4, 3, 2, 1 }, ExpectedResult = new int[] { 1, 2, 3, 4, 5, 6, 7 })]
        public int[] RecursiveQuickSort_ArrayIsNotNull_ReturnsSortedArray(int[] array)
        {
            array.RecursiveQuickSort();

            return array;
        }
    }
}
