#define BOOST_TEST_MODULE MainTests
#include <boost/test/included/unit_test.hpp>
#include <iostream>
#include <sstream>
#include <vector>
#include <thread>
#include <mutex>
#include <condition_variable>
#include <atomic>
#include "Main.h"

BOOST_AUTO_TEST_SUITE(MainTests)

BOOST_AUTO_TEST_CASE(MarkerThreadTest) {
    const int arraySize = 5;
    const int numMarkerThreads = 2;

    std::vector<int> array(arraySize, 0);
    std::mutex arrayMutex;
    std::condition_variable cv;
    std::atomic<bool> startSignal(false);
    std::atomic<bool> continueSignal(true);

    std::vector<MarkerThread> markerThreads;

    for (int i = 0; i < numMarkerThreads; ++i) {
        markerThreads.emplace_back(i + 1, array, arraySize, arrayMutex, cv, startSignal, continueSignal);
    }

    for (auto& markerThread : markerThreads) {
        markerThread.start();
    }

    startSignal.store(true);

    std::this_thread::sleep_for(std::chrono::milliseconds(1000));

    std::istringstream input("1\n");
    std::cin.rdbuf(input.rdbuf());

    for (auto& markerThread : markerThreads) {
        markerThread.terminate();
    }

    for (const auto& markerThread : markerThreads) {
        BOOST_CHECK(markerThread.getTerminationStatus());
    }
}

BOOST_AUTO_TEST_SUITE_END()