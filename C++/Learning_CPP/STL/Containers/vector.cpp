#include <iostream>
#include <vector>
#include <algorithm>
#include <numeric>
#include <ostream>
#include <fstream>

int main() {
	// initializing vector numbers from input.txt
	std::vector<int> numbers;

	std::ifstream in("input.txt");

	if (!in) {
		std::cerr << "Can't open input.txt\n";
		return 1;
	}

	int value;
	while (in >> value) {
		numbers.push_back(value);
	}
	in.close();

	std::cout << "Initial vector: ";
	for (const auto& num : numbers) {
		std::cout << num << " ";
	}
	std::cout << "\n\n";

	// sorting elements of the vector
	std::sort(numbers.begin(), numbers.end());
	std::cout << "After sorting: ";
	// printing contents of vector
	std::copy(numbers.begin(), numbers.end(), std::ostream_iterator<int>(std::cout, " "));
	std::cout << "\n\n";

	// searching for numbers = '8'
	auto it = std::find(numbers.begin(), numbers.end(), 8);
	if (it != numbers.end()) {
		std::cout << "Element 8 was found on the pos " << std::distance(numbers.begin(), it) << "\n";
	}
	else {
		std::cout << "Element 8 was not found\n";
	}

	std::cout << "\n";

	// erasing odd numbers
	numbers.erase(std::remove_if(numbers.begin(), numbers.end(), [](int i) {
		return i % 2 == 0; //
		}), numbers.end());

	std::cout << "After erasing odd numbers: ";
	for (auto it = numbers.begin(); it != numbers.end(); ++it) {
		std::cout << *it << " ";
	}
	std::cout << "\n\n";

	// adding new elements
	numbers.push_back(7);
	numbers.push_back(11);
	std::cout << "After adding new elements: ";
	for (const int& x : numbers) {
		std::cout << x << " ";
	}
	std::cout << "\n\n";

	// counting sum of all numbers in the vector
	int sum = std::accumulate(numbers.begin(), numbers.end(), 0);
	std::cout << "Sum of the elements: " << sum << "\n\n";

	// printing size and capacity of the vector on this stage
	std::cout << "Current size of vector: " << numbers.size() << "\n";
	std::cout << "Current capacity of vector: " << numbers.capacity() << "\n";

	numbers.reserve(20); // reserving space for 20 elements
	std::cout << "Capacity after reserve(20): " << numbers.capacity() << "\n";

	numbers.shrink_to_fit(); // making vector's size real
	std::cout << "Capacity after shrink_to_fit(): " << numbers.capacity() << "\n";

	numbers.emplace_back(13); // adding element without extra copying

	std::cout << "Accessing elements by index: ";
	for (size_t i = 0; i < numbers.size(); ++i) {
		std::cout << numbers[i] << " "; // we can access elements of std::vector by index
	}
	std::cout << "\n\n";

	numbers.insert(numbers.begin() + 1, 42); // inserting num 42 on the first place

	std::cout << "After numbers.insert(numbers.begin() + 1, 42): ";
	for (const auto& i : numbers) {
		std::cout << i << " ";
	}
	std::cout << "\n\n";

	if (!numbers.empty()) {
		numbers.erase(numbers.begin()); // erasing first element
	}

	std::ofstream out("output.txt");

	if (!out) {
		std::cerr << "Can't open output.txt\n";
		return 1;
	}

	out << "After numbers.erase(numbers.begin()): ";
	for (const auto& i : numbers) {
		out << i << " ";
	}
	out << "\n\n";

	numbers.clear();
	std::cout << "After numbers.clear(): size = " << numbers.size() << ", capacity = " << numbers.capacity() << "\n";

	return 0;
}