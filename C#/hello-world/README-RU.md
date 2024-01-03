# Hello, world!

Задача начального уровня для практики навыка управления задачами в AutoCode. Переводы: [Английский](README.md).


## Заберите проект

* [Откройте проект в Visual Studio из внешнего Git-репозитория](https://docs.microsoft.com/ru-ru/visualstudio/get-started/tutorial-open-project-from-repo) или [склонируйте внешний Git-репозиторий на Ваш локальный диск](https://docs.microsoft.com/ru-ru/azure/devops/repos/git/clone#clone-from-another-git-provider) при помощи Visual Studio.


## Завершите задачу

1. Откройте вкладку [Solution Explorer](https://docs.microsoft.com/ru-ru/visualstudio/ide/solutions-and-projects-in-visual-studio#solution-explorer).
    * Выберите элемент меню - _View\Solution Explorer_.
    * Или используйте сочетание клавиш - _Ctrl+W, S_.
1. Найдите во вкладке Solution Explorer проекты "HelloWorld" и "HelloWorld.Tests".
1. Разверните проект "HelloWorld" и найдите в проекте файл [SimpleHelloWorld.cs](HelloWorld/SimpleHelloWorld.cs). Откройте файл в редакторе.
1. Разверните проект "HelloWorld.Tests" и найдите в проекте файл [SimpleHelloWorldTests.cs](HelloWorld.Tests/SimpleHelloWorldTests.cs). Откройте файл в редакторе.
1. [Соберите решение](https://docs.microsoft.com/ru-ru/visualstudio/ide/building-and-cleaning-projects-and-solutions-in-visual-studio).
    * Выберите элемент меню - _Build\Build Solution_.
    * Или используйте сочетание клавиш - _Ctrl+Shift+B_.
1. Откройте вкладку [Error List](https://docs.microsoft.com/ru-ru/visualstudio/ide/find-and-fix-code-errors#review-the-error-list). Убедитесь, что во вкладке нет проблем (ошибок или предупреждений), которые смог обнаружить компилятор C#.
    * Выберите элемент меню - _View\Error List_.
    * Или используйте сочетание клавиш - _Ctrl+W, E_.
1. Откройте вкладку [Test Explorer](https://docs.microsoft.com/ru-ru/visualstudio/test/run-unit-tests-with-test-explorer). Все тесты в списке тестов имеют голубую иконку с восклицательным знаком. Это значит, что тесты не были запущены.
    * Выберите элемент меню - _View\Test Explorer_.
    * Или используйте сочетание клавиш - _Ctrl+E, T_.
1. Выберите элементе "HelloWorld.Tests" в списке тестов, нажмите на нем правой кнопкой мыши и выберите в меню "Run". Все элементы в списке станут "зелеными".
    * Или используйте сочетание клавиш - _Ctrl+R, T_.
1. Разверните список, если необходимо. Нажмите правой клавишей на тесте "ReturnHelloWorld" и выберите в меню "Run". Выбранный элемент останется "зеленым".
    * Или используйте сочетание клави - _Ctrl+R, T_.
1. Запустите все юнит-тесты.
    * Выберите элемент меню - _Test\Run All Tests_.
    * Или используйте сочетание клавиш - _Ctrl+R, A_.

## Save Your Work

В этом задании нет задач на кодирование. Перейдите на портал AutoCode, откройте страницу задания и нажмите кнопку "Check task".

Нет необходимости изменять код, делать коммиты и отправлять во внеший репозиторий (его еще называют удаленным).


## Дополнительная информация

* Visual Studio
  * [Getting Started with Visual Studio 2019](https://www.youtube.com/watch?v=1CgsMtUmVgs)
  * [Default keyboard shortcuts in Visual Studio](https://docs.microsoft.com/ru-ru/visualstudio/ide/default-keyboard-shortcuts-in-visual-studio)
