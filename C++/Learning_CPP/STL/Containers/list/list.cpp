#include <iostream>
#include <fstream>
#include <list>
#include <algorithm>
#include <numeric>

int main() {
	std::ifstream in("input.txt");
	std::ofstream out("output.txt");

	if (!in.is_open()) {
		std::cerr << "Can't open file input.txt.\n";
		return 1;
	}

	std::list<int> myList;
	int num;
	while (in >> num) {
		myList.push_back(num);
	}

	std::cout << "myList: ";
	out << "myList: ";
	for (auto val : myList) {
		std::cout << val << " ";
		out << val << " ";
	}
	std::cout << "\n\n";
	out << "\n\n";

	if (!myList.empty()) {
		myList.pop_front();
	}

	std::cout << "After pop_front(): ";
	for (auto val : myList) {
		std::cout << val << " ";
	}
	std::cout << "\n\n";

	myList.push_front(228);

	std::cout << "After push_front(228): ";
	for (auto val : myList) {
		std::cout << val << " ";
	}
	std::cout << "\n\n";

	if (!myList.empty()) {
		myList.pop_back();
	}

	std::cout << "After pop_back(): ";
	for (auto val : myList) {
		std::cout << val << " ";
	}
	std::cout << "\n\n";

	auto it = myList.begin();
	std::advance(it, myList.size() / 2); // forwarding it from myList.begin() to the middle
	myList.insert(it, 50);

	std::cout << "After inserting 50 to the middle of myList: ";
	for (auto val : myList) {
		std::cout << val << " ";
	}
	std::cout << "\n\n";

	myList.clear();

	out << "myList after clear(): ";
	for (auto val : myList) {
		out << val << " ";
	}
	out << "\n\n";

	myList.push_back(11);
	myList.push_back(15);
	myList.push_back(18);
	myList.push_back(9);
	myList.push_back(5);

	myList.sort();
	std::cout << "myList after sort(): ";
	for (auto val : myList) {
		std::cout << val << " ";
	}
	std::cout << "\n\n";

	myList.remove(3); //removing all number threes from myList
	std::cout << "myList after remove(3): ";
	for (auto val : myList) {
		std::cout << val << " ";
	}
	std::cout << "\n\n";

	std::for_each(myList.begin(), myList.end(), [](int &val) { val *= 2; }); //from the begin() till the end() multiply all the values by 2
	std::cout << "myList after making elements x2: ";
	for (auto val : myList) {
		std::cout << val << " ";
	}
	std::cout << "\n\n";

	auto sum = std::accumulate(myList.begin(), myList.end(), 0); // calculating sum of the all elements of myList
	out << "Sum of the elements of myList is " << sum << "\n\n";
	std::cout << "Sum of the elements of myList is " << sum << "\n\n";

	in.close();
	out.close();

	return 0;
}