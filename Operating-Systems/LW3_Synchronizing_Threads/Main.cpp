#include <iostream>
#include <thread>
#include <vector>
#include <random>
#include <mutex>
#include <condition_variable>

std::mutex mtx;
std::condition_variable cv;
bool canContinue = false;

const int MAX_ARRAY_SIZE = 100;

int* array;
int arraySize;

void markerThread(int markerNumber) {
    std::unique_lock<std::mutex> lock(mtx);
    cv.wait(lock, [&] { return canContinue; });

    std::random_device rd;
    std::mt19937 gen(rd() + markerNumber);
    std::uniform_int_distribution<> dis(0, arraySize - 1);

    int markedCount = 0;

    while (true) {
        int index = dis(gen);

        if (array[index] == 0) {
            std::this_thread::sleep_for(std::chrono::milliseconds(5));
            array[index] = markerNumber;
            std::this_thread::sleep_for(std::chrono::milliseconds(5));
            markedCount++;
        }
        else {
            std::cout << "Marker " << markerNumber << ": Marked count = " << markedCount
                << ", Unable to mark index " << index << std::endl;

            canContinue = false;
            cv.notify_all();

            cv.wait(lock, [&] { return canContinue; });
        }
    }
}

void printArray() {
    std::cout << "Array: ";
    for (int i = 0; i < arraySize; ++i) {
        std::cout << array[i] << " ";
    }
    std::cout << std::endl;
}

int main() {
    std::cout << "Enter array size: ";
    std::cin >> arraySize;

    array = new int[arraySize]();

    int markerCount;
    std::cout << "Enter number of marker threads: ";
    std::cin >> markerCount;

    std::vector<std::thread> markerThreads;

    for (int i = 1; i <= markerCount; ++i) {
        markerThreads.emplace_back(markerThread, i);
    }

    std::this_thread::sleep_for(std::chrono::seconds(1));

    {
        std::lock_guard<std::mutex> lock(mtx);
        canContinue = true;
    }
    cv.notify_all();

    while (true) {
        printArray();

        std::string input;
        std::cout << "Enter 'q' to quit: ";
        std::cin >> input;

        if (input == "q") {
            {
                std::lock_guard<std::mutex> lock(mtx);
                canContinue = false;
            }
            cv.notify_all();

            break;
        }

        std::this_thread::sleep_for(std::chrono::milliseconds(500));

        {
            std::lock_guard<std::mutex> lock(mtx);
            canContinue = true;
        }
        cv.notify_all();
    }

    for (auto& t : markerThreads) {
        t.join();
    }

    delete[] array;

    return 0;
}