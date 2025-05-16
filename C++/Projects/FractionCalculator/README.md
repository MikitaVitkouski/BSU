![image](https://github.com/user-attachments/assets/bd6c4852-02da-4e58-bd57-e22d8ac4c279)
![image](https://github.com/user-attachments/assets/37f02296-a420-4e14-97e7-37993f407fe9)
![image](https://github.com/user-attachments/assets/98ec076d-a99e-4564-ba18-d6bf9b000179)

A simple C++ application for performing arithmetic operations on fractions with a graphical user interface built using Qt.

Features
Fraction Operations: Addition, subtraction, multiplication, division, and exponentiation of fractions.
Simplification: Automatically simplifies fractions to their lowest terms.
Comparison: Compare fractions with other fractions or decimals.
Decimal and Fraction Display: Toggle between fraction and decimal formats for results.
Reverse Fraction: Reverse fractions (e.g., `2/3` becomes `3/2`).

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
