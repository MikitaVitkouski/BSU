using NUnit.Framework;
using static PalindromicNumberTask.NumbersExtension;

namespace PalindromicNumberTask.Tests
{
    public class NumbersExtensionTests
    {
        [TestCase(0, ExpectedResult = true)]
        [TestCase(1, ExpectedResult = true)]
        [TestCase(123321, ExpectedResult = true)]
        [TestCase(1233321, ExpectedResult = true)]
        [TestCase(1111111, ExpectedResult = true)]
        [TestCase(123321, ExpectedResult = true)]
        [TestCase(1233321, ExpectedResult = true)]
        [TestCase(1111111, ExpectedResult = true)]
        [TestCase(987656789, ExpectedResult = true)]
        public bool IsPalindromicNumber_ReturnsTrue(int number)
        {
            return IsPalindromicNumber(number);
        }

        [TestCase(int.MaxValue, ExpectedResult = false)]
        [TestCase(12345, ExpectedResult = false)]
        [TestCase(987654, ExpectedResult = false)]
        [TestCase(2778, ExpectedResult = false)]
        [TestCase(1111111112, ExpectedResult = false)]
        [TestCase(1234654321, ExpectedResult = false)]
        public bool IsPalindromicNumber_ReturnsFalse(int number)
        {
            return IsPalindromicNumber(number);
        }

        [Test]
        public void IsPalindromicNumber_IfNumberIsLessThanZero_ThrowArgumentException()
        {
            Assert.Throws<ArgumentException>(() => IsPalindromicNumber(-1234654321), message: "number cannot be less than zero");
        }

        [Test]
        [Order(2)]
        [Timeout(1000)]
        public void IsPalindromicNumber_PossiblyVerySlowWorksWithTimeLessThan1000Milliseconds()
        {
            for (int source = 0; source < 1_000_000; source++)
            {
                IsPalindromicNumber(source);
            }
        }

        [Test]
        [Order(1)]
        [Timeout(2_500)]
        public void IsPalindromicNumber_PossiblyVerySlowWorksWithTimeLessThan2500Milliseconds()
        {
            for (int source = 0; source < 10_000_000; source++)
            {
                IsPalindromicNumber(source);
            }
        }
    }
}
