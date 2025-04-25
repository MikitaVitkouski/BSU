#include <iostream>
#include <fstream>
#include <string>
#include "employee.h"

// Function to read employee data from the provided stream
void ReadEmployeeData(std::istream& stream, employee& emp) {
    stream.read(reinterpret_cast<char*>(&emp), sizeof(employee));
}

int main(int argc, char* argv[]) {
    // Check for correct command-line arguments
    if (argc != 4) {
        std::cerr << "Usage: " << argv[0] << " binary_file_name report_file_name salaryPerHour" << std::endl;
        return 1;
    }

    const char* binaryFileName = argv[1];
    const char* reportFileName = argv[2];
    double salaryPerHour = std::stod(argv[3]);

    std::ifstream binaryFileStream(binaryFileName, std::ios::in | std::ios::binary);
    if (!binaryFileStream.is_open()) {
        std::cerr << "The binary file could not be opened for reading." << std::endl;
        return 1;
    }

    int countEmployee;
    binaryFileStream.read(reinterpret_cast<char*>(&countEmployee), sizeof(int));

    std::ofstream reportFileStream(reportFileName);
    if (!reportFileStream.is_open()) {
        std::cerr << "The report file could not be opened for writing." << std::endl;
        return 1;
    }

    employee emp;
    double totalSalary = 0.0;

    // Read and display employee data and calculate total salary
    for (int i = 0; i < countEmployee; ++i) {
        ReadEmployeeData(binaryFileStream, emp);

        totalSalary += emp.hours * salaryPerHour;

        // Display employee details
        reportFileStream << "Employee ID: " << emp.num << ", Name: " << emp.name << ", Total Salary: " << (emp.hours * salaryPerHour) << std::endl;
    }

    reportFileStream << "Total Salary for all employees: " << totalSalary << std::endl;

    // Close file streams
    binaryFileStream.close();
    reportFileStream.close();

    std::cout << "Report generated successfully." << std::endl;

    return 0;
}
