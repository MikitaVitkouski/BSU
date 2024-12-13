namespace Exceptions.Tests
{
    [TestFixture]
    public class HandlingExceptionsTests
    {
        [Test]
        public void CatchArgumentOutOfRangeException1_ExceptionIsThrown_ThrowsException()
        {
            Assert.Throws<Exception>(() =>
            {
                HandlingExceptions.CatchArgumentOutOfRangeException1(1, TestArgumentOutOfRangeException);
            });
        }

        [Test]
        public void CatchArgumentOutOfRangeException1_ArgumentOutOfRangeExceptionIsThrown_ThrowsException()
        {
            bool actualResult = HandlingExceptions.CatchArgumentOutOfRangeException1(-1, TestArgumentOutOfRangeException);

            Assert.AreEqual(false, actualResult);
        }

        [Test]
        public void CatchArgumentOutOfRangeException1_I_IsValid_ReturnsNumber()
        {
            bool actualResult = HandlingExceptions.CatchArgumentOutOfRangeException1(0, TestArgumentOutOfRangeException);

            Assert.AreEqual(true, actualResult);
        }

        [TestCase(-11)]
        [TestCase(11)]
        public void CatchArgumentOutOfRangeException2_ArgumentOutOfRangeException(int i)
        {
            string actualResult = HandlingExceptions.CatchArgumentOutOfRangeException2(i, "ABC", "123", out string errorMessage);

            Assert.AreEqual("K139", actualResult);
            Assert.IsTrue(errorMessage.Contains("i should be in [-10, 10] interval.", StringComparison.InvariantCulture));
        }

        [Test]
        public void CatchArgumentOutOfRangeException2_O_IsNull_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                HandlingExceptions.CatchArgumentOutOfRangeException2(0, null, "123", out string errorMessage);
            });
        }

        [Test]
        public void CatchArgumentOutOfRangeException2_S_IsNull_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                HandlingExceptions.CatchArgumentOutOfRangeException2(0, "ABC", null, out string errorMessage);
            });
        }

        [Test]
        public void CatchArgumentOutOfRangeException2_S_IsEmpty_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                HandlingExceptions.CatchArgumentOutOfRangeException2(0, "ABC", string.Empty, out string errorMessage);
            });
        }

        [TestCase(-10, ExpectedResult = "-10ABC123")]
        [TestCase(10, ExpectedResult = "10ABC123")]
        public string CatchArgumentOutOfRangeException2_ReturnsString(int i)
        {
            string actualResult = HandlingExceptions.CatchArgumentOutOfRangeException2(i, "ABC", "123", out string errorMessage);

            Assert.IsTrue(errorMessage is null);
            return actualResult;
        }

        [Test]
        public void CatchArgumentNullException3_ExceptionIsThrown_ThrowsException()
        {
            Assert.Throws<Exception>(() =>
            {
                HandlingExceptions.CatchArgumentNullException3(1, TestNullArgumentException);
            });
        }

        [Test]
        public void CatchArgumentNullException3_ArgumentNullExceptionIsThrown_ThrowsException()
        {
            string actualResult = HandlingExceptions.CatchArgumentNullException3(null, TestNullArgumentException);

            Assert.AreEqual("P456", actualResult);
        }

        [Test]
        public void CatchArgumentNullException3_I_IsValid_ReturnsNumber()
        {
            const string helloWorld = "Hello, world!";

            string actualResult = HandlingExceptions.CatchArgumentNullException3(helloWorld, TestNullArgumentException);

            Assert.AreEqual(helloWorld, actualResult);
        }

        [TestCase(-11)]
        [TestCase(11)]
        public void CatchArgumentNullException4_ArgumentOutOfRangeException(int i)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                HandlingExceptions.CatchArgumentNullException4(i, "ABC", "123", out string errorMessage);
            });
        }

        [Test]
        public void CatchArgumentNullException4_O_IsNull_ThrowsArgumentNullException()
        {
            string actualResult = HandlingExceptions.CatchArgumentNullException4(0, null, "123", out string errorMessage);

            Assert.AreEqual("A732", actualResult);
            Assert.IsTrue(errorMessage.Contains("o is null.", StringComparison.InvariantCulture));
        }

        [Test]
        public void CatchArgumentNullException4_S_IsNull_ThrowsArgumentNullException()
        {
            string actualResult = HandlingExceptions.CatchArgumentNullException4(0, "ABC", null, out string errorMessage);

            Assert.AreEqual("A732", actualResult);
            Assert.IsTrue(errorMessage.Contains("s is null.", StringComparison.InvariantCulture));
        }

        [Test]
        public void CatchArgumentNullException4_S_IsEmpty_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                HandlingExceptions.CatchArgumentNullException4(0, "ABC", string.Empty, out string errorMessage);
            });
        }

        [TestCase(-10, ExpectedResult = "-10ABC123")]
        [TestCase(10, ExpectedResult = "10ABC123")]
        public string CatchArgumentNullException4_ReturnsString(int i)
        {
            string actualResult = HandlingExceptions.CatchArgumentNullException4(i, "ABC", "123", out string errorMessage);

            Assert.IsTrue(errorMessage is null);
            return actualResult;
        }

        [Test]
        public void CatchArgumentException5_ExceptionIsThrown_ThrowsException()
        {
            Assert.Throws<Exception>(() =>
            {
                HandlingExceptions.CatchArgumentException5(new int[] { 0 }, TestArgumentException);
            });
        }

        [Test]
        public void CatchArgumentException5_ArgumentExceptionIsThrown_ThrowsException()
        {
            int actualResult = HandlingExceptions.CatchArgumentException5(Array.Empty<int>(), TestArgumentException);

            Assert.AreEqual(0, actualResult);
        }

        [Test]
        public void CatchArgumentException5_I_IsValid_ReturnsNumber()
        {
            int actualResult = HandlingExceptions.CatchArgumentException5(new int[] { 1, 2, 3 }, TestArgumentException);

            Assert.AreEqual(6, actualResult);
        }

        [TestCase(-11)]
        [TestCase(11)]
        public void CatchArgumentException6_CatchesArgumentException(int i)
        {
            string actualResult = HandlingExceptions.CatchArgumentException6(i, "ABC", "123", out string errorMessage);

            Assert.AreEqual("D948", actualResult);
            Assert.IsTrue(errorMessage.Contains("i should be in [-10, 10] interval.", StringComparison.InvariantCulture));
        }

        [Test]
        public void CatchArgumentException6_O_IsNull_CatchesArgumentException()
        {
            string actualResult = HandlingExceptions.CatchArgumentException6(0, null, "123", out string errorMessage);

            Assert.AreEqual("D948", actualResult);
            Assert.IsTrue(errorMessage.Contains("o is null.", StringComparison.InvariantCulture));
        }

        [Test]
        public void CatchArgumentException6_S_IsNull_CatchesArgumentException()
        {
            string actualResult = HandlingExceptions.CatchArgumentException6(0, "ABC", null, out string errorMessage);

            Assert.AreEqual("D948", actualResult);
            Assert.IsTrue(errorMessage.Contains("s is null.", StringComparison.InvariantCulture));
        }

        [Test]
        public void CatchArgumentException6_S_IsEmpty_CatchesArgumentException()
        {
            string actualResult = HandlingExceptions.CatchArgumentException6(0, "ABC", string.Empty, out string errorMessage);

            Assert.AreEqual("D948", actualResult);
            Assert.IsTrue(errorMessage.Contains("s string is empty.", StringComparison.InvariantCulture));
        }

        [TestCase(-10, ExpectedResult = "-10ABC123")]
        [TestCase(10, ExpectedResult = "10ABC123")]
        public string CatchArgumentException6_ReturnsString(int i)
        {
            string actualResult = HandlingExceptions.CatchArgumentException6(i, "ABC", "123", out string errorMessage);

            Assert.IsTrue(errorMessage is null);
            return actualResult;
        }

        [TestCase(0, "ABC", "123", ExpectedResult = "0ABC123")]
        public string DoSomething_ValidData_ReturnsString(int i, object o, string s)
        {
            return HandlingExceptions.DoSomething(i, o, s);
        }

        [TestCase(-11)]
        [TestCase(11)]
        public void CatchArgumentException7_ArgumentOutOfRangeException(int i)
        {
            string actualResult = HandlingExceptions.CatchArgumentException7(i, "ABC", "123", out string errorMessage);

            Assert.AreEqual("Z029", actualResult);
            Assert.IsTrue(errorMessage.Contains("i should be in [-10, 10] interval.", StringComparison.InvariantCulture));
        }

        [Test]
        public void CatchArgumentException7_O_IsNull_ThrowsArgumentNullException()
        {
            string actualResult = HandlingExceptions.CatchArgumentException7(0, null, "123", out string errorMessage);

            Assert.AreEqual("W694", actualResult);
            Assert.IsTrue(errorMessage.Contains("o is null.", StringComparison.InvariantCulture));
        }

        [Test]
        public void CatchArgumentException7_S_IsNull_ThrowsArgumentNullException()
        {
            string actualResult = HandlingExceptions.CatchArgumentException7(0, "ABC", null, out string errorMessage);

            Assert.AreEqual("W694", actualResult);
            Assert.IsTrue(errorMessage.Contains("s is null.", StringComparison.InvariantCulture));
        }

        [Test]
        public void CatchArgumentException7_S_IsEmpty_ThrowsArgumentException()
        {
            string actualResult = HandlingExceptions.CatchArgumentException7(0, "ABC", string.Empty, out string errorMessage);

            Assert.AreEqual("J954", actualResult);
            Assert.IsTrue(errorMessage.Contains("s string is empty.", StringComparison.InvariantCulture));
        }

        [TestCase(-10, ExpectedResult = "-10ABC123")]
        [TestCase(10, ExpectedResult = "10ABC123")]
        public string CatchArgumentException7_ReturnsString(int i)
        {
            string actualResult = HandlingExceptions.CatchArgumentException7(i, "ABC", "123", out string errorMessage);

            Assert.IsTrue(errorMessage is null);
            return actualResult;
        }

        private static bool TestArgumentOutOfRangeException(int i)
        {
            if (i < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(i));
            }

            if (i > 0)
            {
                throw new Exception();
            }

            return true;
        }

        private static string TestNullArgumentException(object o)
        {
            if (o is null)
            {
                throw new ArgumentNullException(nameof(o));
            }

            if (o is not string)
            {
                throw new Exception();
            }

            return o.ToString();
        }

        private static int TestArgumentException(int[] integers)
        {
            if (integers.Length == 0)
            {
                throw new ArgumentException(string.Empty, nameof(integers));
            }

            if (integers[0] == 0)
            {
                throw new Exception();
            }

            return integers.Sum();
        }
    }
}
