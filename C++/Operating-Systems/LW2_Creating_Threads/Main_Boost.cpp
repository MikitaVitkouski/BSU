#include <iostream>
#include <vector>
#include <boost/thread.hpp>
#include <boost/filesystem.hpp>

// Function for the min_max thread
void FindMinMaxThread(std::vector<int>& arr, int& min, int& max) {
    min = arr[0];
    max = arr[0];

    for (size_t i = 1; i < arr.size(); i++) {
        if (arr[i] < min) {
            min = arr[i];
        }
        if (arr[i] > max) {
            max = arr[i];
        }
        boost::this_thread::sleep(boost::posix_time::milliseconds(7));
    }
}

// Function for the average thread
void AverageThread(std::vector<int>& arr, int min, int max) {
    int sum = 0;

    for (size_t i = 0; i < arr.size(); i++) {
        sum += arr[i];
        boost::this_thread::sleep(boost::posix_time::milliseconds(12));
    }

    double average = static_cast<double>(sum) / arr.size();

    // Replace only the minimum and maximum elements with the average of the entire array
    for (size_t i = 0; i < arr.size(); i++) {
        if (arr[i] == min || arr[i] == max) {
            arr[i] = static_cast<int>(average);
        }
    }
}

// Function for output of elements of the vector
template<typename T>
void printVector(const std::vector<T>& v) {
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

    int min, max;

    // Create the min_max thread
    boost::thread minMaxThread(FindMinMaxThread, boost::ref(arr), boost::ref(min), boost::ref(max));
    minMaxThread.join();

    // Create the average thread
    boost::thread averageThread(AverageThread, boost::ref(arr), min, max);
    averageThread.join();

    // Output the result
    std::cout << std::endl;
    printVector(arr);
    std::cout << std::endl;

    return 0;
}