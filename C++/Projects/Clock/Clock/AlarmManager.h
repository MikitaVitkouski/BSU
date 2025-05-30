#ifndef ALARMMANAGER_H
#define ALARMMANAGER_H

#include <chrono>
#include <vector>
#include <string>

class Alarm {
public:
	std::chrono::system_clock::time_point time;
	std::string label; // "School", "Breakfast", "Meeting", etc.
	bool enabled;

    std::string getLabel() const {
        return label;
    }

    std::string getStatus() const {
        return enabled ? "enabled" : "disabled";
    }

    std::string getTime() const {
        std::time_t tt = std::chrono::system_clock::to_time_t(time);
        std::tm tm = *std::localtime(&tt);

        std::ostringstream oss;
        oss << std::put_time(&tm, "%Y-%m-%dT%H:%M:%S");
        return oss.str();
    }
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
    const std::vector<Alarm>& getAllAlarms() const;
	void sortAlarmsByTime();

	void checkAndTriggerAlarms(); // periodically call to run alarms at the set time
};

#endif
