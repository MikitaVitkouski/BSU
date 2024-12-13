using System.Text;
using NUnit.Framework;

namespace Streams.Tests
{
    [TestFixture]
    public class WritingToStreamTests
    {
        private static readonly object[][] WriteLinesWithNumbersSource = new object[][]
        {
            new object[]
            {
                "one",
                "001 one" + Environment.NewLine,
            },
            new object[]
            {
                "one" + Environment.NewLine +
                "two" + Environment.NewLine +
                "three",
                "001 one" + Environment.NewLine +
                "002 two" + Environment.NewLine +
                "003 three" + Environment.NewLine,
            },
            new object[]
            {
                "Lorem ipsum dolor sit amet" + Environment.NewLine +
                "consectetur adipiscing elit" + Environment.NewLine +
                "sed do eiusmod tempor incididunt ut labore et dolore magna aliqua",
                "001 Lorem ipsum dolor sit amet" + Environment.NewLine +
                "002 consectetur adipiscing elit" + Environment.NewLine +
                "003 sed do eiusmod tempor incididunt ut labore et dolore magna aliqua" + Environment.NewLine,
            },
        };

        [TestCase(new byte[] { }, ExpectedResult = "")]
        [TestCase(new byte[] { 0x01 }, ExpectedResult = "1")]
        [TestCase(new byte[] { 0x01, 0x02 }, ExpectedResult = "12")]
        [TestCase(new byte[] { 0x01, 0x02, 0x03 }, ExpectedResult = "123")]
        [TestCase(new byte[] { 0x0A }, ExpectedResult = "10")]
        [TestCase(new byte[] { 0x0A, 0x0B }, ExpectedResult = "1011")]
        [TestCase(new byte[] { 0x0A, 0x0B, 0x0C }, ExpectedResult = "101112")]
        [TestCase(new byte[] { 0x0A, 0x0B, 0x0C, 0x0D }, ExpectedResult = "10111213")]
        [TestCase(new byte[] { 0x0A, 0x0B, 0x0C, 0x0D, 0x0E }, ExpectedResult = "1011121314")]
        [TestCase(new byte[] { 0x0A, 0x0B, 0x0C, 0x0D, 0x0E, 0x0F }, ExpectedResult = "101112131415")]
        [TestCase(new byte[] { 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08, 0x09, 0x0A, 0x0B, 0x0C, 0x0D, 0x0E, 0x0F }, ExpectedResult = "123456789101112131415")]
        public string ReadAndWriteIntegers_ArgumentsAreValid_WritesToStreamWriter(byte[] buffer)
        {
            // Arrange
            using var contentStream = new MemoryStream(buffer);
            using var contentReader = new StreamReader(contentStream);

            using var outputStream = new MemoryStream();
            using var outputWriter = new StreamWriter(outputStream);

            // Act
            WritingToStream.ReadAndWriteIntegers(contentReader, outputWriter);

            // Assert
            outputWriter.Flush();
            _ = outputStream.Seek(0, SeekOrigin.Begin);
            using var outputReader = new StreamReader(outputStream);
            string actualResult = outputReader.ReadToEnd();

            return actualResult;
        }

        [TestCase(new char[] { })]
        [TestCase(new char[] { 'a' })]
        [TestCase(new char[] { 'a', 'b' })]
        [TestCase(new char[] { 'a', 'b', 'c' })]
        [TestCase(new char[] { 'a', 'b', 'c', 'a' })]
        [TestCase(new char[] { 'a', 'b', 'c', 'a', 'b' })]
        [TestCase(new char[] { 'a', 'b', 'c', 'a', 'b', 'c' })]
        public void ReadAndWriteChars_ArgumentsAreValid_WritesToStreamWriter(char[] chars)
        {
            // Arrange
            byte[] buffer = Encoding.UTF8.GetBytes(chars);
            using var contentStream = new MemoryStream(buffer);
            using var contentReader = new StreamReader(contentStream);

            using var outputStream = new MemoryStream();
            using var outputWriter = new StreamWriter(outputStream);

            // Act
            WritingToStream.ReadAndWriteChars(contentReader, outputWriter);

            // Assert
            _ = outputStream.Seek(0, SeekOrigin.Begin);
            using var outputReader = new StreamReader(outputStream, Encoding.UTF8, false, -1, true);
            char[] actualChars = new char[buffer.Length];
            _ = outputReader.Read(actualChars, 0, actualChars.Length);

            Assert.AreEqual(chars, actualChars);
        }

