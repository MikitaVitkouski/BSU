## Screenchots
![image](https://github.com/user-attachments/assets/1ad32900-4c56-4690-b0da-a7e9998c60d9)
![image](https://github.com/user-attachments/assets/eb8f7ae3-6462-4fde-9611-592d05ad1c29)
![image](https://github.com/user-attachments/assets/4e093a92-55d2-4c07-aaaf-6c58a40934b0)

## Description

A simple C++ application for performing arithmetic operations on fractions or numbers with a graphical user interface built using Qt.

## Features

- **Fraction Operations**: Add, subtract, multiply, divide, and exponentiate fractions.
- **Simplification**: Automatically reduces fractions to their lowest terms.
- **Comparison**: Compare fractions with other fractions or decimal numbers.
- **Fraction & Decimal Display**: Toggle between fraction and decimal formats for results.
- **Reverse Fractions**: Easily invert fractions (e.g., `2/3` becomes `3/2`).
- **Basic Calculator Mode**: Integers are treated as fractions (e.g., `2` → `2/1`), making it usable as a general calculator.

## Technologies Used

- **C++11** – Main programming language.
- **Qt 6.9** – GUI framework.
- **CMake** – Build system.
- **GTest** – Unit testing.
- **CSS** – GUI styling.
  
## Project Structure

```bash
FractionCalculator/
├── FractionCalculator/                    # Backend logic
│   ├── Fraction.{h,cpp}
│   └── CMakeLists.txt
│
├── FractionTests/              # Unit tests
│   ├── test.cpp                # Fraction class tests
│   ├── pch.h
│   └── pch.cpp
│
├── QtGUI/FractionCalculatorGUI/          # GUI with Qt
│   ├── main.cpp
│   ├── mainwindow.{h,cpp}
│   ├── mainwindow.ui
│   ├── ExpressionLineEdit.{h,cpp}
│   ├── style.css
│   ├── resources.qrc
│   └── CMakeLists.txt
│
└── CMakeLists.txt           # Root build config
```

## Installation and Setup

1. Clone the repository:

   ```bash
   git clone https://github.com/MikitaVitkouski/BSU.git
   cd BSU/C++/Projects/FractionCalculator/
   ```

2. Make sure you have **Qt** and **CMake** installed.

3. Open **Qt Creator**.

4. Select the **CMakeLists.txt** file from the `QtGUI - FractionCalculatorGUI` folder (where the code and CMake configuration are located).

5. Build and run the project from Qt Creator.

6. Once built, launch the application to start performing calculations with fractions!

## Usage

- Input fractions or integers via the GUI.
- Perform basic arithmetic operations.
- Switch between fraction and decimal result displays.
- Use the calculator in both simple and fraction modes.
