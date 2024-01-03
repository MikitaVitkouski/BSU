using NUnit.Framework;

namespace TransformerToWords.Tests
{
    [TestFixture]
    public class TransformerTests
    {
        [TestCase(
            new[] { double.NaN, double.NegativeInfinity, double.PositiveInfinity, double.MaxValue, double.MinValue, double.Epsilon },
            ExpectedResult = new[]
            {
                "Not a Number",
                "Negative Infinity",
                "Positive Infinity",
                "One point seven nine seven six nine three one three four eight six two three one five seven E plus three zero eight",
                "Minus one point seven nine seven six nine three one three four eight six two three one five seven E plus three zero eight",
                "Double Epsilon",
            })]
        [TestCase(
            new[] { 2.345, -0.0d, 0.0d, 0.1d, -23.809d, -0.123456789d, 1.23333e308d },
            ExpectedResult = new[]
            {
                "Two point three four five",
                "Minus zero",
                "Zero",
                "Zero point one",
                "Minus two three point eight zero nine",
                "Minus zero point one two three four five six seven eight nine",
                "One point two three three three three E plus three zero eight",
            })]
        public string[] TransformTests(double[] source)
        {
            var transformer = new Transformer();
            return transformer.Transform(source);
        }

        [Test]
        public void Transform_ArrayIsNull_ThrowArgumentNullException() => Assert.Throws<ArgumentNullException>(
            () => new Transformer().Transform(null), "Array cannot be null.");

        [Test]
        public void Transform_ArrayIsEmpty_ThrowArgumentException() => Assert.Throws<ArgumentException>(
            () => new Transformer().Transform(Array.Empty<double>()), "Array cannot be empty.");
    }
}
