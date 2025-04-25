#include <boost/test/unit_test.hpp>
#include <fstream>
#include <sstream>
#include <vector>
#include "employee.h"

void WriteEmployeeData(std::ostream& stream, const employee& emp, std::size_t size) {
    stream.write(reinterpret_cast<const char*>(&emp), size);
}

BOOST_AUTO_TEST_SUITE(CreatorTests)

BOOST_AUTO_TEST_CASE(WriteEmployeeDataTest) {
    const std::string tempFileName = "temp_employee_data.dat";
    std::ofstream tempFileStream(tempFileName, std::ios::out | std::ios::binary);

    employee emp;
    emp.num = 5;
    emp.name = "Mikita Vitkouski";
    emp.hours = 100;

    WriteEmployeeData(tempFileStream, emp, sizeof(employee));
    tempFileStream.close();

    std::ifstream tempFileInputStream(tempFileName, std::ios::in | std::ios::binary);

    employee readEmp;
    tempFileInputStream.read(reinterpret_cast<char*>(&readEmp), sizeof(employee));

    BOOST_CHECK_EQUAL(readEmp.num, 5);
    BOOST_CHECK_EQUAL(readEmp.name, "Mikita Vitkouski");
    BOOST_CHECK_EQUAL(readEmp.hours, 100);

    tempFileInputStream.close();
    remove(tempFileName.c_str());
}

BOOST_AUTO_TEST_SUITE_END()