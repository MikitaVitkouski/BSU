using NUnit.Framework;

namespace IfStatements.Tests
{
    [TestFixture]
    public class Task1Tests
    {
        [TestCase(true, ExpectedResult = 123)]
        [TestCase(false, ExpectedResult = -123)]
        public int DoSomething_ReturnsInteger(bool b)
        {
            return Task1.DoSomething(b);
        }
    }
}
