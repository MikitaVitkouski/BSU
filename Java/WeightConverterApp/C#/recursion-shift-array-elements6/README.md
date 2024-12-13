# Shift Array Elements (Recursion)

An intermediate level task for practicing recursion, local functions and indices.

The task is to implement 2 methods using recursive local functions. The task has **hidden tests**.


## Task Description

In the task you are allowed to use [local functions](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/local-functions), Array.Copy method and indices only. You are _not allowed_ to use extension methods from [System.Linq namespace](https://docs.microsoft.com/en-us/dotnet/api/system.linq), loops (for, while, do..while) and iterators (foreach).


### 1. RecursiveEnumShifter Class

Implement the "Shift" method in the [RecursiveEnumShifter.cs](ShiftArrayElementsRecursion/RecursiveEnumShifter.cs) file using recursive local functions, array indices and Array.Copy method for copying array elements.

The method has two arguments. The "source" arguments has the array of integers to shift and return. _Do not create a new array_. The "directions" argument has the array of values of the "Direction" enum type. Each value in the "directions" array is a shift instruction that tells the shift direction for each iteration. The number of iterations is the "direction" array length. The first and the last elements in the "source" array should be wrapped to the other side of the array.

Use "if..else" statement to handle "directions" array values. Use "else" branch to handle the values other then "Left" and "Right".

```cs
if (currentDirection == Direction.Left)
{
    // TODO: Handle "left" shift.
}
else if (currentDirection == Direction.Right)
{
    // TODO: Handle "right" shift.
}
else
{
    throw new InvalidOperationException($"Incorrect {currentDirection} enum value.");
}
```

See examples for more details regarding the shift algorithm.


#### Example #1.

The "source" array contains three elements [1, 2, 3]. The "directions" array has only one element [Left], that means there will be only one shift iteration.

| Array Index                  | 0 | 1 | 2 |
|------------------------------|---|---|---|
| Initial Array                | 1 | 2 | 3 |
| Iteration 1: Element "Left"  | 2 | 3 | 1 |
| Result                       | 2 | 3 | 1 |


#### Example #2.

The "source" array contains three elements [1, 2, 3]. The "directions" array has two elements [Left, Left], that means there will be two shift iterations.

| Array Index                  | 0 | 1 | 2 |
|------------------------------|---|---|---|
| Initial Array                | 1 | 2 | 3 |
| Iteration 1: Element "Left"  | 2 | 3 | 1 |
| Iteration 2: Element "Left"  | 3 | 1 | 2 |
| Result                       | 3 | 1 | 2 |


#### Example #3.

The "source" array contains three elements [1, 2, 3]. The "directions" array has two elements [Left, Right, Left], that means there will be three shift iterations.

| Array Index                  | 0 | 1 | 2 |
|------------------------------|---|---|---|
| Initial Array                | 1 | 2 | 3 |
| Iteration 1: Element "Left"  | 2 | 3 | 1 |
| Iteration 2: Element "Right" | 1 | 2 | 3 |
| Iteration 3: Element "Left"  | 2 | 3 | 1 |
| Result                       | 2 | 3 | 1 |


### 2. RecursiveShifter Class

Implement the "Shift" method in the [RecursiveShifter.cs](ShiftArrayElementsRecursion/RecursiveShifter.cs) file using recursive local functions and array indices only.

The method has two arguments. The "source" arguments has the array of integers to shift and return. _Do not create a new array_. The "iterations" argument has the array of integers. Each value in the "iterations" array is a shift instruction that tells the number of shift iterations. The odd elements (an element with odd index) tells the number of right shift iterations. The even elements (an element with even index or zero index) tells the number of left shift iterations. The first and the last elements in the "source" array should be wrapped to the other side of the array.

See examples for more details regarding the shift algorithm.


#### Example #4.

The "source" array contains three elements [1, 2, 3]. The "iterations" array has only one element [1], that means there will be only one left shift iteration ("1" is an zero index element).

| Array Index                     | 0 | 1 | 2 |
|---------------------------------|---|---|---|
| Initial Array                   | 1 | 2 | 3 |
| Iteration 1: Element 1 (left)   | 2 | 3 | 1 |
| Result                          | 2 | 3 | 1 |


#### Example #5.

The "source" array contains three elements [1, 2, 3]. The "iterations" array has two elements [0, 1], that means there will be only one right shift iteration ("1" is an odd index element).

| Array Index                     | 0 | 1 | 2 |
|---------------------------------|---|---|---|
| Initial Array                   | 1 | 2 | 3 |
| No shift: Element 0 (left)      | 1 | 2 | 3 |
| Iteration 1: Element 1 (right)  | 3 | 1 | 2 |
| Result                          | 3 | 1 | 2 |


#### Example #6.

The "source" array contains three elements [1, 2, 3]. The "iterations" array has two elements [2, 1], that means there will be two left shift iterations and one right shift iteration.

| Array Index                     | 0 | 1 | 2 |
|---------------------------------|---|---|---|
| Initial Array                   | 1 | 2 | 3 |
| Iteration 1: Element 2 (left)   | 2 | 3 | 1 |
| Iteration 2: Element 2 (left)   | 3 | 1 | 2 |
| Iteration 3: Element 1 (right)  | 2 | 3 | 1 |
| Result                          | 2 | 3 | 1 |


#### Example #7.

The "source" array contains three elements [1, 2, 3]. The "iterations" array has three elements [1, 2, 3], that means there will be six iterations (one left shift iteration, then two right shift iterations, and then three left shift iterations).

| Array Index                     | 0 | 1 | 2 |
|---------------------------------|---|---|---|
| Initial Array                   | 1 | 2 | 3 |
| Iteration 1: Element 1 (left)   | 2 | 3 | 1 |
| Iteration 2: Element 2 (right)  | 1 | 2 | 3 |
| Iteration 3: Element 2 (right)  | 3 | 1 | 2 |
| Iteration 4: Element 3 (left)   | 1 | 2 | 3 |
| Iteration 5: Element 3 (left)   | 2 | 3 | 1 |
| Iteration 6: Element 3 (left)   | 3 | 1 | 2 |
| Result                          | 3 | 1 | 2 |


## Hidden Tests

The task has hidden unit tests that are not available in your solution, but will be run by the portal when you will start the task check. The hidden unit test may fail if your solution is not good enough to cover all the test cases.


## See also

* Tour of C#
  * [Indices and ranges](https://docs.microsoft.com/en-us/dotnet/csharp/tutorials/ranges-indexes)
* C# Programming Guide
  * [Arrays](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/arrays/)
  * [Single-Dimensional Arrays](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/arrays/single-dimensional-arrays)
  * [local functions](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/local-functions)
* C# Reference
  * [Enumeration types](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/enum)
* .NET API
  * [Array Class](https://docs.microsoft.com/en-us/dotnet/api/system.array)
  * [Array.Copy](https://docs.microsoft.com/en-us/dotnet/api/system.array.copy)
  * [Enum Class](https://docs.microsoft.com/en-us/dotnet/api/system.enum)
