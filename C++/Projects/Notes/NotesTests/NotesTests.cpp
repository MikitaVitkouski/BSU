#include "pch.h"
#include "NoteManager.h"

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

}

TEST(TaskTest, removeTask) {

}

TEST(TaskTest, updateTask) {

}

TEST(TaskTest, toggleTaskStatus) {

}