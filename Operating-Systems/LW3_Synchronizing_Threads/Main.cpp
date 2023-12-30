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
    MarkerThread(int markerNumber, std::vector<int>& array, int arraySize, std::mutex& arrayMutex, std::condition_variable& cv, std::atomic<bool>& startSignal)
        : markerNumber(markerNumber), array(array), arraySize(arraySize), arrayMutex(arrayMutex), cv(cv), startSignal(startSignal), isTerminated(false) {}

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
    bool isTerminated;

    void run() {
        std::cout << "Marker " << markerNumber << ": Thread started" << std::endl;

        srand(static_cast<unsigned int>(markerNumber));

        startSignal.store(true);

        while (true) {
            int randomNumber = rand();
            int index = -1;

            {
                std::unique_lock<std::mutex> lock(arrayMutex);

                for (int i = 0; i < arraySize; ++i) {
                    if (array[i] == 0) {
                        index = i;
                        break;
                    }
                }

                if (index != -1 && !isTerminated) {
                    std::this_thread::sleep_for(std::chrono::milliseconds(5));
                    array[index] = markerNumber;
                    std::this_thread::sleep_for(std::chrono::milliseconds(5));

                    std::cout << "Array state: ";
                    for (int i = 0; i < arraySize; ++i) {
                        std::cout << array[i] << " ";
                    }
                    std::cout << std::endl;
                }
                else {
                    std::cout << "Marker " << markerNumber << ": Unable to find a zero to mark" << std::endl;
                    isTerminated = true;
                    break;
                }
            }

            cv.notify_all();
            std::unique_lock<std::mutex> lock(arrayMutex);
            cv.wait(lock, [&] { return isTerminated || array[index] == 0; });
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

    std::cout << "Enter number of marker threads: ";
    std::cin >> numMarkerThreads;

    std::vector<MarkerThread> markerThreads;

    for (int i = 0; i < numMarkerThreads; ++i) {
        markerThreads.emplace_back(i + 1, array, arraySize, arrayMutex, cv, startSignal);
    }

    for (auto& markerThread : markerThreads) {
        markerThread.start();
    }

    while (!startSignal.load()) {
        std::this_thread::yield();
    }

    while (true) {
        std::this_thread::sleep_for(std::chrono::milliseconds(500));

        std::cout << "Array state: ";
        for (int i = 0; i < arraySize; ++i) {
            std::cout << array[i] << " ";
        }
        std::cout << std::endl;

        std::cout << "Active threads: ";
        for (size_t i = 0; i < markerThreads.size(); ++i) {
            if (!markerThreads[i].getTerminationStatus()) {
                std::cout << "Marker " << i + 1 << " ";
            }
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

        if (threadToTerminate >= 0 && threadToTerminate <= markerThreads.size()) {
            markerThreads[threadToTerminate - 1].terminate();
        }

        
        bool allThreadsTerminated = std::all_of(markerThreads.begin(), markerThreads.end(),
            [](const MarkerThread& markerThread) { return markerThread.getTerminationStatus(); });

        if (allThreadsTerminated) {
            break;
        }
    }

    return 0;
}