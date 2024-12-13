#include <iostream>
#include <fstream>
#include <vector>
#include <algorithm>

using namespace std;

int main(){
	ifstream in("input.txt");
	ofstream out("output.txt");

	int vertex_count = 0; int edge_count = 0;

	in >> vertex_count;

	int** adjacency_matrix = new int* [vertex_count];
	for (int i = 0; i < vertex_count; ++i) {
		adjacency_matrix[i] = new int[vertex_count];
	}

	for (int i = 0; i < vertex_count; ++i) {
		for (int j = 0; j < vertex_count; ++j) {
			adjacency_matrix[i][j] = 0;
		}
	}

	in >> edge_count;

	vector<pair<int, int>> edges;

	int v1 = 0; int v2 = 0;

	for (int i = 0; i < edge_count; i++) {
		in >> v1;
		in >> v2;
		edges.push_back(make_pair(v1, v2));

		adjacency_matrix[v1 - 1][v2 - 1] = 1;
		adjacency_matrix[v2 - 1][v1 - 1] = 1;
	}

	for (int i = 0; i < vertex_count; ++i) {
		for (int j = 0; j < vertex_count; ++j) {
			out << adjacency_matrix[i][j] << " ";
		}
		out << endl;
	}

	delete[] adjacency_matrix;

	return 0;
}