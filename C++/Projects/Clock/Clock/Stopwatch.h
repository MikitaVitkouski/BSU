#ifndef STOPWATCH_H
#define STOPWATCH_H

#include <chrono>
#include <vector>

class Stopwatch {
private:
	bool running = false;
	std::chrono::steady_clock::time_point startTime;
	std::chrono::milliseconds accumulatedTime{0};
	std::vector<std::chrono::milliseconds> laps;
public:
	void start();
	void pause();
	void reset();
	void lap();

	bool isRunning() const;
	std::chrono::milliseconds elapsed() const;
	const std::vector <std::chrono::milliseconds>& getLaps() const;

};

#endif