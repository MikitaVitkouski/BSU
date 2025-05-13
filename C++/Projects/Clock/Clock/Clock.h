#ifndef CLOCK_H
#define CLOCK_H

#include <iostream>
#include <string>

class Clock {
public:
	Clock();

	std::string getTime() const;
};

#endif