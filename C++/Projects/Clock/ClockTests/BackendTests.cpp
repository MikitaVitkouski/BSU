#include "pch.h"
#include "AlarmManager.h"
#include "Clock.h"
#include "Stopwatch.h"
#include "TimerManager.h"
#include <regex>
#include <thread>

//testing: getTime returns valid time format or not
TEST(ClockTest, ReturnsValidTimeFormat) {
	Clock clock;
	std::string timeStr = clock.getTime();

	// HH:MM:SS
	std::regex timeFormat(R"(^\d{1,2}:\d{2}:\d{2}(?:\.\d+)?$)");

	EXPECT_FALSE(timeStr.empty());

	EXPECT_TRUE(std::regex_match(timeStr, timeFormat)) << "Returned: " << timeStr;
}

TEST(StopwatchTest, StartsAndPausesCorrectly) {
	Stopwatch sw;

	EXPECT_FALSE(sw.isRunning());

	sw.start();

	EXPECT_TRUE(sw.isRunning());

	std::this_thread::sleep_for(std::chrono::milliseconds(100));
	sw.pause();

	EXPECT_FALSE(sw.isRunning());

	auto elapsed = sw.elapsed().count();

	EXPECT_GE(elapsed, 90); // elapsed time >= 90?
	EXPECT_LE(elapsed, 200); // elapsed time <= 200?
}

TEST(StopwatchTest, ResetClearsTimeAndLaps) {
	Stopwatch sw;
	sw.start();

	std::this_thread::sleep_for(std::chrono::milliseconds(150));
	sw.lap();
	sw.pause();

	EXPECT_FALSE(sw.getLaps().empty());
	EXPECT_GT(sw.elapsed().count(), 0); // elapsed time > 0?

	sw.reset();

	EXPECT_EQ(sw.elapsed().count(), 0); // elapsed time = 0?
	EXPECT_TRUE(sw.getLaps().empty());
	EXPECT_FALSE(sw.isRunning());
}

TEST(StopwatchTest, LapsAreStoredCorrectly) {
	Stopwatch sw;
	sw.start();
	std::this_thread::sleep_for(std::chrono::milliseconds(75));
	sw.lap();
	std::this_thread::sleep_for(std::chrono::milliseconds(75));
	sw.lap();
	sw.pause();

	const auto& laps = sw.getLaps();
	EXPECT_EQ(laps.size(), 2);
	EXPECT_GE(laps[1], laps[0]); // second lap's time >= first lap's time
}

TEST(AlarmManagerTest, AddAlarmIncreasesCount) {
	AlarmManager manager;
	Alarm a1{ std::chrono::system_clock::now(), "Breakfast", true};
	manager.addAlarm(a1);

	EXPECT_EQ(manager.getActiveAlarms().size(), 1);
}

TEST(AlarmManagerTest, ToggleAlarmDisablesEnabledAlarm) {
	AlarmManager manager;
	Alarm a1{ std::chrono::system_clock::now(),"Dinner",true };
	manager.addAlarm(a1);

	manager.toggleAlarm(0);

	EXPECT_EQ(manager.getActiveAlarms().size(), 0);
}

TEST(AlarmManagerTest, ToggleAlarmEnablesDisabledAlarm) {
	AlarmManager manager;
	Alarm a1{ std::chrono::system_clock::now(),"Dinner",false };
	manager.addAlarm(a1);

	manager.toggleAlarm(0);

	EXPECT_EQ(manager.getActiveAlarms().size(), 1);
}

TEST(AlarmManagerTest, SetAlarmEnabledEnablesAlarm) {
	AlarmManager manager;
	Alarm a1{ std::chrono::system_clock::now(),"Dinner",false };
	Alarm a2{ std::chrono::system_clock::now(),"Breakfast",false };
	Alarm a3{ std::chrono::system_clock::now(),"Going for a walk",false };
	manager.addAlarm(a1);
	manager.addAlarm(a2);
	manager.addAlarm(a3);

	manager.setAlarmEnabled(0,true);
	manager.setAlarmEnabled(1,true);


	EXPECT_EQ(manager.getActiveAlarms().size(), 2);
}

TEST(AlarmManagerTest, RemoveAlarmRemovesCertainAlarmFromVectorAlarms) {
	AlarmManager manager;
	Alarm a1{ std::chrono::system_clock::now(),"Dinner",true };
	Alarm a2{ std::chrono::system_clock::now(),"Wake up",true };
	Alarm a3{ std::chrono::system_clock::now(),"Sleep",true };
	manager.addAlarm(a1);
	manager.addAlarm(a2);
	manager.addAlarm(a3);

	manager.removeAlarm(2);
	manager.removeAlarm(0);

	Alarm a4{ std::chrono::system_clock::now(), "University", true };
	manager.addAlarm(a4);

	EXPECT_EQ(manager.getActiveAlarms().size(), 2);
}