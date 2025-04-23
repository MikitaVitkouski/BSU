#include <iostream>
#include <memory>
#include <string>

class Handler {
public:
	virtual Handler* setNext(Handler* nextHandler) = 0;
	virtual void handleRequest(const std::string& issue) = 0;
	virtual ~Handler() = default;
};

int main() {


	return 0;
}