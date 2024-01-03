# Literals

## Convert Numbers

This tutorial shows how to use Visual Studio features for converting decimals to hexadecimal and binary numbers. If you don't have enough knowledge in numeral systems, just google for [number system conversion articles](https://www.google.com/search?q=number+system+conversion) that show you how to convert numbers between numeral systems.


### Decimal to Hex

1. Navigate to [ReturnLongInteger25](Integers/LongIntegers.cs#L29) method, and return the expected value as _decimal literal_.

```cs
public static long ReturnLongInteger25()
{
    return 9_223_372_036_854_775_807L;
}
```

2. [Toggle a breakpoint](https://learn.microsoft.com/en-us/visualstudio/debugger/using-breakpoints) in [ReturnLongInteger25_ReturnsLongInteger](Integers.Tests/LongIntegersTests.cs#L49) unit test.

![Toggle Breakpoint](images/convert-to-hex-1.png)

3. Debug a unit test.

![Debug Tests](images/convert-to-hex-2.png)

4. Open [Watch window](https://learn.microsoft.com/en-us/visualstudio/debugger/watch-and-quickwatch-windows).

![Watch Window](images/convert-to-hex-3.png)

If you don't see this menu item in the _Debug_ menu, your Visual Studio is not in the [debug mode](https://learn.microsoft.com/en-us/visualstudio/debugger).

![No Watch Menu Item](images/convert-to-hex-3-no-watch-menu.png)

Toggle a breakpoint and start the debugging of an unit test first.

5. Add `result` variable to the watch list.

![Add Variable](images/convert-to-hex-4.png)

6. Open a context menu for `result` item and toggle _Hexadecimal Display_.

![Hexadecimal Display](images/convert-to-hex-5.png)

7. Open a context menu for `result` item and copy the item value.

![Copy Value](images/convert-to-hex-6.png)

8. Stop the execution.

9. Paste the value to `ReturnLongInteger25` method.

```cs
public static long ReturnLongInteger25()
{
    return 0x7fffffffffffffff;
}
```

10. Select the value in the code window, and make the selection uppercase.

![Make Uppercase](images/convert-to-hex-7.png)

11. Add digit separators and a suffix if necessary. For example, add `L` suffix for the literal of the `long` type.

```cs
public static long ReturnLongInteger25()
{
    return 0x7FFF_FFFF_FFFF_FFFFL;
}
```


### Decimal to Binary

1. Navigate to [ReturnLongInteger29](Integers/LongIntegers.cs#L53) method, and return the expected value as a _decimal literal_.

```cs
public static long ReturnLongInteger29()
{
    return 4_100_761_908_933_204_629L;
}
```

2. [Toggle a breakpoint](https://learn.microsoft.com/en-us/visualstudio/debugger/using-breakpoints) in [ReturnLongInteger29_ReturnsLongInteger](Integers.Tests/LongIntegersTests.cs#L89) unit test.

![Toggle Breakpoint](images/convert-to-binary-1.png)

3. Debug the unit test.

![Debug Tests](images/convert-to-binary-2.png)

4. Open [Immediate window](https://learn.microsoft.com/en-us/visualstudio/ide/reference/immediate-window).

![Immediate window](images/convert-to-binary-3.png)

5. Add the code to the Immediate window.

```cs
Convert.ToString(result, 2)
```

![Immediate window](images/convert-to-binary-4.png)

Run the code by pressing _Enter_.

6. Select the binary value in the Immediate window, and copy it.

![Immediate window](images/convert-to-binary-5.png)

7. Stop the execution.

8. Paste the value to `ReturnLongInteger29` method.

```cs
public static long ReturnLongInteger29()
{
    return 11100011101000110101010011101010111010011010101001101010010101;
}
```

9. Add `0b` prefix to define a binary literal.

```cs
public static long ReturnLongInteger29()
{
    return 0b11100011101000110101010011101010111010011010101001101010010101;
}
```

10. Add digit separators and a suffix if necessary. For example, add `L` suffix for the literal of the `long` type.

```cs
public static long ReturnLongInteger25()
{
    return 0b111000_11101000_11010101_00111010_10111010_01101010_10011010_10010101L;
}
```
