namespace ForStatements.Tests
{
    [TestFixture]
    public class FibonacciSequenceTests
    {
        [TestCase(0, ExpectedResult = 0)]
        [TestCase(1, ExpectedResult = 1)]
        [TestCase(2, ExpectedResult = 1)]
        [TestCase(3, ExpectedResult = 2)]
        [TestCase(4, ExpectedResult = 3)]
        [TestCase(5, ExpectedResult = 5)]
        [TestCase(6, ExpectedResult = 8)]
        [TestCase(7, ExpectedResult = 13)]
        [TestCase(8, ExpectedResult = 21)]
        [TestCase(9, ExpectedResult = 34)]
        [TestCase(10, ExpectedResult = 55)]
        [TestCase(11, ExpectedResult = 89)]
        [TestCase(12, ExpectedResult = 144)]
        [TestCase(13, ExpectedResult = 233)]
        [TestCase(14, ExpectedResult = 377)]
        public int GetFibonacciNumber_ReturnsNumber(int n)
        {
            return FibonacciSequence.GetFibonacciNumber(n);
        }

        [TestCase(0ul, ExpectedResult = 0ul)]
        [TestCase(1ul, ExpectedResult = 1ul)]
        [TestCase(2ul, ExpectedResult = 1ul)]
        [TestCase(3ul, ExpectedResult = 2ul)]
        [TestCase(4ul, ExpectedResult = 3ul)]
        [TestCase(5ul, ExpectedResult = 5ul)]
        [TestCase(6ul, ExpectedResult = 8ul)]
        [TestCase(7ul, ExpectedResult = 3ul)]
        [TestCase(8ul, ExpectedResult = 2ul)]
        [TestCase(9ul, ExpectedResult = 12ul)]
        [TestCase(10ul, ExpectedResult = 25ul)]
        [TestCase(11ul, ExpectedResult = 72ul)]
        [TestCase(12ul, ExpectedResult = 16ul)]
        [TestCase(13ul, ExpectedResult = 18ul)]
        [TestCase(14ul, ExpectedResult = 147ul)]
        public ulong GetProductOfFibonacciNumberDigits(ulong n)
        {
            return FibonacciSequence.GetProductOfFibonacciNumberDigits(n);
        }
    }
}
