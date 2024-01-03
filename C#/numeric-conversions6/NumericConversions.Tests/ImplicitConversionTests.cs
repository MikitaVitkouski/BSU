using NUnit.Framework;

namespace NumericConversions.Tests
{
    [TestFixture]
    public sealed class ImplicitConversionTests
    {
        [TestCase(0, ExpectedResult = 0)]
        [TestCase(int.MaxValue, ExpectedResult = int.MaxValue)]
        [TestCase(int.MinValue, ExpectedResult = int.MinValue)]
        public long IntToLong_CorrectParameters_ReturnsResult(int value)
        {
            return ImplicitConversion.IntToLong(intValue: value);
        }

        [TestCase(0, ExpectedResult = 0.0f)]
        [TestCase(int.MaxValue, ExpectedResult = (float)int.MaxValue)]
        [TestCase(int.MinValue, ExpectedResult = (float)int.MinValue)]
        public float IntToFloat_CorrectParameters_ReturnsResult(int value)
        {
            return ImplicitConversion.IntToFloat(intValue: value);
        }

        [TestCase(0, ExpectedResult = 0.0)]
        [TestCase(int.MaxValue, ExpectedResult = (double)int.MaxValue)]
        [TestCase(int.MinValue, ExpectedResult = (double)int.MinValue)]
        public double IntToDouble_CorrectParameters_ReturnsResult(int value)
        {
            return ImplicitConversion.IntToDouble(intValue: value);
        }

        [TestCase(0, ExpectedResult = 0.0)]
        [TestCase(int.MaxValue, ExpectedResult = int.MaxValue)]
        [TestCase(int.MinValue, ExpectedResult = int.MinValue)]
        public decimal IntToDecimal_CorrectParameters_ReturnsResult(int value)
        {
            return ImplicitConversion.IntToDecimal(intValue: value);
        }

        [TestCase(0, ExpectedResult = 0.0f)]
        [TestCase(long.MaxValue, ExpectedResult = (float)long.MaxValue)]
        [TestCase(long.MinValue, ExpectedResult = (float)long.MinValue)]
        public float LongToFloat_CorrectParameters_ReturnsResult(long value)
        {
            return ImplicitConversion.LongToFloat(longValue: value);
        }

        [TestCase(0, ExpectedResult = 0.0)]
        [TestCase(long.MaxValue, ExpectedResult = (double)long.MaxValue)]
        [TestCase(long.MinValue, ExpectedResult = (double)long.MinValue)]
        public double LongToDouble_CorrectParameters_ReturnsResult(long value)
        {
            return ImplicitConversion.LongToDouble(longValue: value);
        }

        [TestCase(0, 0)]
        [TestCase(long.MaxValue, long.MaxValue)]
        [TestCase(long.MinValue, long.MinValue)]
        public void LongToDecimal_CorrectParameters_ReturnsResult(long value, long expectedResult)
        {
            decimal result = ImplicitConversion.LongToDecimal(longValue: value);
            Assert.AreEqual((decimal)expectedResult, result);
        }

        [TestCase(0, ExpectedResult = 0)]
        [TestCase(byte.MaxValue, ExpectedResult = (short)byte.MaxValue)]
        [TestCase(byte.MinValue, ExpectedResult = (short)byte.MinValue)]
        public short ByteToShort_CorrectParameters_ReturnsResult(byte value)
        {
            return ImplicitConversion.ByteToShort(byteValue: value);
        }

        [TestCase(0, ExpectedResult = 0)]
        [TestCase(byte.MaxValue, ExpectedResult = (int)byte.MaxValue)]
        [TestCase(byte.MinValue, ExpectedResult = (int)byte.MinValue)]
        public int ByteToInt_CorrectParameters_ReturnsResult(byte value)
        {
            return ImplicitConversion.ByteToInt(byteValue: value);
        }
    }
}
