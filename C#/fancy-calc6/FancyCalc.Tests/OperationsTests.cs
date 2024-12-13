using NUnit.Framework;

namespace FancyCalc.Tests
{
    [TestFixture]
    public sealed class OperationsTests
    {
        [Test]
        public void Plus_WithOneAndOne_ReturnsTwo()
        {
            var result = Operations.Plus(1, 1);

            Assert.AreEqual(2, result);
        }

        [TestCase(0, 0, ExpectedResult = 0)]
        [TestCase(1, 0, ExpectedResult = 1)]
        [TestCase(0, 1, ExpectedResult = 1)]
        [TestCase(1, 1, ExpectedResult = 2)]
        public int Plus(int x, int y)
        {
            return Operations.Plus(x, y);
        }

        [TestCase(0, 0, ExpectedResult = 0)]
        [TestCase(1, 0, ExpectedResult = 1)]
        [TestCase(0, 1, ExpectedResult = -1)]
        [TestCase(1, 1, ExpectedResult = 0)]
        public int Minus(int x, int y)
        {
            return Operations.Minus(x, y);
        }

        [TestCase(0, 0, ExpectedResult = 0)]
        [TestCase(1, 0, ExpectedResult = 0)]
        [TestCase(0, 1, ExpectedResult = 0)]
        [TestCase(1, 1, ExpectedResult = 1)]
        public int Multiply(int x, int y)
        {
            return Operations.Multiply(x, y);
        }

        [TestCase(0, 0, 0, ExpectedResult = 0)]
        [TestCase(1, 0, 0, ExpectedResult = 1)]
        [TestCase(0, 1, 0, ExpectedResult = 1)]
        [TestCase(0, 0, 1, ExpectedResult = 1)]
        [TestCase(1, 1, 0, ExpectedResult = 2)]
        [TestCase(0, 1, 1, ExpectedResult = 2)]
        [TestCase(1, 1, 1, ExpectedResult = 3)]
        public int Sum(int x1, int x2, int x3)
        {
            return Operations.Sum(x1, x2, x3);
        }
    }
}
