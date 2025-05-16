cmake_minimum_required(VERSION 3.16)
set(CMAKE_CXX_STANDARD 20)
set(CMAKE_CXX_STANDARD_REQUIRED ON)
project(ClockGUI LANGUAGES CXX)

find_package(Qt6 REQUIRED COMPONENTS Widgets)
qt_standard_project_setup()

add_subdirectory(../../Clock/ ${CMAKE_BINARY_DIR}/ClockBuild)

set(SOURCES
    main.cpp
    mainwindow.cpp
)

set(HEADERS
    mainwindow.h
)

set(UIS
    mainwindow.ui
)

qt_add_executable(ClockGUI
    ${SOURCES}
    ${HEADERS}
    ${UIS}
)

target_include_directories(ClockGUI
    PRIVATE
        ../../Clock
)

target_link_libraries(ClockGUI
    PRIVATE Qt6::Widgets ClockBackend
)

