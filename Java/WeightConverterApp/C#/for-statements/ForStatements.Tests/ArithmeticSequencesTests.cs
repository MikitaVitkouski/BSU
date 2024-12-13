global using NUnit.Framework;

namespace ForStatements.Tests
{
    [TestFixture]
    public class ArithmeticSequencesTests
    {
        [TestCase(0, 0, ExpectedResult = 0)]
        [TestCase(1, 0, ExpectedResult = 0)]
        [TestCase(1, 1, ExpectedResult = 1)]
        [TestCase(1, 2, ExpectedResult = 3)]
        [TestCase(1, 3, ExpectedResult = 6)]
        [TestCase(1, 4, ExpectedResult = 10)]
        [TestCase(1, 5, ExpectedResult = 15)]
        [TestCase(2, 0, ExpectedResult = 0)]
        [TestCase(2, 1, ExpectedResult = 2)]
        [TestCase(2, 2, ExpectedResult = 5)]
        [TestCase(2, 3, ExpectedResult = 9)]
        [TestCase(2, 4, ExpectedResult = 14)]
        [TestCase(2, 5, ExpectedResult = 20)]
        [TestCase(3, 0, ExpectedResult = 0)]
        [TestCase(3, 1, ExpectedResult = 3)]
        [TestCase(3, 2, ExpectedResult = 7)]
        [TestCase(3, 3, ExpectedResult = 12)]
        [TestCase(3, 4, ExpectedResult = 18)]
        [TestCase(3, 5, ExpectedResult = 25)]
        [TestCase(4, 0, ExpectedResult = 0)]
        [TestCase(4, 1, ExpectedResult = 4)]
        [TestCase(4, 2, ExpectedResult = 9)]
        [TestCase(4, 3, ExpectedResult = 15)]
        [TestCase(4, 4, ExpectedResult = 22)]
        [TestCase(4, 5, ExpectedResult = 30)]
        [TestCase(5, 0, ExpectedResult = 0)]
        [TestCase(5, 1, ExpectedResult = 5)]
        [TestCase(5, 2, ExpectedResult = 11)]
        [TestCase(5, 3, ExpectedResult = 18)]
        [TestCase(5, 4, ExpectedResult = 26)]
        [TestCase(5, 5, ExpectedResult = 35)]
        public int SumArithmeticSequenceTerms1_ReturnsSum(int a, int n)
        {
            return ArithmeticSequences.SumArithmeticSequenceTerms1(a, n);
        }

        [TestCase(0, ExpectedResult = 0)]
        [TestCase(1, ExpectedResult = 47)]
        [TestCase(2, ExpectedResult = 107)]
        [TestCase(3, ExpectedResult = 180)]
        [TestCase(4, ExpectedResult = 266)]
        [TestCase(5, ExpectedResult = 365)]
        [TestCase(6, ExpectedResult = 477)]
        [TestCase(7, ExpectedResult = 602)]
        [TestCase(8, ExpectedResult = 740)]
        [TestCase(9, ExpectedResult = 891)]
        [TestCase(10, ExpectedResult = 1055)]
        public int SumArithmeticSequenceTerms2_ReturnsSum(int n)
        {
            return ArithmeticSequences.SumArithmeticSequenceTerms2(n);
        }

        [TestCase(0, 0, ExpectedResult = 0)]
        [TestCase(1, 0, ExpectedResult = 0)]
        [TestCase(1, 1, ExpectedResult = 1)]
        [TestCase(1, 2, ExpectedResult = 7)]
        [TestCase(1, 3, ExpectedResult = 18)]
        [TestCase(1, 4, ExpectedResult = 34)]
        [TestCase(1, 5, ExpectedResult = 55)]
        [TestCase(2, 0, ExpectedResult = 0)]
        [TestCase(2, 1, ExpectedResult = 2)]
        [TestCase(2, 2, ExpectedResult = 9)]
        [TestCase(2, 3, ExpectedResult = 21)]
        [TestCase(2, 4, ExpectedResult = 38)]
        [TestCase(2, 5, ExpectedResult = 60)]
        [TestCase(3, 0, ExpectedResult = 0)]
        [TestCase(3, 1, ExpectedResult = 3)]
        [TestCase(3, 2, ExpectedResult = 11)]
        [TestCase(3, 3, ExpectedResult = 24)]
        [TestCase(3, 4, ExpectedResult = 42)]
        [TestCase(3, 5, ExpectedResult = 65)]
        [TestCase(4, 0, ExpectedResult = 0)]
        [TestCase(4, 1, ExpectedResult = 4)]
        [TestCase(4, 2, ExpectedResult = 13)]
        [TestCase(4, 3, ExpectedResult = 27)]
        [TestCase(4, 4, ExpectedResult = 46)]
        [TestCase(4, 5, ExpectedResult = 70)]
        [TestCase(5, 0, ExpectedResult = 0)]
        [TestCase(5, 1, ExpectedResult = 5)]
        [TestCase(5, 2, ExpectedResult = 15)]
        [TestCase(5, 3, ExpectedResult = 30)]
        [TestCase(5, 4, ExpectedResult = 50)]
        [TestCase(5, 5, ExpectedResult = 75)]
        public int SumArithmeticSequenceTerms3_ReturnsSum(int a, int n)
        {
            var result = ArithmeticSequences.SumArithmeticSequenceTerms3(a, n);
            Console.Write($"[TestCase({a}, {n}, ExpectedResult = {result})]");
            return result;
        }
    }
}
