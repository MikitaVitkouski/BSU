namespace WhilePractice.Tests
{
    public class Task5Tests
    {
        [TestCase(6, 3.154706790123457)]
        [TestCase(10, 3.342847116573682)]
        [TestCase(100, 3.639682294531309)]
        [TestCase(1_000_000, 3.676074234300874)]
        [TestCase(10_000_000, 3.6760775427785917)]
        public void GetSequenceProduct(int n, double expectedResult)
        {
            double actualResult = Task5.GetSequenceProduct(n);

            Assert.AreEqual(expectedResult, actualResult, 1e-10);
        }
    }
}
