#include <cassert>
#include <vector>
#include <cmath>
#include "Main.h"

void testFindMinMaxThread() {
	std::vector<int> testVector = { 5,2,8,3,1 };
	DWORD result = FindMinMaxThread(&testVector);

	int min = static_cast<int>(result & 0xFFFF);
	int max = static_cast<int>(result >> 16);

	assert(min == 1);
	assert(min == 8);
}

void testAverageThread() {
    std::vector<int> testVector = { 5, 2, 8, 3, 1 };
    std::vector<int> testVectorCopy = testVector;

    AverageThread(&testVectorCopy);

    double sum = 0.0;
    for (int i : testVectorCopy) {
        sum += i;
    }

    double average = static_cast<double>(sum) / testVectorCopy.size();
    double tolerance = 1e-9;

    assert(std::abs(testVectorCopy[0] - average) < tolerance);

    assert(testVectorCopy[0] == static_cast<int>(average + 0.5));
}