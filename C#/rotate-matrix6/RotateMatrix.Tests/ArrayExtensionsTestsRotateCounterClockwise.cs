using NUnit.Framework;

namespace RotateMatrix.Tests
{
    public class ArrayExtensionsTestsRotateCounterClockwise
    {
        [TestCaseSource(typeof(TestCasesSource), nameof(TestCasesSource.TestCasesRotate90DegreesCounterClockwise))]
        public void Rotate90DegreesCounterClockwise_Tests(int[,] matrix, int[,] rotatedMatrix)
        {
            matrix.Rotate90DegreesCounterClockwise();
            Assert.AreEqual(rotatedMatrix, matrix);
        }

        [Test]
        public void Rotate90DegreesCounterClockwise_MatrixIsNull_ThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => ArrayExtensions.Rotate90DegreesCounterClockwise(null));
        }

        [TestCaseSource(typeof(TestCasesSource), nameof(TestCasesSource.TestCasesRotate180DegreesCounterClockwise))]
        public void Rotate180DegreesCounterClockwise_Tests(int[,] matrix, int[,] rotatedMatrix)
        {
            matrix.Rotate180DegreesCounterClockwise();
            Assert.AreEqual(rotatedMatrix, matrix);
        }

        [Test]
        public void Rotate180DegreesCounterClockwise_MatrixIsNull_ThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => ArrayExtensions.Rotate180DegreesCounterClockwise(null));
        }

        [TestCaseSource(typeof(TestCasesSource), nameof(TestCasesSource.TestCasesRotate270DegreesCounterClockwise))]
        public void Rotate270DegreesCounterClockwise_Tests(int[,] matrix, int[,] rotatedMatrix)
        {
            matrix.Rotate270DegreesCounterClockwise();
            Assert.AreEqual(rotatedMatrix, matrix);
        }

        [Test]
        public void Rotate270DegreesCounterClockwise_MatrixIsNull_ThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => ArrayExtensions.Rotate270DegreesCounterClockwise(null));
        }

        [TestCaseSource(typeof(TestCasesSource), nameof(TestCasesSource.TestCasesRotate360DegreesCounterClockwise))]
        public void Rotate360DegreesCounterClockwise_Tests(int[,] matrix, int[,] rotatedMatrix)
        {
            matrix.Rotate360DegreesCounterClockwise();
            Assert.AreEqual(rotatedMatrix, matrix);
        }

        [Test]
        public void Rotate360DegreesCounterClockwise_MatrixIsNull_ThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => ArrayExtensions.Rotate360DegreesCounterClockwise(null));
        }
    }
}
