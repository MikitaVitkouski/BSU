using NUnit.Framework;

namespace IfStatements.Tests
{
    [TestFixture]
    public class Task2Tests
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
        [TestCase(-1, ExpectedResult = 1)]
        [TestCase(-2, ExpectedResult = 2)]
        [TestCase(-3, ExpectedResult = 3)]
        [TestCase(-4, ExpectedResult = 4)]
        [TestCase(-5, ExpectedResult = 5)]
        [TestCase(-6, ExpectedResult = -36)]
        [TestCase(-7, ExpectedResult = -49)]
        [TestCase(-8, ExpectedResult = -64)]
        [TestCase(-9, ExpectedResult = -81)]
        [TestCase(-10, ExpectedResult = -100)]
        public int DoSomething1_ReturnsInteger(int i)
        {
            return Task2.DoSomething1(i);
        }

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
        [TestCase(-1, ExpectedResult = 1)]
        [TestCase(-2, ExpectedResult = 2)]
        [TestCase(-3, ExpectedResult = 3)]
        [TestCase(-4, ExpectedResult = 4)]
        [TestCase(-5, ExpectedResult = 5)]
        [TestCase(-6, ExpectedResult = -36)]
        [TestCase(-7, ExpectedResult = -49)]
        [TestCase(-8, ExpectedResult = -64)]
        [TestCase(-9, ExpectedResult = -81)]
        [TestCase(-10, ExpectedResult = -100)]
        public int DoSomething2_ReturnsInteger(int i)
        {
            return Task2.DoSomething2(i);
        }
    }
}
