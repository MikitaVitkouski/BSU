namespace Literals.Tests
{
    [TestFixture]
    public class DoublesTests
    {
        [Test]
        public void ReturnDouble41_ReturnsDouble()
        {
            // Act
            double result = Doubles.ReturnDouble41();

            // Assert
            Assert.AreEqual(0.0, result);
        }

        [Test]
        public void ReturnDouble42_ReturnsDouble()
        {
            // Act
            double result = Doubles.ReturnDouble42();

            // Assert
            Assert.AreEqual(1E-4, result);
        }

        [Test]
        public void ReturnDouble43_ReturnsDouble()
        {
            // Act
            double result = Doubles.ReturnDouble43();

            // Assert
            Assert.AreEqual(-10000.0000000001, result);
        }

        [Test]
        public void ReturnDouble44_ReturnsDouble()
        {
            // Act
            double result = Doubles.ReturnDouble44();

            // Assert
            Assert.AreEqual(1.0482948294385491E+27, result);
        }

        [Test]
        public void ReturnDouble45_ReturnsDouble()
        {
            // Act
            double result = Doubles.ReturnDouble45();

            // Assert
            Assert.AreEqual(-3.049299683750238E+31, result);
        }

        [Test]
        public void ReturnDouble46_ReturnsDouble()
        {
            // Act
            double result = Doubles.ReturnDouble46();

            // Assert
            Assert.AreEqual(0.7, result);
        }
    }
}
