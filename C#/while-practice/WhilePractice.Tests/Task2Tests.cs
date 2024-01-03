namespace WhilePractice.Tests
{
    public class Task2Tests
    {
        [TestCase(6, 0.3761904761904762)]
        [TestCase(10, 0.3821789321789322)]
        [TestCase(100, 0.3862453487194004)]
        [TestCase(1_000_000, 0.38629436111938714)]
        [TestCase(10_000_000, 0.38629436111988125)]
        public void SumSequenceElementsTests(int n, double expectedResult)
        {
            double actualResult = Task2.SumSequenceElements(n);

            Assert.AreEqual(expectedResult, actualResult, 1e-10);
        }
    }
}
