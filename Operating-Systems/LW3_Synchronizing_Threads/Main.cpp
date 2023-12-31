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

class MarkerThread {
public:
    MarkerThread(int markerNumber, std::vector<int>& array, int arraySize, std::mutex& arrayMutex, std::condition_variable& cv, std::atomic<bool>& startSignal, std::atomic<bool>& continueSignal)
        : markerNumber(markerNumber), array(array), arraySize(arraySize), arrayMutex(arrayMutex), cv(cv), startSignal(startSignal), continueSignal(continueSignal), isTerminated(false) {}

    void start() {
        thread = std::thread(&MarkerThread::run, this);
    }

    void terminate() {
        {
            std::unique_lock<std::mutex> lock(arrayMutex);
            isTerminated = true;
        }
        cv.notify_all();
        thread.join();
        std::cout << "Marker " << markerNumber << ": Thread terminated" << std::endl;
    }

private:
    int markerNumber;
    std::vector<int>& array;
    int arraySize;
    std::thread thread;
    std::mutex& arrayMutex;
    std::condition_variable& cv;
    std::atomic<bool>& startSignal;
    std::atomic<bool>& continueSignal;
    bool isTerminated;

    void run() {
        std::cout << "Marker " << markerNumber << ": Thread started" << std::endl;

        srand(static_cast<unsigned int>(markerNumber));

        {
            std::unique_lock<std::mutex> lock(arrayMutex);
            cv.wait(lock, [&] { return startSignal.load(); });
        }

        while (true) {
            int randomNumber = rand();
            int index = randomNumber % arraySize;

            {
                std::unique_lock<std::mutex> lock(arrayMutex);

                if (array[index] == 0) {
                    std::this_thread::sleep_for(std::chrono::milliseconds(5));
                    array[index] = markerNumber;
                    std::this_thread::sleep_for(std::chrono::milliseconds(5));

                    std::cout << "Marker " << markerNumber << ": Marked element at index " << index << std::endl;
                }
                else {
                    std::cout << "Marker " << markerNumber << ": Element at index " << index << " is already marked" << std::endl;
                    std::cout << "Marker " << markerNumber << ": Signaling main thread about inability to continue" << std::endl;
                    continueSignal.store(false);
                    cv.notify_one();
                    cv.wait(lock, [&] { return startSignal.load() || isTerminated; });

                    if (isTerminated) {
                        break;
                    }
                }
            }

            std::unique_lock<std::mutex> lock(arrayMutex);
            cv.wait(lock, [&] { return continueSignal.load() || isTerminated; });

            if (isTerminated) {
                break;
            }
        }

        std::cout << "Marker " << markerNumber << ": Thread ended" << std::endl;
    }

public:
    bool getTerminationStatus() const {
        return isTerminated;
    }
};

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