using NUnit.Framework;

namespace IfStatements.Tests
{
    [TestFixture]
    public class Task6Tests
    {
        [TestCase(0, ExpectedResult = 0)]
        [TestCase(1, ExpectedResult = 3)]
        [TestCase(2, ExpectedResult = 8)]
        [TestCase(3, ExpectedResult = 15)]
        [TestCase(4, ExpectedResult = -12)]
        [TestCase(5, ExpectedResult = -20)]
        [TestCase(6, ExpectedResult = -30)]
        [TestCase(7, ExpectedResult = 14)]
        [TestCase(8, ExpectedResult = 16)]
        [TestCase(9, ExpectedResult = 18)]
        [TestCase(10, ExpectedResult = 20)]
        [TestCase(-1, ExpectedResult = -1)]
        [TestCase(-2, ExpectedResult = -6)]
        [TestCase(-3, ExpectedResult = -9)]
        [TestCase(-4, ExpectedResult = -12)]
        [TestCase(-5, ExpectedResult = -15)]
        [TestCase(-6, ExpectedResult = -18)]
        [TestCase(-7, ExpectedResult = -21)]
        [TestCase(-8, ExpectedResult = -24)]
        [TestCase(-9, ExpectedResult = 81)]
        [TestCase(-10, ExpectedResult = 100)]
        public int DoSomething_ReturnsInteger(int i)
        {
            return Task6.DoSomething(i);
        }
    }
}
