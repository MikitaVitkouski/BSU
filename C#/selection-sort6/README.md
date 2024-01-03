# Selection Sort Algorithm

An intermediate level task for practicing selection sort algorithm.

The task is to implement selection sort algorithm using loops and recursion.

Read more on [selection sort topic](https://www.google.com/search?q=selection+sort):

* [Selection Sort](https://en.wikipedia.org/wiki/Selection_sort)
* [Сортировка выбором](https://habr.com/ru/company/otus/blog/509674/)
* [Visualgo](https://visualgo.net/)


## Task Description

Use loop statements and recursion calls only to solve the task. Methods "SelectionSort" and "RecursiveSelectionSort" are implemented as [extension methods](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/extension-methods). It's **not allowed** to use a static or instance methods of the [Array class](https://docs.microsoft.com/en-us/dotnet/api/system.array) or any extension method from [System.Linq namespace](https://docs.microsoft.com/en-us/dotnet/api/system.linq).

1. Implement "SelectionSort" method in the [Sorter.cs](SelectionSort/Sorter.cs) file. The method should be implemented using a loop statement and use a selection sort algorithm to sort array items.
2. Implement "RecursiveSelectionSort" method in the [Sorter.cs](SelectionSort/Sorter.cs) file. The method should be implemented using a recursive selection sort algorithm. You can add new [static methods](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/static-classes-and-static-class-members) or use [local functions](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/local-functions).


## See also

* C# Reference
  * [for statement](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/for)
  * [while statement](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/while)
  * [static](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/static)
* C# Programming Guide
  * [Static Classes and Static Class Members](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/static-classes-and-static-class-members)
  * [Extension Methods](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/extension-methods)
  * [Local functions](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/local-functions)
* .NET API
  * [Array.Length Property](https://docs.microsoft.com/en-us/dotnet/api/system.array.length)
  * [Array.IList.Item[Int32] Property](https://docs.microsoft.com/en-us/dotnet/api/system.array.system-collections-ilist-item)
