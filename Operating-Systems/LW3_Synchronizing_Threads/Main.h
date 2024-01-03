#pragma once

#include <iostream>
#include <vector>
#include <thread>
#include <atomic>
#include <mutex>
#include <condition_variable>
#include <chrono>

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