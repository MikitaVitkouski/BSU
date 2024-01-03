using NUnit.Framework;

namespace RecursionIndexOfChar.Tests
{
    [TestFixture]
    public sealed class GetIndexRecursivelyTests
    {
        [Test]
        public void GetIndexOfChar_NullString_ThrowsException()
        {
            Assert.Throws<ArgumentNullException>(() => GetIndexRecursively.GetIndexOfChar(null, 'a'));
        }

        [TestCase("abcdefghijklmnoprstquvwxyzabcdefghijklmnoprstquvwxyz", 'a', ExpectedResult = 0)]
        [TestCase("abcdefghijklmnoprstquvwxyzabcdefghijklmnoprstquvwxyz", 'b', ExpectedResult = 1)]
        [TestCase("abcdefghijklmnoprstquvwxyzabcdefghijklmnoprstquvwxyz", 'c', ExpectedResult = 2)]
        [TestCase("abcdefghijklmnoprstquvwxyzabcdefghijklmnoprstquvwxyz", 'x', ExpectedResult = 23)]
        [TestCase("abcdefghijklmnoprstquvwxyzabcdefghijklmnoprstquvwxyz", 'y', ExpectedResult = 24)]
        [TestCase("abcdefghijklmnoprstquvwxyzabcdefghijklmnoprstquvwxyz", 'z', ExpectedResult = 25)]
        [TestCase("abcefghijklmnoprstquvwxyzabcefghijklmnoprstquvwxyz", 'd', ExpectedResult = -1)]
        public int GetIndexOfChar_NonEmptyString_ReturnsPosition(string str, char value)
        {
            return GetIndexRecursively.GetIndexOfChar(str, value);
        }

        [Test]
        public void GetIndexOfCharStartIndexCount_NullString_ThrowsException()
        {
            Assert.Throws<ArgumentNullException>(() => GetIndexRecursively.GetIndexOfChar(null, 'a', 0, 0));
        }

        [TestCase("abcdefghijklmnoprstquvwxyzabcdefghijklmnoprstquvwxyz", 'a', 0, 52, ExpectedResult = 0)]
        [TestCase("abcdefghijklmnoprstquvwxyzabcdefghijklmnoprstquvwxyz", 'a', 1, 51, ExpectedResult = 26)]
        [TestCase("abcdefghijklmnoprstquvwxyzabcdefghijklmnoprstquvwxyz", 'a', 1, 26, ExpectedResult = 26)]
        [TestCase("abcdefghijklmnoprstquvwxyzabcdefghijklmnoprstquvwxyz", 'a', 0, 1, ExpectedResult = 0)]
        [TestCase("abcdefghijklmnoprstquvwxyzabcdefghijklmnoprstquvwxyz", 'a', 1, 25, ExpectedResult = -1)]
        [TestCase("abcdefghijklmnoprstquvwxyzabcdefghijklmnoprstquvwxyz", 'a', 26, 1, ExpectedResult = 26)]
        [TestCase("abcdefghijklmnoprstquvwxyzabcdefghijklmnoprstquvwxyz", 'a', 26, 26, ExpectedResult = 26)]
        [TestCase("abcdefghijklmnoprstquvwxyzabcdefghijklmnoprstquvwxyz", 'a', 27, 25, ExpectedResult = -1)]
        [TestCase("abcdefghijklmnoprstquvwxyzabcdefghijklmnoprstquvwxyz", 'b', 0, 52, ExpectedResult = 1)]
        [TestCase("abcdefghijklmnoprstquvwxyzabcdefghijklmnoprstquvwxyz", 'b', 0, 26, ExpectedResult = 1)]
        [TestCase("abcdefghijklmnoprstquvwxyzabcdefghijklmnoprstquvwxyz", 'b', 1, 1, ExpectedResult = 1)]
        [TestCase("abcdefghijklmnoprstquvwxyzabcdefghijklmnoprstquvwxyz", 'b', 1, 51, ExpectedResult = 1)]
        [TestCase("abcdefghijklmnoprstquvwxyzabcdefghijklmnoprstquvwxyz", 'b', 2, 26, ExpectedResult = 27)]
        [TestCase("abcdefghijklmnoprstquvwxyzabcdefghijklmnoprstquvwxyz", 'b', 2, 25, ExpectedResult = -1)]
        [TestCase("abcdefghijklmnoprstquvwxyzabcdefghijklmnoprstquvwxyz", 'b', 27, 25, ExpectedResult = 27)]
        [TestCase("abcdefghijklmnoprstquvwxyzabcdefghijklmnoprstquvwxyz", 'b', 27, 1, ExpectedResult = 27)]
        [TestCase("abcdefghijklmnoprstquvwxyzabcdefghijklmnoprstquvwxyz", 'b', 28, 24, ExpectedResult = -1)]
        [TestCase("abcdefghijklmnoprstquvwxyzabcdefghijklmnoprstquvwxyz", 'c', 0, 52, ExpectedResult = 2)]
        [TestCase("abcdefghijklmnoprstquvwxyzabcdefghijklmnoprstquvwxyz", 'x', 0, 52, ExpectedResult = 23)]
        [TestCase("abcdefghijklmnoprstquvwxyzabcdefghijklmnoprstquvwxyz", 'y', 0, 52, ExpectedResult = 24)]
        [TestCase("abcdefghijklmnoprstquvwxyzabcdefghijklmnoprstquvwxyz", 'z', 0, 52, ExpectedResult = 25)]
        [TestCase("abcefghijklmnoprstquvwxyzabcefghijklmnoprstquvwxyz", 'd', 0, 50, ExpectedResult = -1)]
        public int GetIndexOfCharStartIndexCount_NonEmptyString_ReturnsPosition(string str, char value, int startIndex, int count)
        {
            return GetIndexRecursively.GetIndexOfChar(str, value, startIndex, count);
        }
    }
}
