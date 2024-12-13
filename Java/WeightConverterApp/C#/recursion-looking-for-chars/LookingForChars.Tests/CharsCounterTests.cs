using NUnit.Framework;

// ReSharper disable StringLiteralTypo
namespace LookingForChars.Tests
{
    [TestFixture]
    public class CharsCounterTests
    {
        [Test]
        public void GetCharsCount_StrParameterIsNull_ThrowsException()
        {
            // Act
            Assert.Throws<ArgumentNullException>(() => CharsCounter.GetCharsCount(null, null));
        }

        [Test]
        public void GetCharsCount_CharsParameterIsNull_ThrowsException()
        {
            // Act
            Assert.Throws<ArgumentNullException>(() => CharsCounter.GetCharsCount(string.Empty, null));
        }

        [TestCase("", new char[] { }, ExpectedResult = 0)]
        [TestCase("abcdef", new char[] { 'a' }, ExpectedResult = 1)]
        [TestCase("abcdef", new char[] { 'a', 'e' }, ExpectedResult = 2)]
        [TestCase("abcdefabcdef", new char[] { 'a' }, ExpectedResult = 2)]
        [TestCase("abcdefabcdef", new char[] { 'a', 'e' }, ExpectedResult = 4)]
        public int GetCharsCount_ParametersAreValid_ReturnsResult(string str, char[] chars)
        {
            // Act
            return CharsCounter.GetCharsCount(str, chars);
        }

        [Test]
        public void GetCharsCountStartIndexEndIndex_StrParameterIsNull_ThrowsException()
        {
            // Act
            Assert.Throws<ArgumentNullException>(() => CharsCounter.GetCharsCount(null, null, 0, 0));
        }

        [Test]
        public void GetCharsCountStartIndexEndIndex_CharsParameterIsNull_ThrowsException()
        {
            // Act
            Assert.Throws<ArgumentNullException>(() => CharsCounter.GetCharsCount(string.Empty, null, 0, 0));
        }

        [Test]
        public void GetCharsCountStartIndexEndIndex_StartIndexLessZero_ThrowsException()
        {
            // Act
            Assert.Throws<ArgumentOutOfRangeException>(() => CharsCounter.GetCharsCount(string.Empty, new char[] { 'a' }, -1, 0));
        }

        [Test]
        public void GetCharsCountStartIndexEndIndex_StartIndexGreaterStringLength_ThrowsException()
        {
            // Act
            Assert.Throws<ArgumentOutOfRangeException>(() => CharsCounter.GetCharsCount(string.Empty, new char[] { 'a' }, 1, 0));
        }

        [Test]
        public void GetCharsCountStartIndexEndIndex_EndIndexLessZero_ThrowsException()
        {
            // Act
            Assert.Throws<ArgumentOutOfRangeException>(() => CharsCounter.GetCharsCount(string.Empty, new char[] { 'a' }, 0, -1));
        }

        [Test]
        public void GetCharsCountStartIndexEndIndex_EndIndexGreaterStringLength_ThrowsException()
        {
            // Act
            Assert.Throws<ArgumentOutOfRangeException>(() => CharsCounter.GetCharsCount(string.Empty, new char[] { 'a' }, 0, 1));
        }

        [Test]
        public void GetCharsCountStartIndexEndIndex_StartIndexGreaterEndIndex_ThrowsException()
        {
            // Act
            Assert.Throws<ArgumentOutOfRangeException>(() => CharsCounter.GetCharsCount("aa", new char[] { 'a' }, 1, 0));
        }

        [TestCase("abcdefabcdef", new char[] { 'a', 'e' }, 0, 5, ExpectedResult = 2)]
        [TestCase("abcdefghabcdefgh", new char[] { 'a', 'e', 'h' }, 9, 15, ExpectedResult = 2)]
        [TestCase("abcdefghijklmnabcdefghijklmn", new char[] { 'a', 'b', 'c', 'k', 'l', 'm' }, 5, 15, ExpectedResult = 5)]
        [TestCase("abcdefghijklmnabcdefghijklmn", new char[] { 'a', 'c', 'd', 'l' }, 26, 27, ExpectedResult = 0)]
        [TestCase("abcdefghijklmnabcdefghijklmn", new char[] { 'a', 'c', 'd', 'l', 'm' }, 1, 16, ExpectedResult = 6)]
        public int GetCharsCount_ParametersAreValid_ReturnsResult(string str, char[] chars, int startIndex, int endIndex)
        {
            // Act
            return CharsCounter.GetCharsCount(str, chars, startIndex, endIndex);
        }

