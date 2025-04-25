#include <iostream>
#include <fstream>
#include <string>
#include <boost/interprocess/shared_memory_object.hpp>
#include <boost/interprocess/mapped_region.hpp>
#include "employee.h"

// Function to write employee data to the shared memory
void WriteEmployeeDataToSharedMemory(boost::interprocess::mapped_region& region, const employee& emp) {
    std::memcpy(region.get_address(), &emp, sizeof(employee));
}

int main(int argc, char* argv[]) {
    // Check for the correct command-line arguments
    if (argc != 3) {
        std::cerr << "Usage: " << argv[0] << " file_name countEmployee" << std::endl;
        return 1;
    }

    const char* file_name = argv[1];
    int countEmployee = std::stoi(argv[2]);

    // Create or open shared memory
    boost::interprocess::shared_memory_object shm(boost::interprocess::open_or_create, "shared_memory", boost::interprocess::read_write);
    shm.truncate(sizeof(employee));

    // Map the shared memory region
    boost::interprocess::mapped_region region(shm, boost::interprocess::read_write);

    // Loop to input employee data and write to the shared memory
    for (int i = 0; i < countEmployee; ++i) {
        employee emp;

        // Input employee details
        std::cout << "Enter ID of employee: ";
        std::cin >> emp.num;
        std::cout << "Enter name of employee: ";
        std::cin >> emp.name;
        std::cout << "Enter number of hours of employee: ";
        std::cin >> emp.hours;

        // Write employee data to the shared memory
        WriteEmployeeDataToSharedMemory(region, emp);
    }

    std::cout << "Data written to shared memory successfully." << std::endl;

    return 0;
}
