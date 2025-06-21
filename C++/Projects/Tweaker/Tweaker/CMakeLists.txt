cmake_minimum_required(VERSION 3.16)
project(Tweaker LANGUAGES CXX)

set(CMAKE_CXX_STANDARD 20)
set(CMAKE_CXX_STANDARD_REQUIRED ON)

find_package(Qt6 REQUIRED COMPONENTS Widgets)
qt_standard_project_setup()

qt_add_resources(PROJECT_SOURCES resources.qrc)

set(SOURCES
    main.cpp
    mainwindow.cpp
    RamLabel.cpp
    ${RESOURCE_SOURCES}
)

set(HEADERS
    mainwindow.h
    RamLabel.h
)

set(UIS
    mainwindow.ui
)

if(WIN32)
    set(WINDOWS_MANIFEST resources.rc)
endif()

qt_add_executable(Tweaker
    ${SOURCES}
    ${HEADERS}
    ${UIS}
    ${WINDOWS_MANIFEST}
    RamLabel.cpp
    RamLabel.h
)

target_link_libraries(Tweaker PRIVATE Qt6::Widgets)
