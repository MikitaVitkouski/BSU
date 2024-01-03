using NUnit.Framework;

namespace RotateMatrix.Tests
{
    public class ArrayExtensionsTestsRotateClockwise
    {
        [TestCaseSource(typeof(TestCasesSource), nameof(TestCasesSource.TestCasesRotate90DegreesClockwise))]
        public void Rotate90DegreesClockwise_Tests(int[,] matrix, int[,] rotatedMatrix)
        {
            matrix.Rotate90DegreesClockwise();
            Assert.AreEqual(rotatedMatrix, matrix);
        }

        [Test]
        public void Rotate90DegreesClockwise_MatrixIsNull_ThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => ArrayExtensions.Rotate90DegreesClockwise(null));
        }

        [TestCaseSource(typeof(TestCasesSource), nameof(TestCasesSource.TestCasesRotate180DegreesClockwise))]
        public void Rotate180DegreesClockwise_Tests(int[,] matrix, int[,] rotatedMatrix)
        {
            matrix.Rotate180DegreesClockwise();
            Assert.AreEqual(rotatedMatrix, matrix);
        }

        [Test]
        public void Rotate180DegreesClockwise_MatrixIsNull_ThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => ArrayExtensions.Rotate180DegreesClockwise(null));
        }

        [TestCaseSource(typeof(TestCasesSource), nameof(TestCasesSource.TestCasesRotate270DegreesClockwise))]
        public void Rotate270DegreesClockwise_Tests(int[,] matrix, int[,] rotatedMatrix)
        {
            matrix.Rotate270DegreesClockwise();
            Assert.AreEqual(rotatedMatrix, matrix);
        }

        [Test]
        public void Rotate270DegreesClockwise_MatrixIsNull_ThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => ArrayExtensions.Rotate270DegreesClockwise(null));
        }

        [TestCaseSource(typeof(TestCasesSource), nameof(TestCasesSource.TestCasesRotate360DegreesClockwise))]
        public void Rotate360DegreesClockwise_Tests(int[,] matrix, int[,] rotatedMatrix)
        {
            matrix.Rotate360DegreesClockwise();
            Assert.AreEqual(rotatedMatrix, matrix);
        }

        [Test]
        public void Rotate360DegreesClockwise_MatrixIsNull_ThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => ArrayExtensions.Rotate360DegreesClockwise(null));
        }
    }
}