        [TestCase(new byte[] { }, ExpectedResult = "")]
        [TestCase(new byte[] { 0x01 }, ExpectedResult = "01")]
        [TestCase(new byte[] { 0x01, 0x02, }, ExpectedResult = "0102")]
        [TestCase(new byte[] { 0x01, 0x02, 0x03 }, ExpectedResult = "010203")]
        [TestCase(new byte[] { 0x01, 0x02, 0x03, 0x04 }, ExpectedResult = "01020304")]
        [TestCase(new byte[] { 0x01, 0x02, 0x03, 0x04, 0x05 }, ExpectedResult = "0102030405")]
        [TestCase(new byte[] { 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08, 0x09, 0x0A, 0x0B, 0x0C, 0x0D, 0x0E, 0x0F }, ExpectedResult = "0102030405060708090A0B0C0D0E0F")]
        public string TransformToHex_ArgumentsAreValid_WritesToStreamWriter(byte[] buffer)
        {
            // Arrange
            using var contentStream = new MemoryStream(buffer);
            using var contentReader = new StreamReader(contentStream);

            using var outputStream = new MemoryStream();
            using var outputWriter = new StreamWriter(outputStream)
            {
                AutoFlush = true,
            };

            // Act
            WritingToStream.TransformBytesToHex(contentReader, outputWriter);

            // Assert
            _ = outputStream.Seek(0, SeekOrigin.Begin);
            using var outputReader = new StreamReader(outputStream);
            string actualContent = outputReader.ReadToEnd();

            return actualContent;
        }

        [TestCaseSource(nameof(WriteLinesWithNumbersSource))]
        public void WriteLinesWithNumbers_ArgumentsAreValid_WritesToStreamWriter(string content, string expectedContent)
        {
            // Arrange
            var contentBytes = Encoding.ASCII.GetBytes(content);
            using var contentStream = new MemoryStream(contentBytes);
            using var contentReader = new StreamReader(contentStream);

            using var outputStream = new MemoryStream();
            using var outputWriter = new StreamWriter(outputStream);

            // Act
            WritingToStream.WriteLinesWithNumbers(contentReader, outputWriter);

            // Assert
            _ = outputStream.Seek(0, SeekOrigin.Begin);
            using var outputReader = new StreamReader(outputStream);
            string actualContent = outputReader.ReadToEnd();

            Assert.AreEqual(expectedContent, actualContent);
        }

        [TestCase("Lorem ipsum dolor sit amet", "ipsum", ExpectedResult = "Lorem  dolor sit amet")]
        [TestCase("Lorem ipsum dolor sit amet", "ipsum\namet", ExpectedResult = "Lorem  dolor sit ")]
        [TestCase("Lorem ipsum dolor sit amet", "ippsum", ExpectedResult = "Lorem ipsum dolor sit amet")]
        [TestCase("Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.", "ipsum", ExpectedResult = "Lorem  dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.")]
        [TestCase("Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.", "ipsum\naliqua", ExpectedResult = "Lorem  dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna .")]
        [TestCase("Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.", "ipsum\naliqua\nsed", ExpectedResult = "Lorem  dolor sit amet, consectetur adipiscing elit,  do eiusmod tempor incididunt ut labore et dolore magna .")]
        [TestCase("Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.", "ipsum\namet\neuysmod\nlabore\naliqua", ExpectedResult = "Lorem  dolor sit , consectetur adipiscing elit, sed do eiusmod tempor incididunt ut  et dolore magna .")]
        [TestCase("Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.", "Lorem\nipsum\namet\neuysmod\nlabore\naliqua\ntempor\nsit\nsed\ndolore\ndolor\nconsectetur\nmagna\nadipiscing\nelit\neiusmod\nincididunt\ndo\net\nut", ExpectedResult = "    ,   ,           .")]
        public string RemoveWordsFromContentAndWrite_ArgumentsAreValid_WritesToStreamWriter(string content, string words)
        {
            // Arrange
            var contentBytes = Encoding.ASCII.GetBytes(content);
            using var contentStream = new MemoryStream(contentBytes);
            using var contentReader = new StreamReader(contentStream);

            var wordsBytes = Encoding.ASCII.GetBytes(words);
            using var wordsStream = new MemoryStream(wordsBytes);
            using var wordsReader = new StreamReader(wordsStream);

            using var outputStream = new MemoryStream();
            using var outputWriter = new StreamWriter(outputStream)
            {
                AutoFlush = true,
            };

            // Act
            WritingToStream.RemoveWordsFromContentAndWrite(contentReader, wordsReader, outputWriter);

            // Assert
            _ = outputStream.Seek(0, SeekOrigin.Begin);
            using var outputReader = new StreamReader(outputStream);
            string updatedContent = outputReader.ReadToEnd();

            return updatedContent;
        }
    }
}
