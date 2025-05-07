cmake_minimum_required(VERSION 3.16)
project(FractionCalculator LANGUAGES CXX)

add_library(FractionLib STATIC
    Fraction.cpp
    Fraction.h
)