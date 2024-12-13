using System.Globalization;
using System.Text;
using NUnit.Framework;

[assembly: CLSCompliant(false)]

namespace Streams.Tests
{
    [TestFixture]
    public class CreatingReaderWritersTests
    {
        [TestCase("", ExpectedResult = null)]
        [TestCase("abc", ExpectedResult = "abc")]
        public string? CreateStringReader_StrIsNotNull_ReturnsStringReader(string str)
        {
            // Act
            using var stringReader = CreatingReaderWriters.CreateStringReader(str);

            // Assert
            Assert.IsNotNull(stringReader);
            return stringReader.ReadLine();
        }

        [Test]
        public void CreateStringWriter_ReturnsStringWriter()
        {
            // Act
            using var stringWriter = CreatingReaderWriters.CreateStringWriter();

            // Assert
            Assert.IsNotNull(stringWriter);
        }

        [Test]
        public void CreateStringWriterThatWritesToStringBuilder_ReturnsStringWriter()
        {
            // Arrange
            const string content = "abcdefg";
            var stringBuilder = new StringBuilder();

            // Act
            using var stringWriter = CreatingReaderWriters.CreateStringWriterThatWritesToStringBuilder(stringBuilder);

            // Assert
            Assert.IsNotNull(stringWriter);
            stringWriter.Write(content);
            Assert.AreEqual(content, stringBuilder.ToString());
        }

        [TestCase("en-US", ExpectedResult = "-123456.123456-123456.125-123456.123456")]
        [TestCase("fr-FR", ExpectedResult = "-123456,123456-123456,125-123456,123456")]
        /* test case is disable because behavior is different on win and linux systems [TestCase("fa-IR", ExpectedResult = "-123456/123456-123456/125-123456/123456")] */
        public string CreateStringWriterThatWritesCultureSpecificData_ReturnsStringWriter(string cultureName)
        {
            // Arrange
            CultureInfo cultureInfo = CultureInfo.GetCultureInfo(cultureName);

            // Act
            using var stringWriter = CreatingReaderWriters.CreateStringWriterThatWritesCultureSpecificData(cultureInfo);

            // Assert
            stringWriter.Write(-123456.123456);
            stringWriter.Write(-123456.123456f);
            stringWriter.Write(-123456.123456m);

            StringBuilder stringBuilder = stringWriter.GetStringBuilder();
            return stringBuilder.ToString();
        }

        [Test]
        public void CreateStreamReaderFromStream_StreamIsNotNull_ReturnsStreamReader()
        {
            // Arrange
            const string content = "abcdefg";
            byte[] buffer = Encoding.ASCII.GetBytes(content);
            Stream stream = new MemoryStream(buffer);

            // Act
            using var streamReader = CreatingReaderWriters.CreateStreamReaderFromStream(stream);

            // Assert
            Assert.IsNotNull(streamReader);
            string actualContent = streamReader.ReadToEnd();
            Assert.AreEqual(content, actualContent);
        }

        [Test]
        public void CreateStreamWriterToStream_StreamIsNotNull_ReturnsStreamWriter()
        {
            // Arrange
            const string content = "abcdefg";
            MemoryStream stream = new MemoryStream();

            // Act
            using var streamWriter = CreatingReaderWriters.CreateStreamWriterToStream(stream);

            // Assert
            Assert.IsNotNull(streamWriter);
            streamWriter.Write(content);
            streamWriter.Flush();
            _ = stream.Seek(0, SeekOrigin.Begin);
            using var streamReader = new StreamReader(stream);
            var actualString = streamReader.ReadToEnd();
            Assert.AreEqual(content, actualString);
        }
    }
}
