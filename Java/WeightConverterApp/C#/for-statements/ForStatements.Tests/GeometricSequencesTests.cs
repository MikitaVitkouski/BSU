namespace ForStatements.Tests
{
    [TestFixture]
    public class GeometricSequencesTests
    {
        [TestCase(1u, 1u, 1u, ExpectedResult = 1ul)]
        [TestCase(1u, 1u, 2u, ExpectedResult = 1ul)]
        [TestCase(1u, 1u, 3u, ExpectedResult = 1ul)]
        [TestCase(1u, 1u, 4u, ExpectedResult = 1ul)]
        [TestCase(1u, 1u, 5u, ExpectedResult = 1ul)]
        [TestCase(2u, 1u, 1u, ExpectedResult = 2ul)]
        [TestCase(2u, 1u, 2u, ExpectedResult = 4ul)]
        [TestCase(2u, 1u, 3u, ExpectedResult = 8ul)]
        [TestCase(2u, 1u, 4u, ExpectedResult = 16ul)]
        [TestCase(2u, 1u, 5u, ExpectedResult = 32ul)]
        [TestCase(3u, 1u, 1u, ExpectedResult = 3ul)]
        [TestCase(3u, 1u, 2u, ExpectedResult = 9ul)]
        [TestCase(3u, 1u, 3u, ExpectedResult = 27ul)]
        [TestCase(3u, 1u, 4u, ExpectedResult = 81ul)]
        [TestCase(3u, 1u, 5u, ExpectedResult = 243ul)]
        [TestCase(4u, 2u, 1u, ExpectedResult = 4ul)]
        [TestCase(4u, 2u, 2u, ExpectedResult = 32ul)]
        [TestCase(4u, 2u, 3u, ExpectedResult = 512ul)]
        [TestCase(4u, 2u, 4u, ExpectedResult = 16384ul)]
        [TestCase(4u, 2u, 5u, ExpectedResult = 1048576ul)]
        [TestCase(5u, 3u, 1u, ExpectedResult = 5ul)]
        [TestCase(5u, 3u, 2u, ExpectedResult = 75ul)]
        [TestCase(5u, 3u, 3u, ExpectedResult = 3375ul)]
        [TestCase(5u, 3u, 4u, ExpectedResult = 455625ul)]
        [TestCase(5u, 3u, 5u, ExpectedResult = 184528125ul)]
        public ulong GetGeometricSequenceTermsProduct_ReturnsProduct(uint a, uint r, uint n)
        {
            return GeometricSequences.GetGeometricSequenceTermsProduct(a, r, n);
        }

        [TestCase(1u, ExpectedResult = 5ul)]
        [TestCase(2u, ExpectedResult = 20ul)]
        [TestCase(3u, ExpectedResult = 65ul)]
        [TestCase(4u, ExpectedResult = 200ul)]
        [TestCase(5u, ExpectedResult = 605ul)]
        [TestCase(6u, ExpectedResult = 1820ul)]
        [TestCase(7u, ExpectedResult = 5465ul)]
        [TestCase(8u, ExpectedResult = 16400ul)]
        [TestCase(9u, ExpectedResult = 49205ul)]
        [TestCase(10u, ExpectedResult = 147620ul)]
        [TestCase(11u, ExpectedResult = 442865ul)]
        [TestCase(12u, ExpectedResult = 1328600ul)]
        [TestCase(13u, ExpectedResult = 3985805ul)]
        [TestCase(14u, ExpectedResult = 11957420ul)]
        [TestCase(15u, ExpectedResult = 35872265ul)]
        public ulong SumGeometricSequenceTerms_ReturnsSum(uint n)
        {
            return GeometricSequences.SumGeometricSequenceTerms(n);
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
        public ulong CountGeometricSequenceTerms3_ReturnsTermCount(uint a, uint r, uint maxTerm)
        {
            return GeometricSequences.CountGeometricSequenceTerms1(a, r, maxTerm);
        }

        [TestCase(3u, 2u, 10u, 1537u, ExpectedResult = 0ul)]
        [TestCase(3u, 2u, 10u, 1536u, ExpectedResult = 1ul)]
        [TestCase(3u, 2u, 10u, 768u, ExpectedResult = 2ul)]
        [TestCase(3u, 2u, 10u, 384u, ExpectedResult = 3ul)]
        [TestCase(3u, 2u, 10u, 192u, ExpectedResult = 4ul)]
        [TestCase(3u, 2u, 10u, 96u, ExpectedResult = 5ul)]
        [TestCase(3u, 2u, 10u, 48u, ExpectedResult = 6ul)]
        [TestCase(3u, 2u, 10u, 24u, ExpectedResult = 7ul)]
        [TestCase(3u, 2u, 10u, 12u, ExpectedResult = 8ul)]
        [TestCase(3u, 2u, 10u, 6u, ExpectedResult = 9ul)]
        [TestCase(3u, 2u, 10u, 3u, ExpectedResult = 10ul)]
        [TestCase(3u, 2u, 10u, 0u, ExpectedResult = 10ul)]
        [TestCase(3u, 2u, 9u, 769u, ExpectedResult = 0ul)]
        [TestCase(3u, 2u, 9u, 768u, ExpectedResult = 1ul)]
        [TestCase(3u, 2u, 9u, 384u, ExpectedResult = 2ul)]
        [TestCase(3u, 2u, 9u, 192u, ExpectedResult = 3ul)]
        [TestCase(3u, 2u, 9u, 96u, ExpectedResult = 4ul)]
        [TestCase(3u, 2u, 9u, 48u, ExpectedResult = 5ul)]
        [TestCase(3u, 2u, 9u, 24u, ExpectedResult = 6ul)]
        [TestCase(3u, 2u, 9u, 12u, ExpectedResult = 7ul)]
        [TestCase(3u, 2u, 9u, 6u, ExpectedResult = 8ul)]
        [TestCase(3u, 2u, 9u, 3u, ExpectedResult = 9ul)]
        [TestCase(3u, 2u, 9u, 0u, ExpectedResult = 9ul)]
        public ulong CountGeometricSequenceTerms4_ReturnsTermCount(uint a, uint r, uint n, uint minTerm)
        {
            return GeometricSequences.CountGeometricSequenceTerms2(a, r, n, minTerm);
        }
    }
}
