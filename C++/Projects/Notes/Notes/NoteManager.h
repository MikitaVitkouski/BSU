#pragma once

#include <string>
#include <vector>
#include <algorithm>
#include <iostream>

class Note {
private:
	std::string note;
	std::string title;
public:
	Note(std::string text, std::string tit) : note(text), title(tit) {}
	~Note() = default;

	std::string getNote() const { return note; }
	std::string getTitle() const { return title; }
};

class NoteManager {
private:
	std::vector<Note> notes;
public:
	NoteManager() = default;
	NoteManager(std::vector<Note> v);
	~NoteManager() = default;
	void addNote(const Note& note);
	void removeNote(int index);
    void updateNote(int index, const Note& updatedNote);
	std::vector<Note> getNotes() const;
	int getSize() const;
};
