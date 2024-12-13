using NUnit.Framework;
using static RelocationElements.ArrayExtension;

namespace RelocationElements.Tests
{
    public class ArrayExtensionTests
    {
        [TestCase(new int[] { 1, 2, 3, 4, 5, 3, 2, 3, 1, 3, 4, 5, 1, 5, 0, 7, 6, 5 }, 3, new int[] { 1, 2, 4, 5, 2, 1, 4, 5, 1, 5, 0, 7, 6, 5, 3, 3, 3, 3 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 3, 2, 3, 1, 3, 4, 5, 1, 5, 0, 7, 6, 5 }, 1, new int[] { 2, 3, 4, 5, 3, 2, 3, 3, 4, 5, 5, 0, 7, 6, 5, 1, 1, 1 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 3, 2, 3, 1, 3, 4, 5, 1, 5, 0, 7, 6, 5 }, 5, new int[] { 1, 2, 3, 4, 3, 2, 3, 1, 3, 4, 1, 0, 7, 6, 5, 5, 5, 5 })]
        [TestCase(new int[] { 1, int.MinValue, int.MinValue, int.MaxValue, int.MinValue, -1, -3, -9, 1 }, int.MinValue, new int[] { 1, int.MaxValue, -1, -3, -9, 1, int.MinValue, int.MinValue, int.MinValue })]
        public void MoveToTailTests(int[] source, int value, int[] expected)
        {
            MoveToTail(source, value);
            Assert.AreEqual(expected, source);
        }

        [Test]
        public void MoveToTail_ArrayIsNull_ThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => MoveToTail(null, 1), "Array cannot be null.");
        }

        [Test]
        public void MoveToTail_ArrayIsEmpty_ThrowArgumentException()
        {
            Assert.Throws<ArgumentException>(() => MoveToTail(Array.Empty<int>(), 1), "Array cannot be empty.");
        }
    }
}
