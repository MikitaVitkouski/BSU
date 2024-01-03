using NUnit.Framework;

namespace JaggedArrays.Tests
{
    [TestFixture]
    public class ArrayExtensionTests
    {
        [TestCaseSource(typeof(TestCasesDataSource), nameof(TestCasesDataSource.TestCasesForSumByAscending))]
        public void OrderByAscendingBySum_Tests(int[][] source, int[][] expected)
        {
            source.OrderByAscendingBySum();
            Assert.AreEqual(expected, source);
        }

        [Test]
        public void OrderByAscendingBySum_SourceIsNull_ThrowArgumentNullException()
        {
            int[][] source = null!;
            Assert.Throws<ArgumentNullException>(() => ArrayExtension.OrderByAscendingBySum(source));
        }

        [TestCaseSource(typeof(TestCasesDataSource), nameof(TestCasesDataSource.TestCasesForSumByDescending))]
        public void OrderByDescendingBySum_Tests(int[][] source, int[][] expected)
        {
            source.OrderByDescendingBySum();
            Assert.AreEqual(expected, source);
        }

        [Test]
        public void OrderByDescendingBySum_SourceIsNull_ThrowArgumentNullException()
        {
            int[][] source = null!;
            Assert.Throws<ArgumentNullException>(() => ArrayExtension.OrderByDescendingBySum(source));
        }

        [TestCaseSource(typeof(TestCasesDataSource), nameof(TestCasesDataSource.TestCasesForMaxAscending))]
        public void OrderByAscendingByMax_Tests(int[][] source, int[][] expected)
        {
            source.OrderByAscendingByMax();
            Assert.AreEqual(expected, source);
        }

        [Test]
        public void OrderByAscendingByMax_SourceIsNull_ThrowArgumentNullException()
        {
            int[][] source = null!;
            Assert.Throws<ArgumentNullException>(() => ArrayExtension.OrderByAscendingByMax(source));
        }

        [TestCaseSource(typeof(TestCasesDataSource), nameof(TestCasesDataSource.TestCasesForMaxDescending))]
        public void OrderByDescendingByMax_Tests(int[][] source, int[][] expected)
        {
            source.OrderByDescendingByMax();
            Assert.AreEqual(expected, source);
        }

        [Test]
        public void OrderByDescendingByMax_SourceIsNull_ThrowArgumentNullException()
        {
            int[][] source = null!;
            Assert.Throws<ArgumentNullException>(() => ArrayExtension.OrderByDescendingByMax(source));
        }
    }
}
