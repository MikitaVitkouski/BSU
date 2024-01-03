// ReSharper disable IdentifierTypo
global using NUnit.Framework;

namespace StaticMethods.Tests
{
    [TestFixture]
    public class ReturningMethodsTests
    {
        [Test]
        public void ReturnInt_ReturnsInteger()
        {
            // Act
            int actualResult = ReturningMethods.ReturnInt();

            // Assert
            Assert.AreEqual(-1234567, actualResult);
        }

        [Test]
        public void ReturnUnsignedInt_ReturnsUnsignedInteger()
        {
            // Act
            uint actualResult = ReturningMethods.ReturnUnsignedInt();

            // Assert
            Assert.AreEqual(1234567u, actualResult);
        }

        [Test]
        public void ReturnLong_ReturnsLongInteger()
        {
            // Act
            long actualResult = ReturningMethods.ReturnLong();

            // Assert
            Assert.AreEqual(-987654321L, actualResult);
        }

        [Test]
        public void ReturnUnsignedLong_ReturnsUnsignedLongInteger()
        {
            // Act
            ulong actualResult = ReturningMethods.ReturnUnsignedLong();

            // Assert
            Assert.AreEqual(987654321uL, actualResult);
        }

        [Test]
        public void ReturnFloat_ReturnsFloat()
        {
            // Act
            float actualResult = ReturningMethods.ReturnFloat();

            // Assert
            Assert.AreEqual(1234.567f, actualResult);
        }

        [Test]
        public void ReturnDouble_ReturnsDouble()
        {
            // Act
            double actualResult = ReturningMethods.ReturnDouble();

            // Assert
            Assert.AreEqual(-9876.54321, actualResult);
        }

        [Test]
        public void ReturnDecimal_ReturnsDecimal()
        {
            // Act
            decimal actualResult = ReturningMethods.ReturnDecimal();

            // Assert
            Assert.AreEqual(-123456789.987654321m, actualResult);
        }

        [Test]
        public void ReturnString_ReturnsString()
        {
            // Act
            string actualResult = ReturningMethods.ReturnString();

            // Assert
            Assert.AreEqual("Hello, world!", actualResult);
        }

        [Test]
        public void ReturnChar_ReturnsChar()
        {
            // Act
            char actualResult = ReturningMethods.ReturnChar();

            // Assert
            Assert.AreEqual('A', actualResult);
        }

        [Test]
        public void ReturnByte_ReturnsByte()
        {
            // Act
            byte actualResult = ReturningMethods.ReturnByte();

            // Assert
            Assert.AreEqual(0xAB, actualResult);
        }

        [Test]
        public void ReturnBool_ReturnsBool()
        {
            // Act
            bool actualResult = ReturningMethods.ReturnBool();

            // Assert
            Assert.AreEqual(true, actualResult);
        }
    }
}
