using NUnit.Framework;

namespace CompilerErrors.Tests
{
    [TestFixture]
    public class CompilerErrorsTests
    {
        [Test]
        public void CS0103_MyMethod_ReturnsInteger()
        {
            // Act
            int actualResult = CS0103.MyClass.MyMethod();

            // Assert
            Assert.AreEqual(534_947_886, actualResult);
        }

        [Test]
        public void CS0117_MyMethod_ReturnsInteger()
        {
            // Act
            long actualResult = CS0117.MyClass.MyMethod();

            // Assert
            Assert.AreEqual(49_023_471L, actualResult);
        }

        [Test]
        public void CS1501_MyMethod_ReturnsInteger()
        {
            // Act
            int actualResult = CS1501.MyClass.MyMethod();

            // Assert
            Assert.AreEqual(1_785_394, actualResult);
        }

        [Test]
        public void CS1739_MyMethod_ReturnsInteger()
        {
            // Act
            int actualResult = CS1739.MyClass.MyMethod();

            // Assert
            Assert.AreEqual(9_389_572, actualResult);
        }

        [Test]
        public void CS7036_MyMethod_ReturnsInteger()
        {
            // Act
            int actualResult = CS7036.MyClass.MyMethod();

            // Assert
            Assert.AreEqual(5_689_375, actualResult);
        }
    }
}
