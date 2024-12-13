# Integral Numeric Literals

A beginner level task for practicing integer number literals.

Estimated time to complete the task - 1h.

The task requires .NET 6 SDK installed.


## Task Description

In  this task, you will use the numeric literals of the integral numeric types and numeric type constants. Also, you will learn how to use the Visual Studio debugger to convert decimal numbers to hexadecimal and binary numbers.

Before starting the task, read the [Built-in value types](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/value-types#built-in-value-types) section.


### Integer Literals

Read the [Integral numeric types](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/integral-numeric-types) article.


#### _int_ and _uint_ data types

Open the [Integers.cs](Integers/Integers.cs) file, and implement all methods using the information from the table below.

| Method Name      | Number         | Literal Type | Suffix |
|------------------|----------------|--------------|--------|
| ReturnInteger11  | 0              | Decimal      |        |
| ReturnInteger12  | 1              | Decimal      |        |
| ReturnInteger13  | -1             | Decimal      |        |
| ReturnInteger14  | 2,147,483,647  | Decimal      |        |
| ReturnInteger15  | -2,147,483,648 | Decimal      |        |
| ReturnInteger16  | 1              | Decimal      | u      |
| ReturnInteger17  | 32,767         | Decimal      | u      |
| ReturnInteger18  | 2,147,483,647  | Decimal      | u      |

Start with the first method - [ReturnInteger11](Integers/Integers.cs#L7):

```cs
public static int ReturnInteger11()
{
    // TODO #1-1. Return "0" literal.
    throw new NotImplementedException();
}
```

The [throw](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/throw) keyword signals the occurrence of an exception during program execution. In this method the `throw new NotImplementedException()` statement tells you that the method is not implemented.

Replace the `throw new NotImplementedException()` statement with the `return 0` statement:

```cs
public static int ReturnInteger11()
{
    // TODO #1-1. Return "0" literal.
    return 0;
}
```

The [return](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/return) statement terminates the method execution and returns `0` as a return value. `0` is the [decimal literal](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/integral-numeric-types#integer-literals).

Remove the TODO comment:

```cs
public static int ReturnInteger11()
{
    return 0;
}
```

Sonar will raise an [#1135 issue](https://rules.sonarsource.com/csharp/RSPEC-1135) for each TODO comment during the task check.

The [digit separator](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/integral-numeric-types#integer-literals) may improve the readability of large numeric literals. Use the digit separator symbol in this task for number literals with *more than 3 digits*.

```cs
public static int ReturnInteger14()
{
    return 2_147_483_647;
}
```

To specify the number literal is _unsigned_ use the `u` or `U` suffixes:

```cs
public static uint ReturnInteger16()
{
    return 1u;
}
```

In your own code you can often skip these suffixes, because the compiler understands that the literal is unsigned. But for the sake of learning we ask you to add suffixes in this task.


#### _long_ and _ulong_ data types

Open the [LongIntegers.cs](Integers/LongIntegers.cs) file, and implement all methods using the information from the table below.

| Method Name          | Number                     | Literal Type | Suffix |
|----------------------|----------------------------|--------------|--------|
| ReturnLongInteger21  | 4,956,185,095,298,947,214  | Decimal      | L      |
| ReturnLongInteger22  | -1,280,010,762,458,239,942 | Decimal      | L      |
| ReturnLongInteger23  | -945,783,496,234,828,465   | Decimal      | L      |
| ReturnLongInteger24  | 16,269,823,234,523,742,845 | Decimal      | uL     |
| ReturnLongInteger25  | 9,223,372,036,854,775,807  | Hexadecimal  | L      |
| ReturnLongInteger26  | 773,738,404,492,802,748    | Hexadecimal  | L      |
| ReturnLongInteger27  | 17,977,307,477,258,691,517 | Hexadecimal  | uL     |
| ReturnLongInteger28  | 14,193,065,825,095,688,383 | Hexadecimal  | uL     |
| ReturnLongInteger29  | 4,100,761,908,933,204,629  | Binary       | L      |
| ReturnLongInteger210 | 1,645,102,583,813,967,509  | Binary       | L      |
| ReturnLongInteger211 | 6,148,914,691,236,517,205  | Binary       | L      |
| ReturnLongInteger212 | 8,446,744,073,709,551,615  | Binary       | L      |

Use the `L` suffix to specify that a number literal has the `long` type:

```cs
public static long ReturnLongInteger21()
{
    return 4_956_185_095_298_947_214L;
}
```

If you put `l` suffix you will get [CS0078 warning](https://learn.microsoft.com/en-us/dotnet/csharp/misc/cs0078).

![CS0078 warning](images/cs0078.png)

In methods with the _Hexadecimal_ literal type use [hexadecimal literals](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/integral-numeric-types#integer-literals). See the [Convert Numbers](convert-numbers.md) tutorial for more information on how to convert decimal numbers.

```cs
public static long ReturnLongInteger25()
{
    return 0x7FFF_FFFF_FFFF_FFFFL;
}
```

In methods with the _Binary_ literal type use [binary literals](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/integral-numeric-types#integer-literals). See the [Convert Numbers](convert-numbers.md) tutorial for more information on how to convert decimal numbers.

```cs
public static long ReturnLongInteger29()
{
    return 0b00111000_11101000_11010101_00111010_10111010_01101010_10011010_10010101L;
}
```

## Type Aliases

In the [Characteristics of the integral types](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/integral-numeric-types#characteristics-of-the-integral-types) table there are ".NET type" and "C# type" columns which contain the .NET data types and their respective C# language type _alias_.

The `int` type is an alias for [System.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32) data type. Use the table to find corresponding .NET data types for `uint`, `long` and `ulong` aliases.


## Constants

Read the [Constants](https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/constants) article, open the [Consts.cs](Integers/Consts.cs) file, and implement all methods using the information from the table below.

| Method Name                       | Data Type | Value    |
|-----------------------------------|-----------|----------|
| ReturnLargestInteger              | int       | largest  |
| ReturnSmallestInteger             | int       | smallest |
| ReturnLargestUnsignedInteger      | uint      | largest  |
| ReturnSmallestUnsignedInteger     | uint      | smallest |
| ReturnLargestLongInteger          | long      | largest  |
| ReturnSmallestLongInteger         | long      | smallest |
| ReturnLargestUnsignedLongInteger  | ulong     | largest  |
| ReturnSmallestUnsignedLongInteger | ulong     | smallest |
| ReturnSmallestShortInteger        | short     | largest  |
| ReturnLargestShortInteger         | short     | smallest |

Integer data types contain constants that represent the largest and the smallest possible values. Return the respective constant. You may find the list of type constants in the type documentation (links are in "See also" section).

Return the [Int32.MaxValue](https://learn.microsoft.com/en-us/dotnet/api/system.int32.maxvalue) constant value in the [ReturnLargestInteger](Integers/Consts.cs#L5) method.

```cs
public static int ReturnLargestInteger()
{
    return int.MaxValue;
}
```

You can navigate to the constant definition via the [Go To Definition](https://learn.microsoft.com/en-us/visualstudio/ide/go-to-and-peek-definition) menu item to see the actual constant value.

![Go To Definition](images/go-to-definition.png)


## Fix Compiler Issues

Additional style and code checks are enabled for the projects in this solution to help you maintaining consistency of the project source code and avoiding silly mistakes. [Review the Error List](https://learn.microsoft.com/en-us/visualstudio/ide/find-and-fix-code-errors#review-the-error-list) in Visual Studio to see all compiler warnings and errors.

If a compiler error or warning message is not clear, [review errors details](https://learn.microsoft.com/en-us/visualstudio/ide/find-and-fix-code-errors#review-errors-in-detail) or google for the error or warning code to get more information about the issue.


## Task Checklist

1. Rebuild the solution.
1. Fix all compiler warnings and errors.
1. Run all unit tests, make sure all unit tests completed successfully.
1. Review all changes, make sure the only code files (.cs) in Integers project have changes. No changes in project files (.csproj) or in Integers.Tests project.
1. Stage your changes, and create a commit.
1. Push your changes to remote repository.


## See also

* C# Language Reference
  * [Integral numeric types](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/integral-numeric-types)
  * [return](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/statements/jump-statements#the-return-statement)
  * [throw](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/throw)
* C# Programming Guide
  * [Constants](https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/constants)
* .NET API
  * [Int16 Struct](https://learn.microsoft.com/en-us/dotnet/api/system.int16)
  * [Int32 Struct](https://learn.microsoft.com/en-us/dotnet/api/system.int32)
  * [UInt32 Struct](https://learn.microsoft.com/en-us/dotnet/api/system.uint32)
  * [Int64 Struct](https://learn.microsoft.com/en-us/dotnet/api/system.int64)
  * [UInt64 Struct](https://learn.microsoft.com/en-us/dotnet/api/system.uint64)
