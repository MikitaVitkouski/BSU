#pragma once

#include <iostream>
#include <vector>
#include <windows.h>

DWORD WINAPI FindMinMaxThread(LPVOID param);
DWORD WINAPI AverageThread(LPVOID param);

template<typename T>
void printVector(std::vector<T>& v);