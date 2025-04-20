#include <iostream>
#include <string>
#include <mutex>

class Logger {
private:
	static std::unique_ptr<Logger> instance;
	static std::mutex mutex;

	Logger() = default;
public:
	Logger(const Logger&) = delete;
	Logger& operator=(const Logger&) = delete;

	static Logger& getInstance() {
		std::lock_guard<std::mutex> lock(mutex);
		if (!instance) {
			instance = std::unique_ptr<Logger>(new Logger());
		}

		return *instance;
	}

	void log(const std::string& message) {
		std::cout << "[LOG]: " << message << "\n";
	}

};

std::unique_ptr<Logger> Logger::instance = nullptr;
std::mutex Logger::mutex;

int main() {
	Logger::getInstance().log("Starting app...");
	Logger::getInstance().log("Closing app...");

	/* Output:
	[LOG]: Starting app...
	[LOG]: Closing app...
	*/

	return 0;
}