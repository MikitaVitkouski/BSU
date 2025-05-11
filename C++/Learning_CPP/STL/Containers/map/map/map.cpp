#include <iostream>
#include <map>
#include <fstream>
#include <algorithm>
#include <iostream>
#include <iomanip>

void print(const std::map<std::string, int>& m, std::ofstream& output) {
	output << std::left << std::setw(20) << "----CPU----" << std::right << std::setw(10) << "----$----" << "\n";
	for (const auto& elem : m) {
		output << std::left << std::setw(20) << elem.first << std::right << std::setw(10) << elem.second << "\n";
	}
	output << "\n";
}

int main() {
	std::ifstream in("input.txt");
	std::ofstream out("output.txt");

	if (!in.is_open()) {
		std::cerr << "Can not open file input.txt!";
		return 1;
	}

	std::map<std::string, int> CPUs;

	std::string good{""}; int price{};

	while (in >> good >> price) {
		CPUs[good] = price;
	}
	in.close();

	print(CPUs, out);

	auto total{ 0 };
	for (const auto& elem : CPUs) {
		total += elem.second;
	}
	double average_price = (CPUs.empty()) ? 0.0 : static_cast<double>(total) / CPUs.size();
	out << "Average price of CPUs is " << average_price << "$.";

	auto min_it = CPUs.begin();
	auto max_it = CPUs.begin();

	for (auto it = CPUs.begin(); it != CPUs.end(); ++it) {
		if (it->second < min_it->second) min_it = it;
		if (it->second > max_it->second) max_it = it;
	}

	out << "Cheapest CPU: " << min_it->first << " - $" << min_it->second << "\n";
	out << "Most expensive CPU: " << max_it->first << " - $" << max_it->second << "\n";

	out << "\nCPUs cheaper than $150:\n";
	out << std::left << std::setw(20) << "CPU" << std::right << std::setw(10) << "Price" << "\n";
	for (const auto& elem : CPUs) {
		if (elem.second < 150) {
			out << std::left << std::setw(20) << elem.first << std::right << std::setw(10) << elem.second << "\n";
		}
	}

	std::cout << "\nEnter CPU's name (or 'exit' for exit):\n";
	while (true) {
		std::cout << "> ";
		std::cin >> good;

		if (good == "exit") break;

		auto it = CPUs.find(good);
		if (it != CPUs.end()) {
			std::cout << "Price " << it->first << ": $" << it->second << "\n";
		}
		else {
			std::cout << "CPU was not found.\n";
		}
	}

	return 0;
}