#include <iostream>
#include <vector>
#include <thread>
#include <windows.h>
#include "Main.h"

// Function for the min_max thread
DWORD WINAPI FindMinMaxThread(LPVOID param) {
    std::vector<int>* arr = static_cast<std::vector<int>*>(param);
    int min = (*arr)[0];
    int max = (*arr)[0];

    for (int i = 1; i < arr->size(); i++) {
        if ((*arr)[i] < min) {
            min = (*arr)[i];
        }
        if ((*arr)[i] > max) {
            max = (*arr)[i];
        }
        Sleep(7);
    }

    return static_cast<DWORD>(min + (max << 16)); // Return min and max as a combined value
}

// Function for the average thread
DWORD WINAPI AverageThread(LPVOID param) {
    std::vector<int>* arr = static_cast<std::vector<int>*>(param);

    int minMax = FindMinMaxThread(arr); // Call FindMinMaxThread to get min and max
    int min = minMax & 0xFFFF; // Extract min from the combined value
    int max = minMax >> 16; // Extract max from the combined value

    int sum = 0;

    for (int i = 0; i < arr->size(); i++) {
        sum += (*arr)[i];
        Sleep(12);
    }

    double average = static_cast<double>(sum) / arr->size();

    // Replace only the minimum and maximum elements with the average of the entire array
    for (int i = 0; i < arr->size(); i++) {
        if ((*arr)[i] == min || (*arr)[i] == max) {
            (*arr)[i] = static_cast<int>(average);
        }
    }

    return 0;
}

//Function for output of elements of the vector
template<typename T>
void printVector(std::vector<T>& v) {
    for (auto i : v) {
        std::cout << i << " ";
    }

    std::cout << std::endl << std::endl;
}

int main() {
    std::vector<int> arr;
    int n;

    // Input the array size and elements
    std::cout << "Enter the array size: ";
    std::cin >> n;
    arr.resize(n);
    std::cout << "Enter the array elements:" << std::endl;
    for (int i = 0; i < n; i++) {
        std::cin >> arr[i];
    }

    // Create the min_max thread
    HANDLE hMinMax = CreateThread(NULL, 0, FindMinMaxThread, &arr, 0, NULL);

    if (hMinMax == NULL) {
        std::cerr << "Error creating threads." << std::endl;
        return 1;
    }

    // Wait for the min_max thread to finish
    WaitForSingleObject(hMinMax, INFINITE);

    // Create the average thread
    HANDLE hAverage = CreateThread(NULL, 0, AverageThread, &arr, 0, NULL);

    if (hAverage == NULL) {
        std::cerr << "Error creating threads." << std::endl;
        return 1;
    }

    // Wait for the average thread to finish

    WaitForSingleObject(hAverage, INFINITE);

    // Output the result
    std::cout << std::endl;
    printVector(arr);
    std::cout << std::endl;

    return 0;
}