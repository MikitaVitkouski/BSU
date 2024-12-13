using System.Text;
using NUnit.Framework;

namespace Streams.Tests
{
    [TestFixture]
    public class ReadingFromStreamTests
    {
        private static readonly string Content =
            "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua." + Environment.NewLine +
            "Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat." + Environment.NewLine +
            "Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur." + Environment.NewLine +
            "Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.";

        private static readonly object[][] ReadLineByLineSource = new object[][]
        {
            new object[]
            {
                "one" + Environment.NewLine + "two" + Environment.NewLine + "three",
                new string[]
                {
                    "one",
                    "two",
                    "three",
                },
            },
            new object[]
            {
                Content,
                new string[]
                {
                    "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
                    "Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.",
                    "Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur.",
                    "Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                },
            },
        };

        private static readonly object[][] ReadAsCharArraysSource = new object[][]
        {
            new object[]
            {
                string.Empty,
                10,
                Array.Empty<char[]>(),
            },
            new object[]
            {
                "Lorem",
                5,
                new char[][]
                {
                    new char[] { 'L', 'o', 'r', 'e', 'm' },
                },
            },
            new object[]
            {
                "Lorem",
                1,
                new char[][]
                {
                    new char[] { 'L' },
                    new char[] { 'o' },
                    new char[] { 'r' },
                    new char[] { 'e' },
                    new char[] { 'm' },
                },
            },
            new object[]
            {
                "Loremipsumdolorsitamet",
                5,
                new char[][]
                {
                    new char[] { 'L', 'o', 'r', 'e', 'm' },
                    new char[] { 'i', 'p', 's', 'u', 'm' },
                    new char[] { 'd', 'o', 'l', 'o', 'r' },
                    new char[] { 's', 'i', 't', 'a', 'm' },
                    new char[] { 'e', 't' },
                },
            },
        };

        [Test]
        public void ReadAllStreamContent_StreamReaderIsNotNull_ReturnsAllStreamContent()
        {
            // Arrange
            var bytes = Encoding.ASCII.GetBytes(Content);
            using var memoryStream = new MemoryStream(bytes);
            using var streamReader = new StreamReader(memoryStream);

            // Act
            string actualContent = ReadingFromStream.ReadAllStreamContent(streamReader);

            // Assert
            Assert.AreEqual(Content, actualContent);
        }

        [TestCaseSource(nameof(ReadLineByLineSource))]
        public void ReadLineByLine_StreamReaderIsNotNull_ReturnsStringArray(object[] data)
        {
            // Arrange
            var bytes = Encoding.ASCII.GetBytes((string)data[0]);
            using var memoryStream = new MemoryStream(bytes);
            using var streamReader = new StreamReader(memoryStream);
            string[] expectedLines = (string[])data[1];

            // Act
            string[] actualLines = ReadingFromStream.ReadLineByLine(streamReader);

            // Assert
            Assert.AreEqual(expectedLines.Length, actualLines.Length);

            for (int i = 0; i < expectedLines.Length; i++)
            {
                Assert.AreEqual(expectedLines[i], actualLines[i]);
            }
        }

        [TestCase("abcdefg", -1, ExpectedResult = "abcdefg")]
        [TestCase("0123456789", -1, ExpectedResult = "0123456789")]
        [TestCase("abc01234de56789fg", -1, ExpectedResult = "abc01234de56789fg")]
        [TestCase("abc defg", 32, ExpectedResult = "abc")]
        [TestCase("012345,6789", 44, ExpectedResult = "012345")]
        [TestCase(" abc", 32, ExpectedResult = "")]
        [TestCase(":0123456789", 58, ExpectedResult = "")]
        public string ReadOnlyLettersAndNumbers_StreamReaderIsNotNull_ReturnsString(string content, int expectedNextCharacter)
        {
            // Arrange
            var bytes = Encoding.ASCII.GetBytes(content);
            using var memoryStream = new MemoryStream(bytes);
            using var streamReader = new StreamReader(memoryStream);

            // Act
            StringBuilder actualContent = ReadingFromStream.ReadOnlyLettersAndNumbers(streamReader);

            // Assert
            int actualNextCharacter = streamReader.Read();
            Assert.AreEqual(expectedNextCharacter, actualNextCharacter);
            return actualContent.ToString();
        }

        [TestCaseSource(nameof(ReadAsCharArraysSource))]
        public void ReadAsCharArrays_StreamReaderIsNotNull_ReturnsArrayOfCharArrays(object[] data)
        {
            // Arrange
            string content = (string)data[0];
            int arraySize = (int)data[1];
            char[][] expectedResult = (char[][])data[2];
            var bytes = Encoding.ASCII.GetBytes(content);
            using var memoryStream = new MemoryStream(bytes);
            using var streamReader = new StreamReader(memoryStream);

            // Act
            char[][] actualResult = ReadingFromStream.ReadAsCharArrays(streamReader, arraySize);

            // Assert
            Assert.AreEqual(expectedResult.Length, actualResult.Length);

            for (int i = 0; i < expectedResult.Length; i++)
            {
                Assert.AreEqual(expectedResult[i], actualResult[i]);
            }
        }
    }
}
