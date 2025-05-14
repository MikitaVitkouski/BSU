#include "pch.h"
#include "AlarmManager.h"
#include "Clock.h"
#include "Stopwatch.h"
#include "TimerManager.h"
#include <regex>

//testing: getTime returns valid time format or not
TEST(ClockTest, ReturnsValidTimeFormat) {
	Clock clock;
	std::string timeStr = clock.getTime();

	// HH:MM:SS
	std::regex timeFormat(R"(^\d{1,2}:\d{2}:\d{2}(?:\.\d+)?$)");

	EXPECT_FALSE(timeStr.empty());

	EXPECT_TRUE(std::regex_match(timeStr, timeFormat)) << "Returned: " << timeStr;
}