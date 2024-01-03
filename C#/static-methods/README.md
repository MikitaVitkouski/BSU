# Static Methods

Beginner level task for practicing static methods.

Estimated time to complete the task - 1h.

The task requires .NET 6 SDK installed.


## Task Description

The task has two sections with twenty-two sub-tasks. Each sub-task is a small coding exercise.


## Static Methods

Read the [Method signatures](https://docs.microsoft.com/en-us/dotnet/csharp/methods#method-signatures) and the [Return values](https://docs.microsoft.com/en-us/dotnet/csharp/methods#return-values) sections from the [Method](https://docs.microsoft.com/en-us/dotnet/csharp/methods) article.

Open the [ReturningMethods.cs](StaticMethods/ReturningMethods.cs) file, and implement the methods from the table below.

| Method Name        | Return Type | Return Value (Literal) |
|--------------------|-------------|------------------------|
| ReturnInt          | int         | -1234567               |
| ReturnUnsignedInt  | uint        | 1234567u               |
| ReturnLong         | long        | -987654321L            |
| ReturnUnsignedLong | ulong       | 987654321uL            |
| ReturnFloat        | float       | 1234.567f              |
| ReturnDouble       | double      | -9876.54321            |
| ReturnDecimal      | decimal     | -123456789.987654321m  |
| ReturnString       | string      | "Hello, world!"        |
| ReturnChar         | char        | 'A'                    |
| ReturnByte         | byte        | 0xAB                   |
| ReturnBool         | bool        | true                   |

Let's start with implementing the `ReturnInt` method. Copy the following code template:

```cs
public static RETURN_TYPE METHOD_NAME()
{
    return RETURN_VALUE;
}
```

Go to the line with the [TODO #1-1](StaticMethods/ReturningMethods.cs#L5) comment. Paste the template right after the comment.

```cs
// TODO #1-1: Add the static method here with the name "ReturnInt" that should return -1234567 literal (int return type).
public static RETURN_TYPE METHOD_NAME()
{
    return RETURN_VALUE;
}
```

Replace METHOD_NAME with `ReturnInt`.

```cs
// TODO #1-1: Add the static method here with name "ReturnInt" that should return -1234567 literal (int return type).
public static RETURN_TYPE ReturnInt()
{
    return RETURN_VALUE;
}
```

In .NET, it is common practice to give [method names](https://learn.microsoft.com/en-us/dotnet/standard/design-guidelines/names-of-type-members#names-of-methods) that are verbs or verb phrases and use the [PascalCasing convention](https://learn.microsoft.com/en-us/dotnet/standard/design-guidelines/capitalization-conventions#capitalization-rules-for-identifiers) for method names.

Replace RETURN_TYPE with `int` and RETURN_VALUE with the `-1234567` literal.

```cs
// TODO #1-1: Add the static method here with name "ReturnInt" that should return -1234567 literal (int return type).
public static int ReturnInt()
{
    return -1234567;
}
```

Remove the TODO comment. Having a TODO comment in your code make Sonar generate the [S1135 issue](https://rules.sonarsource.com/csharp/RSPEC-1135).

```cs
public static int ReturnInt()
{
    return -1234567;
}
```

Implement the other methods in the same way.

Read the [Method invocation](https://docs.microsoft.com/en-us/dotnet/csharp/methods#method-invocation) section, and learn how static methods are invoked. Open [ReturningMethodsTests.cs](StaticMethods.Tests/ReturningMethodsTests.cs), navigate to the [ReturnInt_ReturnsInteger](StaticMethods.Tests/ReturningMethodsTests.cs#L10) unit test, and find out how the `ReturnInt` method is invoked in the unit test.


## Method Parameters

Read the [Passing parameters by value](https://docs.microsoft.com/en-us/dotnet/csharp/methods#passing-parameters-by-value) section from the [Method](https://docs.microsoft.com/en-us/dotnet/csharp/methods) article.

Open the [PassthroughMethods.cs](StaticMethods/PassthroughMethods.cs) file, and implement the methods from the table below.

| Method Name        | Return Type | Parameter Name   | Parameter Type  |
|--------------------|-------------|------------------|-----------------|
| ReturnInt          | int         | intParameter     | int             |
| ReturnUnsignedInt  | uint        | uintParameter    | uint            |
| ReturnLong         | long        | longParameter    | long            |
| ReturnUnsignedLong | ulong       | ulongParameter   | ulong           |
| ReturnFloat        | float       | floatParameter   | float           |
| ReturnDouble       | double      | doubleParameter  | double          |
| ReturnDecimal      | decimal     | decimalParameter | decimal         |
| ReturnString       | string      | stringParameter  | string          |
| ReturnChar         | char        | charParameter    | char            |
| ReturnByte         | byte        | byteParameter    | byte            |
| ReturnBool         | bool        | boolParameter    | bool            |

Start with implementing the `ReturnInt` method. Go to the line with the [TODO #2-1](StaticMethods/PassthroughMethods.cs#L5) comment, and add the method definition like you did in the previous section.

```cs
// TODO #2-1: Add the static method here with name "ReturnInt" that gets "intParameter" parameter ("int" type) and returns it.
public static int ReturnInt()
{
}
```

Then, add *method parameter* with the specified parameter type.

```cs
// TODO #2-1: Add the static method here with name "ReturnInt" that gets "intParameter" parameter ("int" type) and returns it.
public static int ReturnInt(int intParameter)
{
}
```

Return the method argument from the method body. Remove the TODO comment.

```cs
// TODO #2-1: Add the static method here with name "ReturnInt" that gets "intParameter" parameter ("int" type) and returns it.
public static int ReturnInt(int intParameter)
{
    return intParameter;
}
```

Implement the other methods in the same way.

Open [PassthroughMethodsTests.cs](StaticMethods.Tests/PassthroughMethodsTests.cs), navigate to the [ReturnInt_ReturnsInt](StaticMethods.Tests/PassthroughMethodsTests.cs#L12) unit test.

```cs
[TestCase(int.MaxValue, ExpectedResult = int.MaxValue)]
public int ReturnInt_ReturnsInt(int argument)
{
    return PassthroughMethods.ReturnInt(intParameter: argument);
}
```

*argument* is passed to the `ReturnInt` method as a [named argument](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/named-and-optional-arguments#named-arguments).


## Fix Compiler Issues

Additional style and code checks are enabled for the projects in this solution to help you maintaining consistency of the project source code and avoiding silly mistakes. [Review the Error List](https://docs.microsoft.com/en-us/visualstudio/ide/find-and-fix-code-errors#review-the-error-list) in Visual Studio to see all compiler warnings and errors.

If a compiler error or warning message is not clear, [review errors details](https://docs.microsoft.com/en-us/visualstudio/ide/find-and-fix-code-errors#review-errors-in-detail) or google the error or warning code to get more information about the issue.


## Task Checklist

1. Rebuild the solution.
1. Fix all compiler warnings and errors.
1. Run all unit tests, make sure all unit tests completed successfully.
1. Review all changes, make sure the only code files (.cs) in StaticMethod project have changes. No changes in project files (.csproj) or in StaticMethod.Tests project.
1. Stage your changes, and create a commit.
1. Push your changes to remote repository.


## See also

* [Methods](https://docs.microsoft.com/en-us/dotnet/csharp/methods)
* [Named and Optional Arguments](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/named-and-optional-arguments)
