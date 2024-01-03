namespace WhilePractice.Tests
{
    public class Task4Tests
    {
        [TestCase(6, 0.19804657596199388)]
        [TestCase(10, 0.21098888481753328)]
        [TestCase(100, 0.23122532283135178)]
        [TestCase(1_000_000, 0.23370030013643212)]
        [TestCase(10_000_000, 0.23370052513612405)]
        public void SumSequenceElements(int n, double expectedResult)
        {
            double actualResult = Task4.SumSequenceElements(n);

            Assert.AreEqual(expected: expectedResult, actualResult, 1e-10);
        }
    }
}
