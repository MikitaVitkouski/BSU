#ifndef CLOCK_H
#define CLOCK_H

#include <string>
#include <chrono>

class Clock {
public:
    Clock() : timezone_(std::chrono::current_zone()) {}

    void setTimezone(const std::string& tzName);

    std::string getTime() const;

private:
    const std::chrono::time_zone* timezone_;
};

#endif // CLOCK_H
