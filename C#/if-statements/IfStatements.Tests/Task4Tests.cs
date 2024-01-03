using NUnit.Framework;

namespace IfStatements.Tests
{
    [TestFixture]
    public class Task4Tests
    {
        [TestCase(true, true, ExpectedResult = false)]
        [TestCase(false, true, ExpectedResult = true)]
        [TestCase(true, false, ExpectedResult = true)]
        [TestCase(false, false, ExpectedResult = false)]
        public bool DoSomething1_ReturnsBool(bool b1, bool b2)
        {
            return Task4.DoSomething1(b1, b2);
        }

        [TestCase(true, true, ExpectedResult = false)]
        [TestCase(false, true, ExpectedResult = true)]
        [TestCase(true, false, ExpectedResult = true)]
        [TestCase(false, false, ExpectedResult = false)]
        public bool DoSomething2_ReturnsBool(bool b1, bool b2)
        {
            return Task4.DoSomething2(b1, b2);
        }
    }
}
