namespace Exceptions.Tests
{
    public class NullCoalescingAssignmentTests
    {
        [Test]
        public void CheckParameterAndThrowException1_O_IsNull_ReturnsObject()
        {
            // Act
            object actualResult = NullCoalescingAssignment.CheckParameterAndThrowException1(null);

            // Assert
            Assert.IsNotNull(actualResult);
        }

        [Test]
        public void CheckParameterAndThrowException1_O_IsNotNull_ReturnsObject()
        {
            // Arrange
            object o = new object();

            // Act
            object actualResult = NullCoalescingAssignment.CheckParameterAndThrowException1(o);

            // Assert
            Assert.IsNotNull(actualResult);
            Assert.AreSame(o, actualResult);
        }

        [Test]
        public void CheckParameterAndThrowException2_IntegersIsNull_ReturnsArray()
        {
            // Act
            int[] actualResult = NullCoalescingAssignment.CheckParameterAndThrowException2(null);

            // Assert
            Assert.IsNotNull(actualResult);
            Assert.AreEqual(new int[] { 0 }, actualResult);
        }

        [Test]
        public void CheckParameterAndThrowException2_IntegersIsNotNull_ReturnsArray()
        {
            // Arrange
            int[] integers = new int[] { 1, 2, 3 };

            // Act
            int[] actualResult = NullCoalescingAssignment.CheckParameterAndThrowException2(integers);

            // Assert
            Assert.IsNotNull(actualResult);
            Assert.AreSame(integers, actualResult);
        }

        [TestCase(null, ExpectedResult = "Hello, world!")]
        [TestCase("", ExpectedResult = "")]
        [TestCase("a", ExpectedResult = "a")]
        [TestCase("ab", ExpectedResult = "ab")]
        [TestCase("abc", ExpectedResult = "abc")]
        public string CheckParameterAndThrowException3_ReturnsString(string s)
        {
            string actualResult = NullCoalescingAssignment.CheckParameterAndThrowException3(s);

            return actualResult;
        }

        [TestCase(null, null, ExpectedResult = "Hello, world!")]
        [TestCase(null, "", ExpectedResult = "Hello, !")]
        [TestCase("", null, ExpectedResult = ", world!")]
        [TestCase("Hi", "Joe", ExpectedResult = "Hi, Joe!")]
        public string CheckParametersAndThrowException4_ReturnsString(string s1, string s2)
        {
            string actualResult = NullCoalescingAssignment.CheckParametersAndThrowException4(s1, s2);

            return actualResult;
        }

        [TestCase(null, null, null, ExpectedResult = "abc3123")]
        [TestCase(null, new int[] { }, "", ExpectedResult = "abc0")]
        [TestCase(null, null, "", ExpectedResult = "abc3")]
        [TestCase(null, new int[] { }, null, ExpectedResult = "abc0123")]
        [TestCase("", null, null, ExpectedResult = "3123")]
        [TestCase("", null, "", ExpectedResult = "3")]
        [TestCase("", new int[] { }, null, ExpectedResult = "0123")]
        [TestCase("", new int[] { }, "", ExpectedResult = "0")]
        [TestCase("", new int[] { 0 }, "", ExpectedResult = "1")]
        [TestCase("a", new int[] { 0, 1 }, "", ExpectedResult = "a2")]
        [TestCase("", new int[] { }, "1", ExpectedResult = "01")]
        [TestCase("", new int[] { 0 }, "1", ExpectedResult = "11")]
        [TestCase("a", new int[] { 0, 1 }, "1", ExpectedResult = "a21")]
        [TestCase("ab", new int[] { 0, 1 }, "12", ExpectedResult = "ab212")]
        public string CheckParametersAndThrowException5_ReturnsString(string s1, int[] integers, string s3)
        {
            string actualResult = NullCoalescingAssignment.CheckParametersAndThrowException5(s1, integers, s3);

            return actualResult;
        }
    }
}
