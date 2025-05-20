![image](https://github.com/user-attachments/assets/fef7169d-1437-4b94-9fa7-eb1b85a241e7)
![image](https://github.com/user-attachments/assets/262ab51b-c9c6-4bcc-b1b3-3f12c49f3e8f)
![image](https://github.com/user-attachments/assets/046869c0-abfc-4747-9d93-a758e84c3518)
![image](https://github.com/user-attachments/assets/ae146cd4-fc6b-45c3-9305-2818b5055190)

A modern C++ application providing multiple time-related utilities including a clock, alarm, stopwatch, and timer — all within a sleek, user-friendly graphical interface built with Qt.

## Features
Clock View: Displays the current time, date, and time zone in a stylish format.
Alarms: Add, delete, and manage alarms. Alarms persist during runtime and notify users at the set time.
Stopwatch: Start, pause, resume, reset functionality. Add lap times and review them in a list.
Timer: Countdown timer with start/pause/resume/reset functionality.
Dynamic UI: Switch between sections with visually active navigation buttons for clarity.
Custom Styles: Carefully designed interface using modern colors and Qt Style Sheets (style.css) for a pleasant user experience.

## Technologies Used

Qt 6.9: Used for building the entire graphical interface and managing UI components (QStackedWidget, QPushButton, etc.).
C++11: Core logic and time handling.
CMake: The project uses CMake as the build system for easy compilation and setup across platforms.
GTest: Unit tests are provided for back-end part.

## Project Structure

Clock/
├── Clock/                        # Backend logic
│   ├── AlarmManager.{h,cpp}
│   ├── Stopwatch.{h,cpp}
│   ├── TimerManager.{h,cpp}
│   ├── Clock.{h,cpp}
│
├── ClockTests/                  # Unit tests using GoogleTest
│   ├── BackendTests.cpp
│   ├── pch.h
│   └── pch.cpp
│
├── QtGUI/ClockGUI/              # GUI code built with Qt
│   ├── main.cpp
│   ├── mainwindow.{h,cpp}
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
   cd BSU/C++/Projects/Clock/
   ```

2. Make sure you have **Qt** and **CMake** installed.

3. Open **Qt Creator**.

4. Select the **CMakeLists.txt** file from the `QtGUI - ClockGUI` folder (where the code and CMake configuration are located).

5. Build and run the project from Qt Creator.

6. Once built, launch the application to start performing calculations with fractions!

## Usage

Navigate using the top/bottom navigation buttons (Clock, Alarm, Stopwatch, Timer).
Set Alarms and view them in a list with options to remove.
Use Stopwatch to time events and view lap records.
Run Timer to count down from a set time with pause/resume control.
The active view is highlighted for clear navigation.
