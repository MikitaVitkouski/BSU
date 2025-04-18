#include <iostream>
#include <vector>
#include <algorithm>
#include <numeric>

using namespace std;

class Student {
	string name;
	vector<int> grades;

public:
	Student(string name, vector<int> grades)
		: name(move(name)), grades(move(grades)) { }

	double average() const {
		return accumulate(grades.begin(), grades.end(), 0.0) / grades.size();
	}
};

int main() {



	return 0;
}