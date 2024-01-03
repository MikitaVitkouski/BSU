# Morse Code Translator

An intermediate level task for practicing strings and a StringBuilder class.

The task is to implement four methods for translating a text message to a Morse code message and from a Morse code message to a text message.


## Task Description

1. Implement "TranslateToMorse" method in the [Translator.cs](MorseCodeTranslator/Translator.cs) file. The method should convert a text message to Morse code message using '.' as a dot symbol, '-' as a dash, and ' ' (space) as a space between Morse code letters. The method should ignore all other characters in the source text message. Use the StringBuilder class for creating a result Morse code message, and [MorseCodes](MorseCodeTranslator/MorseCodes.cs) class for translating alpha characters to Morse code letters.
1. Implement "TranslateToText" method in the [Translator.cs](MorseCodeTranslator/Translator.cs) file. The method should convert a Morse code message to a text message using the symbols like in the previous task. Use the StringBuilder class for creating a text message, and [MorseCodes](MorseCodeTranslator/MorseCodes.cs) class for translating Morse code letters to alpha characters.
1. Implement "WriteMorse" method in the [Translator.cs](MorseCodeTranslator/Translator.cs) file. The method should use an external code table for translating a text message to Morse code, and write the Morse code message to a StringBuilder. Also, the method should support additional parameters as a dot, dash and separator symbols.
1. Implement "WriteText" method in the [Translator.cs](MorseCodeTranslator/Translator.cs) file. The method should use an external code table for translating a Morse code message to a text message, and write the text message to a StringBuilder. Also, the method should support additional parameters as a dot, dash and separator symbols.
1. Refactor "TranslateToMorse" method to use "WriteMorse" method for translating messages.
1. Refactor "TranslateToText" method to use "WriteText" method for translating messages.


## See also

* [Morse code](https://en.wikipedia.org/wiki/Morse_code)
* .NET Fundamentals
  * [Using the StringBuilder Class in .NET](https://docs.microsoft.com/en-us/dotnet/standard/base-types/stringbuilder)
* .NET API
  * [StringBuilder Class](https://docs.microsoft.com/en-us/dotnet/api/system.text.stringbuilder)
