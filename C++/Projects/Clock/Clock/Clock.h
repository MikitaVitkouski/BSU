#ifndef CLOCK_H
#define CLOCK_H

#include <iostream>
#include <string>

class Clock {
public:
	Clock() = default;

	std::string getTime() const;
};

#endif