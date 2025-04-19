#include <iostream>

class Notification {
public:
	virtual void send(const std::string& message) = 0;
	virtual ~Notification() = default;
};

class EmailNotification : public Notification {
public:
	void send(const std::string& message) {
		std::cout << "Sending EMAIL: " << message << std::endl;
	}
};

class SMSNotification : public Notification {
public:
	void send(const std::string& message) {
		std::cout << "Sending SMS: " << message << std::endl;
	}
};

int main() {


	return 0;
}