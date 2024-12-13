using NUnit.Framework;

namespace HelloWorld.Tests
{
    [TestFixture]
    public sealed class SimpleHelloWorldTests
    {
        [Test]
        public void ReturnHelloWorld()
        {
            string result = SimpleHelloWorld.ReturnHelloWorld();

            Assert.AreEqual("Hello, world!", result);
        }
    }
}
