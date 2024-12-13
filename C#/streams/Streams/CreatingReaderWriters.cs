using System.Globalization;
using System.Text;

[assembly: CLSCompliant(true)]

namespace Streams
{
    public static class CreatingReaderWriters
    {
        public static StringReader CreateStringReader(string str)
        {
            // TODO #1-1. Implement the method by returning an instantiated object of the StringReader class.
            throw new NotImplementedException();
        }

        public static StringWriter CreateStringWriter()
        {
            // TODO #1-2. Implement the method by returning an instantiated object of the StringWriter class.
            throw new NotImplementedException();
        }

        public static StringWriter CreateStringWriterThatWritesToStringBuilder(StringBuilder stringBuilder)
        {
            // TODO #1-3. Implement the method by returning an instantiated object of the StringWriter class.
            throw new NotImplementedException();
        }

        public static StringWriter CreateStringWriterThatWritesCultureSpecificData(CultureInfo cultureInfo)
        {
            // TODO #1-4. Implement the method by returning an instantiated object of the StringWriter class.
            throw new NotImplementedException();
        }

        public static StreamReader CreateStreamReaderFromStream(Stream stream)
        {
            // TODO #1-5. Implement the method by returning an instantiated object of the StreamReader class.
            throw new NotImplementedException();
        }

        public static StreamWriter CreateStreamWriterToStream(Stream stream)
        {
            // TODO #1-6. Implement the method by returning an instantiated object of the StreamWriter class.
            throw new NotImplementedException();
        }
    }
}
