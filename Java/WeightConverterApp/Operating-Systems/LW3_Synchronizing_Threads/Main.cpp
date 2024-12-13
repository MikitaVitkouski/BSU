#include <iostream>
#include <vector>
#include <thread>
#include <atomic>
#include <cstdlib>
#include <ctime>
#include <mutex>
#include <condition_variable>
#include <chrono>
#include <stdexcept>
#include "Main.h"

int main() {
    int arraySize, numMarkerThreads;

    std::cout << "Enter array size: ";
    std::cin >> arraySize;

    std::vector<int> array(arraySize, 0);
    std::mutex arrayMutex;
    std::condition_variable cv;
    std::atomic<bool> startSignal(false);
    std::atomic<bool> continueSignal(true);

    std::cout << "Enter number of marker threads: ";
    std::cin >> numMarkerThreads;

    std::vector<MarkerThread> markerThreads;

    for (int i = 0; i < numMarkerThreads; ++i) {
        markerThreads.emplace_back(i + 1, array, arraySize, arrayMutex, cv, startSignal, continueSignal);
    }

    for (auto& markerThread : markerThreads) {
        markerThread.start();
    }

    startSignal.store(true);

    while (true) {
        std::this_thread::sleep_for(std::chrono::milliseconds(500));

        std::cout << "Array state: ";
        for (int i = 0; i < arraySize; ++i) {
            std::cout << array[i] << " ";
        }
        std::cout << std::endl;

        int threadToTerminate;
        while (true) {
            std::cout << "Enter marker thread number to terminate (1 to " << numMarkerThreads << "): ";
            std::cin >> threadToTerminate;
            if (threadToTerminate >= 1 && threadToTerminate <= numMarkerThreads && !markerThreads[threadToTerminate - 1].getTerminationStatus()) {
                break;
            }
            else {
                std::cout << "Invalid thread number or thread already terminated. Please try again." << std::endl;
            }
        }

        std::unique_lock<std::mutex> lock(arrayMutex);
        continueSignal.store(true);
        startSignal.store(true);
        lock.unlock();
        cv.notify_all();
        markerThreads[threadToTerminate - 1].terminate();

        bool allThreadsTerminated = std::all_of(markerThreads.begin(), markerThreads.end(),
            [](const MarkerThread& markerThread) { return markerThread.getTerminationStatus(); });

        if (allThreadsTerminated) {
            break;
        }
    }

    return 0;
}