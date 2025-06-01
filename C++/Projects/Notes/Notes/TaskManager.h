#pragma once

#include <string>
#include <vector>
#include <algorithm>

class Task {
private:
	std::string title;
	std::string task;
	bool isCompleted;
public:
	Task(std::string tit, std::string tas, bool isDone) : title(tit), task(tas), isCompleted(isDone) { }
	~Task() = default;

	std::string getTitle() { return title; }
	std::string getTask() { return task; }
	bool getStatus() { return isCompleted; }
};