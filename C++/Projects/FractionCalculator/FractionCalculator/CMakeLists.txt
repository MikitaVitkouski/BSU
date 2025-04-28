cmake_minimum_required(VERSION 3.10)

# Project name
project(FractionCalculator)

# Set the C++ standard
set(CMAKE_CXX_STANDARD 17)

# Add main application
add_executable(FractionCalculator main.cpp Fraction.cpp Fraction.h)
add_executable(FractionCalculatorTests FractionTest.cpp ../FractionCalculator/Fraction.cpp ../FractionCalculator/Fraction.h)

# Enable testing
enable_testing()

# Find GoogleTest package (if installed properly via package manager)
find_package(GTest REQUIRED)

# Create a separate executable for tests
add_executable(FractionTests FractionTest.cpp Fraction.cpp Fraction.h)

# Link GTest and pthread (Linux) or nothing extra on Windows
target_link_libraries(FractionTests GTest::gtest GTest::gtest_main)

# Add test
add_test(NAME FractionTest COMMAND FractionTests)