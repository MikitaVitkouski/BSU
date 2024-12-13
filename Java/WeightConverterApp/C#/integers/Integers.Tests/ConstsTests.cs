using NUnit.Framework;

namespace Literals.Tests
{
    [TestFixture]
    public class ConstsTests
    {
        [Test]
        public void ReturnLargestInteger_ReturnsInteger()
        {
            // Act
            int result = Consts.ReturnLargestInteger();

            // Assert
            Assert.AreEqual(int.MaxValue, result);
        }

        [Test]
        public void ReturnSmallestInteger_ReturnsInteger()
        {
            // Act
            int result = Consts.ReturnSmallestInteger();

            // Assert
            Assert.AreEqual(int.MinValue, result);
        }

        [Test]
        public void ReturnLargestUnsignedInteger_ReturnsUnsignedInteger()
        {
            // Act
            uint result = Consts.ReturnLargestUnsignedInteger();

            // Assert
            Assert.AreEqual(uint.MaxValue, result);
        }

        [Test]
        public void ReturnSmallestUnsignedInteger_ReturnsUnsignedInteger()
        {
            // Act
            uint result = Consts.ReturnSmallestUnsignedInteger();

            // Assert
            Assert.AreEqual(uint.MinValue, result);
        }

        [Test]
        public void ReturnLargestLongInteger_ReturnsLongInteger()
        {
            // Act
            long result = Consts.ReturnLargestLongInteger();

            // Assert
            Assert.AreEqual(long.MaxValue, result);
        }

        [Test]
        public void ReturnSmallestLongInteger_ReturnsLongInteger()
        {
            // Act
            long result = Consts.ReturnSmallestLongInteger();

            // Assert
            Assert.AreEqual(long.MinValue, result);
        }

        [Test]
        public void ReturnLargestUnsignedLongInteger_ReturnsLongInteger()
        {
            // Act
            ulong result = Consts.ReturnLargestUnsignedLongInteger();

            // Assert
            Assert.AreEqual(ulong.MaxValue, result);
        }

        [Test]
        public void ReturnSmallestUnsignedLongInteger_ReturnsLongInteger()
        {
            // Act
            ulong result = Consts.ReturnSmallestUnsignedLongInteger();

            // Assert
            Assert.AreEqual(ulong.MinValue, result);
        }

        [Test]
        public void ReturnSmallestShortInteger_ReturnsShortInteger()
        {
            // Act
            short result = Consts.ReturnSmallestShortInteger();

            // Assert
            Assert.AreEqual(short.MinValue, result);
        }

        [Test]
        public void ReturnLargestShortInteger_ReturnsShortInteger()
        {
            // Act
            short result = Consts.ReturnLargestShortInteger();

            // Assert
            Assert.AreEqual(short.MaxValue, result);
        }
    }
}
