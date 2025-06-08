cmake_minimum_required(VERSION 3.16)
project(FractionCalculatorGUI LANGUAGES CXX)

find_package(Qt6 REQUIRED COMPONENTS Widgets)
qt_standard_project_setup()

add_subdirectory(../../FractionCalculator/ ${CMAKE_BINARY_DIR}/FractionCalculatorBuild)

qt_add_resources(PROJECT_SOURCES resources.qrc)

set(SOURCES
    main.cpp
    mainwindow.cpp
    ExpressionParser.cpp
    ExpressionLineEdit.cpp
)

set(HEADERS
    mainwindow.h
    ExpressionParser.h
    ExpressionLineEdit.h
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
    ExpressionLineEdit.h
    ExpressionLineEdit.cpp
)

target_include_directories(FractionCalculatorGUI
    PRIVATE
        ${CMAKE_CURRENT_SOURCE_DIR}
        ${CMAKE_CURRENT_BINARY_DIR}
        ../../FractionCalculator
)

target_link_libraries(FractionCalculatorGUI
    PRIVATE Qt6::Widgets FractionLib
)
