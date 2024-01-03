# Numeral Systems

## Task description

- Implement a [GetPositiveOctal](NumeralSystems/Converter.cs#L13) extention method that gets the value of a positive integer to its equivalent string representation in the octal numeral systems.
- Implement a [GetPositiveDecimal](NumeralSystems/Converter.cs#L21) extention method that gets the value of a positive integer to its equivalent string representation in the decimal numeral systems.
- Implement a [GetPositiveHex](NumeralSystems/Converter.cs#L29) extention method that gets the value of a positive integer to its equivalent string representation in the hexadecimal numeral systems.
- Implement a [GetPositiveRadix](NumeralSystems/Converter.cs#L39) extention method that gets the value of a positive integer to its equivalent string representation in a specified radix.
- Implement a [GetRadix](NumeralSystems/Converter.cs#L48) extention method that gets the value of a signed integer to its equivalent string representation in a specified radix.    
The task definition is given in the XML-comments for the methods.     
_Restriction: Don't use Framework's converter classes._     
    
_For example:_      
_Base 16 conversion_
- -2147483648       ->  80000000     
- -19327543         ->  FED915C9    
- -13621            ->  FFFFCACB    
- -18               ->  FFFFFFEE    
- 12                ->  C     
- 2147483647        ->  7FFFFFFF   
_Base 8 conversion_      
- -2147483648       ->  20000000000
- -19327543         ->  37666212711
- -13621            ->  37777745313
- -18               ->  37777777756
- 12                ->  14
- 2147483647        ->  17777777777    
