using System.Text;

namespace Streams
{
    public static class WritingToStream
    {
        public static void ReadAndWriteIntegers(StreamReader streamReader, StreamWriter outputWriter)
        {
            // TODO #5-1. Implement the method by reading an integer from the StreamReader and writing it to the outputStream with StreamWriter.Write() method.
            throw new NotImplementedException();
        }

        public static void ReadAndWriteChars(StreamReader streamReader, StreamWriter outputWriter)
        {
            // TODO #5-2. Implement the method by reading a character from the StreamReader and writing it to the outputStream with StreamWriter.Write() method.
            throw new NotImplementedException();
        }

        public static void TransformBytesToHex(StreamReader contentReader, StreamWriter outputWriter)
        {
            // TODO #5-3. Implement the method by reading an integer from the StreamReader and writing it as a hex string to the outputStream with StreamWriter.Write() method that writes a formatted string. Use StreamReader.Peek method for checking whether there are more characters in the underlying string.
            throw new NotImplementedException();
        }

        public static void WriteLinesWithNumbers(StreamReader contentReader, StreamWriter outputWriter)
        {
            // TODO #5-4. Implement the method by reading a line from the StreamReader and writing it with line numbers to the outputWriter with StreamWriter.Write() method that writes a formatted string.
            throw new NotImplementedException();
        }

        public static void RemoveWordsFromContentAndWrite(StreamReader contentReader, StreamReader wordsReader, StreamWriter outputWriter)
        {
            // TODO #5-5. Implement the method by reading the content and words, removing words from the content, and writing the updated content to the outputWriter. Use StreamReader.Peek method for checking whether there are more characters in the underlying string.
            throw new NotImplementedException();
        }
    }
}
