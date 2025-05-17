#ifndef CLOCK_H
#define CLOCK_H

#include <string>
#include <chrono>
#include <string>
#include <format>

class Clock {
private:
    std::string timezone = "UTC";
public:
	Clock() = default;

    void setTimezone(const std::string& tz);
	std::string getTime() const;
};

#endif
