using System.Reflection;
using NUnit.Framework;

// ReSharper disable StringLiteralTypo
namespace StyleIssues.Tests
{
    [TestFixture]
    public sealed class StyleIssuesTests
    {
        [Test]
        public void SA1001_Sum_ReturnsSum()
        {
            int result = SA1001.Math.Sum(1, 1);

            Assert.AreEqual(2, result);
        }

        [Test]
        public void SA1002_Sum_ReturnsSum()
        {
            int result = SA1002.Math.Sum(1, 1);

            Assert.AreEqual(2, result);
        }

        [Test]
        public void SA1005_Sum_ReturnsSum()
        {
            int result = SA1005.Math.Sum(1, 1);

            Assert.AreEqual(2, result);
        }

        [Test]
        public void SA1008_Sum_ReturnsSum()
        {
            int result = SA1008.Math.Sum(1, 1);

            Assert.AreEqual(2, result);
        }

        [Test]
        public void SA1025_Sum_ReturnsSum()
        {
            int result = SA1025.Math.Sum(1, 1);

            Assert.AreEqual(2, result);
        }

        [Test]
        public void SA1028_Sum_ReturnsSum()
        {
            int result = SA1028.Math.Sum(1, 1);

            Assert.AreEqual(2, result);
        }

        [Test]
        public void SA1500_Sum_ReturnsSum()
        {
            int result = SA1500.Math.Sum(1, 1);

            Assert.AreEqual(2, result);
        }

        [Test]
        public void SA1505_Sum_ReturnsSum()
        {
            int result = SA1505.Math.Sum(1, 1);

            Assert.AreEqual(2, result);
        }

        [Test]
        public void SA1507_Sum_ReturnsSum()
        {
            int result = SA1507.Math.Sum(1, 1);

            Assert.AreEqual(2, result);
        }

        [Test]
        public void SA1508_Sum_ReturnsSum()
        {
            int result = SA1508.Math.Sum(1, 1);

            Assert.AreEqual(2, result);
        }

        [TestCase("1", ExpectedResult = "K-1")]
        [TestCase("10", ExpectedResult = "K-10")]
        [TestCase("100", ExpectedResult = "K-100")]
        public string CA1304_MyMethod_ReturnsString(string str)
        {
            return CA1304.MyClass.MyMethod(str);
        }

        [TestCase(1, ExpectedResult = "X1")]
        public string CA1305_MyMethod_ReturnsString(int i)
        {
            return CA1305.MyClass.MyMethod(i);
        }

        [TestCase("a", ExpectedResult = "testa")]
        public string CA1507_MyMethod_ReturnsString(string str)
        {
            return CA1507.MyClass.MyMethod(str);
        }

        [Test]
        public void CA1507_MyMethod_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => CA1507.MyClass.MyMethod(null));
        }

        [Test]
        public void CA1707_MyMethod_ReturnsString()
        {
            Type type = typeof(CA1707.MyClass);
            MethodInfo? methodInfo = type.GetMethod("MyMethod", BindingFlags.Static | BindingFlags.Public);

            Assert.NotNull(methodInfo, "CA1707.MyClass has no MyMethod method.");

#pragma warning disable CS8602 // Dereference of a possibly null reference.
            var parameters = methodInfo.GetParameters();
#pragma warning restore CS8602 // Dereference of a possibly null reference.
            Assert.IsTrue(parameters.Any(p => p.Name == "myStr"), "CA1707.MyClass.MyMethod has no myStr parameter.");
        }
    }
}
