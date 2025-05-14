#include "Clock.h"
#include <chrono>
#include <iomanip>
#include <sstream>

Clock::Clock() {

}

std::string Clock::getTime() const {
	auto now = std::chrono::system_clock::now();
	std::time_t currentTime = std::chrono::system_clock::to_time_t(now);
	std::tm localTime = *std::localtime(&currentTime);

	std::ostringstream oss;
	oss << std::put_time(&localTime, "%H:%M:%S");
	return oss.str();
}