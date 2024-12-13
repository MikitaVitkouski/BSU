using NUnit.Framework;
using static FilterByPalindromicTask.ArrayExtension;

namespace FilterByPalindromicTask.Tests
{
    [TestFixture]
    public class ArrayExtensionTests
    {
        [TestCase(new[] { 2212332, 0, 1405644, 12345, 1, -1236674, 123321, 1111111 }, ExpectedResult = new[] { 0, 1, 123321, 1111111 })]
        [TestCase(new[] { 1111111112, 987654, -24, 1234654321, 32, 1005 }, ExpectedResult = new int[] { })]
        [TestCase(new[] { -27, 987656789, 7557, int.MaxValue, 7556, 7243, 7243427, int.MinValue }, ExpectedResult = new[] { 987656789, 7557, 7243427 })]
        [TestCase(new[] { 111, 111, 111, 11111111 }, ExpectedResult = new[] { 111, 111, 111, 11111111 })]
        [TestCase(new[] { -1, 0, 111, -11, -1 }, ExpectedResult = new[] { 0, 111 })]
        [TestCase(new[] { 0, 1, 2, 3, 4 }, ExpectedResult = new[] { 0, 1, 2, 3, 4 })]
        public int[] FilterByPalindromic_ReturnNewArray(int[] array)
        {
            return FilterByPalindromic(array);
        }

        [Test]
        public void FilterByPalindromic_ArrayIsEmpty_ThrowArgumentException()
        {
            Assert.Throws<ArgumentException>(() => FilterByPalindromic(Array.Empty<int>()), "Array can not be empty.");
        }

        [Test]
        public void FilterByPalindromic_ArrayIsNull_ThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => FilterByPalindromic(null), "Array can not be null.");
        }

        [Test]
        public void FilterByPalindromic_PerformanceTest()
        {
            int sourceLength = 10_000_000;
            int palindromic = 1234554321;
            int[] source = Enumerable.Repeat(int.MaxValue, sourceLength).ToArray();
            int count = 1_000_000, step = sourceLength / count;
            for (int i = 0; i < sourceLength; i += step)
            {
                source[i] = palindromic;
            }

            int[] expected = Enumerable.Repeat(palindromic, count).ToArray();
            int[] actual = FilterByPalindromic(source);
            CollectionAssert.AreEqual(expected, actual);
        }
    }
}
