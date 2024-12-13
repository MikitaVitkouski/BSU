using NUnit.Framework;

namespace TransformToWords.Tests
{
    [TestFixture]
    public class TransformerTests
    {
        [TestCase(double.NaN, ExpectedResult = "NaN")]
        [TestCase(double.NegativeInfinity, ExpectedResult = "Negative Infinity")]
        [TestCase(double.PositiveInfinity, ExpectedResult = "Positive Infinity")]
        [TestCase(-0.0d, ExpectedResult = "Minus zero")]
        [TestCase(0.0d, ExpectedResult = "Zero")]
        [TestCase(0.1d, ExpectedResult = "Zero point one")]
        [TestCase(-23.809d, ExpectedResult = "Minus two three point eight zero nine")]
        [TestCase(-0.123456789d, ExpectedResult = "Minus zero point one two three four five six seven eight nine")]
        [TestCase(1.23333e308d, ExpectedResult = "One point two three three three three E plus three zero eight")]
        [TestCase(double.Epsilon, ExpectedResult = "Double Epsilon")]
        [TestCase(double.MaxValue, ExpectedResult = "One point seven nine seven six nine three one three four eight six two three one five seven E plus three zero eight")]
        [TestCase(double.MinValue, ExpectedResult = "Minus one point seven nine seven six nine three one three four eight six two three one five seven E plus three zero eight")]
        public string TransformToWords_Returns_Words_Representation(double number)
        {
            return Transformer.TransformToWords(number);
        }
    }
}
