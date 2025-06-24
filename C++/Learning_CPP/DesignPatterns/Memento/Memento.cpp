#include <iostream>
#include <string>
#include <stack>

// Memento
class Memento {
	std::string state;
public:
	Memento(const std::string& state) : state(state) { }
	std::string getState() const {
		return state;
	}
};

// Originator
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

// Caretaker
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
	TextEditor editor;
	History history;

	editor.type("Hello");
	history.backup(editor.save());

	editor.type(", world!");
	history.backup(editor.save());

	editor.showText(); //Hello, world!

	std::cout << "Undo...\n";
	editor.restore(history.undo()); //editor.text = "Hello" (removed ", world!")

	editor.showText();

	std::cout << "Undo once again...\n";
	editor.restore(history.undo()); //editor.text = "" (removed "Hello")

	editor.showText();

	return 0;
}
