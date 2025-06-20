#pragma once

#include <string>
#include <vector>
#include <algorithm>

class Task {
private:
	std::string title;
	std::vector<std::pair<std::string, bool>> subtasks;
public:
	Task(std::string tit, std::vector<std::pair<std::string,bool>> tas) : title(tit), subtasks(tas) { }
	~Task() = default;

	std::string getTitle() const { return title; }
    std::vector<std::pair<std::string, bool>>& getSubtasks() { return subtasks; }
    std::vector<std::pair<std::string, bool>> getSubtasks() const { return subtasks; }
	void toggleStatusSubtasks() { 
		for (auto& subtask : subtasks) {
			subtask.second = !subtask.second;
		}
	}
	bool isCompleted() const {
		return std::all_of(subtasks.begin(), subtasks.end(),
			[](const auto& sub) { return sub.second; });
	}
    void setSubtaskChecked(int index, bool checked) {
        if (index >= 0 && index < subtasks.size()) {
            subtasks[index].second = checked;
        }
    }
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
	void toggleTaskStatus(int index);
	const std::vector<Task>& getTasks() const;
	int getSize() const;
	bool isTaskCompleted(int index) const;
    void updateSubtask(int taskIndex, int subIndex, bool checked);
};
