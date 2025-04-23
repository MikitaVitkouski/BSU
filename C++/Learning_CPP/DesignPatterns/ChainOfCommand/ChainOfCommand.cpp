#include <iostream>
#include <memory>
#include <string>

class Handler {
public:
	virtual Handler* setNext(Handler* nextHandler) = 0;
	virtual void handleRequest(const std::string& issue) = 0;
	virtual ~Handler() = default;
};

class BaseHandler : public Handler {
protected:
	Handler* next = nullptr;
public:
	Handler* setNext(Handler* nextHandler) override {
		next = nextHandler;
		return nextHandler;
	}

	void handleRequest(const std::string& issue) override {
		if (next) {
			next->handleRequest(issue);
		}
		else {
			std::cout << "No one can handle this issue: " << issue << "\n";
		}
	}
};

int main() {


	return 0;
}