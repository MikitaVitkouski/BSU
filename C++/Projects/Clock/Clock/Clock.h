#ifndef CLOCK_H
#define CLOCK_H

#include <string>
#include <chrono>
#include <string>
#include <format>

class Clock {
public:
	Clock() = default;

	std::string getTime() const;
};

#endif
