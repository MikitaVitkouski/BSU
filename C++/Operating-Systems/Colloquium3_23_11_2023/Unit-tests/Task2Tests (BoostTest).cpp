#define BOOST_TEST_MODULE Task2Tests
#include <boost/test/included/unit_test.hpp>
#include "Task2.h"

BOOST_AUTO_TEST_CASE(TestGenerateMatrix) {
    int rows = 3;
    int cols = 4;

    std::vector<std::vector<int>> matrix = generate_matrix(rows, cols);

    BOOST_CHECK_EQUAL(matrix.size(), rows);
    for (const auto& row : matrix) {
        BOOST_CHECK_EQUAL(row.size(), cols);
    }
}

BOOST_AUTO_TEST_CASE(TestPrintMatrix) {
    std::stringstream buffer;
    std::streambuf* oldCout = std::cout.rdbuf(buffer.rdbuf());

    std::vector<std::vector<int>> matrix = { {1, 2, 3}, {4, 5, 6}, {7, 8, 9} };
    print_matrix(matrix);

    std::cout.rdbuf(oldCout);

    std::string output = buffer.str();
    BOOST_CHECK_EQUAL(output, "1 2 3 \n4 5 6 \n7 8 9 \n");
}

BOOST_AUTO_TEST_CASE(TestMatrixMultiplyThread) {
    int thread_id = 0;
    int start_row = 0;
    int end_row = 1;

    std::stringstream buffer;
    std::streambuf* oldCout = std::cout.rdbuf(buffer.rdbuf());

    matrix_multiply_thread(thread_id, start_row, end_row);

    std::cout.rdbuf(oldCout);

    std::string output = buffer.str();
    BOOST_CHECK_EQUAL(output, "Thread 0 finished its work.\n");
}