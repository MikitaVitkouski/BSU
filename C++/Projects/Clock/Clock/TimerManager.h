#ifndef TIMERMANAGER_H
#define TIMERMANAGER_H

#include <iostream>
#include <chrono>

class Timer {
public:
	std::chrono::milliseconds duration;
	std::chrono::steady_clock::time_point startTime;
    std::chrono::milliseconds elapsedBeforePause{0};
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
