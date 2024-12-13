using NUnit.Framework;

namespace ShiftArrayElements.Tests
{
    [TestFixture]
    public class RecursiveEnumShifterTests
    {
        [Test]
        public void Shift_SourceIsNull_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => RecursiveEnumShifter.Shift(null, Array.Empty<Direction>()));
        }

        [Test]
        public void Shift_SourceIsNull_ThrowsArgumentNullExceptionWithCorrectParameterName()
        {
            try
            {
                RecursiveEnumShifter.Shift(null, Array.Empty<Direction>());
            }
            catch (ArgumentNullException e) when (e.ParamName == "source")
            {
            }
        }

        [Test]
        public void Shift_DirectionsIsNull_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => RecursiveEnumShifter.Shift(Array.Empty<int>(), null));
        }

        [Test]
        public void Shift_DirectionsIsNull_ThrowsArgumentNullExceptionWithCorrectParameterName()
        {
            try
            {
                RecursiveEnumShifter.Shift(Array.Empty<int>(), null);
            }
            catch (ArgumentNullException e) when (e.ParamName == "directions")
            {
            }
        }

        [TestCase(new int[] { })]
        [TestCase(new int[] { 1 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5 })]
        public void Shift_SourceIsNotNull_SourceEqualsResult(int[] source)
        {
            int[] result = RecursiveEnumShifter.Shift(source, Array.Empty<Direction>());

            Assert.AreSame(source, result);
        }

        [TestCase(new object[] { -1 })]
        [TestCase(new object[] { Direction.Left, 2 })]
        [TestCase(new object[] { Direction.Left, Direction.Right, 3 })]
        public void Shift_DirectionsContainsWrongValues_ThrowsInvalidOperationException(object[] objects)
        {
            var directions = objects.Cast<Direction>().ToArray();
            Assert.Throws<InvalidOperationException>(() => RecursiveEnumShifter.Shift(new[] { 1, 2, 3, 4, 5 }, directions));
        }

        [TestCase(new[] { 1 }, new Direction[] { }, ExpectedResult = new[] { 1 })]
        [TestCase(new[] { 1 }, new[] { Direction.Left }, ExpectedResult = new[] { 1 })]
        [TestCase(new[] { 1 }, new[] { Direction.Right }, ExpectedResult = new[] { 1 })]
        [TestCase(new[] { 1 }, new[] { Direction.Left, Direction.Left }, ExpectedResult = new[] { 1 })]
        [TestCase(new[] { 1 }, new[] { Direction.Right, Direction.Right }, ExpectedResult = new[] { 1 })]
        [TestCase(new[] { 1 }, new[] { Direction.Left, Direction.Right }, ExpectedResult = new[] { 1 })]
        [TestCase(new[] { 1 }, new[] { Direction.Right, Direction.Left }, ExpectedResult = new[] { 1 })]
        [TestCase(new[] { 1, 2 }, new Direction[] { }, ExpectedResult = new[] { 1, 2 })]
        [TestCase(new[] { 1, 2 }, new[] { Direction.Left }, ExpectedResult = new[] { 2, 1 })]
        [TestCase(new[] { 1, 2 }, new[] { Direction.Right }, ExpectedResult = new[] { 2, 1 })]
        [TestCase(new[] { 1, 2 }, new[] { Direction.Left, Direction.Left }, ExpectedResult = new[] { 1, 2 })]
        [TestCase(new[] { 1, 2 }, new[] { Direction.Right, Direction.Right }, ExpectedResult = new[] { 1, 2 })]
        [TestCase(new[] { 1, 2 }, new[] { Direction.Left, Direction.Right }, ExpectedResult = new[] { 1, 2 })]
        [TestCase(new[] { 1, 2 }, new[] { Direction.Right, Direction.Left }, ExpectedResult = new[] { 1, 2 })]
        [TestCase(new[] { 1, 2 }, new[] { Direction.Left, Direction.Left, Direction.Left }, ExpectedResult = new[] { 2, 1 })]
        [TestCase(new[] { 1, 2 }, new[] { Direction.Right, Direction.Right, Direction.Right }, ExpectedResult = new[] { 2, 1 })]
        [TestCase(new[] { 1, 2 }, new[] { Direction.Left, Direction.Right, Direction.Left }, ExpectedResult = new[] { 2, 1 })]
        [TestCase(new[] { 1, 2 }, new[] { Direction.Right, Direction.Left, Direction.Right }, ExpectedResult = new[] { 2, 1 })]
        [TestCase(new[] { 1, 2 }, new[] { Direction.Left, Direction.Left, Direction.Right }, ExpectedResult = new[] { 2, 1 })]
        [TestCase(new[] { 1, 2 }, new[] { Direction.Right, Direction.Right, Direction.Left }, ExpectedResult = new[] { 2, 1 })]
        [TestCase(new[] { 1, 2, 3 }, new Direction[] { }, ExpectedResult = new[] { 1, 2, 3 })]
        [TestCase(new[] { 1, 2, 3 }, new[] { Direction.Left }, ExpectedResult = new[] { 2, 3, 1 })]
        [TestCase(new[] { 1, 2, 3 }, new[] { Direction.Left, Direction.Left }, ExpectedResult = new[] { 3, 1, 2 })]
        [TestCase(new[] { 1, 2, 3 }, new[] { Direction.Left, Direction.Left, Direction.Left }, ExpectedResult = new[] { 1, 2, 3 })]
        [TestCase(new[] { 1, 2, 3 }, new[] { Direction.Right }, ExpectedResult = new[] { 3, 1, 2 })]
        [TestCase(new[] { 1, 2, 3 }, new[] { Direction.Right, Direction.Right }, ExpectedResult = new[] { 2, 3, 1 })]
        [TestCase(new[] { 1, 2, 3 }, new[] { Direction.Right, Direction.Right, Direction.Right }, ExpectedResult = new[] { 1, 2, 3 })]
        [TestCase(new[] { 1, 2, 3 }, new[] { Direction.Left, Direction.Right }, ExpectedResult = new[] { 1, 2, 3 })]
        [TestCase(new[] { 1, 2, 3 }, new[] { Direction.Right, Direction.Left }, ExpectedResult = new[] { 1, 2, 3 })]
        [TestCase(new[] { 1, 2, 3 }, new[] { Direction.Left, Direction.Right, Direction.Left, Direction.Right }, ExpectedResult = new[] { 1, 2, 3 })]
        [TestCase(new[] { 1, 2, 3 }, new[] { Direction.Right, Direction.Left, Direction.Right, Direction.Left }, ExpectedResult = new[] { 1, 2, 3 })]
        [TestCase(new[] { 1, 2, 3 }, new[] { Direction.Left, Direction.Left, Direction.Right, Direction.Right }, ExpectedResult = new[] { 1, 2, 3 })]
        [TestCase(new[] { 1, 2, 3 }, new[] { Direction.Right, Direction.Right, Direction.Left, Direction.Left }, ExpectedResult = new[] { 1, 2, 3 })]
        [TestCase(new[] { 1, 2, 3, 4, 5 }, new[] { Direction.Left }, ExpectedResult = new[] { 2, 3, 4, 5, 1 })]
        [TestCase(new[] { 1, 2, 3, 4, 5 }, new[] { Direction.Right }, ExpectedResult = new[] { 5, 1, 2, 3, 4 })]
        [TestCase(new[] { 1, 2, 3, 4, 5 }, new[] { Direction.Left, Direction.Left }, ExpectedResult = new[] { 3, 4, 5, 1, 2 })]
        [TestCase(new[] { 1, 2, 3, 4, 5 }, new[] { Direction.Right, Direction.Right }, ExpectedResult = new[] { 4, 5, 1, 2, 3 })]
        [TestCase(new[] { 1, 2, 3, 4, 5 }, new[] { Direction.Left, Direction.Left, Direction.Left, Direction.Left, Direction.Left }, ExpectedResult = new[] { 1, 2, 3, 4, 5 })]
        [TestCase(new[] { 1, 2, 3, 4, 5 }, new[] { Direction.Right, Direction.Right, Direction.Right, Direction.Right, Direction.Right }, ExpectedResult = new[] { 1, 2, 3, 4, 5 })]
        [TestCase(new[] { 1, 2, 3, 4, 5 }, new[] { Direction.Left, Direction.Left, Direction.Left, Direction.Left, Direction.Left }, ExpectedResult = new[] { 1, 2, 3, 4, 5 })]
        [TestCase(new[] { 1, 2, 3, 4, 5 }, new[] { Direction.Right, Direction.Right, Direction.Right, Direction.Right, Direction.Right }, ExpectedResult = new[] { 1, 2, 3, 4, 5 })]
        public int[] Shift_SourceAndDirectionsAreNotNull_ReturnsArrayWithShiftedElements(int[] source, Direction[] directions)
        {
            return RecursiveEnumShifter.Shift(source, directions);
        }
    }
}
