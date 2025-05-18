#include "AlarmManager.h"

void AlarmManager::addAlarm(const Alarm& alarm) {
	alarms.emplace_back(alarm);
    sortAlarmsByTime();
}

void AlarmManager::removeAlarm(int index) {
	if (index >= 0 && index < alarms.size()) {
		alarms.erase(alarms.begin() + index);
	}
}

void AlarmManager::toggleAlarm(int index) {
	if (index >= 0 && index < alarms.size()) {
		alarms[index].enabled = !alarms[index].enabled;
	}
}

void AlarmManager::setAlarmEnabled(int index, bool enable) {
	if (index >= 0 && index < alarms.size()) {
		alarms[index].enabled = enable;
	}
}

std::vector<Alarm> AlarmManager::getActiveAlarms() const {
	std::vector<Alarm> result{};
	result.reserve(alarms.size());
	for (const auto& i : alarms) {
		if (i.enabled) {
			result.emplace_back(i);
		}
	}
	
	return result;
}

const std::vector<Alarm>& AlarmManager::getAllAlarms() const {
    return alarms;
}

void AlarmManager::sortAlarmsByTime() {
	std::sort(alarms.begin(), alarms.end(), [](const Alarm& a, const Alarm& b) {
		return a.time < b.time;
		});
}

void AlarmManager::checkAndTriggerAlarms() {
    auto now = std::chrono::system_clock::now();
    for (auto& alarm : alarms) {
        if (alarm.enabled && alarm.time <= now) {
            alarm.enabled = false;
        }
    }
}
