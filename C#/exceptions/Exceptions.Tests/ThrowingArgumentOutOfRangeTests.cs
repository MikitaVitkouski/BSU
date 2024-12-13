global using NUnit.Framework;

namespace Exceptions.Tests
{
    [TestFixture]
    public class ThrowingArgumentOutOfRangeTests
    {
        [TestCase(5)]
        [TestCase(6)]
        [TestCase(7)]
        [TestCase(8)]
        [TestCase(9)]
        [TestCase(10)]
        [TestCase(-5)]
        [TestCase(-6)]
        [TestCase(-7)]
        [TestCase(-8)]
        [TestCase(-9)]
        [TestCase(-10)]
        public void CheckParameterAndThrowException1_ThrowsArgumentOutOfRangeException(int i)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                try
                {
                    ThrowingArgumentOutOfRange.CheckParameterAndThrowException1(i);
                }
                catch (ArgumentOutOfRangeException e)
                {
                    Assert.AreEqual(nameof(i), e.ParamName);
                    throw;
                }
            });
        }

        [TestCase(0)]
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        [TestCase(4)]
        [TestCase(-1)]
        [TestCase(-2)]
        [TestCase(-3)]
        [TestCase(-4)]
        public void CheckParameterAndThrowException1_ReturnsTrue(int i)
        {
            // Act
            bool actualResult = ThrowingArgumentOutOfRange.CheckParameterAndThrowException1(i);

            // Assert
            Assert.IsTrue(actualResult);
        }

        [TestCase(8u)]
        [TestCase(9u)]
        [TestCase(10u)]
        public void CheckParameterAndThrowException2_ThrowsArgumentOutOfRangeException(ulong l)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                try
                {
                    ThrowingArgumentOutOfRange.CheckParameterAndThrowException2(l);
                }
                catch (ArgumentOutOfRangeException e)
                {
                    Assert.AreEqual(nameof(l), e.ParamName);
                    throw;
                }
            });
        }

        [TestCase(0uL)]
        [TestCase(1uL)]
        [TestCase(2uL)]
        [TestCase(3uL)]
        [TestCase(4uL)]
        [TestCase(5uL)]
        [TestCase(6uL)]
        [TestCase(7uL)]
        public void CheckParameterAndThrowException2_ReturnsTrue(ulong l)
        {
            // Act
            bool actualResult = ThrowingArgumentOutOfRange.CheckParameterAndThrowException2(l);

            // Assert
            Assert.IsTrue(actualResult);
        }

        [TestCase(5u, 0.0)]
        [TestCase(6u, 0.0)]
        [TestCase(7u, 0.0)]
        [TestCase(8u, 0.0)]
        [TestCase(9u, 0.0)]
        [TestCase(10u, 0.0)]
        public void CheckParameterAndThrowException3_I_IsOutOfRange_ThrowsArgumentOutOfRangeException(uint i, double d)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                try
                {
                    ThrowingArgumentOutOfRange.CheckParametersAndThrowException3(i, d);
                }
                catch (ArgumentOutOfRangeException e)
                {
                    Assert.AreEqual(nameof(i), e.ParamName);
                    Assert.AreEqual("i should be in [0, 5) interval. (Parameter 'i')", e.Message);
                    throw;
                }
            });
        }

        [TestCase(0u, 1.0001)]
        [TestCase(1u, 1.0001)]
        [TestCase(2u, 1.0001)]
        [TestCase(3u, 1.0001)]
        [TestCase(4u, 1.0001)]
        [TestCase(0u, -1.0001)]
        [TestCase(1u, -1.0001)]
        [TestCase(2u, -1.0001)]
        [TestCase(3u, -1.0001)]
        [TestCase(4u, -1.0001)]
        public void CheckParameterAndThrowException3_D_IsOutOfRange_ThrowsArgumentOutOfRangeException(uint i, double d)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                try
                {
                    ThrowingArgumentOutOfRange.CheckParametersAndThrowException3(i, d);
                }
                catch (ArgumentOutOfRangeException e)
                {
                    Assert.AreEqual(nameof(d), e.ParamName);
                    Assert.AreEqual("d should be in [-1.0, 1.0] interval. (Parameter 'd')", e.Message);
                    throw;
                }
            });
        }

        [TestCase(0u, 0.0)]
        [TestCase(1u, 0.0)]
        [TestCase(2u, 0.0)]
        [TestCase(3u, 0.0)]
        [TestCase(4u, 0.0)]
        [TestCase(0u, 0.9999)]
        [TestCase(1u, 0.9999)]
        [TestCase(2u, 0.9999)]
        [TestCase(3u, 0.9999)]
        [TestCase(4u, 0.9999)]
        [TestCase(0u, -0.9999)]
        [TestCase(1u, -0.9999)]
        [TestCase(2u, -0.9999)]
        [TestCase(3u, -0.9999)]
        [TestCase(4u, -0.9999)]
        public void CheckParameterAndThrowException3_ReturnsTrue(uint i, double d)
        {
            // Act
            bool actualResult = ThrowingArgumentOutOfRange.CheckParametersAndThrowException3(i, d);

            // Assert
            Assert.IsTrue(actualResult);
        }

        [TestCase(0L, 0.0f)]
        [TestCase(1L, 0.0f)]
        [TestCase(2L, 0.0f)]
        [TestCase(9L, 0.0f)]
        [TestCase(10L, 0.0f)]
        [TestCase(-1L, 0.0f)]
        [TestCase(-2L, 0.0f)]
        [TestCase(-3L, 0.0f)]
        [TestCase(-10L, 0.0f)]
        public void CheckParametersAndThrowException4_L_OutOfRange_ThrowsArgumentOutOfRange(long l, float f)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                try
                {
                    ThrowingArgumentOutOfRange.CheckParametersAndThrowException4(l, f);
                }
                catch (ArgumentOutOfRangeException e)
                {
                    Assert.AreEqual(nameof(l), e.ParamName);
                    Assert.AreEqual("l should be in [-9, -3) or [3, 9) intervals. (Parameter 'l')", e.Message);
                    throw;
                }
            });
        }

        [TestCase(3L, -0.3f)]
        [TestCase(4L, -0.3f)]
        [TestCase(5L, -0.3f)]
        [TestCase(6L, -0.3f)]
        [TestCase(7L, -0.3f)]
        [TestCase(8L, -0.3f)]
        [TestCase(-4L, -0.3f)]
        [TestCase(-5L, -0.3f)]
        [TestCase(-6L, -0.3f)]
        [TestCase(-7L, -0.3f)]
        [TestCase(-8L, -0.3f)]
        [TestCase(-9L, -0.3f)]
        [TestCase(3L, 0.3f)]
        [TestCase(4L, 0.3f)]
        [TestCase(5L, 0.3f)]
        [TestCase(6L, 0.3f)]
        [TestCase(7L, 0.3f)]
        [TestCase(8L, 0.3f)]
        [TestCase(-4L, 0.3f)]
        [TestCase(-5L, 0.3f)]
        [TestCase(-6L, 0.3f)]
        [TestCase(-7L, 0.3f)]
        [TestCase(-8L, 0.3f)]
        [TestCase(-9L, 0.3f)]
        public void CheckParametersAndThrowException4_F_OutOfRange_ThrowsArgumentOutOfRange(long l, float f)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                try
                {
                    ThrowingArgumentOutOfRange.CheckParametersAndThrowException4(l, f);
                }
                catch (ArgumentOutOfRangeException e)
                {
                    Assert.AreEqual(nameof(f), e.ParamName);
                    Assert.AreEqual("f should be in the (-0.3, 0.3) interval. (Parameter 'f')", e.Message);
                    throw;
                }
            });
        }

        [TestCase(3L, 0.0f)]
        [TestCase(4L, 0.0f)]
        [TestCase(5L, 0.0f)]
        [TestCase(6L, 0.0f)]
        [TestCase(7L, 0.0f)]
        [TestCase(8L, 0.0f)]
        [TestCase(-4L, 0.0f)]
        [TestCase(-5L, 0.0f)]
        [TestCase(-6L, 0.0f)]
        [TestCase(-7L, 0.0f)]
        [TestCase(-8L, 0.0f)]
        [TestCase(-9L, 0.0f)]
        [TestCase(3L, -0.2999f)]
        [TestCase(4L, -0.2999f)]
        [TestCase(5L, -0.2999f)]
        [TestCase(6L, -0.2999f)]
        [TestCase(7L, -0.2999f)]
        [TestCase(8L, -0.2999f)]
        [TestCase(-4L, -0.2999f)]
        [TestCase(-5L, -0.2999f)]
        [TestCase(-6L, -0.2999f)]
        [TestCase(-7L, -0.2999f)]
        [TestCase(-8L, -0.2999f)]
        [TestCase(-9L, -0.2999f)]
        [TestCase(3L, 0.2999f)]
        [TestCase(4L, 0.2999f)]
        [TestCase(5L, 0.2999f)]
        [TestCase(6L, 0.2999f)]
        [TestCase(7L, 0.2999f)]
        [TestCase(8L, 0.2999f)]
        [TestCase(-4L, 0.2999f)]
        [TestCase(-5L, 0.2999f)]
        [TestCase(-6L, 0.2999f)]
        [TestCase(-7L, 0.2999f)]
        [TestCase(-8L, 0.2999f)]
        [TestCase(-9L, 0.2999f)]
        public void CheckParameterAndThrowException4_ReturnsTrue(long l, float f)
        {
            // Act
            bool actualResult = ThrowingArgumentOutOfRange.CheckParametersAndThrowException4(l, f);

            // Assert
            Assert.IsTrue(actualResult);
        }
    }
}
