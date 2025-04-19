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

class SMSNoficationCenter : public NotificationCreator {
public:
	std::unique_ptr<Notification> createNotification() const override {
		return std::make_unique<EmailNotification>();
	}
};

int main() {


	return 0;
}