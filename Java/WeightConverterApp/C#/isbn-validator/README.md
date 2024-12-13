# ISBN Verification

Beginner level task for practicing loops and string parsing.

Estimated time to complete the task - 1h.

The task requires .NET 6 SDK installed.


## Task description

The [International Standard Book Number](https://en.wikipedia.org/wiki/ISBN) is a commercial numeric book identifier that is assigned to each separate edition and variation of a publication.

An *ISBN-10* code consists of ten digits divided into four parts. Separating the parts of a 10-digit ISBN is done with either hyphens or spaces. The separator can also omitted. The code may contain a "X" character that represents the number 10. Here's the template for 10-digit ISBN code that is separated with hyphens into four parts (1-3-5-1): `#-###-#####-#`.

Most of the parts do not use a fixed number of digits, but the last part has the only one digit - a *checksum character* or [check digit](https://en.wikipedia.org/wiki/ISBN#Check_digits). The number 3 is a check digit for the `1-84356-028-3` ISB number.


To make sure a ISB number is correct, you need to compute the checksum:

$`checksum = \sum_{i=1}^{10}(11-i)x_i=x_1·10+x_2·9+x_3·8+x_4·7+x_5·6+x_6·5+x_7·4+x_8·3+x_9·2+x_{10}·1`$,

where $`x_i`$ is the *i*th digit.

If the `checksum % 11` equals `0`, then the given ISB number is correct (or valid).


Here's an checksum calculation example for `3-598-21508-8` ISB number:

$`3·10+5·9+9·8+8·7+2·6+1·5+5·4+0·3+8·2+8·1=30+45+72+56+12+5+20+0+16+8=264`$

The `3-598-21508-8` is valid, because `264 % 11 = 0`.


Implement the [IsIsbnValid](IsbnValidator/Validator.cs#L11) method that returns `true`, if given ISB number is valid; return `false` otherwise.

