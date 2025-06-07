## Screenshots

![image](https://github.com/user-attachments/assets/3e1caaef-8c76-49a1-be4c-6876456ba844)
![image](https://github.com/user-attachments/assets/5778a8fd-e0de-4cfc-a8f2-db5850853d48)
![image](https://github.com/user-attachments/assets/2232cdf1-629c-44b5-a1c9-eedbd215e958)
![image](https://github.com/user-attachments/assets/501cfdd8-c210-4674-85a5-fbbff4955946)

## Description

A **C++** application for managing **notes** and **tasks** with an elegant and responsive **Qt-based user interface**.  
Users can create, edit, delete, and organize their notes and to-dos in a visually clean layout with **persistent state during runtime**.

## Features

- **Note and Task View**: Organized sections for quick access.
- **Create, Edit, Delete**: Manage both notes and to-dos efficiently.
- **Live Updates**: Changes reflect immediately in the interface.
- **Responsive UI**: Designed with modern Qt widgets and styles.

## Technologies Used

- **Qt 6.9** — GUI.
- **C++11** — Core logic for handling notes and tasks.
- **CMake** — Build system.
- **GTest** — Unit tests for back-end logic.
- **CSS** - Stylesheet for GUI.

## Project Structure

```bash
Notes/
├── Notes/                    # Backend logic
│   ├── NoteManager.{h,cpp}
│   ├── TaskManager.{h,cpp}
│   └── CMakeLists.txt
│
├── NotesTests/              # Unit tests
│   ├── NotesTests.cpp
│   ├── pch.h
│   └── pch.cpp
│
├── QtGUI/NotesGUI/          # GUI with Qt
│   ├── main.cpp
│   ├── mainwindow.{h,cpp}
│   ├── mainwindow.ui
│   ├── NoteItemWidget.{h,cpp}
│   ├── TaskItemWidget.{h,cpp}
│   ├── style.css
│   ├── resources.qrc
│   └── CMakeLists.txt
│
└── CMakeLists.txt           # Root build config
```

## Installation and Setup

1. **Clone the repository**:

   ```bash
   git clone https://github.com/MikitaVitkouski/BSU.git
   cd BSU/C++/Projects/Notes/
   ```

2. **Install dependencies**: Make sure **Qt** and **CMake** are installed.

3. **Open project**: Launch **Qt Creator** and open the `CMakeLists.txt` from `QtGUI/NotesGUI/`.

4. **Build and run**: Compile and launch directly from Qt Creator.

## Usage

- Use top navigation to switch between: **Notes**, **Tasks**, **Add Note**, **Add Task**.
- Create **notes** for general-purpose text or ideas.
- Add **tasks** with progress indicators to track life events or projects.
- All changes are reflected live and stored during runtime for seamless experience.
