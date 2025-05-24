#include "pch.h"
#include "NoteManager.h"

TEST(NotesTest, addNote) {
	Note note("Breakfast", "Having breakfast from 11:00 AM to 11:15 AM");
	NoteManager manager;
	manager.addNote(note);

	EXPECT_EQ(1, manager.getSize());
}