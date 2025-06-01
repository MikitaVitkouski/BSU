#include "pch.h"
#include "NoteManager.h"
#include "TaskManager.h"

TEST(NotesTest, addNoteAndgetSize) {
	Note note1("Having breakfast from 11:00 AM to 11:15 AM", "Breakfast");
	NoteManager manager;
	manager.addNote(note1);

	EXPECT_EQ(1, manager.getSize());

	Note note2("Having dinner from 1:00 PM to 1:30 PM", "Lunch");
	manager.addNote(note2);

	EXPECT_EQ(2, manager.getSize());
}

TEST(NotesTest, removeNoteAndgetSize) {
	Note note1("Having breakfast from 11:00 AM to 11:15 AM", "Breakfast");
	NoteManager manager;
	manager.addNote(note1);

	EXPECT_EQ(1, manager.getSize());

	Note note2("Having dinner from 1:00 PM to 1:30 PM", "Lunch");
	manager.addNote(note2);

	EXPECT_EQ(2, manager.getSize());

	manager.removeNote(0);

	EXPECT_EQ(1, manager.getSize());

	manager.removeNote(0);

	EXPECT_EQ(0, manager.getSize());
}

TEST(NotesTest, getNotes) {
	NoteManager manager;
	Note note1("Having breakfast from 11:00 AM to 11:15 AM", "Breakfast");
	Note note2("Having dinner from 1:00 PM to 1:30 PM", "Lunch");

	manager.addNote(note1);
	manager.addNote(note2);

	std::vector<Note> expected{note1, note2};
	std::vector<Note> actual = manager.getNotes();

	ASSERT_EQ(expected.size(), actual.size());

	for (size_t i = 0; i < expected.size(); ++i) {
		EXPECT_EQ(expected[i].getTitle(), actual[i].getTitle());
		EXPECT_EQ(expected[i].getNote(), actual[i].getNote());
	}
}

TEST(TaskTest, addTask) {
	Task t1("Cake", { {"Milk", false}, {"Eggs",false} });
	Task t2("Gym", { {"Push-ups", false}, {"3 km", false} });

	TaskManager manager;
	manager.addTask(t1); manager.addTask(t2);

	EXPECT_EQ(2, manager.getSize());
}

TEST(TaskTest, removeTask) {
	Task t1("Cake", { {"Milk", false}, {"Eggs",false} });
	Task t2("Gym", { {"Push-ups", false}, {"3 km", false} });

	TaskManager manager;
	manager.addTask(t1); manager.addTask(t2);

	EXPECT_EQ(2, manager.getSize());

	manager.removeTask(0);

	EXPECT_EQ(1, manager.getSize());
}

TEST(TaskTest, updateTask) {
	Task t1("Cake", { {"Milk", false}, {"Eggs",false} });

	TaskManager manager;
	manager.addTask(t1);

	Task t2("Cake", { {"Eggs", false}, {"Milk", false} });
	manager.updateTask(0, t2);

	std::vector<Task> expected{t2};
	std::vector<Task> actual = manager.getTasks();

	ASSERT_EQ(expected.size(), actual.size());

	for (size_t i = 0; i < expected.size(); ++i) {
		EXPECT_EQ(expected[i].getTitle(), actual[i].getTitle());
		EXPECT_EQ(expected[i].getSubtasks(), actual[i].getSubtasks());
	}
}

TEST(TaskTest, toggleTaskStatus) {
	Task t1("Cake", { {"Milk", false}, {"Eggs",false} });
	Task t2("Gym", { {"Push-ups", false}, {"3 km", false} });

	TaskManager manager;
	manager.addTask(t1); manager.addTask(t2);
	manager.toggleTaskStatus(0);
	manager.toggleTaskStatus(1);

	std::vector<Task> tasks = manager.getTasks();

	EXPECT_EQ(1, tasks[0].isCompleted());
	EXPECT_EQ(1, tasks[1].isCompleted());
}

TEST(TaskTest, getTasks) {
	Task t1("Cake", { {"Milk", false}, {"Eggs",false} });
	Task t2("Gym", { {"Push-ups", false}, {"3 km", false} });

	TaskManager manager;
	manager.addTask(t1); manager.addTask(t2);

	std::vector<Task> expected = { t1,t2 };
	std::vector<Task> actual = manager.getTasks();

	for (size_t i = 0; i < expected.size(); ++i) {
		EXPECT_EQ(expected[i].getTitle(), actual[i].getTitle());
		EXPECT_EQ(expected[i].getSubtasks(), actual[i].getSubtasks());
	}
}