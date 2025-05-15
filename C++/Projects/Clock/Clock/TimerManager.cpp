#include "TimerManager.h"

void TimerManager::start(std::chrono::milliseconds duration) {
	timer.duration = duration;
	timer.startTime = std::chrono::steady_clock::now();
	timer.running = true;
}

void TimerManager::pause() {
	timer.running = false;
}

void TimerManager::resume() {
	timer.startTime = std::chrono::steady_clock::now();
	timer.running = true;
}

void TimerManager::reset() {
	timer.duration = std::chrono::milliseconds{ 0 };
	timer.running = false;
	timer.startTime = std::chrono::steady_clock::time_point{};
}

bool TimerManager::isFinished() const {
	if (!timer.running) return false;

	auto elapsed = std::chrono::duration_cast<std::chrono::milliseconds>
		(std::chrono::steady_clock::now() - timer.startTime);
	
	return elapsed >= timer.duration;
}

std::chrono::milliseconds TimerManager::remaining() const {
	if (!timer.running) return timer.duration;

	auto elapsed = std::chrono::duration_cast<std::chrono::milliseconds>
		(std::chrono::steady_clock::now() - timer.startTime);

	return (elapsed >= timer.duration) ? std::chrono::milliseconds{0} : (timer.duration - elapsed);
}