using System;
using System.Text;

namespace MorseCodeTranslator
{
    public static class Translator
    {
        public static string TranslateToMorse(string? message)
        {
            // TODO #1. Implement the method using StringBuilder, and MorseCodes.CodeTable array.
            throw new NotImplementedException();
        }

        public static string TranslateToText(string? morseMessage)
        {
            // TODO #2. Implement the method using StringBuilder, and MorseCodes.CodeTable array.
            throw new NotImplementedException();
        }

        public static void WriteMorse(char[][]? codeTable, string message, StringBuilder? morseMessageBuilder, char dot = '.', char dash = '-', char separator = ' ')
        {
            // TODO #3. Implement the method.
            throw new NotImplementedException();
        }

        public static void WriteText(char[][]? codeTable, string? morseMessage, StringBuilder? messageBuilder, char dot = '.', char dash = '-', char separator = ' ')
        {
            // TODO #4. Implement the method.
            throw new NotImplementedException();
        }
    }
}
