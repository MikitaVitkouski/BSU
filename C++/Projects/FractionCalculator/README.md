## Screenchots
![image](https://github.com/user-attachments/assets/1ad32900-4c56-4690-b0da-a7e9998c60d9)
![image](https://github.com/user-attachments/assets/eb8f7ae3-6462-4fde-9611-592d05ad1c29)
![image](https://github.com/user-attachments/assets/4e093a92-55d2-4c07-aaaf-6c58a40934b0)

## Description

A simple C++ application for performing arithmetic operations on fractions or numbers with a graphical user interface built using Qt.

Features
Fraction Operations: Addition, subtraction, multiplication, division, and exponentiation of fractions.
Simplification: Automatically simplifies fractions to their lowest terms.
Comparison: Compare fractions with other fractions or decimals.
Decimal and Fraction Display: Toggle between fraction and decimal formats for results.
Reverse Fraction: Reverse fractions (e.g., `2/3` becomes `3/2`).
Simple calculator: Each number is like fraction ('2' becomes '2/1'), so you can use this app as default calculator.

## Technologies Used

Qt 6.9: The GUI is built using Qt 6.9, providing a simple and interactive interface for performing calculations.
CMake: The project uses CMake as the build system for easy compilation and setup across platforms.
GTest: Unit tests are provided for core functionalities, ensuring the reliability of fraction operations and handling edge cases.
Standard Libraries: The project utilizes the <iostream>, <cmath>, <numeric>, and <stdexcept> standard libraries.

## Project Structure

FractionCalculator: Contains the core logic for handling fraction operations, simplifications, and comparisons.
QtGUI: Contains the user interface files for interacting with the calculator.
FractionTests: Includes optional unit tests for the core functionality.

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

Enter fractions or integers to perform arithmetic operations.
Toggle between fraction and decimal views for the results.
Perform basic operations like addition, subtraction, multiplication, and division directly in the UI.
