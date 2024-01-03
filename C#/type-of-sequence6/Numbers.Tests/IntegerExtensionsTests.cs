using NUnit.Framework;

namespace Numbers.Tests
{
    [TestFixture]
    public class IntegerExtensionsTests
    {
        [TestCase(123456789L, ExpectedResult = ComparisonSigns.LessThan)]
        [TestCase(long.MinValue, ExpectedResult = ComparisonSigns.MoreThan | ComparisonSigns.Equals | ComparisonSigns.LessThan)]
        [TestCase(long.MaxValue, ExpectedResult = ComparisonSigns.MoreThan | ComparisonSigns.Equals | ComparisonSigns.LessThan)]
        [TestCase(9876543210L, ExpectedResult = ComparisonSigns.MoreThan)]
        [TestCase(98765432110L, ExpectedResult = ComparisonSigns.MoreThan | ComparisonSigns.Equals)]
        [TestCase(11234567889L, ExpectedResult = ComparisonSigns.LessThan | ComparisonSigns.Equals)]
        [TestCase(111111111111111L, ExpectedResult = ComparisonSigns.Equals)]
        [TestCase(12312342098671L, ExpectedResult = ComparisonSigns.MoreThan | ComparisonSigns.LessThan)]
        [TestCase(0L, ExpectedResult = null)]
        [TestCase(1L, ExpectedResult = null)]
        [TestCase(-1L, ExpectedResult = null)]
        public ComparisonSigns? GetTypeComparisonSigns_Tests(long number) => number.GetTypeComparisonSigns();

        [TestCase(123456789L, ExpectedResult = "Strictly Increasing.")]
        [TestCase(long.MinValue, ExpectedResult = "Unordered.")]
        [TestCase(long.MaxValue, ExpectedResult = "Unordered.")]
        [TestCase(9876543210L, ExpectedResult = "Strictly Decreasing.")]
        [TestCase(111111111111111L, ExpectedResult = "Monotonous.")]
        [TestCase(12312342098671L, ExpectedResult = "Unordered.")]
        [TestCase(98765432110L, ExpectedResult = "Decreasing.")]
        [TestCase(11234567889L, ExpectedResult = "Increasing.")]
        [TestCase(0L, ExpectedResult = "One digit number.")]
        [TestCase(1L, ExpectedResult = "One digit number.")]
        [TestCase(-1L, ExpectedResult = "One digit number.")]
        public string GetTypeOfDigitsSequence_Tests(long number) => number.GetTypeOfDigitsSequence();
    }
}
