using NUnit.Framework;

namespace Literals.Tests
{
    [TestFixture]
    public class LongIntegersTests
    {
        [Test]
        public void ReturnLongInteger21_ReturnsLongInteger()
        {
            // Act
            long result = LongIntegers.ReturnLongInteger21();

            // Assert
            Assert.AreEqual(4_956_185_095_298_947_214L, result);
        }

        [Test]
        public void ReturnLongInteger22_ReturnsLongInteger()
        {
            // Act
            long result = LongIntegers.ReturnLongInteger22();

            // Assert
            Assert.AreEqual(-1_280_010_762_458_239_942L, result);
        }

        [Test]
        public void ReturnLongInteger23_ReturnsLongInteger()
        {
            // Act
            long result = LongIntegers.ReturnLongInteger23();

            // Assert
            Assert.AreEqual(-945_783_496_234_828_465L, result);
        }

        [Test]
        public void ReturnLongInteger24_ReturnsLongInteger()
        {
            // Act
            ulong result = LongIntegers.ReturnLongInteger24();

            // Assert
            Assert.AreEqual(16_269_823_234_523_742_845L, result);
        }

        [Test]
        public void ReturnLongInteger25_ReturnsLongInteger()
        {
            // Act
            long result = LongIntegers.ReturnLongInteger25();

            // Assert
            Assert.AreEqual(9_223_372_036_854_775_807L, result);
        }

        [Test]
        public void ReturnLongInteger26_ReturnsLongInteger()
        {
            // Act
            long result = LongIntegers.ReturnLongInteger26();

            // Assert
            Assert.AreEqual(773_738_404_492_802_748L, result);
        }

        [Test]
        public void ReturnLongInteger27_ReturnsLongInteger()
        {
            // Act
            ulong result = LongIntegers.ReturnLongInteger27();

            // Assert
            Assert.AreEqual(17_977_307_477_258_691_517uL, result);
        }

        [Test]
        public void ReturnLongInteger28_ReturnsLongInteger()
        {
            // Act
            ulong result = LongIntegers.ReturnLongInteger28();

            // Assert
            Assert.AreEqual(14_193_065_825_095_688_383uL, result);
        }

        [Test]
        public void ReturnLongInteger29_ReturnsLongInteger()
        {
            // Act
            long result = LongIntegers.ReturnLongInteger29();

            // Assert
            Assert.AreEqual(4_100_761_908_933_204_629L, result);
        }

        [Test]
        public void ReturnLongInteger210_ReturnsLongInteger()
        {
            // Act
            long result = LongIntegers.ReturnLongInteger210();

            // Assert
            Assert.AreEqual(1_645_102_583_813_967_509L, result);
        }

        [Test]
        public void ReturnLongInteger211_ReturnsLongInteger()
        {
            // Act
            long result = LongIntegers.ReturnLongInteger211();

            // Assert
            Assert.AreEqual(6_148_914_691_236_517_205L, result);
        }

        [Test]
        public void ReturnLongInteger212_ReturnsLongInteger()
        {
            // Act
            long result = LongIntegers.ReturnLongInteger212();

            // Assert
            Assert.AreEqual(8_446_744_073_709_551_615L, result);
        }
    }
}
