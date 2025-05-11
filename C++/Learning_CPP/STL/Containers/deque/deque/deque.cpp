#include <iostream>
#include <deque>
#include <fstream>
#include <algorithm>
#include <numeric>

template<typename T>
void print(const std::deque<T>& q, std::ofstream& output) {
	for (const auto& element : q) {
		output << element << " ";
	}
	output << "\n\n";
}

int main() {
	std::ifstream in("input.txt");
	std::ofstream out("output.txt");

	if (!in.is_open()) {
		std::cerr << "Can't open input.txt";
		return 1;
	}

	std::deque<int> q {};
	int value;
	while (in >> value) {
		q.emplace_back(value);
	}
	in.close();

	out << "Read from input.txt: "; print(q, out);

	std::sort(begin(q), end(q));
	out << "Sorted deque: "; print(q, out);

	q.emplace_back(3);
	q.emplace_back(4);

	out << "Emplaced to back values '3' and '4': "; print(q, out);

	q.erase(std::remove_if(q.begin(), q.end(), [](int i) {
		return i % 2 == 0;
		}), q.end());

	out << "Erased odd values from deque: "; print(q, out);

	auto it = std::find(q.cbegin(), q.cend(), 1);

	out << "The position of value '1': ";  out << std::distance(q.cbegin(), it) << std::endl;

	std::for_each(begin(q), end(q), [](int& val) {val *= 15;  });

	out << "After multiplying each value by 15: "; print(q, out);

	auto sum = std::accumulate(q.begin(),q.end(), 0);
	out << "sum of deque: " << sum << "\n";

	q.resize(10, 228);

	out << "deque after q.resize(10, 228): "; print(q, out);

	out << "the first value of deque: " << q.front() << "\nthe second value of deque: " << q.back() << "\n\n";

	// C++23:
	std::deque<int> q2 {1, 2, 3};
	q.prepend_range(q2);

	out << "after q.prepend_range(q2): "; print(q, out);

	q.append_range(q2);

	out << "after q.append_range(q2): "; print(q, out);

	auto it1 = std::next(q.begin(), 7);
	q.insert_range(it1, q2);

	out << "after q.insert_range(it1, q2): "; print(q, out);

	return 0;
}