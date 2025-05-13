cmake_minimum_required(VERSION 3.16)
project(Clock LANGUAGES CXX)

add_library(ClockBackend STATIC
    TimerManager.cpp
    TimerManager.h
    Stopwatch.cpp
    Stopwatch.h
    Clock.cpp
    Clock.h
    AlarmManager.cpp
    AlarmManager.h
)