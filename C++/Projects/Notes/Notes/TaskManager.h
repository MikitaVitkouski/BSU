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

	std::string getTitle() const { return title; }
	std::string getTask() const { return task; }
	bool getStatus() const { return isCompleted; }
};

class TaskManager {
private:
	std::vector<Task> tasks;
public:
	TaskManager() = default;
	TaskManager(std::vector<Task> v);
	~TaskManager() = default;
	void addTask(const Task& task);
	void removeTask(int index);
	void updateTask(int index, const Task& updatedTask);
	std::vector<Task> getTasks() const;
	int getSize() const;
};