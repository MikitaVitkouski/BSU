global using NUnit.Framework;

namespace WhilePractice.Tests
{
    public class Task1Tests
    {
        [TestCase(6, 2.4499999999999997)]
        [TestCase(10, 2.9289682539682538)]
        [TestCase(100, 5.187377517639621)]
        [TestCase(1_000_000, 14.392726722864989)]
        [TestCase(10_000_000, 16.695311365857272)]
        public void SumSequenceElementsTests(int n, double expectedResult)
        {
            double actualResult = Task1.SumSequenceElements(n);

            Assert.AreEqual(expectedResult, actualResult, 1e-10);
        }
    }
}
