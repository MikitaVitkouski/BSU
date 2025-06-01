#include "TaskManager.h"

TaskManager::TaskManager(std::vector<Task> v) : tasks(std::move(v)) { }

void TaskManager::addTask(const Task& task) {
	tasks.emplace_back(task);
}

void TaskManager::removeTask(int index) {
	tasks.erase(begin(tasks) + index);
}

void TaskManager::updateTask(int index, const Task& updatedTask) {
	if (index >= 0 && index < tasks.size()) {
		tasks[index] = updatedTask;
	}
}

const std::vector<Task>& TaskManager::getTasks() const {
	return tasks;
}

int TaskManager::getSize() const {
	return tasks.size();
}

void TaskManager::toggleTaskStatus(int index) {
	if (index >= 0 && index < tasks.size()) {
		tasks[index].toggleStatusSubtasks();
	}
}

bool TaskManager::isTaskCompleted(int index) const {
	if (index >= 0 && index < tasks.size()) {
		return tasks[index].isCompleted();
	}
	else {
		return false;
	}
}