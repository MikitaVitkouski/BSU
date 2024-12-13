#include <iostream>
#include <fstream>
#include <string>
#include <vector>
#include <limits>

using namespace std;

int Min(int a, int b, int c) {
    int min = a;
    if (b < min) {
        min = b;
    }
    if (c < min) {
        min = c;
    }
    return min;
}

int main()
{
    ifstream in("in.txt");
    ofstream out("out.txt");

    int x = 0, y = 0, z = 0, penalty = 0;

    in >> x >> y >> z;

    string A, B;

    in.ignore(numeric_limits<streamsize>::max(), '\n');

    getline(in, A);
    getline(in, B);

    int n = A.length();
    int m = B.length();

    vector<vector<int>> matrix_of_strings(n + 1, vector<int>(m + 1, 0));

    int i = 0;
    while (i <= n) {
        int j = 0;
        while (j <= m) {
            if (i == 0) {
                matrix_of_strings[i][j] = j * y;
            }
            else if (j == 0) {
                matrix_of_strings[i][j] = i * x;
            }
            else if (A[i - 1] == B[j - 1]) {
                matrix_of_strings[i][j] = matrix_of_strings[i - 1][j - 1];
            }
            else {
                matrix_of_strings[i][j] = Min(matrix_of_strings[i - 1][j] + x, matrix_of_strings[i][j - 1] + y, matrix_of_strings[i - 1][j - 1] + z);
            }
            j++;
        }
        i++;
    }

    penalty = matrix_of_strings[n][m];
    out << penalty;
    return 0;
}