        [Test]
        public void GetCharsCountStartIndexEndIndexLimit_StrParameterIsNull_ThrowsException()
        {
            // Act
            Assert.Throws<ArgumentNullException>(() => CharsCounter.GetCharsCount(null, null, 0, 0, 0));
        }

        [Test]
        public void GetCharsCountStartIndexEndIndexLimit_CharsParameterIsNull_ThrowsException()
        {
            // Act
            Assert.Throws<ArgumentNullException>(() => CharsCounter.GetCharsCount(string.Empty, null, 0, 0, 0));
        }

        [Test]
        public void GetCharsCountStartIndexEndIndexLimit_StartIndexLessZero_ThrowsException()
        {
            // Act
            Assert.Throws<ArgumentOutOfRangeException>(() => CharsCounter.GetCharsCount(string.Empty, new char[] { 'a' }, -1, 0, 0));
        }

        [Test]
        public void GetCharsCountStartIndexEndIndexLimit_StartIndexGreaterStringLength_ThrowsException()
        {
            // Act
            Assert.Throws<ArgumentOutOfRangeException>(() => CharsCounter.GetCharsCount(string.Empty, new char[] { 'a' }, 1, 0, 0));
        }

        [Test]
        public void GetCharsCountStartIndexEndIndexLimit_EndIndexLessZero_ThrowsException()
        {
            // Act
            Assert.Throws<ArgumentOutOfRangeException>(() => CharsCounter.GetCharsCount(string.Empty, new char[] { 'a' }, 0, -1, 0));
        }

        [Test]
        public void GetCharsCountStartIndexEndIndexLimit_EndIndexGreaterStringLength_ThrowsException()
        {
            // Act
            Assert.Throws<ArgumentOutOfRangeException>(() => CharsCounter.GetCharsCount(string.Empty, new char[] { 'a' }, 0, 1, 0));
        }

        [Test]
        public void GetCharsCountStartIndexEndIndexLimit_StartIndexGreaterEndIndex_ThrowsException()
        {
            // Act
            Assert.Throws<ArgumentOutOfRangeException>(() => CharsCounter.GetCharsCount("aa", new char[] { 'a' }, 1, 0, 0));
        }

        [Test]
        public void GetCharsCountStartIndexEndIndexLimit_LimitLessZero_ThrowsException()
        {
            // Act
            Assert.Throws<ArgumentOutOfRangeException>(() => CharsCounter.GetCharsCount("aa", new char[] { 'a' }, 0, 1, -1));
        }

        [TestCase("abcdefabcdef", new char[] { 'a', 'e' }, 0, 11, 3, ExpectedResult = 3)]
        [TestCase("abcdefabcdef", new char[] { 'a', 'e' }, 0, 11, 4, ExpectedResult = 4)]
        [TestCase("abcdefghabcdefgh", new char[] { 'a', 'e', 'h' }, 7, 15, 2, ExpectedResult = 2)]
        [TestCase("abcdefghijklmnabcdefghijklmn", new char[] { 'a', 'b', 'c', 'k', 'l', 'm' }, 5, 20, 5, ExpectedResult = 5)]
        [TestCase("abcdefghijklmnabcdefghijklmn", new char[] { 'a', 'c', 'd', 'l' }, 26, 27, 1, ExpectedResult = 0)]
        [TestCase("abcdefghijklmnabcdefghijklmn", new char[] { 'a', 'c', 'd', 'l', 'm' }, 1, 16, 7, ExpectedResult = 6)]
        public int GetCharsCount_ParametersAreValid_ReturnsResult(string str, char[] chars, int startIndex, int endIndex, int limit)
        {
            // Act
            return CharsCounter.GetCharsCount(str, chars, startIndex, endIndex, limit);
        }
    }
}
