#include <iostream>
#include <memory>
#include <string>

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

class NotificationCreator {
public:
	virtual std::unique_ptr<Notification> createNotification() const = 0;

	void notify(const std::string& message) const {
		auto notification = createNotification();
		notification->send(message);
	}

	virtual ~NotificationCreator() = default;
};

class EmailNotificationCreator : public NotificationCreator {
public:
	std::unique_ptr<Notification> createNotification() const override {
		return std::make_unique<EmailNotification>();
	}
};

class SMSNotificationCreator : public NotificationCreator {
public:
	std::unique_ptr<Notification> createNotification() const override {
		return std::make_unique<EmailNotification>();
	}
};

int main() {
	std::string type;
	std::cout << "Enter notification type (email/sms): ";
	std::cin >> type;

	std::unique_ptr<NotificationCreator> creator;

	if (type == "email") {
		creator = std::make_unique<EmailNotificationCreator>();
	}
	else if (type == "sms") {
		creator = std::make_unique<SMSNotificationCreator>();
	}
	else {
		std::cerr << "Unsupported notification type.\n";
		return -1;
	}

	creator->notify("Hello from Fabric Method with Creator!");

	return 0;
}