# Streams

A beginner level task for practicing streams.

In this task a student will learn the basics of stream operations, and will get acquainted with StringReader, StringWriter, StreamReader and StreamWriter classes.

Before starting the task read the "Readers and writers" documentation section, the documentation pages for StringReader, StringWriter, StreamReader, and StreamWriter classes, and "How to" articles. Links to relevant documentation pages, articles and other useful resources are in "See also" section.

Estimated time to complete the task: 4h.


## Task Description

The task has five sections with small sub-tasks in the code files. This document contains a description only for some sub-tasks that require additional explanation. Each section has a list of questions that will allow you to self-check your knowledge. 


### 1. Creating Readers and Writers

Read the "Constructors" documentation pages for the _StringReader_, _StringWriter_, _StreamReader_, and _StreamWriter_ classes, and implement the methods in [CreatingReaderWriters](Streams/CreatingReaderWriters.cs) class.


#### CreateStringWriterThatWritesCultureSpecificData

_StringWriter_ class has a [constructor](https://docs.microsoft.com/en-us/dotnet/api/system.io.stringwriter.-ctor?#System_IO_StringWriter__ctor_System_IFormatProvider_) that initializes a new instance of the class with the specified format control. The argument has [IFormatProvider](https://docs.microsoft.com/en-us/dotnet/api/system.iformatprovider) type:

```cs
public StringWriter (IFormatProvider? formatProvider);
```

It is possible to pass an instance of the [CultureInfo](https://docs.microsoft.com/en-us/dotnet/api/system.globalization.cultureinfo) class because the class implements the _IFormatProvider_ interface:

```cs
public class CultureInfo : ICloneable, IFormatProvider
```


#### Section Questions

Answer these questions after completing all tasks in the section.

1. What is the purpose of StringReader class?
1. What is the purpose of StringWriter class?
1. What is the purpose of StreamReader class?
1. What is the purpose of StreamWriter class?


### 2. Reading from String

Read the documentation pages for the _StringReader.ReadToEnd_, _StringReader.ReadLine_, _StringReader.Read_, and _StringReader.Peek_ methods and implement the methods in the [ReadingFromString](Streams/ReadingFromString.cs) class.


#### ReadNextCharacter

If the underlying string (wrapped in StringReader) has characters available, the method should return "true" and the next character as the "currentChar" argument. If the underlying string has no more characters available, the method should return "false" and the " " (space) character as the "currentChar" argument. You can use the _Convert.ToChar_ method to convert an integer returned by the _StringReader.Read_ method to a character.


#### PeekNextCharacter

If the underlying string has characters available, the method should return true and the next character as "currentChar" argument. If the underlying string has no more characters available, the method should return false and " " (space) character as "currentChar" argument. You can use _Convert.ToChar_ method to convert an integer returned by _StringReader.Read_ method to a character.

To understand the difference between the _StringReader.Read_ and _StringReader.Peek_ methods, analyze and debug unit tests that covers _ReadNextCharacter_ and _PeekNextCharacter_ methods in [ReadingFromStringTests](Streams.Tests/ReadingFromStringTests.cs) class.


#### Section Questions

Answer these questions after completing all tasks in the section.

1. What method of StringReader class should be used for reading all characters from the current position to the end of the string?
1. What method of StringReader class should be used for reading a line of characters from the current string?
1. What method of StringReader class should be used for reading the next character from the input string?
1. What method of StringReader class should be used for reading a block of characters from the input string to an array?


### 3. Writing to String

Read the documentation pages about the _StringWriter.Write_ and _StringWriter.WriteLine_ methods and implement the methods in [WritingToString](Streams/WritingToString.cs) class.


#### WriteBooleansWithNewLines

_WriteBooleansWithNewLines_ should write three Booleans one by one with two-line terminators after the first two Boolean values:

"firstBoolean&lt;line terminator&gt;secondBoolean&lt;line terminator&gt;thirdBoolean"

Use _StringWriter.Write(bool)_ and _StringWriter.WriteLine(bool)_ methods to write Booleans to a string.

See examples in unit tests in [WritingToStringTests.cs](Streams.Tests/WritingToStringTests.cs) file.


#### WriteCharBuffer

The _WriteCharBuffer_ method should write only the third, the fourth, and the fifth characters of the _buffer_ array.

Example:

| Array Index | 0   | 1   | 2   | 3   | 4   | 5   |
|-------------|-----|-----|-----|-----|-----|-----|
| Array Value | 'a' | 'b' | 'c' | 'd' | 'e' | 'f' |
| Writable    |     |     | +   | +   | +   |     |

See more examples in unit tests in [WritingToStringTests.cs](Streams.Tests/WritingToStringTests.cs) file.


#### WriteCharBufferWithNewLines

The _WriteCharBufferWithNewLines_ method should write all characters in the _buffer_ array except the first and the last elements. Also, the method should write a line terminator.

Example:

| Array Index | 0   | 1   | 2   | 3   | 4   | 5   |
|-------------|-----|-----|-----|-----|-----|-----|
| Array Value | 'a' | 'b' | 'c' | 'd' | 'e' | 'f' |
| Writable    |     | +   | +   | +   | +   |     |

See more examples in unit tests in [WritingToStringTests.cs](Streams.Tests/WritingToStringTests.cs) file.


#### Section Questions

Answer these questions after completing all tasks in the section.

1. What methods of StringWriter class may be used for writing values and objects to a string?
1. What methods of StringWriter class may be used for writing a block of characters to a string?
1. What is the difference between StringWriter.Write and StringWriter.WriteLine methods?


### 4. Reading from Stream

Read the documentation pages for the _StreamReader.ReadToEnd_, _StreamReader.ReadLine_, _StreamReader.Read_, _StreamReader.Peek_ methods and implement the methods in the [ReadingFromString](Streams/ReadingFromStream.cs) class.


#### ReadLineByLine

The _ReadLineByLine_ method should return an array of strings and each element of the array is a text line that ends with a line terminator in the underlying string.

* The _StreamReader.ReadLine_ method returns null if the end of the input stream is reached. Check if the returned value is null to stop reading from a stream.
* Use the [List&lt;T&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1) list for storing a list of strings and the _List&lt;T&gt;.ToArray_ method for copying the list elements to a new array.


The example of the string StreamReader consumes:

"one&lt;line terminator&gt;two&lt;line terminator&gt;three"

For the string above the _ReadLineByLine_ method should produce:

```cs
{ "one", "two", "three" }
```

Reading from a stream example:

```cs
string line;
while ((line = streamReader.ReadLine()) != null)
{
    // Add line to a list
}
```


#### ReadOnlyLettersAndNumbers

The _ReadOnlyLettersAndNumbers_ method should read only letters and numbers from a stream, and it should stop reading when the next character is not a letter or a number.
* Use the _StreamReader.Peek_ method for getting the next character from a stream but not consuming it.
* The _StreamReader.Peek_ method returns -1 if there are no characters to be read from the stream. See an example of using the method on the [StreamReader.Peek documentation page](https://docs.microsoft.com/en-us/dotnet/api/system.io.streamreader.peek).
* Use the _Char.IsLetterOrDigit_ method for indicating whether a character is a letter or number.

The example of the string StreamReader consumes: "012345,6789". For this string, the _ReadOnlyLettersAndNumbers_ method should produce: "012345".

See examples in unit tests in [ReadingFromStreamTests.cs](Streams.Tests/ReadingFromStreamTests.cs) file.


#### ReadAsCharArrays

The _ReadAsCharArrays_ method should return a jagged array with the characters from an underlying string that is sliced into an array with the _arraySize_ length.

The example of the string StreamReader consumes:

"Loremipsumdolorsitamet"

For the string above, in case the _arraySize_ argument equals 5, the _ReadAsCharArrays_ method should produce this array:

```cs
{
    { 'L', 'o', 'r', 'e', 'm' },
    { 'i', 'p', 's', 'u', 'm' },
    { 'd', 'o', 'l', 'o', 'r' },
    { 's', 'i', 't', 'a', 'm' },
    { 'e', 't' }
}
```

See examples in unit tests in [ReadingFromStreamTests.cs](Streams.Tests/ReadingFromStreamTests.cs) file.

You can use the [List&lt;T&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1) list for storing a list of char arrays and the [Array.Resize](https://docs.microsoft.com/en-us/dotnet/api/system.array.resize) method for changing the number of elements of a one-dimensional array.


#### Section Questions

Answer these questions after completing all tasks in the section.

1. What is the difference between _StreamReader.Read_ and _StreamReader.Peek_ methods?


### 5. Writing to Stream

Read the documentation pages about the _StreamWriter.Write_ and _StreamWriter.WriteLine_ methods and implement the methods in the [WritingToStream](Streams/WritingToStream.cs) class.


#### ReadAndWriteIntegers

The _ReadAndWriteIntegers_ method has two arguments - _streamReader_ and _outputWriter_. The method should read an integer from _streamReader_ and then write this integer to _outputWriter_.


#### ReadAndWriteChars

The _ReadAndWriteChars_ method has two arguments - _streamReader_ and _outputWriter_. The method should read a character from _streamReader_ and then write this character to _outputWriter_. The method is very similar to _ReadAndWriteIntegers_ but the output is different.

Also, read about the [StreamWriter.Flush method](https://docs.microsoft.com/en-us/dotnet/api/system.io.streamwriter.flush) and add the code to flush all buffers for _outputWriter_ so that all buffered data is written to the underlying stream after all data is written. Compare unit tests for _ReadAndWriteIntegers_ and _ReadAndWriteChars_ in the [WritingToStreamTests](Streams.Tests/WritingToStreamTests.cs) class to understand why there is no need to flush the _outputWriter_ buffers in the _ReadAndWriteIntegers_ method.


#### TransformBytesToHex

The _TransformBytesToHex_ method should read an integer from _streamReader_ and write the value as a hex string to _outputWriter_.

* Use the _StringWriter.Write_ overloaded method for writing a formatted string. Read more information about a format string in [Standard numeric format strings](https://docs.microsoft.com/en-us/dotnet/standard/base-types/standard-numeric-format-strings) article.
* Use the _StreamReader.Peek_ method for checking whether there are more characters in the underlying string.

Read about the [StreamWriter.AutoFlush Property](https://docs.microsoft.com/en-us/dotnet/api/system.io.streamwriter.autoflush) and analyze [unit tests](Streams.Tests/WritingToStreamTests.cs) to understand whether the buffer flushing is required for the _outputWriter_ or not.


#### WriteLinesWithNumbers

The _WriteLinesWithNumbers_ method should read a text line from _streamReader_, add a line number, and write the updated line to _outputWriter_. Use the _StringWriter.Write_ overloaded method for writing a formatted string.

Example of the string the StreamReader consumes:

| Line Number | Line Text |
|-------------|-----------|
| 1           | one       |
| 2           | two       |
| 3           | three     |

For the string above the _WriteLinesWithNumbers_ method should produce the text:

| Line Number | Line Text | Line Terminator |
|-------------|-----------|-----------------|
| 1           | 001 one   | Yes             |
| 2           | 002 two   | Yes             |
| 3           | 003 three | Yes             |

Analyze [unit tests](Streams.Tests/WritingToStreamTests.cs) to understand whether the buffer flushing is required for the _outputWriter_ or not.


#### RemoveWordsFromContentAndWrite

The _RemoveWordsFromContentAndWrite_ method should read the content from _streamReader_ and then read words one by one from _wordsReader_, remove the words from the content, and write the updated content to _outputWriter_. 

* Use the _StreamReader.Peek_ method for checking whether there are more characters in the underlying string.
* Store the content from _contentReader_ to the _StringBuilder_ instance, and use the _StringBuilder.Replace_ method to remove words from the content string.

Example of the string StreamReader consumes:

"Lorem **ipsum** dolor sit amet, consectetur adipiscing elit, **sed** do eiusmod tempor incididunt ut labore et dolore magna **aliqua**."

The word list string is as follows:

"ipsum&lt;line terminator&gt;aliqua&lt;line terminator&gt;sed"

For the string above, the _RemoveWordsFromContentAndWrite_ method should write this text to the output stream:

```
"Lorem  dolor sit amet, consectetur adipiscing elit,  do eiusmod tempor incididunt ut labore et dolore magna ."
```


#### Inheritance and Method Overriding

The _StreamWriter_ class inherits its behavior from the _TextWriter_ class.

```cs
public class StreamWriter : System.IO.TextWriter
```

The _TextWriter_ has [TextWrite.Write(char) method](https://docs.microsoft.com/en-us/dotnet/api/system.io.textwriter.write#System_IO_TextWriter_Write_System_Char_) for writing characters:

```cs
public virtual void Write (char value);
```

The method has **virtual** modifier, that means it has implementation, but it is possible to override the behavior in a derived class. See the documentation for [StringWriter.Write(char) method](https://docs.microsoft.com/en-us/dotnet/api/system.io.streamwriter.write#System_IO_StreamWriter_Write_System_Char_):

```cs
public override void Write (char value);
```

The method has **override** modifier, that means it has different implementation than the base class method.


#### Section Questions

Answer these questions after completing all tasks in the section.

1. What is the difference between StreamWriter.Write and StreamWriter.WriteLine methods?
1. What is the difference between StreamWriter.Write(char) and StreamWriter.Write(int) methods?
1. How to write a formatted string to a stream with StreamWriter class?
1. Why it is important to clear all buffers for the current writer and cause any buffered data to be written to the underlying string?
1. How to cause any buffered data to be written to the underlying stream?
1. What is the purpose of the StreamWriter.AutoFlush property?
1. Does StringWriter class has an overridden implementation for [TextWrite.Write(int)](https://docs.microsoft.com/en-us/dotnet/api/system.io.textwriter.write#System_IO_TextWriter_Write_System_Int32_) method?


## See also

* C# Language Reference
  * [out parameter modifier](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/out-parameter-modifier)
* .NET Guide
  * [File and Stream I/O](https://docs.microsoft.com/en-us/dotnet/standard/io/)
    * [Readers and writers](https://docs.microsoft.com/en-us/dotnet/standard/io/#readers-and-writers)
  * [How to: Read text from a file](https://docs.microsoft.com/en-us/dotnet/standard/io/how-to-read-text-from-a-file)
  * [How to: Write text to a file](https://docs.microsoft.com/en-us/dotnet/standard/io/how-to-write-text-to-a-file)
  * [How to: Read characters from a string](https://docs.microsoft.com/en-us/dotnet/standard/io/how-to-read-characters-from-a-string)
  * [How to: Write characters to a string](https://docs.microsoft.com/en-us/dotnet/standard/io/how-to-write-characters-to-a-string)
* [Standard numeric format strings](https://docs.microsoft.com/en-us/dotnet/standard/base-types/standard-numeric-format-strings)
* .NET API
  * [StringReader Class](https://docs.microsoft.com/en-us/dotnet/api/system.io.stringreader)
  * [StringWriter Class](https://docs.microsoft.com/en-us/dotnet/api/system.io.stringwriter)
  * [StreamReader Class](https://docs.microsoft.com/en-us/dotnet/api/system.io.streamreader)
  * [StreamWriter Class](https://docs.microsoft.com/en-us/dotnet/api/system.io.streamwriter)
  * [MemoryStream Class](https://docs.microsoft.com/en-us/dotnet/api/system.io.memorystream)
  * [TextWriter Class](https://docs.microsoft.com/en-us/dotnet/api/system.io.textwriter)
  * [StringBuilder Class](https://docs.microsoft.com/en-us/dotnet/api/system.text.stringbuilder)
  * [Convert.ToChar Method](https://docs.microsoft.com/en-us/dotnet/api/system.convert.tochar)
  * [Char.IsLetterOrDigit Method](https://docs.microsoft.com/en-us/dotnet/api/system.char.isletterordigit)
