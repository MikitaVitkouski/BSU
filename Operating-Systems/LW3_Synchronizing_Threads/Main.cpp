#include <iostream>
#include <vector>
#include <thread>
#include <atomic>
#include <cstdlib>
#include <ctime>
#include <mutex>
#include <condition_variable>
#include <algorithm>

class MarkerThread {
public:
    MarkerThread(int markerNumber, std::atomic<int>* array, int arraySize, std::mutex& arrayMutex, std::condition_variable& cv)
        : markerNumber(markerNumber), array(array), arraySize(arraySize), arrayMutex(arrayMutex), cv(cv), isTerminated(false) {}

    void start() {
        thread = std::thread(&MarkerThread::run, this);
    }

    void terminate() {
        {
            std::unique_lock<std::mutex> lock(arrayMutex);
            isTerminated = true;
        }
        cv.notify_all(); // Signal other threads to continue working
        thread.join();
    }

private:
    int markerNumber;
    std::atomic<int>* array;
    int arraySize;
    std::thread thread;
    std::mutex& arrayMutex;
    std::condition_variable& cv;
    bool isTerminated;

    void run() {
        srand(static_cast<unsigned int>(markerNumber));

        while (true) {
            int randomNumber = rand();
            int index = randomNumber % arraySize;

            {
                std::unique_lock<std::mutex> lock(arrayMutex);

                if (!isTerminated && array[index].load() == 0) {
                    std::this_thread::sleep_for(std::chrono::milliseconds(5));
                    array[index].store(markerNumber);
                    std::this_thread::sleep_for(std::chrono::milliseconds(5));

                    // Print array state after marking
                    std::cout << "Array state: ";
                    for (int i = 0; i < arraySize; ++i) {
                        std::cout << array[i].load() << " ";
                    }
                    std::cout << std::endl;
                }
                else {
                    std::cout << "Marker " << markerNumber << ": Marked count = " << array[index].load()
                        << ", Unable to mark index " << index << std::endl;
                    isTerminated = true;
                    break;
                }
            }

            cv.notify_all();
            std::unique_lock<std::mutex> lock(arrayMutex);
            cv.wait(lock, [&] { return isTerminated || array[index].load() == 0; });
        }
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

    std::atomic<int>* array = new std::atomic<int>[arraySize](); // Initialize array with zeros
    std::mutex arrayMutex;
    std::condition_variable cv;

    std::cout << "Enter number of marker threads: ";
    std::cin >> numMarkerThreads;

    std::vector<MarkerThread> markerThreads;
    markerThreads.reserve(numMarkerThreads);

    for (int i = 0; i < numMarkerThreads; ++i) {
        markerThreads.emplace_back(i + 1, array, arraySize, arrayMutex, cv);
    }

    // Start threads
    for (auto& markerThread : markerThreads) {
        markerThread.start();
    }

    // Main loop
    while (true) {
        std::this_thread::sleep_for(std::chrono::milliseconds(100));

        // Print array state
        std::cout << "Array state: ";
        for (int i = 0; i < arraySize; ++i) {
            std::cout << array[i].load() << " ";
        }
        std::cout << std::endl;

        int threadToTerminate;
        while (true) {
            std::cout << "Enter marker thread number to terminate (1 to " << numMarkerThreads << "): ";
            std::cin >> threadToTerminate;
            if (threadToTerminate >= 1 && threadToTerminate <= numMarkerThreads) {
                break;
            }
            else {
                std::cout << "Invalid thread number. Please try again." << std::endl;
            }
        }

        if (threadToTerminate >= 0 && threadToTerminate <= markerThreads.size()) {
            markerThreads[threadToTerminate - 1].terminate(); // Signal thread termination
        }

        // Print array state
        std::cout << "Array state: ";
        for (int i = 0; i < arraySize; ++i) {
            std::cout << array[i].load() << " ";
        }
        std::cout << std::endl;

        bool allThreadsTerminated = std::all_of(markerThreads.begin(), markerThreads.end(),
            [](const MarkerThread& markerThread) { return markerThread.getTerminationStatus(); });

        if (allThreadsTerminated) {
            break; // Exit the main loop if all threads are terminated
        }
    }

    delete[] array;

    return 0;
}