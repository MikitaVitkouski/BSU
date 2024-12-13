namespace WhilePractice.Tests
{
    public class Task3Tests
    {
        [TestCase(6, 1.036790389660494)]
        [TestCase(10, 1.0369073413446939)]
        [TestCase(100, 1.0369277526929555)]
        [TestCase(1_000_000, 1.036927755143338)]
        [TestCase(10_000_000, 1.036927755143338)]
        public void SumSequenceElementsTests(int n, double expectedResult)
        {
            double actualResult = Task3.SumSequenceElements(n);

            Assert.AreEqual(expectedResult, actualResult, 1e-10);
        }
    }
}
