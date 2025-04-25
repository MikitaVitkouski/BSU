cmake_minimum_required(VERSION 3.12)

project(LW1_Creating_Processes)

set(SOURCES 
    Main.cpp
    Creator.cpp
    Reporter.cpp
)

add_executable(Solution ${SOURCES})