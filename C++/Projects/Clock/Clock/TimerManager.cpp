#include "TimerManager.h"

void TimerManager::start(std::chrono::milliseconds duration) {
	timer.duration = duration;
}

void TimerManager::pause() {
	timer.running = false;
}

void TimerManager::resume() {
	timer.running = true;
}

void TimerManager::reset() {
	timer.duration = 0;
	timer.running = false;
	timer.startTime = 0;
}

bool TimerManager::isFinished() const {
	return std::chrono::duration_cast<std::chrono::milliseconds>
		(std::chrono::steady_clock::now() - timer.startTime);
}