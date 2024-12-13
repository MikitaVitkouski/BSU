namespace WhileStatements.Tests
{
    [TestFixture]
    public class QuadraticSequencesTests
    {
        [TestCase(3, 5, 7, 15, ExpectedResult = 15)]
        [TestCase(3, 5, 7, 29, ExpectedResult = 44)]
        [TestCase(3, 5, 7, 49, ExpectedResult = 93)]
        [TestCase(3, 5, 7, 75, ExpectedResult = 168)]
        [TestCase(3, 5, 7, 107, ExpectedResult = 275)]
        [TestCase(3, 5, 7, 145, ExpectedResult = 420)]
        [TestCase(3, 5, 7, 189, ExpectedResult = 609)]
        [TestCase(3, 5, 7, 239, ExpectedResult = 848)]
        [TestCase(3, 5, 7, 295, ExpectedResult = 1143)]
        [TestCase(3, 5, 7, 357, ExpectedResult = 1500)]
        [TestCase(3, 5, 7, 425, ExpectedResult = 1925)]
        [TestCase(3, 5, 7, 499, ExpectedResult = 2424)]
        [TestCase(3, 5, 7, 579, ExpectedResult = 3003)]
        [TestCase(3, 5, 7, 665, ExpectedResult = 3668)]
        [TestCase(3, 5, 7, 757, ExpectedResult = 4425)]
        public long SumQuadraticSequenceTerms1_ReturnsSum(long a, long b, long c, long maxTerm)
        {
            return QuadraticSequences.SumQuadraticSequenceTerms1(a, b, c, maxTerm);
        }

        [TestCase(3, 5, 7, 1, 1, ExpectedResult = 15)]
        [TestCase(3, 5, 7, 1, 2, ExpectedResult = 44)]
        [TestCase(3, 5, 7, 1, 3, ExpectedResult = 93)]
        [TestCase(3, 5, 7, 1, 4, ExpectedResult = 168)]
        [TestCase(3, 5, 7, 1, 5, ExpectedResult = 275)]
        [TestCase(3, 5, 7, 1, 6, ExpectedResult = 420)]
        [TestCase(3, 5, 7, 1, 7, ExpectedResult = 609)]
        [TestCase(3, 5, 7, 1, 8, ExpectedResult = 848)]
        [TestCase(3, 5, 7, 1, 9, ExpectedResult = 1143)]
        [TestCase(3, 5, 7, 1, 10, ExpectedResult = 1500)]
        [TestCase(3, 5, 7, 2, 1, ExpectedResult = 29)]
        [TestCase(3, 5, 7, 2, 2, ExpectedResult = 78)]
        [TestCase(3, 5, 7, 2, 3, ExpectedResult = 153)]
        [TestCase(3, 5, 7, 2, 4, ExpectedResult = 260)]
        [TestCase(3, 5, 7, 2, 5, ExpectedResult = 405)]
        [TestCase(3, 5, 7, 2, 6, ExpectedResult = 594)]
        [TestCase(3, 5, 7, 2, 7, ExpectedResult = 833)]
        [TestCase(3, 5, 7, 2, 8, ExpectedResult = 1128)]
        [TestCase(3, 5, 7, 2, 9, ExpectedResult = 1485)]
        [TestCase(3, 5, 7, 8, 1, ExpectedResult = 239)]
        [TestCase(3, 5, 7, 8, 2, ExpectedResult = 534)]
        [TestCase(3, 5, 7, 8, 3, ExpectedResult = 891)]
        [TestCase(3, 5, 7, 9, 1, ExpectedResult = 295)]
        [TestCase(3, 5, 7, 9, 2, ExpectedResult = 652)]
        [TestCase(3, 5, 7, 10, 1, ExpectedResult = 357)]
        public long SumQuadraticSequenceTerms2_ReturnsSum(long a, long b, long c, long startN, long count)
        {
            return QuadraticSequences.SumQuadraticSequenceTerms2(a, b, c, startN, count);
        }
    }
}
