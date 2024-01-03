using NUnit.Framework;

namespace IfStatements.Tests
{
    [TestFixture]
    public class Task5Tests
    {
        [TestCase(false, false, false, false, ExpectedResult = 11)]
        [TestCase(true, false, false, false, ExpectedResult = 0)]
        [TestCase(false, true, false, false, ExpectedResult = 8)]
        [TestCase(true, true, false, false, ExpectedResult = 1)]
        [TestCase(false, false, true, false, ExpectedResult = 5)]
        [TestCase(true, false, true, false, ExpectedResult = 2)]
        [TestCase(false, true, true, false, ExpectedResult = 4)]
        [TestCase(true, true, true, false, ExpectedResult = 1)]
        [TestCase(false, false, false, true, ExpectedResult = 10)]
        [TestCase(true, false, false, true, ExpectedResult = 3)]
        [TestCase(false, true, false, true, ExpectedResult = 9)]
        [TestCase(true, true, false, true, ExpectedResult = 1)]
        [TestCase(false, false, true, true, ExpectedResult = 6)]
        [TestCase(true, false, true, true, ExpectedResult = 2)]
        [TestCase(false, true, true, true, ExpectedResult = 7)]
        [TestCase(true, true, true, true, ExpectedResult = 1)]
        public int DoSomething1_ReturnsInteger(bool b1, bool b2, bool b3, bool b4)
        {
            return Task5.DoSomething1(b1, b2, b3, b4);
        }

        [TestCase(false, false, false, false, ExpectedResult = 11)]
        [TestCase(true, false, false, false, ExpectedResult = 0)]
        [TestCase(false, true, false, false, ExpectedResult = 8)]
        [TestCase(true, true, false, false, ExpectedResult = 1)]
        [TestCase(false, false, true, false, ExpectedResult = 5)]
        [TestCase(true, false, true, false, ExpectedResult = 2)]
        [TestCase(false, true, true, false, ExpectedResult = 4)]
        [TestCase(true, true, true, false, ExpectedResult = 1)]
        [TestCase(false, false, false, true, ExpectedResult = 10)]
        [TestCase(true, false, false, true, ExpectedResult = 3)]
        [TestCase(false, true, false, true, ExpectedResult = 9)]
        [TestCase(true, true, false, true, ExpectedResult = 1)]
        [TestCase(false, false, true, true, ExpectedResult = 6)]
        [TestCase(true, false, true, true, ExpectedResult = 2)]
        [TestCase(false, true, true, true, ExpectedResult = 7)]
        [TestCase(true, true, true, true, ExpectedResult = 1)]
        public int DoSomething2_ReturnsInteger(bool b1, bool b2, bool b3, bool b4)
        {
            return Task5.DoSomething2(b1, b2, b3, b4);
        }
    }
}
