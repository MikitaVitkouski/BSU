#pragma once

#include <string>
#include <vector>

class Note {
private:
	std::string note;
public:
	Note(std::string text) : note(text) {}
	~Note() = default;
};

class NoteManager {
private:
	std::vector<std::string> notes;
public:
	NoteManager(std::vector<std::string> v);
	~NoteManager() = default;
	void addNote(std::string note);
	void removeNote(std::string note);
	std::vector<std::string> getNotes();
};