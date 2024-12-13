# While Practice

Intermediate level task for practicing while statements.

Estimated time to complete the task - 2h.

The task requires .NET 6 SDK installed.


## Task Description

The task has six sub-tasks. Each sub-task is a small coding exercise.

Use the only *while* statements in this task. Using *for* or *do-while* iteration statements is not required.

If you have issues with running test cases for huge _n_ numbers, check your code for _int_ data types and cast values to _double_.


#### Sub-task 1

Open the [Task1.cs](WhilePractice/Task1.cs) file, and navigate to the [SumSequenceElements](WhilePractice/Task1.cs#L10) method.

Implement the method to sum the sequence elements $`^1/_1+^1/_2+^1/_3+...+^1/_n`$:

$`\sum_{i=1}^{n}\frac{1}{i}`$

, where _n_ > 0.


#### Sub-task 2

Open the [Task2.cs](WhilePractice/Task2.cs) file, and navigate to the [SumSequenceElements](WhilePractice/Task2.cs#L11) method.

Implement the method to sum the sequence elements $`^1/_{1\cdot 2}-^1/_{2\cdot 3}+^1/_{3\cdot 4}-...+^{(-1)^{n+1}}/_{n\cdot (n+1)}`$:

$`\sum_{i=1}^{n}\frac{(-1)^{i+1}}{i\cdot (i+1)}`$

,where _n_ > 0.

To raise a number to the required power use a _while_ statement. Don't use the _Math.Pow_ method.


#### Sub-task 3

Open the [Task3.cs](WhilePractice/Task3.cs) file, and navigate to the [SumSequenceElements](WhilePractice/Task3.cs#L11) method.

Implement the method to sum the sequence elements $`^1/_{1^5}+^1/_{2^5}+^1/_{3^5}+...+^1/_{n^5}`$:

$`\sum_{i=1}^{n}\frac{1}{i^5}`$

, where _n_ > 0.


#### Sub-task 4

Open the [Task4.cs](WhilePractice/Task4.cs) file, and navigate to the [SumSequenceElements](WhilePractice/Task4.cs#L11) method.

Implement the method to sum the sequence elements $`^1/_{3^2}+^1/_{5^2}+^1/_{7^2}+...+^1/_{(2\cdot n+1)^2}`$:

$`\sum_{i=1}^{n}\frac{1}{(2\cdot i+1)^2}`$

, where _n_ > 0.

Use a _while_ statement to raise a number to the required power. Don't use _Math.Pow_ method. 


#### Sub-task 5

Open the [Task5.cs](WhilePractice/Task5.cs) file, and navigate to the [GetSequenceProduct](WhilePractice/Task5.cs#L11) method.

Implement the method to get the product of the sequence $`(1+^1/_{1^2})\cdot(1+^1/_{2^2})\cdot(1+^1/_{3^2})\cdot...\cdot(1+^1/_{n^2})`$:

$`\prod_{i=1}^{n} 1+\frac{1}{i^2}`$

, where _n_ > 0.


#### Sub-task 6

Open the [Task6.cs](WhilePractice/Task6.cs) file, and navigate to the [SumSequenceElements](WhilePractice/Task6.cs#L11) method.

Implement the method to sum the sequence elements $`^{-1}/_3+^1/_5+^{-1}/_{7}+...+^{(-1)^n}/_{(2\cdot n+1)}`$

$`\sum_{i=1}^{n}\frac{(-1)^i}{2\cdot i + 1}`$

, where _n_ > 0.

Use a _while_ statement to raise a number to the required power. Don't use _Math.Pow_ method. 


## Fix Compiler Issues

Additional style and code checks are enabled for the projects in this solution to help you maintaining consistency of the project source code and avoiding silly mistakes. [Review the Error List](https://docs.microsoft.com/en-us/visualstudio/ide/find-and-fix-code-errors#review-the-error-list) in Visual Studio to see all compiler warnings and errors.

If a compiler error or warning message is not clear, [review errors details](https://docs.microsoft.com/en-us/visualstudio/ide/find-and-fix-code-errors#review-errors-in-detail) or google the error or warning code to get more information about the issue.


## Task Checklist

1. Rebuild the solution.
1. Fix all compiler warnings and errors.
1. Run all unit tests, make sure all unit tests completed successfully.
1. Review all changes, make sure the only code files (.cs) in WhilePractice project have changes. No changes in project files (.csproj) or in WhilePractice.Tests project.
1. Stage your changes, and create a commit.
1. Push your changes to remote repository.


## See also

* C# Language Reference
  * [The while statement](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/statements/iteration-statements#the-while-statement)
  * [The return statement](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/statements/jump-statements#the-return-statement)
  * [Increment operator](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/arithmetic-operators#increment-operator-)
  * [Decrement operator](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/arithmetic-operators#decrement-operator---)
  * [Compound assignment operators](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/arithmetic-operators#compound-assignment)
