global using NUnit.Framework;

namespace Bools.Tests
{
    [TestFixture]
    public class BooleansTests
    {
        [Test]
        public static void ReturnTrue()
        {
            // Act
            var actualResult = Bools.Booleans.ReturnTrue();

            // Assert
            Assert.IsTrue(actualResult);
        }

        [Test]
        public static void ReturnFalse()
        {
            // Act
            var actualResult = Bools.Booleans.ReturnFalse();

            // Assert
            Assert.IsFalse(actualResult);
        }
    }
}
