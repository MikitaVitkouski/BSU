using NUnit.Framework;

[assembly: CLSCompliant(false)]

namespace Literals.Tests
{
    [TestFixture]
    public class IntegersTests
    {
        [Test]
        public void ReturnInteger11_ReturnsInteger()
        {
            // Act
            int result = Integers.ReturnInteger11();

            // Assert
            Assert.AreEqual(0, result);
        }

        [Test]
        public void ReturnInteger12_ReturnsInteger()
        {
            // Act
            int result = Integers.ReturnInteger12();

            // Assert
            Assert.AreEqual(1, result);
        }

        [Test]
        public void ReturnInteger13_ReturnsInteger()
        {
            // Act
            int result = Integers.ReturnInteger13();

            // Assert
            Assert.AreEqual(-1, result);
        }

        [Test]
        public void ReturnInteger14_ReturnsInteger()
        {
            // Act
            int result = Integers.ReturnInteger14();

            // Assert
            Assert.AreEqual(2_147_483_647, result);
        }

        [Test]
        public void ReturnInteger15_ReturnsInteger()
        {
            // Act
            int result = Integers.ReturnInteger15();

            // Assert
            Assert.AreEqual(-2_147_483_648, result);
        }

        [Test]
        public void ReturnInteger16_ReturnsInteger()
        {
            // Act
            uint result = Integers.ReturnInteger16();

            // Assert
            Assert.AreEqual(1u, result);
        }

        [Test]
        public void ReturnInteger17_ReturnsInteger()
        {
            // Act
            uint result = Integers.ReturnInteger17();

            // Assert
            Assert.AreEqual(32_767u, result);
        }

        [Test]
        public void ReturnInteger18_ReturnsInteger()
        {
            // Act
            uint result = Integers.ReturnInteger18();

            // Assert
            Assert.AreEqual(2_147_483_647u, result);
        }
    }
}
