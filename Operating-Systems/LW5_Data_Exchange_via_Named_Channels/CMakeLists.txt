cmake_minimum_required(VERSION 3.12)
project(NamedPipeCommunication)

set(CMAKE_CXX_STANDARD 14)

set(SOURCES
    Server.cpp
    Client.cpp
    employee.h
)

add_executable(NamedPipeCommunication ${SOURCES})

add_custom_command(TARGET NamedPipeCommunication POST_BUILD
    COMMAND ${CMAKE_COMMAND} -E copy
    ${CMAKE_SOURCE_DIR}/employee_data.bin
    $<TARGET_FILE_DIR:NamedPipeCommunication>
)