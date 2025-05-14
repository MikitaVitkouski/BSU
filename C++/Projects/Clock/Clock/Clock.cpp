#include "Clock.h"
#include <chrono>
#include <format>

std::string Clock::getTime() const {
	auto now = std::chrono::zoned_time{ std::chrono::current_zone(), std::chrono::system_clock::now() };

	return std::format("{:%H:%M:%S}", now);
}