#include <iostream>
#include <string>
#include <fstream>
#include <windows.h>
#include <boost/interprocess/shared_memory_object.hpp>
#include <boost/interprocess/mapped_region.hpp>
#include "employee.h"

const std::string CREATOR = "Creator.exe";
const std::string REPORTER = "Reporter.exe";

// Function to execute an external process
DWORD ExecuteProcess(const std::string& processName, const std::string& arguments, HANDLE& hProcess) {
    std::wstring wideArgs = std::wstring(arguments.begin(), arguments.end());
    LPWSTR lpszMessage = &wideArgs[0];

    STARTUPINFO si;
    PROCESS_INFORMATION pi;
    ZeroMemory(&si, sizeof(STARTUPINFO));
    si.cb = sizeof(STARTUPINFO);

    if (!CreateProcess(NULL, lpszMessage, NULL, NULL, TRUE, CREATE_NEW_CONSOLE, NULL, NULL, &si, &pi)) {
        std::cout << "Something went wrong with " << processName << " process" << std::endl;
        return GetLastError();
    }

    hProcess = pi.hProcess; // Store the process handle

    return 0;
}

int main() {
    std::cout << "//Main process//" << std::endl << std::endl;

    HANDLE hCreator, hReporter;

    // Get the binary file name and the number of notes in the file
    std::string binaryFileName;
    std::cout << "Enter binary file name: ";
    std::cin >> binaryFileName;

    std::string amountOfNotes;
    std::cout << "Enter the number of notes in this file: ";
    std::cin >> amountOfNotes;

    // Construct a message for Creator.exe
    std::string messageToCreator = CREATOR + " " + binaryFileName + " " + amountOfNotes;

    // Launch Creator.exe
    DWORD creatorResult = ExecuteProcess("Creator", messageToCreator, hCreator);

    if (creatorResult != 0) {
        return creatorResult;
    }

    WaitForSingleObject(hCreator, INFINITE); // Wait for Creator process to finish

    // Get the report file name and the salary per hour
    std::string reportFileName;
    std::cout << "Enter report file name: ";
    std::cin >> reportFileName;

    std::string salaryPerHour;
    std::cout << "Enter salary per hour: ";
    std::cin >> salaryPerHour;

    // Construct a message for Reporter.exe
    std::string messageToReporter = REPORTER + " " + binaryFileName + " " + reportFileName + " " + salaryPerHour;

    // Launch Reporter.exe
    DWORD reporterResult = ExecuteProcess("Reporter", messageToReporter, hReporter);

    if (reporterResult != 0) {
        return reporterResult;
    }

    WaitForSingleObject(hReporter, INFINITE); // Wait for Reporter process to finish

    // Read and output the contents of the report file
    std::ifstream reportInput(reportFileName);
    if (reportInput.is_open()) {
        std::string temp;
        while (getline(reportInput, temp)) {
            std::cout << temp << std::endl;
        }
    }
    else {
        std::cout << "Unable to open report file" << std::endl;
    }

    return 0;
}