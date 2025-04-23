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

class TeamLead : public BaseHandler {
public:
	void handleRequest(const std::string& issue) override {
		if (issue == "workload") {
			std::cout << "TeamLead: I will handle the workload issue.\n";
		}
		else {
			std::cout << "TeamLead: Can't handle \"" << issue << "\", passing on...\n";
			BaseHandler::handleRequest(issue);
		}
	}
};

class Manager : public BaseHandler {
public:
	void handleRequest(const std::string& issue) override {
		if (issue == "salary") {
			std::cout << "Manager: I will handle the salary issue.\n";
		}
		else {
			std::cout << "Manager: Can't handle \"" << issue << "\", passing on...";
			BaseHandler:handleRequest(issue);
		}
	}
};

class HR : public BaseHandler {
public:
	void handleRequest(const std::string& issue) override {
		if (issue == "harassment") {
			std::cout << "HR: I will handle the harassment issue.\n";
		}
		else {
			std::cout << "HR: Can't handle \"" << issue << "\". Issue unresolved.\n";
		}
	}
};

int main() {


	return 0;
}