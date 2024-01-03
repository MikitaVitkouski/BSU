using System.Globalization;
using NUnit.Framework;

namespace Streams.Tests
{
    [TestFixture]
    public class WritingToStringTests
    {
        private readonly CultureInfo stringWriterCultureInfo = CultureInfo.GetCultureInfo("en-US");

        [TestCase("a")]
        [TestCase("abc")]
        [TestCase("Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.")]
        public void WriteString_ArgumentsAreValid_WritesToStringWriter(string content)
        {
            // Arrange
            using StringWriter stringWriter = new StringWriter(this.stringWriterCultureInfo);

            // Act
            WritingToString.WriteString(stringWriter, content);

            // Assert
            var actualContent = stringWriter.GetStringBuilder().ToString();
            Assert.AreEqual(content, actualContent);
        }

        [TestCase('a', ExpectedResult = "a")]
        [TestCase('0', ExpectedResult = "0")]
        [TestCase('\n', ExpectedResult = "\n")]
        public string WriteChar_ArgumentsAreValid_WritesToStringWriter(char charToWrite)
        {
            // Arrange
            using StringWriter stringWriter = new StringWriter(this.stringWriterCultureInfo);

            // Act
            WritingToString.WriteChar(stringWriter, charToWrite);

            // Assert
            var actualContent = stringWriter.GetStringBuilder().ToString();
            return actualContent;
        }

        [TestCase(0, ExpectedResult = "0")]
        [TestCase(1, ExpectedResult = "1")]
        [TestCase(-1, ExpectedResult = "-1")]
        [TestCase(123456789, ExpectedResult = "123456789")]
        [TestCase(-123456789, ExpectedResult = "-123456789")]
        public string WriteInteger_ArgumentsAreValid_WritesToStringWriter(int integerToWrite)
        {
            // Arrange
            using StringWriter stringWriter = new StringWriter(this.stringWriterCultureInfo);

            // Act
            WritingToString.WriteInteger(stringWriter, integerToWrite);

            // Assert
            var actualContent = stringWriter.GetStringBuilder().ToString();
            return actualContent;
        }

        [TestCase(0, "0")]
        [TestCase(1, "1")]
        [TestCase(-1, "-1")]
        [TestCase(123456789, "123456789")]
        [TestCase(-123456789, "-123456789")]
        public void WriteIntegerWithNewLine_ArgumentsAreValid_WritesToStringWriter(int integerToWrite, string expectedContent)
        {
            // Arrange
            using StringWriter stringWriter = new StringWriter(this.stringWriterCultureInfo);

            // Act
            WritingToString.WriteIntegerWithNewLine(stringWriter, integerToWrite);

            // Assert
            var actualContent = stringWriter.GetStringBuilder().ToString();
            Assert.AreEqual(expectedContent + Environment.NewLine, actualContent);
        }

        [TestCase(0, ExpectedResult = "0")]
        [TestCase(1.0f, ExpectedResult = "1")]
        [TestCase(-1.0f, ExpectedResult = "-1")]
        [TestCase(1234.1234f, ExpectedResult = "1234.1234")]
        [TestCase(-1234.1234f, ExpectedResult = "-1234.1234")]
        [TestCase(123456789.12f, ExpectedResult = "123456790")]
        [TestCase(-123456789.12f, ExpectedResult = "-123456790")]
        public string WriteFloat_ArgumentsAreValid_WritesToStringWriter(float floatToWrite)
        {
            // Arrange
            using StringWriter stringWriter = new StringWriter(this.stringWriterCultureInfo);

            // Act
            WritingToString.WriteFloat(stringWriter, floatToWrite);

            // Assert
            var actualContent = stringWriter.GetStringBuilder().ToString();
            return actualContent;
        }

        [TestCase(0, "0")]
        [TestCase(1.0f, "1")]
        [TestCase(-1.0f, "-1")]
        [TestCase(1234.1234f, "1234.1234")]
        [TestCase(-1234.1234f, "-1234.1234")]
        [TestCase(123456789.12f, "123456790")]
        [TestCase(-123456789.12f, "-123456790")]
        public void WriteFloatWithNewLine_ArgumentsAreValid_WritesToStringWriter(float floatToWrite, string expectedContent)
        {
            // Arrange
            using StringWriter stringWriter = new StringWriter(this.stringWriterCultureInfo);

            // Act
            WritingToString.WriteFloatWithNewLine(stringWriter, floatToWrite);

            // Assert
            var actualContent = stringWriter.GetStringBuilder().ToString();
            Assert.AreEqual(expectedContent + Environment.NewLine, actualContent);
        }

        [TestCase(true, true, true, ExpectedResult = "True\nTrue\nTrue")]
        [TestCase(true, false, true, ExpectedResult = "True\nFalse\nTrue")]
        [TestCase(false, true, false, ExpectedResult = "False\nTrue\nFalse")]
        public string WriteBooleansWithNewLines_ArgumentsAreValid_WritesToStringWriter(bool firstBoolean, bool secondBoolean, bool thirdBoolean)
        {
            // Arrange
            using StringWriter stringWriter = new StringWriter(this.stringWriterCultureInfo)
            {
                NewLine = "\n",
            };

            // Act
            WritingToString.WriteBooleansWithNewLines(stringWriter, firstBoolean, secondBoolean, thirdBoolean);

            // Assert
            var actualContent = stringWriter.GetStringBuilder().ToString();
            return actualContent;
        }

        [TestCase(new char[] { 'a', 'b', 'c', 'd', 'e', 'f' }, ExpectedResult = "cde")]
        [TestCase(new char[] { '1', '2', '3', '4', '5', '6' }, ExpectedResult = "345")]
        [TestCase(new char[] { '!', '@', '#', '$', '%', '&' }, ExpectedResult = "#$%")]
        public string WriteCharBuffer_ArgumentsAreValid_WritesToStringWriter(char[] buffer)
        {
            // Arrange
            using StringWriter stringWriter = new StringWriter(this.stringWriterCultureInfo);

            // Act
            WritingToString.WriteCharBuffer(stringWriter, buffer);

            // Assert
            var actualContent = stringWriter.GetStringBuilder().ToString();
            return actualContent;
        }

        [TestCase(new char[] { 'a', 'b', 'c', 'd', 'e', 'f' }, ExpectedResult = "bcde*")]
        [TestCase(new char[] { '1', '2', '3', '4', '5', '6', '7' }, ExpectedResult = "23456*")]
        [TestCase(new char[] { '!', '@', '#', '$', '%', '&', '*', ':' }, ExpectedResult = "@#$%&**")]
        public string WriteCharBufferWithNewLines_ArgumentsAreValid_WritesToStringWriter(char[] buffer)
        {
            // Arrange
            using StringWriter stringWriter = new StringWriter(this.stringWriterCultureInfo)
            {
                NewLine = "*",
            };

            // Act
            WritingToString.WriteCharBufferWithNewLines(stringWriter, buffer);

            // Assert
            var actualContent = stringWriter.GetStringBuilder().ToString();
            return actualContent;
        }
    }
}
