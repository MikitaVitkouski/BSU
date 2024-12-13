using NUnit.Framework;

namespace IfStatements.Tests
{
    [TestFixture]
    public class Task12Tests
    {
        [TestCase(0, ExpectedResult = 0)]
        [TestCase(1, ExpectedResult = 0)]
        [TestCase(2, ExpectedResult = 2)]
        [TestCase(3, ExpectedResult = 6)]
        [TestCase(4, ExpectedResult = 12)]
        [TestCase(5, ExpectedResult = 5)]
        [TestCase(6, ExpectedResult = 6)]
        [TestCase(7, ExpectedResult = 7)]
        [TestCase(8, ExpectedResult = 8)]
        [TestCase(9, ExpectedResult = 9)]
        [TestCase(10, ExpectedResult = -100)]
        [TestCase(-1, ExpectedResult = 2)]
        [TestCase(-2, ExpectedResult = 6)]
        [TestCase(-3, ExpectedResult = 12)]
        [TestCase(-4, ExpectedResult = 20)]
        [TestCase(-5, ExpectedResult = 30)]
        [TestCase(-6, ExpectedResult = -6)]
        [TestCase(-7, ExpectedResult = -7)]
        [TestCase(-8, ExpectedResult = -8)]
        [TestCase(-9, ExpectedResult = 81)]
        [TestCase(-10, ExpectedResult = 100)]
        public int DoSomething_ReturnsBool(int i)
        {
            return Task12.DoSomething(i);
        }
    }
}
