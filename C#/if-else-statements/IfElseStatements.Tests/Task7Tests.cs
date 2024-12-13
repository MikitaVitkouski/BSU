using NUnit.Framework;

namespace IfStatements.Tests
{
    [TestFixture]
    public class Task7Tests
    {
        [TestCase(true, 0, ExpectedResult = 10)]
        [TestCase(true, 1, ExpectedResult = 9)]
        [TestCase(true, 2, ExpectedResult = 6)]
        [TestCase(true, 3, ExpectedResult = 1)]
        [TestCase(true, 4, ExpectedResult = -6)]
        [TestCase(true, 5, ExpectedResult = 15)]
        [TestCase(true, 6, ExpectedResult = 16)]
        [TestCase(true, 7, ExpectedResult = 17)]
        [TestCase(true, 8, ExpectedResult = 18)]
        [TestCase(true, 9, ExpectedResult = 19)]
        [TestCase(true, 10, ExpectedResult = 20)]
        [TestCase(true, -1, ExpectedResult = 9)]
        [TestCase(true, -2, ExpectedResult = 6)]
        [TestCase(true, -3, ExpectedResult = 1)]
        [TestCase(true, -4, ExpectedResult = -6)]
        [TestCase(true, -5, ExpectedResult = -15)]
        [TestCase(true, -6, ExpectedResult = 4)]
        [TestCase(true, -7, ExpectedResult = 3)]
        [TestCase(true, -8, ExpectedResult = 2)]
        [TestCase(true, -9, ExpectedResult = 1)]
        [TestCase(true, -10, ExpectedResult = 0)]
        [TestCase(false, 0, ExpectedResult = 10)]
        [TestCase(false, 1, ExpectedResult = 9)]
        [TestCase(false, 2, ExpectedResult = 8)]
        [TestCase(false, 3, ExpectedResult = 7)]
        [TestCase(false, 4, ExpectedResult = 6)]
        [TestCase(false, 5, ExpectedResult = -95)]
        [TestCase(false, 6, ExpectedResult = -94)]
        [TestCase(false, 7, ExpectedResult = -93)]
        [TestCase(false, 8, ExpectedResult = -92)]
        [TestCase(false, 9, ExpectedResult = -91)]
        [TestCase(false, 10, ExpectedResult = -90)]
        [TestCase(false, -1, ExpectedResult = 11)]
        [TestCase(false, -2, ExpectedResult = 12)]
        [TestCase(false, -3, ExpectedResult = 13)]
        [TestCase(false, -4, ExpectedResult = 14)]
        [TestCase(false, -5, ExpectedResult = 15)]
        [TestCase(false, -6, ExpectedResult = 16)]
        [TestCase(false, -7, ExpectedResult = -107)]
        [TestCase(false, -8, ExpectedResult = -108)]
        [TestCase(false, -9, ExpectedResult = -109)]
        [TestCase(false, -10, ExpectedResult = -110)]
        public int DoSomething_ReturnsInteger(bool b, int i)
        {
            return Task7.DoSomething(b, i);
        }
    }
}
