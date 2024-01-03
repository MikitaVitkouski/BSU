namespace WhileStatements.Tests
{
    [TestFixture]
    public class GeometricSequencesTests
    {
        [TestCase(1u, 1u, 1u, ExpectedResult = 1u)]
        [TestCase(1u, 1u, 2u, ExpectedResult = 2u)]
        [TestCase(1u, 1u, 3u, ExpectedResult = 3u)]
        [TestCase(1u, 1u, 4u, ExpectedResult = 4u)]
        [TestCase(1u, 1u, 5u, ExpectedResult = 5u)]
        [TestCase(2u, 1u, 1u, ExpectedResult = 2u)]
        [TestCase(2u, 1u, 2u, ExpectedResult = 4u)]
        [TestCase(2u, 1u, 3u, ExpectedResult = 6u)]
        [TestCase(2u, 1u, 4u, ExpectedResult = 8u)]
        [TestCase(2u, 1u, 5u, ExpectedResult = 10u)]
        [TestCase(3u, 1u, 1u, ExpectedResult = 3u)]
        [TestCase(3u, 1u, 2u, ExpectedResult = 6u)]
        [TestCase(3u, 1u, 3u, ExpectedResult = 9u)]
        [TestCase(3u, 1u, 4u, ExpectedResult = 12u)]
        [TestCase(3u, 1u, 5u, ExpectedResult = 15u)]
        [TestCase(4u, 2u, 1u, ExpectedResult = 4u)]
        [TestCase(4u, 2u, 2u, ExpectedResult = 12u)]
        [TestCase(4u, 2u, 3u, ExpectedResult = 28u)]
        [TestCase(4u, 2u, 4u, ExpectedResult = 60u)]
        [TestCase(4u, 2u, 5u, ExpectedResult = 124u)]
        [TestCase(5u, 3u, 1u, ExpectedResult = 5u)]
        [TestCase(5u, 3u, 2u, ExpectedResult = 20u)]
        [TestCase(5u, 3u, 3u, ExpectedResult = 65u)]
        [TestCase(5u, 3u, 4u, ExpectedResult = 200u)]
        [TestCase(5u, 3u, 5u, ExpectedResult = 605u)]
        public uint SumGeometricSequenceTerms1_ReturnsSum(uint a, uint r, uint n)
        {
            return GeometricSequences.SumGeometricSequenceTerms1(a, r, n);
        }

        [TestCase(1u, ExpectedResult = 13u)]
        [TestCase(2u, ExpectedResult = 52u)]
        [TestCase(3u, ExpectedResult = 169u)]
        [TestCase(4u, ExpectedResult = 520u)]
        [TestCase(5u, ExpectedResult = 1573u)]
        [TestCase(6u, ExpectedResult = 4732u)]
        [TestCase(7u, ExpectedResult = 14209u)]
        [TestCase(8u, ExpectedResult = 42640u)]
        [TestCase(9u, ExpectedResult = 127933u)]
        [TestCase(10u, ExpectedResult = 383812u)]
        [TestCase(11u, ExpectedResult = 1151449u)]
        [TestCase(12u, ExpectedResult = 3454360u)]
        [TestCase(13u, ExpectedResult = 10363093u)]
        [TestCase(14u, ExpectedResult = 31089292u)]
        [TestCase(15u, ExpectedResult = 93267889u)]
        public uint SumGeometricSequenceTerms2_ReturnsSum(uint n)
        {
            return GeometricSequences.SumGeometricSequenceTerms2(n);
        }

        [TestCase(3u, 2u, 2u, ExpectedResult = 0u)]
        [TestCase(3u, 2u, 3u, ExpectedResult = 1u)]
        [TestCase(3u, 2u, 6u, ExpectedResult = 2u)]
        [TestCase(3u, 2u, 12u, ExpectedResult = 3u)]
        [TestCase(3u, 2u, 24u, ExpectedResult = 4u)]
        [TestCase(3u, 2u, 48u, ExpectedResult = 5u)]
        [TestCase(3u, 2u, 96u, ExpectedResult = 6u)]
        [TestCase(3u, 2u, 192u, ExpectedResult = 7u)]
        [TestCase(3u, 2u, 384u, ExpectedResult = 8u)]
        [TestCase(3u, 2u, 768u, ExpectedResult = 9u)]
        [TestCase(3u, 2u, 1536u, ExpectedResult = 10u)]
        [TestCase(3u, 2u, 3072u, ExpectedResult = 11u)]
        public uint CountGeometricSequenceTerms3_ReturnsTermCount(uint a, uint r, uint maxTerm)
        {
            return GeometricSequences.CountGeometricSequenceTerms3(a, r, maxTerm);
        }

        [TestCase(3u, 2u, 10u, 1537u, ExpectedResult = 0u)]
        [TestCase(3u, 2u, 10u, 1536u, ExpectedResult = 1u)]
        [TestCase(3u, 2u, 10u, 768u, ExpectedResult = 2u)]
        [TestCase(3u, 2u, 10u, 384u, ExpectedResult = 3u)]
        [TestCase(3u, 2u, 10u, 192u, ExpectedResult = 4u)]
        [TestCase(3u, 2u, 10u, 96u, ExpectedResult = 5u)]
        [TestCase(3u, 2u, 10u, 48u, ExpectedResult = 6u)]
        [TestCase(3u, 2u, 10u, 24u, ExpectedResult = 7u)]
        [TestCase(3u, 2u, 10u, 12u, ExpectedResult = 8u)]
        [TestCase(3u, 2u, 10u, 6u, ExpectedResult = 9u)]
        [TestCase(3u, 2u, 10u, 3u, ExpectedResult = 10u)]
        [TestCase(3u, 2u, 10u, 0u, ExpectedResult = 10u)]
        [TestCase(3u, 2u, 9u, 769u, ExpectedResult = 0u)]
        [TestCase(3u, 2u, 9u, 768u, ExpectedResult = 1u)]
        [TestCase(3u, 2u, 9u, 384u, ExpectedResult = 2u)]
        [TestCase(3u, 2u, 9u, 192u, ExpectedResult = 3u)]
        [TestCase(3u, 2u, 9u, 96u, ExpectedResult = 4u)]
        [TestCase(3u, 2u, 9u, 48u, ExpectedResult = 5u)]
        [TestCase(3u, 2u, 9u, 24u, ExpectedResult = 6u)]
        [TestCase(3u, 2u, 9u, 12u, ExpectedResult = 7u)]
        [TestCase(3u, 2u, 9u, 6u, ExpectedResult = 8u)]
        [TestCase(3u, 2u, 9u, 3u, ExpectedResult = 9u)]
        [TestCase(3u, 2u, 9u, 0u, ExpectedResult = 9u)]
        public uint CountGeometricSequenceTerms4_ReturnsTermCount(uint a, uint r, uint n, uint minTerm)
        {
            return GeometricSequences.CountGeometricSequenceTerms4(a, r, n, minTerm);
        }
    }
}
