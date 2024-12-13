using NUnit.Framework;

namespace IfStatements.Tests
{
    [TestFixture]
    public class Task3Tests
    {
        [TestCase(true, ExpectedResult = false)]
        [TestCase(false, ExpectedResult = true)]
        public bool DoSomething1_ReturnsBool(bool b)
        {
            return Task3.DoSomething1(b);
        }

        [TestCase(true, ExpectedResult = false)]
        [TestCase(false, ExpectedResult = true)]
        public bool DoSomething2_ReturnsBool(bool b)
        {
            return Task3.DoSomething2(b);
        }
    }
}
