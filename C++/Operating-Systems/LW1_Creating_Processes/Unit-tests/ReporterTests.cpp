#include <boost/test/unit_test.hpp>
#include <iostream>
#include <fstream>
#include <sstream>
#include "employee.h"

void ReadEmployeeData(std::istream& stream, employee& emp, std::size_t size) {
    stream.read(reinterpret_cast<char*>(&emp), size);
}

BOOST_AUTO_TEST_SUITE(EmployeeTests)

BOOST_AUTO_TEST_CASE(ReadEmployeeDataTest) {
    const std::string tempFileName = "temp_employee_data.dat";
    std::ofstream tempFileStream(tempFileName, std::ios::out | std::ios::binary);

    employee emp;
    emp.num = 5;
    emp.name = "Mikita Vitkouski";
    emp.hours = 100;

    tempFileStream.write(reinterpret_cast<char*>(&emp), sizeof(employee));
    tempFileStream.close();

    std::ifstream tempFileInputStream(tempFileName, std::ios::in | std::ios::binary);

    ReadEmployeeData(tempFileInputStream, emp, sizeof(employee));

    BOOST_CHECK_EQUAL(emp.num, 5);
    BOOST_CHECK_EQUAL(emp.name, "Mikita Vitkouski");
    BOOST_CHECK_EQUAL(emp.hours, 100);

    tempFileInputStream.close();
    remove(tempFileName.c_str());
}

BOOST_AUTO_TEST_SUITE_END()