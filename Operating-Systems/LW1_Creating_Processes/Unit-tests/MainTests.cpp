#define BOOST_TEST_MODULE MyTest
#include <boost/test/included/unit_test.hpp>

DWORD ExecuteProcess(const std::string& processName, const std::string& arguments, HANDLE& hProcess) {
    return 0;
}

BOOST_AUTO_TEST_CASE(test_execute_process) {
    HANDLE hProcess;
    DWORD result = ExecuteProcess("TestProcess", "arguments", hProcess);

    BOOST_CHECK_EQUAL(result, 0);
}