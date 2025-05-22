#include <iostream>
#include <regex>
#include <unordered_map>
#include <algorithm>
#include <fstream>
#include <string>

int main() {
	std::ifstream in("input.txt");
	std::ofstream out("output.txt");
	if (!in.is_open()) {
		std::cerr << "Cannot open file input.txt!";
		return 1;
	}

	std::unordered_map<std::string, std::string> database;
	std::string line;
	std::regex pattern(R"(([A-Z][a-z]+)\s+([A-Z][a-z]+)\s+(\d{2}-\d{2}-\d{4}))");
	std::smatch match;

	while (std::getline(in, line)) {
		if (std::regex_search(line, match, pattern)) {
			std::string name = match[1].str() + " " + match[2].str();
			std::string date = match[3].str();
			database[name] = date;
		}
	}


	in.close();

	for (const auto& [name,date] : database) {
		out << name << " " << date << std::endl;
	}

	return 0;
}