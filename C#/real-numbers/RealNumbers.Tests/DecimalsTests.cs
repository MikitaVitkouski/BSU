namespace Literals.Tests
{
    [TestFixture]
    public class DecimalsTests
    {
        [Test]
        public void ReturnDecimal51_ReturnsDecimal()
        {
            // Act
            decimal result = Decimals.ReturnDecimal51();

            // Assert
            Assert.AreEqual(0.0m, result);
        }

        [Test]
        public void ReturnDecimal52_ReturnsDecimal()
        {
            // Act
            decimal result = Decimals.ReturnDecimal52();

            // Assert
            Assert.AreEqual(0.000_000_1m, result);
        }

        [Test]
        public void ReturnDecimal53_ReturnsDecimal()
        {
            // Act
            decimal result = Decimals.ReturnDecimal53();

            // Assert
            Assert.AreEqual(-10_000.000_000_000_1m, result);
        }

        [Test]
        public void ReturnDecimal54_ReturnsDecimal()
        {
            // Act
            decimal result = Decimals.ReturnDecimal54();

            // Assert
            Assert.AreEqual(1_048_294_829_438_549_029_840_452_834.1m, result);
        }

        [Test]
        public void ReturnDecimal55_ReturnsDecimal()
        {
            // Act
            decimal result = Decimals.ReturnDecimal55();

            // Assert
            Assert.AreEqual(-30_492_996_837_502_378_502_387_459_851m, result);
        }

        [Test]
        public void ReturnDecimal56_ReturnsDecimal()
        {
            // Act
            decimal result = Decimals.ReturnDecimal56();

            // Assert
            Assert.AreEqual(0.7m, result);
        }
    }
}
