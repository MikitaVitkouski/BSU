#ifndef ALARMMANAGER_H
#define ALARMMANAGER_H

#include <iostream>
#include <chrono>

class Alarm {
public:
	std::chrono::system_clock::time_point time;
	std::string label; // "School", "Breakfast", "Meeting", etc.
	bool enabled;
};

class AlarmManager {
private:
	std::vector<Alarm> alarms;
public:
	AlarmManager() = default;

	void addAlarm(const Alarm& alarm);
	void removeAlarm(int index);
	void toggleAlarm(int index);
	void setAlarmEnabled(int index, bool enable);
	std::vector<Alarm> getActiveAlarms() const;
	void sortAlarmsByTime();

	void checkAndTriggerAlarms(); // periodically call to run alarms at the set time
};

#endif