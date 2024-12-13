using NUnit.Framework;

namespace RecursionIndexOfChar.Tests
{
    [TestFixture]
    public sealed class GetLastItemRecursivelyTests
    {
        [Test]
        public void GetLastIndexOfChar_NullString_ThrowsException()
        {
            Assert.Throws<ArgumentNullException>(() => GetLastIndexRecursively.GetLastIndexOfChar(null, 'a'));
        }

        [TestCase("", 'a', ExpectedResult = -1)]
        [TestCase("abcdefghijklmnoprstquvwxyzabcdefghijklmnoprstquvwxyz", 'a', ExpectedResult = 26)]
        [TestCase("abcdefghijklmnoprstquvwxyzabcdefghijklmnoprstquvwxyz", 'b', ExpectedResult = 27)]
        [TestCase("abcdefghijklmnoprstquvwxyzabcdefghijklmnoprstquvwxyz", 'c', ExpectedResult = 28)]
        [TestCase("abcdefghijklmnoprstquvwxyzabcdefghijklmnoprstquvwxyz", 'x', ExpectedResult = 49)]
        [TestCase("abcdefghijklmnoprstquvwxyzabcdefghijklmnoprstquvwxyz", 'y', ExpectedResult = 50)]
        [TestCase("abcdefghijklmnoprstquvwxyzabcdefghijklmnoprstquvwxyz", 'z', ExpectedResult = 51)]
        [TestCase("abcefghijklmnoprstquvwxyzabcefghijklmnoprstquvwxyz", 'd', ExpectedResult = -1)]
        public int GetLastIndexOfChar_NonEmptyString_ReturnsPosition(string str, char value)
        {
            return GetLastIndexRecursively.GetLastIndexOfChar(str, value);
        }

        [Test]
        public void GetLastIndexOfCharStartIndexCount_NullString_ThrowsException()
        {
            Assert.Throws<ArgumentNullException>(() => GetLastIndexRecursively.GetLastIndexOfChar(null, 'a', 0, 0));
        }

        [TestCase("", 'a', 0, 0, ExpectedResult = -1)]
        [TestCase("abcdefghijklmnoprstquvwxyzabcdefghijklmnoprstquvwxyz", 'a', 0, 52, ExpectedResult = 26)]
        [TestCase("abcdefghijklmnoprstquvwxyzabcdefghijklmnoprstquvwxyz", 'a', 0, 26, ExpectedResult = 0)]
        [TestCase("abcdefghijklmnoprstquvwxyzabcdefghijklmnoprstquvwxyz", 'a', 1, 26, ExpectedResult = 26)]
        [TestCase("abcdefghijklmnoprstquvwxyzabcdefghijklmnoprstquvwxyz", 'a', 26, 1, ExpectedResult = 26)]
        [TestCase("abcdefghijklmnoprstquvwxyzabcdefghijklmnoprstquvwxyz", 'a', 26, 26, ExpectedResult = 26)]
        [TestCase("abcdefghijklmnoprstquvwxyzabcdefghijklmnoprstquvwxyz", 'a', 1, 25, ExpectedResult = -1)]
        [TestCase("abcdefghijklmnoprstquvwxyzabcdefghijklmnoprstquvwxyz", 'a', 27, 25, ExpectedResult = -1)]
        [TestCase("abcdefghijklmnoprstquvwxyzabcdefghijklmnoprstquvwxyz", 'b', 0, 52, ExpectedResult = 27)]
        [TestCase("abcdefghijklmnoprstquvwxyzabcdefghijklmnoprstquvwxyz", 'b', 1, 25, ExpectedResult = 1)]
        [TestCase("abcdefghijklmnoprstquvwxyzabcdefghijklmnoprstquvwxyz", 'b', 2, 26, ExpectedResult = 27)]
        [TestCase("abcdefghijklmnoprstquvwxyzabcdefghijklmnoprstquvwxyz", 'b', 27, 1, ExpectedResult = 27)]
        [TestCase("abcdefghijklmnoprstquvwxyzabcdefghijklmnoprstquvwxyz", 'b', 27, 25, ExpectedResult = 27)]
        [TestCase("abcdefghijklmnoprstquvwxyzabcdefghijklmnoprstquvwxyz", 'b', 2, 25, ExpectedResult = -1)]
        [TestCase("abcdefghijklmnoprstquvwxyzabcdefghijklmnoprstquvwxyz", 'b', 28, 24, ExpectedResult = -1)]
        [TestCase("abcdefghijklmnoprstquvwxyzabcdefghijklmnoprstquvwxyz", 'c', 0, 52, ExpectedResult = 28)]
        [TestCase("abcdefghijklmnoprstquvwxyzabcdefghijklmnoprstquvwxyz", 'x', 0, 52, ExpectedResult = 49)]
        [TestCase("abcdefghijklmnoprstquvwxyzabcdefghijklmnoprstquvwxyz", 'y', 0, 52, ExpectedResult = 50)]
        [TestCase("abcdefghijklmnoprstquvwxyzabcdefghijklmnoprstquvwxyz", 'z', 0, 52, ExpectedResult = 51)]
        [TestCase("abcdefghijklmnoprstquvwxyzabcdefghijklmnoprstquvwxyz", 'z', 0, 51, ExpectedResult = 25)]
        [TestCase("abcdefghijklmnoprstquvwxyzabcdefghijklmnoprstquvwxyz", 'z', 0, 26, ExpectedResult = 25)]
        [TestCase("abcdefghijklmnoprstquvwxyzabcdefghijklmnoprstquvwxyz", 'z', 0, 25, ExpectedResult = -1)]
        [TestCase("abcefghijklmnoprstquvwxyzabcefghijklmnoprstquvwxyz", 'd', 0, 50, ExpectedResult = -1)]
        public int GetLastIndexOfCharStartIndexCount_NonEmptyString_ReturnsPosition(string str, char value, int startIndex, int count)
        {
            return GetLastIndexRecursively.GetLastIndexOfChar(str, value, startIndex, count);
        }
    }
}
