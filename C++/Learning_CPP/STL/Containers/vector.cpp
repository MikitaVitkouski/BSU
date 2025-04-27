#include <iostream>
#include <vector>
#include <algorithm>
#include <numeric>
#include <ostream>

int main() {
	// initializing elements of vector numbers
	std::vector<int> numbers = { 5,1,8,3,9,2 };

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

	return 0;
}