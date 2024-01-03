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

    void start();

    void terminate();

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

    void run();

public:
    bool getTerminationStatus() const {
        return isTerminated;
    }
};