using NUnit.Framework;

namespace IfStatements.Tests
{
    [TestFixture]
    public class Task6Tests
    {
        [TestCase(0, ExpectedResult = 0)]
        [TestCase(1, ExpectedResult = 0)]
        [TestCase(2, ExpectedResult = -2)]
        [TestCase(3, ExpectedResult = -6)]
        [TestCase(4, ExpectedResult = 4)]
        [TestCase(5, ExpectedResult = 5)]
        [TestCase(6, ExpectedResult = 6)]
        [TestCase(7, ExpectedResult = 7)]
        [TestCase(8, ExpectedResult = 8)]
        [TestCase(9, ExpectedResult = 9)]
        [TestCase(10, ExpectedResult = 10)]
        [TestCase(-1, ExpectedResult = -3)]
        [TestCase(-2, ExpectedResult = -6)]
        [TestCase(-3, ExpectedResult = -9)]
        [TestCase(-4, ExpectedResult = -4)]
        [TestCase(-5, ExpectedResult = -5)]
        [TestCase(-6, ExpectedResult = -6)]
        [TestCase(-7, ExpectedResult = -7)]
        [TestCase(-8, ExpectedResult = -8)]
        [TestCase(-9, ExpectedResult = -9)]
        [TestCase(-10, ExpectedResult = -10)]
        public int DoSomething_ReturnsInteger(int i)
        {
            return Task6.DoSomething(i);
        }
    }
}
