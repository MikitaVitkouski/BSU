#define BOOST_TEST_MODULE MainTests
#include <boost/test/included/unit_test.hpp>
#include <vector>
#include <iostream>
#include <thread>

DWORD WINAPI FindMinMaxThread(LPVOID param);

DWORD WINAPI AverageThread(LPVOID param);

template<typename T>
void printVector(std::vector<T>& v);

BOOST_AUTO_TEST_SUITE(MainTests)

BOOST_AUTO_TEST_CASE(FindMinMaxThreadTest) {
    std::vector<int> arr = { 5, 2, 8, 1, 9, 3 };

    HANDLE hThread = CreateThread(NULL, 0, FindMinMaxThread, &arr, 0, NULL);
    WaitForSingleObject(hThread, INFINITE);

    DWORD result;
    int success = GetExitCodeThread(hThread, &result);

    int exitCode = (success != 0) ? result : -1;
    int min = result & 0xFFFF;
    int max = result >> 16;

    BOOST_CHECK_EQUAL(min, 1);
    BOOST_CHECK_EQUAL(max, 9);

    CloseHandle(hThread);
}

BOOST_AUTO_TEST_CASE(AverageThreadTest) {
    std::vector<int> arr = { 1,2,3,4,5 };

    HANDLE hThread = CreateThread(NULL, 0, AverageThread, &arr, 0, NULL);
    if (hThread == NULL) {
        // error
    }

    WaitForSingleObject(hThread, INFINITE);

    BOOST_CHECK_EQUAL_COLLECTIONS(arr.begin(), arr.end(), std::vector<int>({ 3,2,3,4,3 }).begin(), std::vector<int>({ 3,2,3,4,3 }).end());

    CloseHandle(hThread);
}

BOOST_AUTO_TEST_SUITE_END()