cmake_minimum_required(VERSION 3.16)
project(FractionCalculatorGUI LANGUAGES CXX)

find_package(Qt6 REQUIRED COMPONENTS Widgets)
qt_standard_project_setup()

add_subdirectory(../../FractionCalculator/ ${CMAKE_BINARY_DIR}/FractionCalculatorBuild)

set(SOURCES
    main.cpp
    mainwindow.cpp
    ExpressionParser.cpp
)

set(HEADERS
    mainwindow.h
    ExpressionParser.h
)

set(UIS
    mainwindow.ui
)

qt_add_executable(FractionCalculatorGUI
    ${SOURCES}
    ${HEADERS}
    ${UIS}
    ExpressionParser.h
    ExpressionParser.cpp
)

target_include_directories(FractionCalculatorGUI
    PRIVATE
        ../../FractionCalculator
)

target_link_libraries(FractionCalculatorGUI
    PRIVATE Qt6::Widgets FractionLib
)
