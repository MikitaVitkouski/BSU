namespace ForStatements.Tests
{
    [TestFixture]
    public class PrimeNumbersTests
    {
        [TestCase(0u, ExpectedResult = false)]
        [TestCase(1u, ExpectedResult = false)]
        [TestCase(2u, ExpectedResult = true)]
        [TestCase(3u, ExpectedResult = true)]
        [TestCase(4u, ExpectedResult = false)]
        [TestCase(5u, ExpectedResult = true)]
        [TestCase(6u, ExpectedResult = false)]
        [TestCase(7u, ExpectedResult = true)]
        [TestCase(8u, ExpectedResult = false)]
        [TestCase(9u, ExpectedResult = false)]
        [TestCase(10u, ExpectedResult = false)]
        [TestCase(11u, ExpectedResult = true)]
        [TestCase(12u, ExpectedResult = false)]
        [TestCase(13u, ExpectedResult = true)]
        [TestCase(14u, ExpectedResult = false)]
        [TestCase(15u, ExpectedResult = false)]
        [TestCase(16u, ExpectedResult = false)]
        [TestCase(17u, ExpectedResult = true)]
        [TestCase(18u, ExpectedResult = false)]
        [TestCase(19u, ExpectedResult = true)]
        [TestCase(20u, ExpectedResult = false)]
        [TestCase(21u, ExpectedResult = false)]
        [TestCase(22u, ExpectedResult = false)]
        [TestCase(23u, ExpectedResult = true)]
        [TestCase(29u, ExpectedResult = true)]
        [TestCase(31u, ExpectedResult = true)]
        [TestCase(37u, ExpectedResult = true)]
        [TestCase(41u, ExpectedResult = true)]
        [TestCase(43u, ExpectedResult = true)]
        [TestCase(47u, ExpectedResult = true)]
        [TestCase(53u, ExpectedResult = true)]
        public bool IsPrimeNumber(uint n)
        {
            return PrimeNumbers.IsPrimeNumber(n);
        }

        [TestCase(0, 0, ExpectedResult = 0ul)]
        [TestCase(0, 1, ExpectedResult = 0ul)]
        [TestCase(0, 2, ExpectedResult = 2ul)]
        [TestCase(0, 3, ExpectedResult = 5ul)]
        [TestCase(0, 4, ExpectedResult = 5ul)]
        [TestCase(0, 5, ExpectedResult = 10ul)]
        [TestCase(0, 6, ExpectedResult = 10ul)]
        [TestCase(0, 7, ExpectedResult = 17ul)]
        [TestCase(0, 8, ExpectedResult = 17ul)]
        [TestCase(0, 9, ExpectedResult = 17ul)]
        [TestCase(0, 10, ExpectedResult = 17ul)]
        [TestCase(0, 11, ExpectedResult = 19ul)]
        [TestCase(0, 12, ExpectedResult = 19ul)]
        [TestCase(0, 13, ExpectedResult = 23ul)]
        [TestCase(0, 14, ExpectedResult = 23ul)]
        [TestCase(0, 15, ExpectedResult = 23ul)]
        [TestCase(0, 16, ExpectedResult = 23ul)]
        [TestCase(0, 17, ExpectedResult = 31ul)]
        [TestCase(0, 18, ExpectedResult = 31ul)]
        [TestCase(0, 19, ExpectedResult = 41ul)]
        [TestCase(0, 20, ExpectedResult = 41ul)]
        [TestCase(10, 10, ExpectedResult = 0ul)]
        [TestCase(10, 11, ExpectedResult = 2ul)]
        [TestCase(10, 12, ExpectedResult = 2ul)]
        [TestCase(10, 13, ExpectedResult = 6ul)]
        [TestCase(10, 14, ExpectedResult = 6ul)]
        [TestCase(10, 15, ExpectedResult = 6ul)]
        [TestCase(10, 16, ExpectedResult = 6ul)]
        [TestCase(10, 17, ExpectedResult = 14ul)]
        [TestCase(10, 18, ExpectedResult = 14ul)]
        [TestCase(10, 19, ExpectedResult = 24ul)]
        [TestCase(10, 20, ExpectedResult = 24ul)]
        public ulong SumDigitsOfPrimeNumbers(int start, int end)
        {
            return PrimeNumbers.SumDigitsOfPrimeNumbers(start, end);
        }
    }
}
