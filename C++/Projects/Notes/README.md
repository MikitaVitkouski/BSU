## Screenshots

![image](https://github.com/user-attachments/assets/3e1caaef-8c76-49a1-be4c-6876456ba844)
![image](https://github.com/user-attachments/assets/5778a8fd-e0de-4cfc-a8f2-db5850853d48)
![image](https://github.com/user-attachments/assets/2232cdf1-629c-44b5-a1c9-eedbd215e958)
![image](https://github.com/user-attachments/assets/501cfdd8-c210-4674-85a5-fbbff4955946)

## Description

A C++ application for managing notes and tasks with an elegant and responsive Qt-based user interface.
Users can create, edit, delete, and organize their notes and to-dos in a visually clean layout with persistent state during runtime.

## Features

Note and task view, add, delete, edit.

## Technologies Used

Qt 6.9: Used for building the entire graphical interface and managing UI components (QStackedWidget, QPushButton, etc.).
C++11: Core logic and time handling.
CMake: The project uses CMake as the build system for easy compilation and setup across platforms.
GTest: Unit tests are provided for back-end part.

## Project Structure

Notes/
├── Notes/                        # Backend logic
│   ├── NoteManager.{h,cpp}
│   ├── TaskManager.{h,cpp}
│   ├── CMakeLists.txt
│
├── NotesTests/                  # Unit tests using GoogleTest
│   ├── NotesTests.cpp
│   ├── pch.h
│   └── pch.cpp
│
├── QtGUI/NotesGUI/              # GUI code built with Qt
│   ├── main.cpp
│   ├── mainwindow.{h,cpp}
│   ├── TaskItemWidget.{h,cpp}
│   ├── NoteItemWidget.{h,cpp}
│   ├── mainwindow.ui
│   ├── style.css
│   ├── resources.qrc
│   └── CMakeLists.txt
│
└── CMakeLists.txt               # Root CMake build config

## Installation and Setup

1. Clone the repository:

   ```bash
   git clone https://github.com/MikitaVitkouski/BSU.git
   cd BSU/C++/Projects/Notes/
   ```

2. Make sure you have **Qt** and **CMake** installed.

3. Open **Qt Creator**.

4. Select the **CMakeLists.txt** file from the `QtGUI - NotesGUI` folder (where the code and CMake configuration are located).

5. Build and run the project from Qt Creator.

6. Once built, launch the application to start work with tasks and notes!

## Usage

Navigate using the top/bottom navigation buttons (Notes, Add note, Add task, Tasks).
Add notes for usual things.
Add tasks for any tasks in your life, mark its progress.
