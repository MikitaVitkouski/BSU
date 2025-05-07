cmake_minimum_required(VERSION 3.16)
project(FractionCalculatorGUI LANGUAGES CXX)

# Найти Qt
find_package(Qt6 REQUIRED COMPONENTS Widgets)
qt_standard_project_setup()

# Добавляем бэкенд как подпроект
add_subdirectory(../../FractionCalculator/ ${CMAKE_BINARY_DIR}/FractionCalculatorBuild)

# Источники для GUI
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

qt_add_executable(FractionCalculatorGUI
    ${SOURCES}
    ${HEADERS}
    ${UIS}
)

target_include_directories(FractionCalculatorGUI
    PRIVATE
        ../../FractionCalculator
)

target_link_libraries(FractionCalculatorGUI
    PRIVATE Qt6::Widgets FractionLib
)