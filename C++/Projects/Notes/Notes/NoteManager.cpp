#include "NoteManager.h"

NoteManager::NoteManager(std::vector<Note> v) : notes(std::move(v)) { }

void NoteManager::addNote(const Note& note) {
	notes.emplace_back(std::move(note));
}

void NoteManager::removeNote(int index) {
	if (index >= 0 && index < notes.size()) {
		notes.erase(begin(notes) + index);
	}
	else {
		std::cerr << "Invalid index: " << index << "\n";
	}
}

std::vector<Note> NoteManager::getNotes() const {
	return notes;
}

int NoteManager::getSize() const {
	return notes.size();
}