#pragma once

#include <iostream>
#include <vector>
#include <thread>
#include <mutex>
#include <fstream>
#include <sstream>
#include <chrono>
#include <random>

extern std::mutex mtx;
extern std::vector<std::vector<int>> matrix_A, matrix_B, matrix_C;
extern std::vector<std::string> result_messages;
extern int m, n, k;

std::vector<std::vector<int>> generate_matrix(int rows, int cols);
void print_matrix(const std::vector<std::vector<int>>& matrix);
void matrix_multiply_thread(int thread_id, int start_row, int end_row);