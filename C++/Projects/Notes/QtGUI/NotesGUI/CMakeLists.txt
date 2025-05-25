cmake_minimum_required(VERSION 3.16)
set(CMAKE_CXX_STANDARD 20)
set(CMAKE_CXX_STANDARD_REQUIRED ON)
project(NotesGUI LANGUAGES CXX)

find_package(Qt6 REQUIRED COMPONENTS Widgets)
qt_standard_project_setup()

add_subdirectory(../../Notes/ ${CMAKE_BINARY_DIR}/NotesBuild)
qt_add_resources(PROJECT_SOURCES resources.qrc)

set(SOURCES
    main.cpp
    mainwindow.cpp
    NoteItemWidget.cpp
)

set(HEADERS
    mainwindow.h
    NoteItemWidget.h
)

set(UIS
    mainwindow.ui
)

qt_add_executable(ClockGUI
    ${SOURCES}
    ${HEADERS}
    ${UIS}
    NoteItemWidget.h
    NoteItemWidget.cpp
)

target_include_directories(ClockGUI
    PRIVATE
        ../../Notes
)

target_link_libraries(ClockGUI
    PRIVATE Qt6::Widgets NotesBackend
)
