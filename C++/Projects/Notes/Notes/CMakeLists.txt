cmake_minimum_required(VERSION 3.16)
project(Notes LANGUAGES CXX)

add_library(NotesBackend STATIC
    NoteManager.h
    NoteManager.cpp
    TaskManager.h
    TaskManager.cpp
)