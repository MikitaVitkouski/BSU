using NUnit.Framework;

namespace IfStatements.Tests
{
    [TestFixture]
    public class Task2Tests
    {
        [TestCase(true, true, ExpectedResult = 123)]
        [TestCase(true, false, ExpectedResult = -345)]
        [TestCase(false, true, ExpectedResult = -567)]
        [TestCase(false, false, ExpectedResult = 789)]
        public int DoSomething1_ReturnsInteger(bool b1, bool b2)
        {
            return Task2.DoSomething1(b1, b2);
        }

        [TestCase(true, true, ExpectedResult = 123)]
        [TestCase(true, false, ExpectedResult = -345)]
        [TestCase(false, true, ExpectedResult = -567)]
        [TestCase(false, false, ExpectedResult = 789)]
        public int DoSomething2_ReturnsInteger(bool b1, bool b2)
        {
            return Task2.DoSomething2(b1, b2);
        }
    }
}
