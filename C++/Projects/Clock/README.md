## Screenshots
![image](https://github.com/user-attachments/assets/96d761cb-eaec-48b4-a65a-e587c7efd8ef)
![image](https://github.com/user-attachments/assets/e58d05e5-6a8a-4ddb-be54-484ff2a46ab0)
![image](https://github.com/user-attachments/assets/719558fc-2572-4c63-a5d8-ea80d641ac42)
![image](https://github.com/user-attachments/assets/1496626f-701f-4c8e-a974-bd66c1b1c5e2)

## Description
A modern C++ application providing multiple time-related utilities including a clock, alarm, stopwatch, and timer — all within a sleek, user-friendly graphical interface built with Qt.

## Features

- **Clock View**: Displays the current time, date, and time zone in a stylish format.
- **Alarms**: Add, delete, and manage alarms. Alarms persist during runtime and notify users at the set time.
- **Stopwatch**: Start, pause, resume, and reset. Add lap times and review them in a list.
- **Timer**: Countdown timer with full control (start/pause/resume/reset).
- **Dynamic UI**: Switch between sections using visually active navigation buttons.
- **Custom Styles**: Carefully designed with Qt Style Sheets (`style.css`) for a pleasant experience.

## Technologies Used

- **Qt 6.9** — GUI.
- **C++11** — Core logic and time processing.
- **CMake** — Build system.
- **GTest** — Unit tests for backend logic.
- **CSS** - Stylesheet for GUI.

## Project Structure

```bash
Clock/
├── Clock/                    # Backend logic
│   ├── AlarmManager.{h,cpp}
│   ├── Stopwatch.{h,cpp}
│   ├── TimerManager.{h,cpp}
│   ├── Clock.{h,cpp}
│   └── CMakeLists.txt
│
├── ClockTests/              # Unit tests (Google Test)
│   ├── BackendTests.cpp
│   ├── pch.h
│   └── pch.cpp
│
├── QtGUI/ClockGUI/          # GUI with Qt
│   ├── main.cpp
│   ├── mainwindow.{h,cpp}
│   ├── mainwindow.ui
│   ├── style.css
│   ├── resources.qrc
│   └── CMakeLists.txt
│
└── CMakeLists.txt           # Root build configuration
```

## Installation and Setup

1. **Clone the repository**:

   ```bash
   git clone https://github.com/MikitaVitkouski/BSU.git
   cd BSU/C++/Projects/Clock/
   ```

2. **Install dependencies**: Ensure **Qt** and **CMake** are installed.

3. **Open project**: Launch **Qt Creator** and open the `CMakeLists.txt` from the `QtGUI/ClockGUI` folder.

4. **Build and run**: Use Qt Creator's interface to build and launch the app.

## Usage


- Navigate using the top/bottom buttons: **Clock**, **Alarm**, **Stopwatch**, **Timer**.
- Set alarms and manage them in a list with delete options.
- Use the **Stopwatch** to time events with lap tracking.
- Use the **Timer** for countdowns with control options.
- Active section is visually highlighted for intuitive UX.
