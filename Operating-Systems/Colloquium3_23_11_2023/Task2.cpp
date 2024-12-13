#include "Task2.h"

std::mutex mtx;
std::vector<std::vector<int>> matrix_A, matrix_B, matrix_C;
std::vector<std::string> result_messages;
int m, n, k;

std::vector<std::vector<int>> generate_matrix(int rows, int cols) {
    std::vector<std::vector<int>> matrix;

    std::random_device rd;

    std::default_random_engine generator(rd());
    std::uniform_int_distribution<int> distribution(0, 9);

    for (int i = 0; i < rows; ++i) {
        std::vector<int> row;
        for (int j = 0; j < cols; ++j) {
            row.push_back(distribution(generator));
        }
        matrix.push_back(row);
    }
    return matrix;
}

void print_matrix(const std::vector<std::vector<int>>& matrix) {
    for (const auto& row : matrix) {
        for (int element : row) {
            std::cout << element << " ";
        }
        std::cout << std::endl;
    }
}

void matrix_multiply_thread(int thread_id, int start_row, int end_row) {
    for (int row = start_row; row < end_row; ++row) {
        for (int col = 0; col < k; ++col) {
            int result = 0;
            for (int i = 0; i < n; ++i) {
                result += matrix_A[row][i] * matrix_B[i][col];
            }

            {
                std::lock_guard<std::mutex> lock(mtx);
                matrix_C[row][col] = result;
            }

            std::this_thread::sleep_for(std::chrono::milliseconds(500));
        }
    }

    std::stringstream ss;
    ss << "Thread " << thread_id << " finished its work.";
    result_messages[thread_id] = ss.str();
}

int main() {
    std::cout << "Enter the number of rows for matrix A: ";
    std::cin >> m;
    std::cout << "Enter the number of columns for matrix A (and rows for matrix B): ";
    std::cin >> n;
    std::cout << "Enter the number of columns for matrix B: ";
    std::cin >> k;

    matrix_A = generate_matrix(m, n);
    matrix_B = generate_matrix(n, k);

    matrix_C.resize(m, std::vector<int>(k, 0));

    std::cout << "Enter the number of threads: ";
    int num_threads;
    std::cin >> num_threads;

    std::cout << "Enter the path to the output directory: ";
    std::string output_directory;
    std::cin >> output_directory;

    std::string output_path_C = output_directory + "/out.dat";

    std::vector<std::thread> threads;
    result_messages.resize(num_threads);

    for (int i = 0; i < num_threads; ++i) {
        int start_row = i * (m / num_threads);
        int end_row = (i == num_threads - 1) ? m : (i + 1) * (m / num_threads);
        threads.emplace_back(matrix_multiply_thread, i, start_row, end_row);
    }

    for (auto& thread : threads) {
        thread.join();
    }

    std::cout << "Matrix A:" << std::endl;
    print_matrix(matrix_A);

    std::cout << "\nMatrix B:" << std::endl;
    print_matrix(matrix_B);

    std::cout << "\nMatrix C (Result of A * B):" << std::endl;
    print_matrix(matrix_C);

    std::ofstream outfile(output_path_C);
    if (outfile.is_open()) {
        for (const auto& row : matrix_C) {
            for (int element : row) {
                outfile << element << " ";
            }
            outfile << std::endl;
        }
        outfile.close();
    }
    else {
        std::cerr << "Unable to open the file for writing." << std::endl;
    }

    for (const auto& message : result_messages) {
        std::cout << message << std::endl;
    }

    return 0;
}