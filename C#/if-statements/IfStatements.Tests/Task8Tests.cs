using NUnit.Framework;

namespace IfStatements.Tests
{
    [TestFixture]
    public class Task8Tests
    {
        [TestCase(true, 0, ExpectedResult = false)]
        [TestCase(true, 1, ExpectedResult = true)]
        [TestCase(true, 2, ExpectedResult = true)]
        [TestCase(true, 3, ExpectedResult = true)]
        [TestCase(true, 4, ExpectedResult = false)]
        [TestCase(true, 5, ExpectedResult = false)]
        [TestCase(true, 6, ExpectedResult = false)]
        [TestCase(true, 7, ExpectedResult = true)]
        [TestCase(true, 8, ExpectedResult = true)]
        [TestCase(true, 9, ExpectedResult = true)]
        [TestCase(true, 10, ExpectedResult = true)]
        [TestCase(true, -1, ExpectedResult = true)]
        [TestCase(true, -2, ExpectedResult = true)]
        [TestCase(true, -3, ExpectedResult = true)]
        [TestCase(true, -4, ExpectedResult = false)]
        [TestCase(true, -5, ExpectedResult = false)]
        [TestCase(true, -6, ExpectedResult = false)]
        [TestCase(true, -7, ExpectedResult = true)]
        [TestCase(true, -8, ExpectedResult = true)]
        [TestCase(true, -9, ExpectedResult = true)]
        [TestCase(true, -10, ExpectedResult = true)]
        [TestCase(false, 0, ExpectedResult = false)]
        [TestCase(false, 1, ExpectedResult = true)]
        [TestCase(false, 2, ExpectedResult = true)]
        [TestCase(false, 3, ExpectedResult = false)]
        [TestCase(false, 4, ExpectedResult = false)]
        [TestCase(false, 5, ExpectedResult = false)]
        [TestCase(false, 6, ExpectedResult = false)]
        [TestCase(false, 7, ExpectedResult = true)]
        [TestCase(false, 8, ExpectedResult = true)]
        [TestCase(false, 9, ExpectedResult = true)]
        [TestCase(false, 10, ExpectedResult = true)]
        [TestCase(false, -1, ExpectedResult = true)]
        [TestCase(false, -2, ExpectedResult = true)]
        [TestCase(false, -3, ExpectedResult = false)]
        [TestCase(false, -4, ExpectedResult = false)]
        [TestCase(false, -5, ExpectedResult = false)]
        [TestCase(false, -6, ExpectedResult = false)]
        [TestCase(false, -7, ExpectedResult = true)]
        [TestCase(false, -8, ExpectedResult = true)]
        [TestCase(false, -9, ExpectedResult = true)]
        [TestCase(false, -10, ExpectedResult = true)]
        public bool DoSomething_ReturnsBool(bool b, int i)
        {
            return Task8.DoSomething(b, i);
        }
    }
}
