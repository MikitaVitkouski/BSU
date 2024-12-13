using NUnit.Framework;

namespace NumericConversions.Tests
{
    [TestFixture]
    public class ExplicitConversionTests
    {
        [TestCase(0L, ExpectedResult = 0)]
        [TestCase((long)int.MaxValue, ExpectedResult = int.MaxValue)]
        [TestCase((long)int.MinValue, ExpectedResult = int.MinValue)]
        [TestCase(long.MaxValue, ExpectedResult = -1)]
        [TestCase(long.MinValue, ExpectedResult = 0)]
        public int LongToInt_CorrectParameters_ReturnsResult(long value)
        {
            return ExplicitConversion.LongToInt(longValue: value);
        }

        [TestCase(0.0f, ExpectedResult = 0)]
        [TestCase((float)int.MaxValue, ExpectedResult = int.MinValue)]
        [TestCase((float)int.MinValue, ExpectedResult = int.MinValue)]
        [TestCase(float.MaxValue, ExpectedResult = int.MinValue)]
        [TestCase(float.MinValue, ExpectedResult = int.MinValue)]
        public int FloatToInt_CorrectParameters_ReturnsResult(float value)
        {
            return ExplicitConversion.FloatToInt(floatValue: value);
        }

        [TestCase(0.0, ExpectedResult = 0)]
        [TestCase((double)int.MaxValue, ExpectedResult = int.MaxValue)]
        [TestCase((double)int.MinValue, ExpectedResult = int.MinValue)]
        [TestCase(double.MaxValue, ExpectedResult = int.MinValue)]
        [TestCase(double.MinValue, ExpectedResult = int.MinValue)]
        public int DoubleToInt_CorrectParameters_ReturnsResult(double value)
        {
            return ExplicitConversion.DoubleToInt(doubleValue: value);
        }

        [TestCase(0.0, ExpectedResult = 0)]
        [TestCase(int.MaxValue, ExpectedResult = int.MaxValue)]
        [TestCase(int.MinValue, ExpectedResult = int.MinValue)]
        [TestCase(int.MaxValue, ExpectedResult = int.MaxValue)]
        [TestCase(int.MinValue, ExpectedResult = int.MinValue)]
        public int DecimalToInt_CorrectParameters_ReturnsResult(decimal value)
        {
            return ExplicitConversion.DecimalToInt(decimalValue: value);
        }

        [Test]
        public void DecimalToInt_MaxValue_ThrowsException()
        {
            Assert.Throws<OverflowException>(() => ExplicitConversion.DecimalToInt(decimalValue: decimal.MaxValue));
        }

        [Test]
        public void DecimalToInt_MinValue_ThrowsException()
        {
            Assert.Throws<OverflowException>(() => ExplicitConversion.DecimalToInt(decimalValue: decimal.MinValue));
        }

        [TestCase(0.0f, ExpectedResult = 0)]
        [TestCase((float)long.MaxValue, ExpectedResult = long.MinValue)]
        [TestCase((float)long.MinValue, ExpectedResult = long.MinValue)]
        [TestCase(float.MaxValue, ExpectedResult = long.MinValue)]
        [TestCase(float.MinValue, ExpectedResult = long.MinValue)]
        public long FloatToLong_CorrectParameters_ReturnsResult(float value)
        {
            return ExplicitConversion.FloatToLong(floatValue: value);
        }

        [TestCase(0.0, ExpectedResult = 0)]
        [TestCase((double)long.MaxValue, ExpectedResult = long.MinValue)]
        [TestCase((double)long.MinValue, ExpectedResult = long.MinValue)]
        [TestCase(double.MaxValue, ExpectedResult = long.MinValue)]
        [TestCase(double.MinValue, ExpectedResult = long.MinValue)]
        public long DoubleToLong_CorrectParameters_ReturnsResult(double value)
        {
            return ExplicitConversion.DoubleToLong(doubleValue: value);
        }

        [TestCase(0L, ExpectedResult = 0)]
        [TestCase(long.MaxValue, ExpectedResult = long.MaxValue)]
        [TestCase(long.MinValue, ExpectedResult = long.MinValue)]
        public long DecimalToLong_CorrectParameters_ReturnsResult(long value)
        {
            return ExplicitConversion.DecimalToLong(decimalValue: (decimal)value);
        }

        [Test]
        public void DecimalToLong_MaxValue()
        {
            Assert.Throws<OverflowException>(() => ExplicitConversion.DecimalToLong(decimalValue: decimal.MaxValue));
        }

        [Test]
        public void DecimalToLong_MinValue()
        {
            Assert.Throws<OverflowException>(() => ExplicitConversion.DecimalToLong(decimalValue: decimal.MinValue));
        }

        [TestCase(0, ExpectedResult = 0)]
        [TestCase((short)byte.MaxValue, ExpectedResult = byte.MaxValue)]
        [TestCase((short)byte.MinValue, ExpectedResult = byte.MinValue)]
        [TestCase(short.MaxValue, ExpectedResult = byte.MaxValue)]
        [TestCase(short.MinValue, ExpectedResult = byte.MinValue)]
        public byte ShortToByte_CorrectParameters_ReturnsResult(short value)
        {
            return ExplicitConversion.ShortToByte(shortValue: value);
        }

        [TestCase(0, ExpectedResult = 0)]
        [TestCase((int)byte.MaxValue, ExpectedResult = byte.MaxValue)]
        [TestCase((int)byte.MinValue, ExpectedResult = byte.MinValue)]
        [TestCase(int.MaxValue, ExpectedResult = byte.MaxValue)]
        [TestCase(int.MinValue, ExpectedResult = byte.MinValue)]
        public byte IntToByte_CorrectParameters_ReturnsResult(int value)
        {
            return ExplicitConversion.IntToByte(intValue: value);
        }

        [TestCase(0, ExpectedResult = 0)]
        [TestCase((int)short.MaxValue, ExpectedResult = short.MaxValue)]
        [TestCase((int)short.MinValue, ExpectedResult = short.MinValue)]
        [TestCase(int.MaxValue, ExpectedResult = -1)]
        [TestCase(int.MinValue, ExpectedResult = 0)]
        public short IntToShort_CorrectParameters_ReturnsResult(int value)
        {
            return ExplicitConversion.IntToShort(intValue: value);
        }
    }
}
