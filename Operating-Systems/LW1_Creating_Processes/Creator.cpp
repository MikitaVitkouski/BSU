#include <iostream>
#include <fstream>
#include <string>
#include "employee.h"

// Function to write employee data to the provided stream
void WriteEmployeeData(std::ostream& stream, const employee& emp) {
    stream.write(reinterpret_cast<const char*>(&emp), sizeof(employee));
}

int main(int argc, char* argv[]) {
    // Check for the correct command-line arguments
    if (argc != 3) {
        std::cerr << "Usage: " << argv[0] << " file_name countEmployee" << std::endl;
        return 1;
    }

    const char* file_name = argv[1];
    int countEmployee = std::stoi(argv[2]);

    // Open the output file stream
    std::ofstream outputFileStream(file_name, std::ios::out | std::ios::binary);
    if (!outputFileStream.is_open()) {
        std::cerr << "The file could not be opened for writing." << std::endl;
        return 1;
    }

    // Write the number of employees to the file
    outputFileStream.write(reinterpret_cast<char*>(&countEmployee), sizeof(int));

    // Loop to input employee data and write to the file
    for (int i = 0; i < countEmployee; ++i) {
        employee emp;

        // Input employee details
        std::cout << "Enter ID of employee: ";
        std::cin >> emp.num;
        std::cout << "Enter name of employee: ";
        std::cin >> emp.name;
        std::cout << "Enter number of hours of employee: ";
        std::cin >> emp.hours;

        // Write employee data to the file
        WriteEmployeeData(outputFileStream, emp);
    }

    // Close the output file stream
    outputFileStream.close();
    std::cout << "The file was created successfully." << std::endl;

    return 0;
}
