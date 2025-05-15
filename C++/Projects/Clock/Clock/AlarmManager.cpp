#include "AlarmManager.h"

void AlarmManager::addAlarm(const Alarm& alarm) {
	alarms.emplace_back(alarm);
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