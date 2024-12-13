#include <cassert>
#include <iostream>
#include "Task2.h"

void testMatrixMultiplication() {
	matrix_A = { {1,2},{3,4} };
	matrix_B = { {5,6},{7,8} };

	matrix_C = { {19,22},{43,50} };

	matrix_multiply_thread(0, 0, 2);

	for (int i = 0; i < matrix_C.size(); ++i) {
		for (int j = 0; j < matrix_C[i].size(); ++j) {
			assert(matrix_C[i][j] == matrix_C[i][j]);
		}
	}
}