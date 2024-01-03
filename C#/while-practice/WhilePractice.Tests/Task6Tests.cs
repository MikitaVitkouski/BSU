namespace WhilePractice.Tests
{
    public class Task6Tests
    {
        [TestCase(6, -0.17906537906537906)]
        [TestCase(10, -0.1919210476486018)]
        [TestCase(100, -0.21212664973225237)]
        [TestCase(1_000_000, -0.21460158660281903)]
        [TestCase(10_000_000, -0.2146018116025734)]
        public void SumSequenceElements(int n, double expectedResult)
        {
            double actualResult = Task6.SumSequenceElements(n);

            Assert.AreEqual(expectedResult, actualResult, 1e-10);
        }
    }
}
