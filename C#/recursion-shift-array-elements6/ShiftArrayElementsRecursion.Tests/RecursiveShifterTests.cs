using NUnit.Framework;

namespace ShiftArrayElements.Tests
{
    [TestFixture]
    public class RecursiveShifterTests
    {
        [Test]
        public void Shift_SourceIsNull_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => RecursiveShifter.Shift(null, Array.Empty<int>()));
        }

        [Test]
        public void Shift_SourceIsNull_ThrowsArgumentNullExceptionWithCorrectParameterName()
        {
            try
            {
                RecursiveShifter.Shift(null, Array.Empty<int>());
            }
            catch (ArgumentNullException e) when (e.ParamName == "source")
            {
            }
        }

        [Test]
        public void Shift_IterationsIsNull_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => RecursiveShifter.Shift(Array.Empty<int>(), null));
        }

        [Test]
        public void Shift_IterationsIsNull_ThrowsArgumentNullExceptionWithCorrectParameterName()
        {
            try
            {
                RecursiveShifter.Shift(Array.Empty<int>(), null);
            }
            catch (ArgumentNullException e) when (e.ParamName == "iterations")
            {
            }
        }

        [TestCase(new int[] { })]
        [TestCase(new int[] { 1 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5 })]
        public void Shift_SourceIsNotNull_SourceEqualsResult(int[] source)
        {
            int[] result = RecursiveShifter.Shift(source, Array.Empty<int>());

            Assert.AreSame(source, result);
        }

        [TestCase(new int[] { }, new[] { 0 }, ExpectedResult = new int[] { })]
        [TestCase(new int[] { }, new int[] { }, ExpectedResult = new int[] { })]
        [TestCase(new[] { 1 }, new int[] { }, ExpectedResult = new[] { 1 })]
        [TestCase(new[] { 1 }, new[] { 0 }, ExpectedResult = new[] { 1 })]
        [TestCase(new[] { 1 }, new[] { 1 }, ExpectedResult = new[] { 1 })]
        [TestCase(new[] { 1 }, new[] { 2 }, ExpectedResult = new[] { 1 })]
        [TestCase(new[] { 1 }, new[] { 3 }, ExpectedResult = new[] { 1 })]
        [TestCase(new[] { 1 }, new[] { 4 }, ExpectedResult = new[] { 1 })]
        [TestCase(new[] { 1 }, new[] { 0, 0 }, ExpectedResult = new[] { 1 })]
        [TestCase(new[] { 1 }, new[] { 0, 1 }, ExpectedResult = new[] { 1 })]
        [TestCase(new[] { 1 }, new[] { 0, 2 }, ExpectedResult = new[] { 1 })]
        [TestCase(new[] { 1 }, new[] { 0, 3 }, ExpectedResult = new[] { 1 })]
        [TestCase(new[] { 1 }, new[] { 0, 4 }, ExpectedResult = new[] { 1 })]
        [TestCase(new[] { 1 }, new[] { 1, 0 }, ExpectedResult = new[] { 1 })]
        [TestCase(new[] { 1 }, new[] { 1, 1 }, ExpectedResult = new[] { 1 })]
        [TestCase(new[] { 1 }, new[] { 1, 2 }, ExpectedResult = new[] { 1 })]
        [TestCase(new[] { 1 }, new[] { 1, 3 }, ExpectedResult = new[] { 1 })]
        [TestCase(new[] { 1 }, new[] { 1, 4 }, ExpectedResult = new[] { 1 })]
        [TestCase(new[] { 1 }, new[] { 2, 0 }, ExpectedResult = new[] { 1 })]
        [TestCase(new[] { 1 }, new[] { 2, 1 }, ExpectedResult = new[] { 1 })]
        [TestCase(new[] { 1 }, new[] { 2, 2 }, ExpectedResult = new[] { 1 })]
        [TestCase(new[] { 1 }, new[] { 2, 3 }, ExpectedResult = new[] { 1 })]
        [TestCase(new[] { 1 }, new[] { 2, 4 }, ExpectedResult = new[] { 1 })]
        [TestCase(new[] { 1, 2 }, new int[] { }, ExpectedResult = new[] { 1, 2 })]
        [TestCase(new[] { 1, 2 }, new[] { 0 }, ExpectedResult = new[] { 1, 2 })]
        [TestCase(new[] { 1, 2 }, new[] { 1 }, ExpectedResult = new[] { 2, 1 })]
        [TestCase(new[] { 1, 2 }, new[] { 2 }, ExpectedResult = new[] { 1, 2 })]
        [TestCase(new[] { 1, 2 }, new[] { 3 }, ExpectedResult = new[] { 2, 1 })]
        [TestCase(new[] { 1, 2 }, new[] { 4 }, ExpectedResult = new[] { 1, 2 })]
        [TestCase(new[] { 1, 2 }, new[] { 0, 1 }, ExpectedResult = new[] { 2, 1 })]
        [TestCase(new[] { 1, 2 }, new[] { 0, 2 }, ExpectedResult = new[] { 1, 2 })]
        [TestCase(new[] { 1, 2 }, new[] { 0, 3 }, ExpectedResult = new[] { 2, 1 })]
        [TestCase(new[] { 1, 2 }, new[] { 0, 4 }, ExpectedResult = new[] { 1, 2 })]
        [TestCase(new[] { 1, 2 }, new[] { 1, 1 }, ExpectedResult = new[] { 1, 2 })]
        [TestCase(new[] { 1, 2 }, new[] { 1, 2 }, ExpectedResult = new[] { 2, 1 })]
        [TestCase(new[] { 1, 2 }, new[] { 1, 3 }, ExpectedResult = new[] { 1, 2 })]
        [TestCase(new[] { 1, 2 }, new[] { 1, 4 }, ExpectedResult = new[] { 2, 1 })]
        [TestCase(new[] { 1, 2 }, new[] { 2, 1 }, ExpectedResult = new[] { 2, 1 })]
        [TestCase(new[] { 1, 2 }, new[] { 2, 2 }, ExpectedResult = new[] { 1, 2 })]
        [TestCase(new[] { 1, 2 }, new[] { 2, 3 }, ExpectedResult = new[] { 2, 1 })]
        [TestCase(new[] { 1, 2 }, new[] { 2, 4 }, ExpectedResult = new[] { 1, 2 })]
        [TestCase(new[] { 1, 2 }, new[] { 3, 1 }, ExpectedResult = new[] { 1, 2 })]
        [TestCase(new[] { 1, 2 }, new[] { 3, 2 }, ExpectedResult = new[] { 2, 1 })]
        [TestCase(new[] { 1, 2 }, new[] { 3, 3 }, ExpectedResult = new[] { 1, 2 })]
        [TestCase(new[] { 1, 2 }, new[] { 3, 4 }, ExpectedResult = new[] { 2, 1 })]
        [TestCase(new[] { 1, 2 }, new[] { 4, 1 }, ExpectedResult = new[] { 2, 1 })]
        [TestCase(new[] { 1, 2 }, new[] { 4, 2 }, ExpectedResult = new[] { 1, 2 })]
        [TestCase(new[] { 1, 2 }, new[] { 4, 3 }, ExpectedResult = new[] { 2, 1 })]
        [TestCase(new[] { 1, 2 }, new[] { 4, 4 }, ExpectedResult = new[] { 1, 2 })]
        [TestCase(new[] { 1, 2, 3, 4, 5 }, new int[] { }, ExpectedResult = new[] { 1, 2, 3, 4, 5 })]
        [TestCase(new[] { 1, 2, 3, 4, 5 }, new[] { 0 }, ExpectedResult = new[] { 1, 2, 3, 4, 5 })]
        [TestCase(new[] { 1, 2, 3, 4, 5 }, new[] { 0, 0 }, ExpectedResult = new[] { 1, 2, 3, 4, 5 })]
        [TestCase(new[] { 1, 2, 3, 4, 5 }, new[] { 0, 0, 0 }, ExpectedResult = new[] { 1, 2, 3, 4, 5 })]
        [TestCase(new[] { 1, 2, 3, 4, 5 }, new[] { 1 }, ExpectedResult = new[] { 2, 3, 4, 5, 1 })]
        [TestCase(new[] { 1, 2, 3, 4, 5 }, new[] { 0, 1 }, ExpectedResult = new[] { 5, 1, 2, 3, 4 })]
        [TestCase(new[] { 1, 2, 3, 4, 5 }, new[] { 1, 1 }, ExpectedResult = new[] { 1, 2, 3, 4, 5 })]
        [TestCase(new[] { 1, 2, 3, 4, 5 }, new[] { 1, 1, 1 }, ExpectedResult = new[] { 2, 3, 4, 5, 1 })]
        [TestCase(new[] { 1, 2, 3, 4, 5 }, new[] { 1, 1, 1, 1 }, ExpectedResult = new[] { 1, 2, 3, 4, 5 })]
        [TestCase(new[] { 1, 2, 3, 4, 5 }, new[] { 1, 2 }, ExpectedResult = new[] { 5, 1, 2, 3, 4 })]
        [TestCase(new[] { 1, 2, 3, 4, 5 }, new[] { 2, 1 }, ExpectedResult = new[] { 2, 3, 4, 5, 1 })]
        [TestCase(new[] { 1, 2, 3, 4, 5 }, new[] { 1, 2, 3 }, ExpectedResult = new[] { 3, 4, 5, 1, 2 })]
        [TestCase(new[] { 1, 2, 3, 4, 5 }, new[] { 1, 2, 3, 4 }, ExpectedResult = new[] { 4, 5, 1, 2, 3 })]
        public int[] Shift_SourceAndIterationsAreNotNull_ReturnsArrayWithShiftedElements(int[] source, int[] iterations)
        {
            return RecursiveShifter.Shift(source, iterations);
        }
    }
}
