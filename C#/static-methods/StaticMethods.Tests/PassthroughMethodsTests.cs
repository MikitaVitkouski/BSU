// ReSharper disable IdentifierTypo
namespace StaticMethods.Tests
{
    [TestFixture]
    public class PassthroughMethodsTests
    {
        [TestCase(0, ExpectedResult = 0)]
        [TestCase(1000, ExpectedResult = 1000)]
        [TestCase(-1000, ExpectedResult = -1000)]
        [TestCase(int.MinValue, ExpectedResult = int.MinValue)]
        [TestCase(int.MaxValue, ExpectedResult = int.MaxValue)]
        public int ReturnInt_ReturnsInt(int argument)
        {
            return PassthroughMethods.ReturnInt(intParameter: argument);
        }

        [TestCase(0u, ExpectedResult = 0u)]
        [TestCase(1u, ExpectedResult = 1u)]
        [TestCase(uint.MinValue, ExpectedResult = uint.MinValue)]
        [TestCase(uint.MaxValue, ExpectedResult = uint.MaxValue)]
        public uint ReturnUnsignedInt_ReturnsUnsignedInt(uint argument)
        {
            return PassthroughMethods.ReturnUnsignedInt(uintParameter: argument);
        }

        [TestCase(0L, ExpectedResult = 0L)]
        [TestCase(1L, ExpectedResult = 1L)]
        [TestCase(-1L, ExpectedResult = -1L)]
        [TestCase(long.MinValue, ExpectedResult = long.MinValue)]
        [TestCase(long.MaxValue, ExpectedResult = long.MaxValue)]
        public long ReturnLong_ReturnsLong(long argument)
        {
            return PassthroughMethods.ReturnLong(longParameter: argument);
        }

        [TestCase(0ul, ExpectedResult = 0ul)]
        [TestCase(1ul, ExpectedResult = 1ul)]
        [TestCase(ulong.MinValue, ExpectedResult = ulong.MinValue)]
        [TestCase(ulong.MaxValue, ExpectedResult = ulong.MaxValue)]
        public ulong ReturnUnsignedLong_ReturnsUnsignedLong(ulong argument)
        {
            return PassthroughMethods.ReturnUnsignedLong(ulongParameter: argument);
        }

        [TestCase(0, ExpectedResult = 0)]
        [TestCase(0.1f, ExpectedResult = 0.1f)]
        [TestCase(-0.1f, ExpectedResult = -0.1f)]
        [TestCase(float.MinValue, ExpectedResult = float.MinValue)]
        [TestCase(float.MaxValue, ExpectedResult = float.MaxValue)]
        [TestCase(float.Epsilon, ExpectedResult = float.Epsilon)]
        [TestCase(float.NaN, ExpectedResult = float.NaN)]
        [TestCase(float.PositiveInfinity, ExpectedResult = float.PositiveInfinity)]
        [TestCase(float.NegativeInfinity, ExpectedResult = float.NegativeInfinity)]
        public float ReturnFloat_ReturnsFloat(float argument)
        {
            return PassthroughMethods.ReturnFloat(floatParameter: argument);
        }

        [TestCase(0, ExpectedResult = 0)]
        [TestCase(0.1, ExpectedResult = 0.1)]
        [TestCase(-0.1, ExpectedResult = -0.1)]
        [TestCase(double.MinValue, ExpectedResult = double.MinValue)]
        [TestCase(double.MaxValue, ExpectedResult = double.MaxValue)]
        [TestCase(double.Epsilon, ExpectedResult = double.Epsilon)]
        [TestCase(double.PositiveInfinity, ExpectedResult = double.PositiveInfinity)]
        [TestCase(double.NegativeInfinity, ExpectedResult = double.NegativeInfinity)]
        [TestCase(double.NaN, ExpectedResult = double.NaN)]
        public double ReturnDouble_ReturnsDouble(double argument)
        {
            return PassthroughMethods.ReturnDouble(doubleParameter: argument);
        }

        [TestCase(0, ExpectedResult = 0)]
        [TestCase(0.1, ExpectedResult = 0.1)]
        [TestCase(-0.1, ExpectedResult = -0.1)]
        [TestCase(1000.0001, ExpectedResult = 1000.0001)]
        [TestCase(-1000.0001, ExpectedResult = -1000.0001)]
        public decimal ReturnDecimal_ReturnsDecimal(decimal argument)
        {
            return PassthroughMethods.ReturnDecimal(decimalParameter: argument);
        }

        [TestCase("", ExpectedResult = "")]
        [TestCase("a", ExpectedResult = "a")]
        [TestCase("abcdef", ExpectedResult = "abcdef")]
        [TestCase("Hello, world!", ExpectedResult = "Hello, world!")]
        public string ReturnChar_ReturnsChar(string argument)
        {
            return PassthroughMethods.ReturnString(stringParameter: argument);
        }

        [TestCase('A', ExpectedResult = 'A')]
        [TestCase('a', ExpectedResult = 'a')]
        [TestCase('Z', ExpectedResult = 'Z')]
        [TestCase('z', ExpectedResult = 'z')]
        public char ReturnChar_ReturnsChar(char argument)
        {
            return PassthroughMethods.ReturnChar(charParameter: argument);
        }

        [TestCase(0, ExpectedResult = 0)]
        [TestCase(1, ExpectedResult = 1)]
        [TestCase(byte.MinValue, ExpectedResult = byte.MinValue)]
        [TestCase(byte.MaxValue, ExpectedResult = byte.MaxValue)]
        public byte ReturnByte_ReturnsByte(byte argument)
        {
            return PassthroughMethods.ReturnByte(byteParameter: argument);
        }

        [TestCase(true, ExpectedResult = true)]
        [TestCase(false, ExpectedResult = false)]
        public bool ReturnBool_ReturnsBoolean(bool argument)
        {
            return PassthroughMethods.ReturnBool(boolParameter: argument);
        }
    }
}
