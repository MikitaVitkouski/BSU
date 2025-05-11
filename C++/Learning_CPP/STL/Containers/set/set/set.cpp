#include <iostream>
#include <set>
#include <algorithm>
#include <fstream>
#include <iterator>

template<typename T>
void print(const std::set<T>& s, std::ofstream& output) {
	std::copy(s.begin(), s.end(), std::ostream_iterator<T>(output, " "));
	output << "\n\n";
}

int main() {
	std::ifstream in{"input.txt"};
	std::ofstream out{"output.txt"};

	if (!in.is_open()) {
		std::cerr << "Can not open input.txt!";
		return 1;
	}

	std::set<int> s {};
	int value{ 0 };

	while (in >> value) {
		s.insert(value);
	}

	print(s, out);

	s.erase(-8);

	print(s, out);

	auto it = s.find(10);
	if (it != s.end()) {
		out << "Found 10 in set\n";
	}
	else {
		out << "10 not found\n";
	}

	int query{ 5 };
	auto range = s.equal_range(query); //equal_range returns pair of iterators: [lower_bound, upperbound)
	out << "equal_range(" << query << ") = [";
	if (range.first != s.end()) out << *range.first;
	else out << "end";
	out << ", ";
	if (range.second != s.end()) out << *range.second;
	else out << "end";
	out << ")\n\n";

	std::set<int> s2 { 3, 5, 7, 10, 20 };

	out << "s2: "; print(s2, out);

	std::set<int> intersection;
	std::set_intersection(
		s.begin(), s.end(),
		s2.begin(), s2.end(),
		std::inserter(intersection, intersection.begin())
	);
	out << "Intersection of s and s2: "; print(intersection, out);

	std::set<int> union_set;
	std::set_union(
		s.begin(), s.end(),
		s2.begin(), s2.end(),
		std::inserter(union_set, union_set.begin())
	);
	out << "Union of s and s2: "; print(union_set, out);

	std::set<int> diff;
	std::set_difference(
		s.begin(), s.end(),
		s2.begin(), s2.end(),
		std::inserter(diff, diff.begin())
	);
	out << "Difference s - s2: "; print(diff, out);

	std::set<int> sym_diff;
	std::set_symmetric_difference(
		s.begin(), s.end(),
		s2.begin(), s2.end(),
		std::inserter(sym_diff, sym_diff.begin())
	);
	out << "Symmetric difference between s and s2 (unique elements from both s and s2 sets): ";  print(sym_diff, out);

	return 0;
}