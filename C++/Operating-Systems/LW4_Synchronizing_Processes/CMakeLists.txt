cmake_minimum_required(VERSION 3.12)

project(LW4_Synchronizing_Processes)

set(SOURCES 
    Main.cpp
)

add_executable(Solution ${SOURCES})

add_custom_command(TARGET Solution POST_BUILD
    COMMAND ${CMAKE_COMMAND} -E copy
    ${CMAKE_SOURCE_DIR}/input.txt
    ${CMAKE_SOURCE_DIR}/shared_messages.bin
    $<TARGET_FILE_DIR:Solution>
)