#include <iostream>
#include <vector>
#include <algorithm>
#include <numeric>
#include <memory>
#include <string>

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

	void display() const {
		cout << name << " - average grade: " << average() << endl;
	}

	const string& getName() const { return name;  }
};

int main() {
	vector<unique_ptr<Student>> students;
	students.push_back(make_unique<Student>("Nikita", vector<int>{90, 85, 92}));
	students.push_back(make_unique <Student>("Julia", vector<int>{70, 60, 75}));
	students.push_back(make_unique<Student>("Timofey", vector<int>{88, 90, 85}));

	cout << "\nStudent and their average grades:\n";
	for (const auto& student : students) {
		student->display();
	}

	sort(students.begin(), students.end(), [](const auto& a, const auto& b) {
		return a->average() > b->average();
		});

	cout << "\nSorted by average grades:\n";
	for (const auto& student : students) {
		student->display();
	}

	return 0;
}