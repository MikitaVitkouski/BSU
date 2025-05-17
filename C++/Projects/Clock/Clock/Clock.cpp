#include "Clock.h"

std::string Clock::getTime() const {
    using namespace std::chrono;
    auto now = zoned_time{ timezone_, floor<seconds>(system_clock::now()) }; // <-- округляем до секунд
    return std::format("{:%H:%M:%S}", now);
}

void Clock::setTimezone(const std::string& tzName) {
    timezone_ = std::chrono::locate_zone(tzName);
}
