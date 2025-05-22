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
	std::regex pattern(R"(([A-Z][a-z]+)\s+([A-Z][a-z]+)\s+((0[1-9]|[12][0-9]|3[01])-(0[1-9]|1[0-2])-(1[0-9]{3}|20[0-9]{2}|2100)))");
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

	std::ofstream winter("winter.txt");
	std::ofstream spring("spring.txt");
	std::ofstream summer("summer.txt");
	std::ofstream autumn("autumn.txt");

	for (const auto& pair : database) {
		std::string name = pair.first;
		std::string date = pair.second;

		int month = std::stoi(date.substr(3, 2));

		if (month == 12 || month == 1 || month == 2) {
			winter << name << " " << date << std::endl;
		}
		else if (month >= 3 && month <= 5) {
			spring << name << " " << date << std::endl;
		}
		else if (month >= 6 && month <= 8) {
			summer << name << " " << date << std::endl;
		}
		else if (month >= 9 && month <= 11) {
			autumn << name << " " << date << std::endl;
		}
	}

	winter.close(); spring.close(); summer.close(); autumn.close();

	return 0;
}