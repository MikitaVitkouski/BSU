#include <iostream>
#include <stack>
#include <fstream>
#include <string>

void print_stack(std::stack<std::string> st, std::ofstream& out, const std::string& header) {
	out << header << "\n[top] ";
	while (!st.empty()) {
		out << st.top() << " ";
		st.pop();
	}
	out << "[bottom]\n\n";
}

int main() {
	std::stack<std::string> actions{};
	std::ifstream in("input.txt");
	std::ofstream out("output.txt");

	if (!in.is_open()) {
		std::cerr << "Can not open input.txt file!";
		return 1;
	}

	std::string action;
	while (std::getline(in,action)) {
		actions.push(action);
	}
	in.close();

	print_stack(actions, out, "Before ctrl+z:");

	// Simulating three backup actions (ctrl + z)
	for (int i = 0; i < 3 && !actions.empty(); ++i) {
		out << "Undo: " << actions.top() << "\n";
		actions.pop();
	}

	out << "\n";
	print_stack(actions,out,"After 3 backup actions: ");

	return 0;
}