namespace ForStatements.Tests
{
    [TestFixture]
    public class QuadraticSequencesTests
    {
        [TestCase(3, 5, 7, 15, ExpectedResult = 1)]
        [TestCase(3, 5, 7, 29, ExpectedResult = 2)]
        [TestCase(3, 5, 7, 49, ExpectedResult = 3)]
        [TestCase(3, 5, 7, 75, ExpectedResult = 4)]
        [TestCase(3, 5, 7, 107, ExpectedResult = 5)]
        [TestCase(3, 5, 7, 145, ExpectedResult = 6)]
        [TestCase(3, 5, 7, 189, ExpectedResult = 7)]
        [TestCase(3, 5, 7, 239, ExpectedResult = 8)]
        [TestCase(3, 5, 7, 295, ExpectedResult = 9)]
        [TestCase(3, 5, 7, 357, ExpectedResult = 10)]
        [TestCase(3, 5, 7, 425, ExpectedResult = 11)]
        [TestCase(3, 5, 7, 499, ExpectedResult = 12)]
        [TestCase(3, 5, 7, 579, ExpectedResult = 13)]
        [TestCase(3, 5, 7, 665, ExpectedResult = 14)]
        [TestCase(3, 5, 7, 757, ExpectedResult = 15)]
        public uint CountQuadraticSequenceTerms_ReturnsSum(long a, long b, long c, long maxTerm)
        {
            return QuadraticSequences.CountQuadraticSequenceTerms(a, b, c, maxTerm);
        }

        [TestCase(1u, ExpectedResult = 13ul)]
        [TestCase(2u, ExpectedResult = 494ul)]
        [TestCase(3u, ExpectedResult = 38_038ul)]
        [TestCase(4u, ExpectedResult = 4_944_940ul)]
        [TestCase(5u, ExpectedResult = 974_153_180ul)]
        [TestCase(6u, ExpectedResult = 270_814_584_040ul)]
        [TestCase(7u, ExpectedResult = 101_013_839_846_920ul)]
        [TestCase(8u, ExpectedResult = 48_688_670_806_215_440ul)]
        public ulong GetQuadraticSequenceTermsProduct1_ReturnsProduct(uint count)
        {
            return QuadraticSequences.GetQuadraticSequenceTermsProduct1(count);
        }

        [TestCase(3, 5, 7, 1, 1, ExpectedResult = 15ul)]
        [TestCase(3, 5, 7, 1, 2, ExpectedResult = 435ul)]
        [TestCase(3, 5, 7, 1, 3, ExpectedResult = 21_315ul)]
        [TestCase(3, 5, 7, 1, 4, ExpectedResult = 1_598_625ul)]
        [TestCase(3, 5, 7, 1, 5, ExpectedResult = 171_052_875ul)]
        [TestCase(3, 5, 7, 1, 6, ExpectedResult = 24_802_666_875ul)]
        [TestCase(3, 5, 7, 1, 7, ExpectedResult = 4_687_704_039_375ul)]
        [TestCase(3, 5, 7, 1, 8, ExpectedResult = 1_120_361_265_410_625ul)]
        [TestCase(3, 5, 7, 1, 9, ExpectedResult = 330_506_573_296_134_375ul)]
        [TestCase(3, 5, 7, 2, 1, ExpectedResult = 29ul)]
        [TestCase(3, 5, 7, 2, 2, ExpectedResult = 1_421ul)]
        [TestCase(3, 5, 7, 2, 3, ExpectedResult = 106_575ul)]
        [TestCase(3, 5, 7, 2, 4, ExpectedResult = 11_403_525ul)]
        [TestCase(3, 5, 7, 2, 5, ExpectedResult = 1_653_511_125ul)]
        [TestCase(3, 5, 7, 2, 6, ExpectedResult = 312_513_602_625ul)]
        [TestCase(3, 5, 7, 2, 7, ExpectedResult = 74_690_751_027_375ul)]
        [TestCase(3, 5, 7, 2, 8, ExpectedResult = 22_033_771_553_075_625ul)]
        [TestCase(3, 5, 7, 2, 9, ExpectedResult = 7_866_056_444_447_998_125ul)]
        [TestCase(3, 5, 7, 8, 1, ExpectedResult = 239ul)]
        [TestCase(3, 5, 7, 8, 2, ExpectedResult = 70_505ul)]
        [TestCase(3, 5, 7, 8, 3, ExpectedResult = 25_170_285ul)]
        [TestCase(3, 5, 7, 9, 1, ExpectedResult = 295ul)]
        [TestCase(3, 5, 7, 9, 2, ExpectedResult = 105_315ul)]
        [TestCase(3, 5, 7, 10, 1, ExpectedResult = 357)]
        public ulong GetQuadraticSequenceProduct2_ReturnsSum(long a, long b, long c, long startN, long count)
        {
            return QuadraticSequences.GetQuadraticSequenceProduct2(a, b, c, startN, count);
        }
    }
}
