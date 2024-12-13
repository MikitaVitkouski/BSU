#include <iostream>
#include <fstream>
#include <string>
#include <boost/interprocess/shared_memory_object.hpp>
#include <boost/interprocess/mapped_region.hpp>
#include "employee.h"

// Function to read employee data from the shared memory
void ReadEmployeeDataFromSharedMemory(boost::interprocess::mapped_region& region, employee& emp) {
    std::memcpy(&emp, region.get_address(), sizeof(employee));
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

    // Create or open shared memory
    boost::interprocess::shared_memory_object shm(boost::interprocess::open_or_create, "shared_memory", boost::interprocess::read_write);
    shm.truncate(sizeof(employee));

    // Map the shared memory region
    boost::interprocess::mapped_region region(shm, boost::interprocess::read_write);

    std::ofstream reportFileStream(reportFileName);
    if (!reportFileStream.is_open()) {
        std::cerr << "The report file could not be opened for writing." << std::endl;
        return 1;
    }

    employee emp;
    double totalSalary = 0.0;

    // Read and display employee data and calculate total salary
    for (int i = 0; i < 1; ++i) { // Assuming only one employee for simplicity
        ReadEmployeeDataFromSharedMemory(region, emp);

        totalSalary += emp.hours * salaryPerHour;

        // Display employee details
        reportFileStream << "Employee ID: " << emp.num << ", Name: " << emp.name << ", Total Salary: " << (emp.hours * salaryPerHour) << std::endl;
    }

    reportFileStream << "Total Salary for all employees: " << totalSalary << std::endl;

    // Close file streams
    reportFileStream.close();

    std::cout << "Report generated successfully." << std::endl;

    return 0;
}