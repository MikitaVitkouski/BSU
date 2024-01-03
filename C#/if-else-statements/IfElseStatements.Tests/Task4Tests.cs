using NUnit.Framework;

namespace IfStatements.Tests
{
    [TestFixture]
    public class Task4Tests
    {
        [TestCase(false, false, false, false, ExpectedResult = 5)]
        [TestCase(true, false, false, false, ExpectedResult = 2)]
        [TestCase(false, true, false, false, ExpectedResult = 5)]
        [TestCase(true, true, false, false, ExpectedResult = 2)]
        [TestCase(false, false, true, false, ExpectedResult = 6)]
        [TestCase(true, false, true, false, ExpectedResult = 3)]
        [TestCase(false, true, true, false, ExpectedResult = 6)]
        [TestCase(true, true, true, false, ExpectedResult = 2)]
        [TestCase(false, false, false, true, ExpectedResult = 8)]
        [TestCase(true, false, false, true, ExpectedResult = 1)]
        [TestCase(false, true, false, true, ExpectedResult = 5)]
        [TestCase(true, true, false, true, ExpectedResult = 1)]
        [TestCase(false, false, true, true, ExpectedResult = 7)]
        [TestCase(true, false, true, true, ExpectedResult = 4)]
        [TestCase(false, true, true, true, ExpectedResult = 6)]
        [TestCase(true, true, true, true, ExpectedResult = 1)]
        public int DoSomething_ReturnsInteger(bool b1, bool b2, bool b3, bool b4)
        {
            return Task4.DoSomething(b1, b2, b3, b4);
        }
    }
}
