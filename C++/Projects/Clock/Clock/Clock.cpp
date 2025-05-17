#include "Clock.h"

std::string Clock::getTime() const {
	auto now = std::chrono::zoned_time{ std::chrono::current_zone(), std::chrono::system_clock::now() };

	return std::format("{:%H:%M:%S}", now);
}

void Clock::setTimezone(const std::string& tz) {
    timezone = tz;
}
