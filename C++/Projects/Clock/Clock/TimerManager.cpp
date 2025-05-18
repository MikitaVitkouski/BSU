#include "TimerManager.h"

void TimerManager::start(std::chrono::milliseconds duration) {
    timer.duration = duration;
    timer.elapsedBeforePause = std::chrono::milliseconds{0};
    timer.startTime = std::chrono::steady_clock::now();
    timer.running = true;
}

void TimerManager::pause() {
    if (!timer.running) return;
    auto now = std::chrono::steady_clock::now();
    timer.elapsedBeforePause += std::chrono::duration_cast<std::chrono::milliseconds>(now - timer.startTime);
    timer.running = false;
}

void TimerManager::resume() {
    if (timer.running) return;
    timer.startTime = std::chrono::steady_clock::now();
    timer.running = true;
}

void TimerManager::reset() {
    timer.duration = std::chrono::milliseconds{0};
    timer.elapsedBeforePause = std::chrono::milliseconds{0};
    timer.running = false;
    timer.startTime = std::chrono::steady_clock::time_point{};
}

bool TimerManager::isFinished() const {
    return remaining().count() == 0 && timer.running;
}

std::chrono::milliseconds TimerManager::remaining() const {
    auto elapsed = timer.elapsedBeforePause;

    if (timer.running) {
        elapsed += std::chrono::duration_cast<std::chrono::milliseconds>(
            std::chrono::steady_clock::now() - timer.startTime);
    }

    return (elapsed >= timer.duration) ? std::chrono::milliseconds{0} : (timer.duration - elapsed);
}
