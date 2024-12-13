using NUnit.Framework;

namespace Sequences.Tests
{
    [TestFixture]
    public class SequencesTests
    {
        [TestCase("1", 1, new[] { "1" })]
        [TestCase("12", 1, new[] { "1", "2" })]
        [TestCase("35", 2, new[] { "35" })]
        [TestCase("9142", 2, new[] { "91", "14", "42" })]
        [TestCase("777777", 3, new[] { "777", "777", "777", "777" })]
        [TestCase("918493904243", 5, new[] { "91849", "18493", "84939", "49390", "93904", "39042", "90424", "04243" })]
        public void GetSubstringsTests(string numbers, int sliceLength, string[] expected)
        {
            Assert.AreEqual(expected, Sequences.GetSubstrings(numbers, sliceLength));
        }

        [Test]
        public void GetSubstrings_StringContainsNonDigitCharacter_ThrowArgumentException()
        {
            Assert.Throws<ArgumentException>(() => Sequences.GetSubstrings("123a", 1));
        }

        [Test]
        public void GetSubstrings_LengthOfSubstringIsTooLarge_ThrowArgumentException()
        {
            Assert.Throws<ArgumentException>(() => Sequences.GetSubstrings("12345", 6));
        }

        [Test]
        public void GetSubstrings_LengthOfSubstringIsZero_ThrowArgumentException()
        {
            Assert.Throws<ArgumentException>(() => Sequences.GetSubstrings("12345", 0));
        }

        [Test]
        public void GetSubstrings_LengthOfSubstringIsNegative_ThrowArgumentException()
        {
            Assert.Throws<ArgumentException>(() => Sequences.GetSubstrings("123", -1));
        }

        [Test]
        public void GetSubstrings_LengthIsEmpty_ThrowArgumentException()
        {
            Assert.Throws<ArgumentException>(() => Sequences.GetSubstrings(string.Empty, 1));
        }

        [Test]
        public void GetSubstrings_LengthIsNull_ThrowArgumentException()
        {
            Assert.Throws<ArgumentException>(() => Sequences.GetSubstrings(string.Empty, 1));
        }

        [Test]
        public void GetSubstrings_LengthIsWhiteSpace_ThrowArgumentException()
        {
            Assert.Throws<ArgumentException>(() => Sequences.GetSubstrings("    ", 1));
        }
    }
}
