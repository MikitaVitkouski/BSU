#include <iostream>
#include <string>
#include <stack>

class Memento {
	std::string state;
public:
	Memento(const std::string& state) : state(state) { }
	std::string getState() const {
		return state;
	}
};

class TextEditor {
	std::string text;
public:
	void type(const std::string& newText) {
		text += newText;
	}

	void showText() const {
		std::cout << "Current text: " << text << "\n";
	}

	Memento save() const {
		return Memento(text);
	}

	void restore(const Memento& memento) {
		text = memento.getState();
	}
};

class History {
	std::stack<Memento> mementos;
public:
	void backup(const Memento& memento) {
		mementos.push(memento);
	}

	Memento undo() {
		if (mementos.empty()) {
			std::cout << "Nothing to undo.\n";
			return Memento("");
		}
		Memento last = mementos.top();
		mementos.pop();
		return last;
	}
};

int main() {


	return 0;
}