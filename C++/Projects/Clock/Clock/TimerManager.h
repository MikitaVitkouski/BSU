#ifndef TIMERMANAGER_H
#define TIMERMANAGER_H

#include <iostream>
#include <chrono>

class Timer {
	std::chrono::milliseconds duration;
	std::chrono::steady_clock::time_point startTime;
	bool running;
};

class TimerManager {
private:
	Timer timer;
public:
	TimerManager() = default;

	void start(std::chrono::milliseconds duration);
	void pause();
	void resume();
	void reset();
	bool isFinished() const;
	std::chrono::milliseconds remaining() const;
};

#endif