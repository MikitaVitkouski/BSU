using NUnit.Framework;

namespace IfStatements.Tests
{
    [TestFixture]
    public class Task1Tests
    {
        [TestCase(0, ExpectedResult = 0)]
        [TestCase(1, ExpectedResult = 1)]
        [TestCase(2, ExpectedResult = 2)]
        [TestCase(3, ExpectedResult = 3)]
        [TestCase(4, ExpectedResult = 4)]
        [TestCase(5, ExpectedResult = 5)]
        [TestCase(6, ExpectedResult = 6)]
        [TestCase(7, ExpectedResult = 7)]
        [TestCase(8, ExpectedResult = 8)]
        [TestCase(9, ExpectedResult = 9)]
        [TestCase(10, ExpectedResult = 10)]
        [TestCase(-1, ExpectedResult = 0)]
        [TestCase(-2, ExpectedResult = 0)]
        [TestCase(-3, ExpectedResult = 0)]
        [TestCase(-4, ExpectedResult = 0)]
        [TestCase(-5, ExpectedResult = 0)]
        [TestCase(-6, ExpectedResult = 0)]
        [TestCase(-7, ExpectedResult = 0)]
        [TestCase(-8, ExpectedResult = 0)]
        [TestCase(-9, ExpectedResult = 0)]
        [TestCase(-10, ExpectedResult = 0)]
        public int DoSomething_ReturnsInteger(int i)
        {
            return Task1.DoSomething(i);
        }
    }
}
