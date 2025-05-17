#include "Stopwatch.h"

// Is stopwatch running - yes or no
bool Stopwatch::isRunning() const{
	return running;
}

// total time elapsed, pauses count
std::chrono::milliseconds Stopwatch::elapsed() const {
    if (isRunning()) {
        return accumulatedTime + std::chrono::duration_cast<std::chrono::milliseconds>(
                   std::chrono::steady_clock::now() - startTime);
    }
    return accumulatedTime;
}

// start a stopwatch, fix a start time
void Stopwatch::start() {
	if (!isRunning()) {
		running = true;
		startTime = std::chrono::steady_clock::now();
	}
}

// pause a stopwatch, fix accumulated time
void Stopwatch::pause() {
	if (isRunning()) {
		accumulatedTime += std::chrono::duration_cast<std::chrono::milliseconds>(
			std::chrono::steady_clock::now() - startTime
		);
		running = false;
	}
}

// resume a stopwatch
void Stopwatch::resume() {
    if (!isRunning()) {
        startTime = std::chrono::steady_clock::now();
        running = true;
    }
}

// reset a stopwatch, clear laps, accumulated time becomes zero
void Stopwatch::reset() {
	running = false;
	accumulatedTime = std::chrono::milliseconds{ 0 };
	laps.clear();
}

// push_back lap's time to laps' vector
void Stopwatch::lap() {
    if (!isRunning()) return;

    auto now = elapsed();

    if (!laps.empty() && laps.back() == now)
        return;

    laps.push_back(now);
}

// get laps' vector
const std::vector<std::chrono::milliseconds>& Stopwatch::getLaps() const {
	return laps;
}
