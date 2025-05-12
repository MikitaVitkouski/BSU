#include <iostream>
#include <queue>
#include <fstream>
#include <string>

void print_queue(std::queue<std::string> q, std::ofstream& out, const std::string& header) {
	out << header << "\n[front] ";
	while (!q.empty()) {
		out << q.front() << " ";
		q.pop();
	}
	out << "[back]\n\n";
}

int main() {
	std::queue<std::string> visitors{};
	std::ifstream in("input.txt");
	std::ofstream out("output.txt");

	if (!in.is_open()) {
		std::cerr << "Can not open input.txt file!";
		return 1;
	}

	std::string visitor;
	while (std::getline(in, visitor)) {
		visitors.push(visitor);
	}
	in.close();

	print_queue(visitors, out, "Queue before servicing:");

	// Simulating three backup actions (ctrl + z)
	for (int i = 0; i < 2 && !visitors.empty(); ++i) {
		out << "Serviced: " << visitors.front() << "\n";
		visitors.pop();
	}

	out << "\n";
	print_queue(visitors, out, "Queue after 2 people have been serviced: ");

	return 0;
}