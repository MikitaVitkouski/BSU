# Bools and Logic Operators

Beginner level task for practicing Boolean values and logic operators.

Estimated time to complete the task - 1h.

The task requires .NET 6 SDK installed.


## Task Description

The task has three sections with small sub-tasks in the code files. Each sub-task is a small coding exercise.


### Bools

Read the [bool](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool) article.

Open the [Booleans.cs](Bools/Booleans.cs) file, and implement all methods by returning a Boolean value.

| Method Name | Literals |
|-------------|----------|
| ReturnTrue  | true     |
| ReturnFalse | false    |

There are only two possible literals for the _bool_ data type - _true_ and _false_.


### Logical Operators

Read the [Boolean logical operators](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/boolean-logical-operators) article.

Open the [LogicalOperators.cs](Bools/LogicalOperators.cs) file, and implement all methods by applying a logical operation to method parameters.

| Method Name | Logical Operation    | Operator |
|-------------|----------------------|----------|
| LogicalAnd1 | Logical AND          | &&       |
| LogicalAnd2 | Logical AND          | &&       |
| LogicalAnd3 | Logical AND          | &&       |
| LogicalOr1  | Logical OR           | \|\|     |
| LogicalOr2  | Logical OR           | \|\|     |
| LogicalOr3  | Logical OR           | \|\|     |
| LogicalXor1 | Logical exclusive OR | ^        |
| LogicalXor2 | Logical exclusive OR | ^        |
| LogicalXor3 | Logical exclusive OR | ^        |
| Negate      | Logical negation     | !        |

Start with the [LogicalAnd1](Bools/LogicalOperators.cs#L5) method.

```cs
public static bool LogicalAnd1(bool b1, bool b2)
{
    // TODO #2-1. Return the result of logical AND for b1 and b2 parameters.
    throw new NotImplementedException();
}
```

Remove the _throw_ statement.

```cs
public static bool LogicalAnd1(bool b1, bool b2)
{
    // TODO #2-1. Return the result of logical AND for b1 and b2 parameters.
}
```

Return the result of logical AND operation for the _b1_ and _b2_ parameters by applying [operator &&](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/boolean-logical-operators#conditional-logical-and-operator-).

```cs
public static bool LogicalAnd1(bool b1, bool b2)
{
    // TODO #2-1. Return the result of logical AND for b1 and b2 parameters.
    return b1 && b2;
}
```

Remove the _TODO_ comment.

```cs
public static bool LogicalAnd1(bool b1, bool b2)
{
    return b1 && b2;
}
```

Create the [truth table](https://en.wikipedia.org/wiki/Truth_table) for _logical AND (conjunction)_ for the _b1_ and _b2_ parameters.

| b1    | b2    | b1 && b2 |
|-------|-------|----------|
| false | false | false    |
| true  | false | false    |
| false | true  | false    |
| true  | true  | true     |

Implement the other methods and create the truth tables for them (no need to add these tables to your solution).


### Logical Puzzles

In this section you have to use the logical operators to solve the logical puzzles in the [LogicalPuzzles.cs](Bools/LogicalPuzzles.cs) file. You can combine the logical operators together to get the expected result of a logical function. Start with creating a _truth table_ for a logical function you work with, then analyze it and reconstruct a logical function to satisfy the truth table criteria.

Here's the example of solving [Puzzle1](Bools/LogicalPuzzles.cs#L5) puzzle.

Take a look at the list of test cases for the [Puzzle1_ReturnBool](Bools.Tests/LogicalOperatorsTests.cs#L10) unit test and create an expected truth table for the operation you have to implement in the _Puzzle1_ method.

| b1    | b2    | Expected Result |
|-------|-------|-----------------|
| false | false | true            |
| true  | false | false           |
| false | true  | true            |
| true  | true  | true            |

Compare this truth table with the [truth table for logical OR operation](https://en.wikipedia.org/wiki/Truth_table#Logical_disjunction_(OR)) - you will find that they are very similar.

| b1    | b2    | Logical OR      |
|-------|-------|-----------------|
| false | false | false           |
| true  | false | true            |
| false | true  | true            |
| true  | true  | true            |

Apply _operator ||_ to _b1_ and _b2_ parameters.

```cs
public static bool Puzzle1(bool b1, bool b2)
{
    return b1 || b2;
}
```

Now, the _Puzzle1_ truth table is similar to the expected truth table except for the case when _b2_ parameter is false.

| b1    | b2    | Actual Result | Expected Result |
|-------|-------|---------------|-----------------|
| false | false | **false**     | **true**        |
| true  | false | **true**      | **false**       |
| false | true  | true          | true            |
| true  | true  | true          | true            |

That means a logical negation should be applied to the _b1_ parameter.

```cs
public static bool Puzzle1(bool b1, bool b2)
{
    return !b1 || b2;
}
```

Now the method produces correct expected results for all tests cases for the _Puzzle1_ReturnBool_ unit test.

Implement the other logical puzzles in the same way. Some puzzles assume using parentheses to change the order of [operand evaluation](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/#operand-evaluation).


## Fix Compiler Issues

Additional style and code checks are enabled for the projects in this solution to help you maintaining consistency of the project source code and avoiding silly mistakes. [Review the Error List](https://docs.microsoft.com/en-us/visualstudio/ide/find-and-fix-code-errors#review-the-error-list) in Visual Studio to see all compiler warnings and errors.

If a compiler error or warning message is not clear, [review errors details](https://docs.microsoft.com/en-us/visualstudio/ide/find-and-fix-code-errors#review-errors-in-detail) or google the error or warning code to get more information about the issue.


## Task Checklist

1. Rebuild the solution.
1. Fix all compiler warnings and errors.
1. Run all unit tests, make sure all unit tests completed successfully.
1. Review all changes, make sure the only code files (.cs) in Bools project have changes. No changes in project files (.csproj) or in Bools.Tests project.
1. Stage your changes, and create a commit.
1. Push your changes to remote repository.


## See also

* C# Language Reference
  * [bool](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool)
  * [Boolean logical operators](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/boolean-logical-operators)
* .NET API
  * [Boolean Struct](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)
* [Truth table](https://en.wikipedia.org/wiki/Truth_table)
