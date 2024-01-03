using NUnit.Framework;

namespace Streams.Tests
{
    [TestFixture]
    public class ReadingFromStringTests
    {
        private readonly string content =
            "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.\n" +
            "Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.\n" +
            "Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur.\n" +
            "Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.";

        [Test]
        public void ReadAllStreamContent_StringReaderIsNotNull_ReturnsAllStreamContent()
        {
            // Arrange
            using var stringReader = new StringReader(this.content);

            // Act
            string actualContent = ReadingFromString.ReadAllStreamContent(stringReader);

            // Assert
            Assert.AreEqual(this.content, actualContent);
        }

        [TestCase(0, ExpectedResult = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.")]
        [TestCase(1, ExpectedResult = "Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.")]
        [TestCase(2, ExpectedResult = "Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur.")]
        [TestCase(3, ExpectedResult = "Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.")]
        public string? ReadCurrentLine_StringReaderIsNotNull_ReturnsCurrentLine(int linesToRead)
        {
            // Arrange
            using var stringReader = new StringReader(this.content);

            while (linesToRead > 0)
            {
                _ = stringReader.ReadLine();
                linesToRead--;
            }

            // Act
            string? actualContent = ReadingFromString.ReadCurrentLine(stringReader);

            // Assert
            return actualContent;
        }

        [TestCase(0, 'L', 'o', ExpectedResult = true)]
        [TestCase(1, 'o', 'r', ExpectedResult = true)]
        [TestCase(2, 'r', 'e', ExpectedResult = true)]
        [TestCase(3, 'e', 'm', ExpectedResult = true)]
        [TestCase(4, 'm', ' ', ExpectedResult = true)]
        [TestCase(124, 'U', 't', ExpectedResult = true)]
        [TestCase(444, '.', ' ', ExpectedResult = true)]
        [TestCase(448, ' ', ' ', ExpectedResult = false)]
        public bool ReadNextCharacter_StringReaderIsNotNull_ReturnsCurrentCharacter(int charsToRead, char expectedCharacter, char nextCharacter)
        {
            // Arrange
            using var stringReader = new StringReader(this.content);

            int streamValue = 0;

            while (charsToRead > 0 && streamValue >= 0)
            {
                streamValue = stringReader.Read();
                charsToRead--;
            }

            // Act
            bool actualResult = ReadingFromString.ReadNextCharacter(stringReader, out char actualCharacter);

            // Assert
            Assert.AreEqual(expectedCharacter, actualCharacter);

            streamValue = stringReader.Read();
            if (streamValue >= 0)
            {
                Assert.AreEqual(nextCharacter, Convert.ToChar(streamValue));
            }

            return actualResult;
        }

        [TestCase(0, 'L', 'L', ExpectedResult = true)]
        [TestCase(1, 'o', 'o', ExpectedResult = true)]
        [TestCase(2, 'r', 'r', ExpectedResult = true)]
        [TestCase(3, 'e', 'e', ExpectedResult = true)]
        [TestCase(4, 'm', 'm', ExpectedResult = true)]
        [TestCase(124, 'U', 'U', ExpectedResult = true)]
        [TestCase(444, '.', '.', ExpectedResult = true)]
        [TestCase(448, ' ', ' ', ExpectedResult = false)]
        public bool ReadNextLetter_StringReaderIsNotNull_ReturnsCurrentCharacter(int charsToRead, char expectedCharacter, char nextCharacter)
        {
            // Arrange
            using var stringReader = new StringReader(this.content);

            int streamValue = 0;

            while (charsToRead > 0 && streamValue >= 0)
            {
                streamValue = stringReader.Read();
                charsToRead--;
            }

            // Act
            bool actualResult = ReadingFromString.PeekNextCharacter(stringReader, out char actualCharacter);

            // Assert
            Assert.AreEqual(expectedCharacter, actualCharacter);

            streamValue = stringReader.Read();
            if (streamValue >= 0)
            {
                Assert.AreEqual(nextCharacter, Convert.ToChar(streamValue));
            }

            return actualResult;
        }

        [TestCase(0, 1, ExpectedResult = new char[] { 'L' })]
        [TestCase(0, 2, ExpectedResult = new char[] { 'L', 'o' })]
        [TestCase(0, 3, ExpectedResult = new char[] { 'L', 'o', 'r' })]
        [TestCase(0, 4, ExpectedResult = new char[] { 'L', 'o', 'r', 'e' })]
        [TestCase(0, 5, ExpectedResult = new char[] { 'L', 'o', 'r', 'e', 'm' })]
        public char[] ReadCharactersToBuffer_StringReaderIsNotNull_ReturnsBufferWithCharacters(int charsToRead, int count)
        {
            // Arrange
            using var stringReader = new StringReader(this.content);

            while (charsToRead > 0)
            {
                _ = stringReader.Read();
                charsToRead--;
            }

            // Act
            char[] actualBuffer = ReadingFromString.ReadCharactersToBuffer(stringReader, count);

            // Assert
            return actualBuffer;
        }
    }
}
