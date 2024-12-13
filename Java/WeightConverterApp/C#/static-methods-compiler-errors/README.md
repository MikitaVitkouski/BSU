# Static Methods - Compiler Errors

Beginner level task to practice fixing the most common compiler errors.

Estimated time to complete the task - 1h.

The task requires .NET 6 SDK installed.


## Task Description

The task has five sub-tasks. Each sub-task is a small coding exercise.


## CS0103

1. [Build the solution](https://docs.microsoft.com/en-us/visualstudio/ide/building-and-cleaning-projects-and-solutions-in-visual-studio).
    * Click on the menu item - _Build\Build Solution_.
    * Or use the default keyboard shortcut - _Ctrl+Shift+B_ (different versions of Visual Studio may have different keyboard shortcuts. See [Keyboard shortcuts in Visual Studio](https://docs.microsoft.com/en-us/visualstudio/ide/default-keyboard-shortcuts-in-visual-studio) article).

![Build Solution](images/build-solution.png)

2. Open the [Error List](https://docs.microsoft.com/en-us/visualstudio/ide/find-and-fix-code-errors#review-the-error-list) view.
    * Click on the menu item - _View\Error List_.
    * Or use the default shortcut - _Ctrl+\\, E_.

![View Error List](images/view-error-list.png)

3. Find an error with CS0103 code and review the error in detail by clicking on the link in the "Code" column.

![Open CS0103](images/open-cs0103.png)

You will get to the issue documentation page.

4. Double-click on the CS0103 issue in the _Error List_ window. 

![Navigate to CS0103](images/navigate-to-cs0103.png)

You will get to the [CS0103/MyClass.cs](CompilerErrors/CS0103/MyClass.cs) file.

![CS0103](images/cs0103.png)

5. Read the documentation page and learn [how to fix the error](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/compiler-messages/cs0103): "Check the spelling of the name and check your [**using** directives](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/using-directive) and assembly references to make sure that the name that you are trying to use is available."

6. Replace the name of the method called in the return statement with correct spelling - _ReturnInt_.

```cs
public static int MyMethod()
{
    return ReturnInt(intParameter: 534_947_886);
}
```

7. Rebuild the solution.

![Rebuild Solution](images/rebuild-solution.png)

8. Open the _Error List_ window again and make sure there are no CS0103 issues.


## CS0117

![CS0117](images/cs0117.png)

1. Open the _Error List_ window, find the CS0117 issue.
2. Open and read the issue documentation page.
3. Navigate to the code by clicking on the issue line in _Error List_ window.
4. Replace the name of the method called in the return statement with correct spelling - _ReturnLong_.

```cs
public static long MyMethod()
{
    return AnotherClass.ReturnLong(longParameter: 49_023_471L);
}
```

5. Rebuild the solution.
6. Open the _Error List_ window again and make sure there are no CS0117 issues anymore.


## CS1501

![CS1501](images/cs1501.png)

Fix the issue by removing the method argument from the method call.

```cs
public static int MyMethod()
{
    return ReturnInt();
}
```


## CS1739

![CS1739](images/cs1739.png)

Fix the issue by replacing the named parameter with correct argument name.

```cs
public static int MyMethod()
{
    return ReturnInt(intParameter: 9_389_572);
}
```


## CS7036

![CS7036](images/cs7036.png)

Fix the issue by adding the parameter to the _ReturnInt_ method call.

```cs
public static int MyMethod()
{
    return ReturnInt(5_689_375);
}
```


## Fix Compiler Issues

Additional style and code checks are enabled for the projects in this solution to help you maintaining consistency of the project source code and avoiding silly mistakes. [Review the Error List](https://docs.microsoft.com/en-us/visualstudio/ide/find-and-fix-code-errors#review-the-error-list) in Visual Studio to see all compiler warnings and errors.

If a compiler error or warning message is not clear, [review errors details](https://docs.microsoft.com/en-us/visualstudio/ide/find-and-fix-code-errors#review-errors-in-detail) or google the error or warning code to get more information about the issue.


## Task Checklist

1. Rebuild the solution.
2. Fix all compiler warnings and errors. Make sure there are no warnings and errors in _Error List_.

![Output and Error List](images/rebuild-solution-output-error-list.png)

3. Run all unit tests, make sure all unit tests completed successfully.

![Test Explorer](images/test-explorer.png)

4. Review all changes, make sure that only the code files (.cs) in CompilerErrors project are changed.

![Good Git Changes](images/git-changes-good.png)

Do not make any changes to project files (.csproj) or in code files in CompilerErrors.Tests project.

![Bad Git Changes](images/git-changes-bad.png)

5. Stage your changes.

![Stage Changes](images/git-changes-stage.png)

All your changes are staged now.

![Staged Changes](images/git-changes-staged-changes.png)

6. Create a commit and push your changes to remote repository.

![Commit and Push](images/git-changes-commit-push.png)


## See also

* Visual Studio
  * [Getting Started with Visual Studio 2019](https://www.youtube.com/watch?v=1CgsMtUmVgs)
  * [Default keyboard shortcuts in Visual Studio](https://docs.microsoft.com/en-us/visualstudio/ide/default-keyboard-shortcuts-in-visual-studio)

